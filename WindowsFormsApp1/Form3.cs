using DosageDomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactiveVariablesExtension;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private Subject<SignalValue<IOperand>> amount = new Subject<SignalValue<IOperand>>();
        private Subject<SignalValue<IOperand>> volume = new Subject<SignalValue<IOperand>>();
        private Subject<SignalValue<IOperand>> concentration = new Subject<SignalValue<IOperand>>();
        public Subject<SignalValue<IOperand>> Rate = new Subject<SignalValue<IOperand>>();
        public Subject<SignalValue<IOperand>> Dose = new Subject<SignalValue<IOperand>>();
        public Subject<SignalValue<IOperand>> Duration = new Subject<SignalValue<IOperand>>();

        public Form3()
        {
            InitializeComponent();

            ConnectCells();

            SpreadsheetFormulas();

           
        }

        private void ConnectCells()
        {
            Connect(amount, AmountCell);
            Connect(volume, VolumeControl);
            Connect(concentration, ConcentrationControl);
            Connect(Rate, RateControl);
            Connect(Dose, DoseCell);
            Connect(Duration, DurationCell);
        }

        private void SpreadsheetFormulas()
        {
            concentration.Set(amount.Div(volume));
            amount.Set(concentration.Mul(volume));
            volume.Set(amount.Div(concentration));

            Dose.Set(amount.Div(Duration));
            Rate.Set(volume.Div(Duration));

            Duration.Set(amount.Div(Dose));
            Duration.Set(volume.Div(Rate));

            amount.Set(Duration.Mul(Dose));
            volume.Set(Duration.Mul(Rate));
        }

        public event EventHandler<double> ControlValueChanged;
        NumericUpDown _lastValueChangedControl;
        string _id = Guid.NewGuid().ToString();

        void Connect(Subject<SignalValue<IOperand>> subject, NumericUpDown control)
        {
            subject.Subscribe(x => SetValue(control, x));
            var observable = GetObservable(control);
            observable.Subscribe(x => subject.OnNext(x));

            control.GotFocus += Control_GotFocus;
            control.ValueChanged += O_ValueChanged1;
            control.LostFocus += O_LostFocus;
        }

        private void SetValue(NumericUpDown control, SignalValue<IOperand> sig)
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
                        control.BackColor = Color.Yellow;
                    }
                }
            }

        }


        private void Control_GotFocus(object sender, EventArgs e)
        {
            txtFormula.Text = (sender as NumericUpDown).Tag?.ToString()?.Replace("\\n",Environment.NewLine);
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

        IObservable<SignalValue<IOperand>> GetObservable(NumericUpDown control)
        {
            return Observable.FromEventPattern<double>(this, "ControlValueChanged").Where(o => o.Sender == control).Select(o => (o.Sender as NumericUpDown).Value.ToString())//.Scan((x,y)=>y)//.Select(o=> Convert.ToDouble(o))
                .Select(o => new QuantableValue(Convert.ToDouble(o))).Select(o => new SignalValue<IOperand>(o)).DistinctUntilChanged()
                .Select(o => o).Publish().RefCount().Select(o => o);
        }

    }
}
