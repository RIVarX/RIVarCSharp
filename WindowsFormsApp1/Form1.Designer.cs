namespace WindowsFormsApp1
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownMedication = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownvolume = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownconc = new System.Windows.Forms.NumericUpDown();
            this.labelMed = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.labelConce = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDuration = new System.Windows.Forms.Label();
            this.labelRate = new System.Windows.Forms.Label();
            this.labelDose = new System.Windows.Forms.Label();
            this.numericUpDowndure = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownrate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDowndose = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMedication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownvolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownconc)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowndure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowndose)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownMedication
            // 
            this.numericUpDownMedication.DecimalPlaces = 2;
            this.numericUpDownMedication.Location = new System.Drawing.Point(22, 63);
            this.numericUpDownMedication.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMedication.Name = "numericUpDownMedication";
            this.numericUpDownMedication.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMedication.TabIndex = 0;
            // 
            // numericUpDownvolume
            // 
            this.numericUpDownvolume.DecimalPlaces = 2;
            this.numericUpDownvolume.Location = new System.Drawing.Point(341, 63);
            this.numericUpDownvolume.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownvolume.Name = "numericUpDownvolume";
            this.numericUpDownvolume.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownvolume.TabIndex = 1;
            // 
            // numericUpDownconc
            // 
            this.numericUpDownconc.DecimalPlaces = 2;
            this.numericUpDownconc.Location = new System.Drawing.Point(192, 63);
            this.numericUpDownconc.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownconc.Name = "numericUpDownconc";
            this.numericUpDownconc.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownconc.TabIndex = 2;
            // 
            // labelMed
            // 
            this.labelMed.AutoSize = true;
            this.labelMed.Location = new System.Drawing.Point(57, 29);
            this.labelMed.Name = "labelMed";
            this.labelMed.Size = new System.Drawing.Size(59, 13);
            this.labelMed.TabIndex = 3;
            this.labelMed.Text = "Medication";
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(371, 29);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(42, 13);
            this.labelVolume.TabIndex = 4;
            this.labelVolume.Text = "Volume";
            // 
            // labelConce
            // 
            this.labelConce.AutoSize = true;
            this.labelConce.Location = new System.Drawing.Point(221, 29);
            this.labelConce.Name = "labelConce";
            this.labelConce.Size = new System.Drawing.Size(73, 13);
            this.labelConce.TabIndex = 5;
            this.labelConce.Text = "Concentration";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelDuration);
            this.panel1.Controls.Add(this.labelRate);
            this.panel1.Controls.Add(this.labelDose);
            this.panel1.Controls.Add(this.numericUpDowndure);
            this.panel1.Controls.Add(this.numericUpDownrate);
            this.panel1.Controls.Add(this.numericUpDowndose);
            this.panel1.Location = new System.Drawing.Point(21, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 93);
            this.panel1.TabIndex = 6;
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(200, 14);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(47, 13);
            this.labelDuration.TabIndex = 11;
            this.labelDuration.Text = "Duration";
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(351, 14);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(30, 13);
            this.labelRate.TabIndex = 10;
            this.labelRate.Text = "Rate";
            // 
            // labelDose
            // 
            this.labelDose.AutoSize = true;
            this.labelDose.Location = new System.Drawing.Point(37, 14);
            this.labelDose.Name = "labelDose";
            this.labelDose.Size = new System.Drawing.Size(32, 13);
            this.labelDose.TabIndex = 9;
            this.labelDose.Text = "Dose";
            // 
            // numericUpDowndure
            // 
            this.numericUpDowndure.DecimalPlaces = 2;
            this.numericUpDowndure.Location = new System.Drawing.Point(171, 48);
            this.numericUpDowndure.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDowndure.Name = "numericUpDowndure";
            this.numericUpDowndure.Size = new System.Drawing.Size(120, 20);
            this.numericUpDowndure.TabIndex = 8;
            // 
            // numericUpDownrate
            // 
            this.numericUpDownrate.DecimalPlaces = 2;
            this.numericUpDownrate.Location = new System.Drawing.Point(320, 48);
            this.numericUpDownrate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownrate.Name = "numericUpDownrate";
            this.numericUpDownrate.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownrate.TabIndex = 7;
            // 
            // numericUpDowndose
            // 
            this.numericUpDowndose.DecimalPlaces = 2;
            this.numericUpDowndose.Location = new System.Drawing.Point(2, 48);
            this.numericUpDowndose.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDowndose.Name = "numericUpDowndose";
            this.numericUpDowndose.Size = new System.Drawing.Size(120, 20);
            this.numericUpDowndose.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Infusion;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(23, 221);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 317);
            this.panel2.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 541);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelConce);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.labelMed);
            this.Controls.Add(this.numericUpDownconc);
            this.Controls.Add(this.numericUpDownvolume);
            this.Controls.Add(this.numericUpDownMedication);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMedication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownvolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownconc)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowndure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowndose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.NumericUpDown numericUpDowndure;
        internal System.Windows.Forms.NumericUpDown numericUpDownrate;
        internal System.Windows.Forms.NumericUpDown numericUpDowndose;
        internal System.Windows.Forms.NumericUpDown numericUpDownMedication;
        internal System.Windows.Forms.NumericUpDown numericUpDownvolume;
        internal System.Windows.Forms.NumericUpDown numericUpDownconc;
        public System.Windows.Forms.Label labelMed;
        public System.Windows.Forms.Label labelVolume;
        public System.Windows.Forms.Label labelDose;
        public System.Windows.Forms.Label labelRate;
        public System.Windows.Forms.Label labelConce;
        public System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Panel panel2;
    }
}

