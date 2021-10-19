using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class InfusionTherapy : Form
    {
        public event EventHandler<double> ControlValueChanged;
        NumericUpDown _lastValueChangedControl;
        string _id = Guid.NewGuid().ToString();
        public InfusionTherapy()
        {
            
            InitializeComponent();

            var a = this.Controls.OfType<NumericUpDown>().Union(panel1.Controls.OfType<NumericUpDown>()).ToList();
            a.ForEach(o =>
            {
                o.ValueChanged += O_ValueChanged1;
                o.LostFocus += O_LostFocus;

            });
            
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


    }
}
