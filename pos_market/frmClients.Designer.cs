namespace Supermarkets
{
    partial class frmClients
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFindCl = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClFullName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIdCl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(9, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 58);
            this.panel1.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(310, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Administrimi Klienteve";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnDelete.Location = new System.Drawing.Point(518, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 47);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Fshij (Del)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFindCl
            // 
            this.btnFindCl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnFindCl.Location = new System.Drawing.Point(153, 10);
            this.btnFindCl.Name = "btnFindCl";
            this.btnFindCl.Size = new System.Drawing.Size(130, 47);
            this.btnFindCl.TabIndex = 11;
            this.btnFindCl.Text = "Gjej (CTRL F)";
            this.btnFindCl.UseVisualStyleBackColor = true;
            this.btnFindCl.Click += new System.EventHandler(this.btnFindCl_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnNew.Location = new System.Drawing.Point(14, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(133, 47);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "Krijo(Ctrl N)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnSave.Location = new System.Drawing.Point(367, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 47);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Ruaj (Enter)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnClose.Location = new System.Drawing.Point(639, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 47);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Mbyll";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnFindCl);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(12, 274);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 66);
            this.panel2.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Constantia", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Adresa , Emaili, Numri telefonit";
            // 
            // txtClFullName
            // 
            this.txtClFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClFullName.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtClFullName.Location = new System.Drawing.Point(102, 102);
            this.txtClFullName.MaxLength = 50;
            this.txtClFullName.Multiline = true;
            this.txtClFullName.Name = "txtClFullName";
            this.txtClFullName.Size = new System.Drawing.Size(676, 40);
            this.txtClFullName.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Constantia", 10F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(99, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 17);
            this.label10.TabIndex = 45;
            this.label10.Text = "Emri Plot, Numri tiketes";
            // 
            // txtIdCl
            // 
            this.txtIdCl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdCl.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtIdCl.Location = new System.Drawing.Point(23, 102);
            this.txtIdCl.MaxLength = 10;
            this.txtIdCl.Multiline = true;
            this.txtIdCl.Name = "txtIdCl";
            this.txtIdCl.Size = new System.Drawing.Size(73, 40);
            this.txtIdCl.TabIndex = 1;
            this.txtIdCl.TextChanged += new System.EventHandler(this.txtIDCl_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Constantia", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 47;
            this.label1.Text = "ID";
            // 
            // txtDetails
            // 
            this.txtDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetails.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtDetails.Location = new System.Drawing.Point(23, 172);
            this.txtDetails.MaxLength = 20;
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(755, 96);
            this.txtDetails.TabIndex = 48;
            // 
            // frmClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(790, 345);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdCl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtClFullName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmClients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrimi Klienteve";
            this.Load += new System.EventHandler(this.frmClients_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFindCl;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClFullName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIdCl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDetails;
    }
}