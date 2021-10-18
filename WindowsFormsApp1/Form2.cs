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
    public partial class Form2 : Form
    {
      

        Subject<SignalValue<IOperand>> A1 = new Subject<SignalValue<IOperand>>();
        Subject<SignalValue<IOperand>> B1 = new Subject<SignalValue<IOperand>>();
        Subject<SignalValue<IOperand>> C1 = new Subject<SignalValue<IOperand>>();
  

        public Form2()
        {
            InitializeComponent();

            Connect(A1, _A1);
            Connect(B1, _B1);
            Connect(C1, _C1);

            C1.Set(A1.Mul(B1));
            A1.Set(C1.Div(B1));
            B1.Set(C1.Div(A1));

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

        private  void SetValue( NumericUpDown control, SignalValue<IOperand> sig)
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
            txtFormula.Text = (sender as NumericUpDown).Tag?.ToString();
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

         IObservable<SignalValue<IOperand>> GetObservable( NumericUpDown control)
        {
            return Observable.FromEventPattern<double>(this, "ControlValueChanged").Where(o => o.Sender == control).Select(o => (o.Sender as NumericUpDown).Value.ToString())//.Scan((x,y)=>y)//.Select(o=> Convert.ToDouble(o))
                .Select(o => new QuantableValue(Convert.ToDouble(o))).Select(o => new SignalValue<IOperand>(o)).DistinctUntilChanged()
                .Select(o => o).Publish().RefCount().Select(o => o);
        }

    }
}
