﻿namespace WindowsFormsApp1
{
    partial class InfusionTherapy_UserControls
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
            this.userControl_Bag1 = new WindowsFormsApp1.UserControl_Bag();
            this.SuspendLayout();
            // 
            // userControl_Bag1
            // 
            this.userControl_Bag1.Location = new System.Drawing.Point(122, 39);
            this.userControl_Bag1.Name = "userControl_Bag1";
            this.userControl_Bag1.Size = new System.Drawing.Size(507, 123);
            this.userControl_Bag1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userControl_Bag1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl_Bag userControl_Bag1;
    }
}