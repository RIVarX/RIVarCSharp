namespace WindowsFormsApp1
{
    partial class UserControl_Bag
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
            this.labelConce = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.labelMed = new System.Windows.Forms.Label();
            this.numericUpDownconc = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownvolume = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMedication = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownconc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownvolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMedication)).BeginInit();
            this.SuspendLayout();
            // 
            // labelConce
            // 
            this.labelConce.AutoSize = true;
            this.labelConce.Location = new System.Drawing.Point(215, 37);
            this.labelConce.Name = "labelConce";
            this.labelConce.Size = new System.Drawing.Size(73, 13);
            this.labelConce.TabIndex = 11;
            this.labelConce.Text = "Concentration";
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(365, 37);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(42, 13);
            this.labelVolume.TabIndex = 10;
            this.labelVolume.Text = "Volume";
            // 
            // labelMed
            // 
            this.labelMed.AutoSize = true;
            this.labelMed.Location = new System.Drawing.Point(51, 37);
            this.labelMed.Name = "labelMed";
            this.labelMed.Size = new System.Drawing.Size(59, 13);
            this.labelMed.TabIndex = 9;
            this.labelMed.Text = "Medication";
            // 
            // numericUpDownconc
            // 
            this.numericUpDownconc.DecimalPlaces = 2;
            this.numericUpDownconc.Location = new System.Drawing.Point(186, 71);
            this.numericUpDownconc.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownconc.Name = "numericUpDownconc";
            this.numericUpDownconc.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownconc.TabIndex = 8;
            // 
            // numericUpDownvolume
            // 
            this.numericUpDownvolume.DecimalPlaces = 2;
            this.numericUpDownvolume.Location = new System.Drawing.Point(335, 71);
            this.numericUpDownvolume.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownvolume.Name = "numericUpDownvolume";
            this.numericUpDownvolume.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownvolume.TabIndex = 7;
            // 
            // numericUpDownMedication
            // 
            this.numericUpDownMedication.DecimalPlaces = 2;
            this.numericUpDownMedication.Location = new System.Drawing.Point(16, 71);
            this.numericUpDownMedication.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMedication.Name = "numericUpDownMedication";
            this.numericUpDownMedication.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMedication.TabIndex = 6;
            // 
            // UserControl_Bag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelConce);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.labelMed);
            this.Controls.Add(this.numericUpDownconc);
            this.Controls.Add(this.numericUpDownvolume);
            this.Controls.Add(this.numericUpDownMedication);
            this.Name = "UserControl_Bag";
            this.Size = new System.Drawing.Size(507, 123);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownconc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownvolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMedication)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelConce;
        public System.Windows.Forms.Label labelVolume;
        public System.Windows.Forms.Label labelMed;
        internal System.Windows.Forms.NumericUpDown numericUpDownconc;
        internal System.Windows.Forms.NumericUpDown numericUpDownvolume;
        internal System.Windows.Forms.NumericUpDown numericUpDownMedication;
    }
}
