﻿namespace Supermarkets
{
    partial class frmGenerateBarcode
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
            this.btnGenerateBarcode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerateBarcode
            // 
            this.btnGenerateBarcode.Location = new System.Drawing.Point(87, 104);
            this.btnGenerateBarcode.Name = "btnGenerateBarcode";
            this.btnGenerateBarcode.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateBarcode.TabIndex = 0;
            this.btnGenerateBarcode.Text = "Generate Barcode";
            this.btnGenerateBarcode.UseVisualStyleBackColor = true;
            this.btnGenerateBarcode.Click += new System.EventHandler(this.btnGenerateBarcode_Click);
            // 
            // frmGenerateBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 266);
            this.Controls.Add(this.btnGenerateBarcode);
            this.Name = "frmGenerateBarcode";
            this.Text = "frmGenerateBarcode";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateBarcode;
    }
}