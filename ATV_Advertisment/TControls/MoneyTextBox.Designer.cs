﻿namespace TControls
{
    partial class MoneyTextBox
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
            this.SuspendLayout();
            // 
            // MoneyTextBox
            // 
            this.Size = new System.Drawing.Size(804, 20);
            this.TextChanged += new System.EventHandler(this.MoneyTextBox_TextChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MoneyTextBox_KeyPress);
            this.Validated += new System.EventHandler(this.MoneyTextBox_Validated);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
