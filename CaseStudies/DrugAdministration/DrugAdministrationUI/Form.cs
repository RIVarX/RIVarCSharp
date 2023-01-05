using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrugAdministrationUI
{
    public partial class Form : System.Windows.Forms.Form
    {
        UserControl_Pump _userControl_Pump;
        public Form(UserControl_Bag userControl_Bag, UserControl_Pump userControl_Pump)
        {
            InitializeComponent();

            userControl_Bag.Location = new System.Drawing.Point(-2, 2);
            userControl_Bag.Size = new System.Drawing.Size(507, 123);
            this.Controls.Add(userControl_Bag);

            userControl_Pump.Location = new System.Drawing.Point(0, 150);
            userControl_Pump.Size = new System.Drawing.Size(507, 123);
            this.Controls.Add(userControl_Pump);

         
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        
            this.Controls.Add(this._userControl_Pump);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }
    }
}
