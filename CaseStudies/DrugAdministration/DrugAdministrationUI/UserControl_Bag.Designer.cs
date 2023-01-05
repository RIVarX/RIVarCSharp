namespace DrugAdministrationUI
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
            this.Concentration_Control = new System.Windows.Forms.NumericUpDown();
            this.Volume_Control = new System.Windows.Forms.NumericUpDown();
            this.Drug_Control = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Concentration_Control)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Volume_Control)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Drug_Control)).BeginInit();
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
            this.labelVolume.Location = new System.Drawing.Point(359, 37);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(75, 13);
            this.labelVolume.TabIndex = 10;
            this.labelVolume.Text = "VolumeOfFluid";
            // 
            // labelMed
            // 
            this.labelMed.AutoSize = true;
            this.labelMed.Location = new System.Drawing.Point(51, 37);
            this.labelMed.Name = "labelMed";
            this.labelMed.Size = new System.Drawing.Size(30, 13);
            this.labelMed.TabIndex = 9;
            this.labelMed.Text = "Drug";
            // 
            // Concentration_Control
            // 
            this.Concentration_Control.DecimalPlaces = 2;
            this.Concentration_Control.Location = new System.Drawing.Point(186, 71);
            this.Concentration_Control.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Concentration_Control.Name = "Concentration_Control";
            this.Concentration_Control.Size = new System.Drawing.Size(120, 20);
            this.Concentration_Control.TabIndex = 8;
            // 
            // Volume_Control
            // 
            this.Volume_Control.DecimalPlaces = 2;
            this.Volume_Control.Location = new System.Drawing.Point(335, 71);
            this.Volume_Control.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Volume_Control.Name = "Volume_Control";
            this.Volume_Control.Size = new System.Drawing.Size(120, 20);
            this.Volume_Control.TabIndex = 7;
            // 
            // Drug_Control
            // 
            this.Drug_Control.DecimalPlaces = 2;
            this.Drug_Control.Location = new System.Drawing.Point(16, 71);
            this.Drug_Control.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Drug_Control.Name = "Drug_Control";
            this.Drug_Control.Size = new System.Drawing.Size(120, 20);
            this.Drug_Control.TabIndex = 6;
            // 
            // UserControl_Bag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelConce);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.labelMed);
            this.Controls.Add(this.Concentration_Control);
            this.Controls.Add(this.Volume_Control);
            this.Controls.Add(this.Drug_Control);
            this.Name = "UserControl_Bag";
            this.Size = new System.Drawing.Size(507, 123);
            ((System.ComponentModel.ISupportInitialize)(this.Concentration_Control)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Volume_Control)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Drug_Control)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelConce;
        public System.Windows.Forms.Label labelVolume;
        public System.Windows.Forms.Label labelMed;
        internal System.Windows.Forms.NumericUpDown Concentration_Control;
        internal System.Windows.Forms.NumericUpDown Volume_Control;
        internal System.Windows.Forms.NumericUpDown Drug_Control;
    }
}
