using DosageDomainModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RIvarX;



namespace WindowsFormsApp1
{
    static class Program
    {
       

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new CascadingDropdown());
            return;

            //CycleExample cycle = new CycleExample();
            //cycle.left.Subscribe(x => { });
            //cycle.right.Subscribe(x => { });
            //cycle.width.Subscribe(x => { });

            //cycle.right.OnNext(new Signal<double>(50));
            //cycle.left.OnNext(new Signal<double>(20));

            //cycle.width.OnNext(new Signal<double>(100));



            //var wikiExample = new DosageDomainModel.another.GlitchExample();
            //wikiExample.g.Subscribe(x => { });
            //wikiExample.seconds.OnNext(new Signal<int>(1));
            //wikiExample.seconds.OnNext(new Signal<int>(2));



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form1 = new Form1();

            Bind(form1);

            var f = new Form2();
           var a1 = GetObservable(f, f._A1);
            var b1 = GetObservable(f, f._B1);
            var c1 = GetObservable(f, f._C1);

           //  Application.Run(new Form2());//simple excel
             Application.Run(new Form3());//infusion in excel

          //   Application.Run(form1);//infusion modular

        }

       
        static void Bind(Form1 form1)
        {

            var medicationInputs = GetObservable(form1, form1.numericUpDownMedication);
            var volumeInputs = GetObservable(form1, form1.numericUpDownvolume);
            var concentratioInputs = GetObservable(form1, form1.numericUpDownconc);
            var doseInputs = GetObservable(form1, form1.numericUpDowndose);
            var rateInputs = GetObservable(form1, form1.numericUpDownrate);
            var durationInputs = GetObservable(form1, form1.numericUpDowndure);

            var bag = new Bag();
            var infusedBag = new InfusedBag(bag);

            medicationInputs.Subscribe(x => bag.Amount.OnNext(x));
            volumeInputs.Subscribe(x => bag.Volume.OnNext(x));
            concentratioInputs.Subscribe(x => bag.Concentration.OnNext(x));
            doseInputs.Subscribe(x => infusedBag.Dose.OnNext(x));
            rateInputs.Subscribe(x => infusedBag.Rate.OnNext(x));
            durationInputs.Subscribe(x => infusedBag.Duration.OnNext(x));

            infusedBag.Dose.Subscribe(x => SetValue(form1, form1.numericUpDowndose, x));
            infusedBag.Rate.Subscribe(x => SetValue(form1, form1.numericUpDownrate, x));
            infusedBag.Duration.Subscribe(x => SetValue(form1, form1.numericUpDowndure, x));
            bag.Volume.Subscribe(x => SetValue(form1, form1.numericUpDownvolume, x));
            bag.Amount.Subscribe(x => SetValue(form1, form1.numericUpDownMedication, x));
            bag.Concentration.Subscribe(x => SetValue(form1, form1.numericUpDownconc, x));
        }

    
        private static decimal GetValue(Signal<IOperand> sig)
        {
            if ((sig?.Value as QuantableValue)?.Value == null)
                return 0;

            return Convert.ToDecimal((sig.Value as QuantableValue).Value);
        }

        private static void SetValue(Form1 form1, NumericUpDown control, Signal<IOperand> sig)
        {
            lock (form1)
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

        static IObservable<Signal<IOperand>>  GetObservable(Form form1, NumericUpDown control)
        {
            return Observable.FromEventPattern<double>(form1, "ControlValueChanged").Where(o => o.Sender == control).Select(o => (o.Sender as NumericUpDown).Value.ToString())//.Scan((x,y)=>y)//.Select(o=> Convert.ToDouble(o))
                .Select(o => new QuantableValue(Convert.ToDouble(o))).Select(o => new Signal<IOperand>(o)).DistinctUntilChanged()
                .Select(o => o).Publish().RefCount().Select(o => o);
        }
    }


}
