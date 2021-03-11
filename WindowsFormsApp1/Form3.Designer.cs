namespace WindowsFormsApp1
{
    partial class Form3
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
            this.txtFormula = new System.Windows.Forms.TextBox();
            this.DurationCell = new System.Windows.Forms.NumericUpDown();
            this.DoseCell = new System.Windows.Forms.NumericUpDown();
            this.AmountCell = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.ConcentrationControl = new System.Windows.Forms.NumericUpDown();
            this.RateControl = new System.Windows.Forms.NumericUpDown();
            this.VolumeControl = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DurationCell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoseCell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountCell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConcentrationControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeControl)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFormula
            // 
            this.txtFormula.Location = new System.Drawing.Point(49, 12);
            this.txtFormula.Multiline = true;
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Size = new System.Drawing.Size(276, 47);
            this.txtFormula.TabIndex = 29;
            // 
            // DurationCell
            // 
            this.DurationCell.DecimalPlaces = 2;
            this.DurationCell.Location = new System.Drawing.Point(143, 168);
            this.DurationCell.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.DurationCell.Name = "DurationCell";
            this.DurationCell.Size = new System.Drawing.Size(88, 20);
            this.DurationCell.TabIndex = 28;
            this.DurationCell.Tag = "=Amount/Dose\\n=Volume/Rate";
            // 
            // DoseCell
            // 
            this.DoseCell.DecimalPlaces = 2;
            this.DoseCell.Location = new System.Drawing.Point(49, 168);
            this.DoseCell.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.DoseCell.Name = "DoseCell";
            this.DoseCell.Size = new System.Drawing.Size(88, 20);
            this.DoseCell.TabIndex = 27;
            this.DoseCell.Tag = "=Amount/Duration";
            // 
            // AmountCell
            // 
            this.AmountCell.DecimalPlaces = 2;
            this.AmountCell.Location = new System.Drawing.Point(49, 116);
            this.AmountCell.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.AmountCell.Name = "AmountCell";
            this.AmountCell.Size = new System.Drawing.Size(88, 20);
            this.AmountCell.TabIndex = 26;
            this.AmountCell.Tag = "=Dose*Duration\\n=Concentration*Volume";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "B";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "A";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 20);
            this.textBox1.TabIndex = 30;
            this.textBox1.Text = "Amount";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(49, 142);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(88, 20);
            this.textBox2.TabIndex = 31;
            this.textBox2.Text = "Dose";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(143, 142);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(88, 20);
            this.textBox3.TabIndex = 32;
            this.textBox3.Text = "Duration";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(143, 90);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(88, 20);
            this.textBox4.TabIndex = 40;
            this.textBox4.Text = "Concentration";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(237, 142);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(88, 20);
            this.textBox5.TabIndex = 39;
            this.textBox5.Text = "Rate";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(237, 90);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(88, 20);
            this.textBox6.TabIndex = 38;
            this.textBox6.Text = "Volume";
            // 
            // ConcentrationControl
            // 
            this.ConcentrationControl.DecimalPlaces = 2;
            this.ConcentrationControl.Location = new System.Drawing.Point(143, 116);
            this.ConcentrationControl.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ConcentrationControl.Name = "ConcentrationControl";
            this.ConcentrationControl.Size = new System.Drawing.Size(88, 20);
            this.ConcentrationControl.TabIndex = 1;
            this.ConcentrationControl.Tag = "=Amount/Volume";
            // 
            // RateControl
            // 
            this.RateControl.DecimalPlaces = 2;
            this.RateControl.Location = new System.Drawing.Point(237, 168);
            this.RateControl.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.RateControl.Name = "RateControl";
            this.RateControl.Size = new System.Drawing.Size(88, 20);
            this.RateControl.TabIndex = 36;
            this.RateControl.Tag = "=Volume/Duration";
            // 
            // VolumeControl
            // 
            this.VolumeControl.DecimalPlaces = 2;
            this.VolumeControl.Location = new System.Drawing.Point(237, 116);
            this.VolumeControl.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.VolumeControl.Name = "VolumeControl";
            this.VolumeControl.Size = new System.Drawing.Size(88, 20);
            this.VolumeControl.TabIndex = 35;
            this.VolumeControl.Tag = "=Amount/Concentration\\n=Duration*Rate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "f(x)";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 233);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.ConcentrationControl);
            this.Controls.Add(this.RateControl);
            this.Controls.Add(this.VolumeControl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtFormula);
            this.Controls.Add(this.DurationCell);
            this.Controls.Add(this.DoseCell);
            this.Controls.Add(this.AmountCell);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.DurationCell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoseCell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountCell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConcentrationControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.NumericUpDown DurationCell;
        private System.Windows.Forms.NumericUpDown DoseCell;
        private System.Windows.Forms.NumericUpDown AmountCell;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.NumericUpDown ConcentrationControl;
        private System.Windows.Forms.NumericUpDown RateControl;
        private System.Windows.Forms.NumericUpDown VolumeControl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}