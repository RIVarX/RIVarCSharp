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
    public partial class UserControl_Pump : UserControl
    {
        public event EventHandler<decimal> ControlValueChanged;
        NumericUpDown _lastValueChangedControl;

        public UserControl_Pump(Pump pump)
        {
            InitializeComponent();

            this.Controls.OfType<NumericUpDown>().ToList().ForEach(ProduceChangeEvents);

            Connect(Dose_Control, pump.Dose);
            Connect(Rate_Control, pump.Rate);
            Connect(Duration_Control, pump.Duration);
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
                        Log($"\r\n{_lastValueChangedControl.Name}:{value}");
                        ControlValueChanged?.Invoke(sender, value);
                        (sender as NumericUpDown).BackColor = Color.White;
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
                    var value = Math.Round(Convert.ToDecimal(signal.Value), 2);
                    Log($"\r\n{control.Name}: {value} <{string.Join(",", signal.PrioritySet)}>");
                    if (control.Value != value)
                    {
                        control.Value = value;
                        control.BackColor = Color.Yellow;
                    }
                }
            }
        }
        IObservable<Signal<decimal>> GetObservable(NumericUpDown control)
        {
            return Observable.FromEventPattern<decimal>(this, "ControlValueChanged").Where(o => o.Sender == control).Select(o => (o.Sender as NumericUpDown).Value.ToString())//.Scan((x,y)=>y)//.Select(o=> Convert.ToDouble(o))
                .Select(o => Convert.ToDecimal(o)).Select(o => new Signal<decimal>(o)).DistinctUntilChanged()
                .Select(o => o).Publish().RefCount().Select(o => o);
        }
        void Log(string text)
        {
            System.IO.File.AppendAllText($"log.txt", text);
        }
    }
}
