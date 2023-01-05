using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RIVarX;
using System.Reactive.Linq;
using DrugAdministration;

namespace DrugAdministrationUI
{
    public partial class UserControl_Bag : UserControl
    {
        public event EventHandler<double> ControlValueChanged;
        NumericUpDown _lastValueChangedControl;
        string _id = Guid.NewGuid().ToString();

        public UserControl_Bag(Bag bag)
        {
            InitializeComponent();

            this.Controls.OfType<NumericUpDown>().ToList().ForEach(ProduceChangeEvents);

            Connect(numericUpDownMedication, bag.Amount);
            Connect(numericUpDownvolume, bag.Volume);
            Connect(numericUpDownconc, bag.Concentration);
        }

        private void ProduceChangeEvents(NumericUpDown control)
        {
            control.LostFocus += (sender, e) => _lastValueChangedControl = (sender as NumericUpDown);
            control.ValueChanged += (sender, e) =>
            {
                if (sender == _lastValueChangedControl)
                {
                    lock (this)
                    {
                        var value = (sender as NumericUpDown).Value;
                        ControlValueChanged?.Invoke(sender, Convert.ToDouble(value));
                        (sender as NumericUpDown).BackColor = Color.White;

                        System.IO.File.AppendAllText($"log{_id}.txt", $"\r\n{_lastValueChangedControl.Name}:{value}");
                        System.IO.File.AppendAllText($"sets.txt", $"\r\n{_lastValueChangedControl.Name}:{value}");
                    }
                }
            };
        }

        private void Connect(NumericUpDown numericUpDown, RIVar<decimal> rIVar)
        {
            GetObservable(numericUpDown).Subscribe(x => rIVar.OnNext(x));
            rIVar.Subscribe(x => SetValue(numericUpDown, x));
        }
        private void SetValue(NumericUpDown control, Signal<decimal> signal)
        {
            lock (this)
            {
                if (signal?.Value == null)
                {
                    if (control.Value != 0)
                    {
                        control.Value = 0;
                    }
                }
                else
                {
                    var dec = Math.Round(Convert.ToDecimal(signal.Value), 2);
                    System.IO.File.AppendAllText($"sets.txt", $"\r\n{control.Name}: {dec} <{string.Join(",", signal.PrioritySet)}>");
                    if (control.Value != dec)
                    {
                        control.Value = dec;
                        control.BackColor = Color.Yellow;
                    }
                }
            }
        }
        IObservable<Signal<decimal>> GetObservable(NumericUpDown control)
        {
            return Observable.FromEventPattern<double>(this, "ControlValueChanged").Where(o => o.Sender == control).Select(o => (o.Sender as NumericUpDown).Value.ToString())//.Scan((x,y)=>y)//.Select(o=> Convert.ToDouble(o))
                .Select(o => Convert.ToDecimal(o)).Select(o => new Signal<decimal>(o)).DistinctUntilChanged()
                .Select(o => o).Publish().RefCount().Select(o => o);
        }
    }
}
