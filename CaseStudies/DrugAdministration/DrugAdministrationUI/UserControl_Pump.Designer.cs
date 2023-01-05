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
            this.Duration_Control = new System.Windows.Forms.NumericUpDown();
            this.Rate_Control = new System.Windows.Forms.NumericUpDown();
            this.Dose_Control = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Duration_Control)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rate_Control)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dose_Control)).BeginInit();
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
            // Duration_Control
            // 
            this.Duration_Control.DecimalPlaces = 2;
            this.Duration_Control.Location = new System.Drawing.Point(192, 54);
            this.Duration_Control.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Duration_Control.Name = "Duration_Control";
            this.Duration_Control.Size = new System.Drawing.Size(120, 20);
            this.Duration_Control.TabIndex = 14;
            // 
            // Rate_Control
            // 
            this.Rate_Control.DecimalPlaces = 2;
            this.Rate_Control.Location = new System.Drawing.Point(341, 54);
            this.Rate_Control.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Rate_Control.Name = "Rate_Control";
            this.Rate_Control.Size = new System.Drawing.Size(120, 20);
            this.Rate_Control.TabIndex = 13;
            // 
            // Dose_Control
            // 
            this.Dose_Control.DecimalPlaces = 2;
            this.Dose_Control.Location = new System.Drawing.Point(23, 54);
            this.Dose_Control.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Dose_Control.Name = "Dose_Control";
            this.Dose_Control.Size = new System.Drawing.Size(120, 20);
            this.Dose_Control.TabIndex = 12;
            // 
            // UserControl_Pump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.labelRate);
            this.Controls.Add(this.labelDose);
            this.Controls.Add(this.Duration_Control);
            this.Controls.Add(this.Rate_Control);
            this.Controls.Add(this.Dose_Control);
            this.Name = "UserControl_Pump";
            this.Size = new System.Drawing.Size(493, 102);
            ((System.ComponentModel.ISupportInitialize)(this.Duration_Control)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rate_Control)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dose_Control)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelDuration;
        public System.Windows.Forms.Label labelRate;
        public System.Windows.Forms.Label labelDose;
        internal System.Windows.Forms.NumericUpDown Duration_Control;
        internal System.Windows.Forms.NumericUpDown Rate_Control;
        internal System.Windows.Forms.NumericUpDown Dose_Control;
    }
}
