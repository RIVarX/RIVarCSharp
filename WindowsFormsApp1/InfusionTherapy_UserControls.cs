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
    public partial class InfusionTherapy_UserControls : Form
    {
        UserControl_Pump _userControl_Pump;
        public InfusionTherapy_UserControls()
        {
            InitializeComponent();
            _userControl_Pump = new WindowsFormsApp1.UserControl_Pump(userControl_Bag1);
            this._userControl_Pump.Location = new System.Drawing.Point(50, 300);
        
            this._userControl_Pump.Size = new System.Drawing.Size(507, 123);
            this._userControl_Pump.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._userControl_Pump);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }
    }
}
