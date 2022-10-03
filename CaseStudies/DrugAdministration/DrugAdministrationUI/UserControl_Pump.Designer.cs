namespace DrugAdministrationUI
{
    partial class UserControl_Pump
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelDuration = new System.Windows.Forms.Label();
            this.labelRate = new System.Windows.Forms.Label();
            this.labelDose = new System.Windows.Forms.Label();
            this.numericUpDowndure = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownrate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDowndose = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowndure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowndose)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(221, 20);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(47, 13);
            this.labelDuration.TabIndex = 17;
            this.labelDuration.Text = "Duration";
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(372, 20);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(30, 13);
            this.labelRate.TabIndex = 16;
            this.labelRate.Text = "Rate";
            // 
            // labelDose
            // 
            this.labelDose.AutoSize = true;
            this.labelDose.Location = new System.Drawing.Point(58, 20);
            this.labelDose.Name = "labelDose";
            this.labelDose.Size = new System.Drawing.Size(32, 13);
            this.labelDose.TabIndex = 15;
            this.labelDose.Text = "Dose";
            // 
            // numericUpDowndure
            // 
            this.numericUpDowndure.DecimalPlaces = 2;
            this.numericUpDowndure.Location = new System.Drawing.Point(192, 54);
            this.numericUpDowndure.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDowndure.Name = "numericUpDowndure";
            this.numericUpDowndure.Size = new System.Drawing.Size(120, 20);
            this.numericUpDowndure.TabIndex = 14;
            // 
            // numericUpDownrate
            // 
            this.numericUpDownrate.DecimalPlaces = 2;
            this.numericUpDownrate.Location = new System.Drawing.Point(341, 54);
            this.numericUpDownrate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownrate.Name = "numericUpDownrate";
            this.numericUpDownrate.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownrate.TabIndex = 13;
            // 
            // numericUpDowndose
            // 
            this.numericUpDowndose.DecimalPlaces = 2;
            this.numericUpDowndose.Location = new System.Drawing.Point(23, 54);
            this.numericUpDowndose.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDowndose.Name = "numericUpDowndose";
            this.numericUpDowndose.Size = new System.Drawing.Size(120, 20);
            this.numericUpDowndose.TabIndex = 12;
            // 
            // UserControl_Pump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.labelRate);
            this.Controls.Add(this.labelDose);
            this.Controls.Add(this.numericUpDowndure);
            this.Controls.Add(this.numericUpDownrate);
            this.Controls.Add(this.numericUpDowndose);
            this.Name = "UserControl_Pump";
            this.Size = new System.Drawing.Size(493, 102);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowndure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowndose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelDuration;
        public System.Windows.Forms.Label labelRate;
        public System.Windows.Forms.Label labelDose;
        internal System.Windows.Forms.NumericUpDown numericUpDowndure;
        internal System.Windows.Forms.NumericUpDown numericUpDownrate;
        internal System.Windows.Forms.NumericUpDown numericUpDowndose;
    }
}
