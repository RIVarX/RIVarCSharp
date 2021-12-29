using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RIvarX;
using System.Reactive.Linq;
using SignalExample_InfusionTherapy;

namespace WindowsFormsApp1
{
    public partial class UserControl_Bag : UserControl, IBag
    {
        public event EventHandler<double> ControlValueChanged;
        NumericUpDown _lastValueChangedControl;
        string _id = Guid.NewGuid().ToString();
        Bag _bag;
        public RIvar<IOperand> Amount => _bag.Amount;

        public RIvar<IOperand> Volume => _bag.Volume;

        public UserControl_Bag()
        {
            var bag = _bag = new Bag();

         


            InitializeComponent();

            var a = this.Controls.OfType<NumericUpDown>().Union(Controls.OfType<NumericUpDown>()).ToList();
            a.ForEach(o =>
            {
                o.ValueChanged += O_ValueChanged1;
                o.LostFocus += O_LostFocus;

            });

            var medicationInputs = GetObservable(numericUpDownMedication);
            var volumeInputs = GetObservable(numericUpDownvolume);
            var concentratioInputs = GetObservable(numericUpDownconc);


            medicationInputs.Subscribe(x => bag.Amount.OnNext(x));
            volumeInputs.Subscribe(x => bag.Volume.OnNext(x));
            concentratioInputs.Subscribe(x => bag.Concentration.OnNext(x));

            bag.Volume.Subscribe(x => SetValue(numericUpDownvolume, x));
            bag.Amount.Subscribe(x => SetValue(numericUpDownMedication, x));
            bag.Concentration.Subscribe(x => SetValue(numericUpDownconc, x));
        }

        private void O_LostFocus(object sender, EventArgs e)
        {
            _lastValueChangedControl = (sender as NumericUpDown);

        }

        private void O_ValueChanged1(object sender, EventArgs e)
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
        }

        private static decimal GetValue(Signal<IOperand> sig)
        {
            if ((sig?.Value as QuantableValue)?.Value == null)
                return 0;

            return Convert.ToDecimal((sig.Value as QuantableValue).Value);
        }

        private void SetValue(NumericUpDown control, Signal<IOperand> sig)
        {
            lock (this)
            {


                if ((sig?.Value as QuantableValue)?.Value == null)
                {
                    if (control.Value != 0)
                    {
                        control.Value = 0;
                    }

                }

                else

                {
                    var dec = Math.Round(Convert.ToDecimal((sig.Value as QuantableValue).Value), 2);
                    System.IO.File.AppendAllText($"sets.txt", $"\r\n{control.Name}: {dec} <{string.Join(",", sig.PrioritySet)}>");
                    if (control.Value != dec)
                    {
                        control.Value = dec;
                        //control.Tag = sig.PrioritySet;
                        control.BackColor = Color.Yellow;

                    }
                }
            }

        }

        IObservable<Signal<IOperand>> GetObservable(NumericUpDown control)
        {
            return Observable.FromEventPattern<double>(this, "ControlValueChanged").Where(o => o.Sender == control).Select(o => (o.Sender as NumericUpDown).Value.ToString())//.Scan((x,y)=>y)//.Select(o=> Convert.ToDouble(o))
                .Select(o => new QuantableValue(Convert.ToDouble(o))).Select(o => new Signal<IOperand>(o)).DistinctUntilChanged()
                .Select(o => o).Publish().RefCount().Select(o => o);
        }
    }
}
