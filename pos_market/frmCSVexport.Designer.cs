namespace Supermarkets
{
    partial class frmCSVexport
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDistributor = new System.Windows.Forms.ComboBox();
            this.btnExp = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cmbDistributor);
            this.panel4.Controls.Add(this.btnExp);
            this.panel4.Location = new System.Drawing.Point(12, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(522, 48);
            this.panel4.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Copperplate Gothic Light", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tabela per Eksport";
            // 
            // cmbDistributor
            // 
            this.cmbDistributor.Font = new System.Drawing.Font("Courier New", 12F);
            this.cmbDistributor.FormattingEnabled = true;
            this.cmbDistributor.Location = new System.Drawing.Point(135, 9);
            this.cmbDistributor.Name = "cmbDistributor";
            this.cmbDistributor.Size = new System.Drawing.Size(195, 26);
            this.cmbDistributor.TabIndex = 1;
            this.cmbDistributor.SelectedIndexChanged += new System.EventHandler(this.cmbDistributor_SelectedIndexChanged);
            // 
            // btnExp
            // 
            this.btnExp.BackColor = System.Drawing.Color.Transparent;
            this.btnExp.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnExp.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.btnExp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExp.Location = new System.Drawing.Point(336, 4);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(177, 39);
            this.btnExp.TabIndex = 2;
            this.btnExp.Text = "Eksporto CSV";
            this.btnExp.UseVisualStyleBackColor = false;
            this.btnExp.Visible = false;
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // frmCSVexport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 70);
            this.Controls.Add(this.panel4);
            this.Name = "frmCSVexport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export CSV files";
            this.Load += new System.EventHandler(this.frmCSVexport_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnExp;
        private System.Windows.Forms.ComboBox cmbDistributor;
        private System.Windows.Forms.Label label3;
    }
}