namespace Supermarkets
{
    partial class frmStaff
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtStaffId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStaffFullName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStaffEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStaffPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStaffCountry = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStaffPCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStaffCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFindCl = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtStaffUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStaffAdress = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStaffPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbLevelAdmin = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Constantia", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(50, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 67;
            this.label1.Text = "ID";
            // 
            // txtStaffId
            // 
            this.txtStaffId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffId.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtStaffId.Location = new System.Drawing.Point(53, 102);
            this.txtStaffId.MaxLength = 10;
            this.txtStaffId.Multiline = true;
            this.txtStaffId.Name = "txtStaffId";
            this.txtStaffId.Size = new System.Drawing.Size(46, 40);
            this.txtStaffId.TabIndex = 1;
            this.txtStaffId.TextChanged += new System.EventHandler(this.txtStaffId_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Constantia", 10F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(102, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 17);
            this.label10.TabIndex = 65;
            this.label10.Text = "Emri Plot";
            // 
            // txtStaffFullName
            // 
            this.txtStaffFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffFullName.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtStaffFullName.Location = new System.Drawing.Point(105, 102);
            this.txtStaffFullName.MaxLength = 20;
            this.txtStaffFullName.Multiline = true;
            this.txtStaffFullName.Name = "txtStaffFullName";
            this.txtStaffFullName.Size = new System.Drawing.Size(645, 40);
            this.txtStaffFullName.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Constantia", 10F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(442, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 63;
            this.label9.Text = "Emaili";
            // 
            // txtStaffEmail
            // 
            this.txtStaffEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffEmail.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtStaffEmail.Location = new System.Drawing.Point(445, 393);
            this.txtStaffEmail.MaxLength = 50;
            this.txtStaffEmail.Multiline = true;
            this.txtStaffEmail.Name = "txtStaffEmail";
            this.txtStaffEmail.Size = new System.Drawing.Size(305, 40);
            this.txtStaffEmail.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Constantia", 10F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(50, 373);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 17);
            this.label8.TabIndex = 62;
            this.label8.Text = "Telefoni";
            // 
            // txtStaffPhone
            // 
            this.txtStaffPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffPhone.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtStaffPhone.Location = new System.Drawing.Point(53, 393);
            this.txtStaffPhone.MaxLength = 20;
            this.txtStaffPhone.Multiline = true;
            this.txtStaffPhone.Name = "txtStaffPhone";
            this.txtStaffPhone.Size = new System.Drawing.Size(305, 40);
            this.txtStaffPhone.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Constantia", 10F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(442, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 61;
            this.label6.Text = "Shteti";
            // 
            // txtStaffCountry
            // 
            this.txtStaffCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffCountry.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtStaffCountry.Location = new System.Drawing.Point(445, 316);
            this.txtStaffCountry.MaxLength = 20;
            this.txtStaffCountry.Multiline = true;
            this.txtStaffCountry.Name = "txtStaffCountry";
            this.txtStaffCountry.Size = new System.Drawing.Size(305, 40);
            this.txtStaffCountry.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Constantia", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(50, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "Kodi Postal";
            // 
            // txtStaffPCode
            // 
            this.txtStaffPCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffPCode.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtStaffPCode.Location = new System.Drawing.Point(53, 316);
            this.txtStaffPCode.MaxLength = 10;
            this.txtStaffPCode.Multiline = true;
            this.txtStaffPCode.Name = "txtStaffPCode";
            this.txtStaffPCode.Size = new System.Drawing.Size(305, 40);
            this.txtStaffPCode.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Constantia", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(442, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 59;
            this.label4.Text = "Qyteti";
            // 
            // txtStaffCity
            // 
            this.txtStaffCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffCity.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtStaffCity.Location = new System.Drawing.Point(445, 245);
            this.txtStaffCity.MaxLength = 20;
            this.txtStaffCity.Multiline = true;
            this.txtStaffCity.Name = "txtStaffCity";
            this.txtStaffCity.Size = new System.Drawing.Size(305, 40);
            this.txtStaffCity.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Constantia", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(50, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 58;
            this.label3.Text = "Adresa";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnFindCl);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(12, 463);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 66);
            this.panel2.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnDelete.Location = new System.Drawing.Point(518, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 47);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Fshij (Del)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFindCl
            // 
            this.btnFindCl.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnFindCl.Location = new System.Drawing.Point(151, 10);
            this.btnFindCl.Name = "btnFindCl";
            this.btnFindCl.Size = new System.Drawing.Size(130, 47);
            this.btnFindCl.TabIndex = 13;
            this.btnFindCl.Text = "Gjej (CTRL F)";
            this.btnFindCl.UseVisualStyleBackColor = true;
            this.btnFindCl.Click += new System.EventHandler(this.btnFindCl_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnNew.Location = new System.Drawing.Point(14, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(131, 47);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "Krijo(Ctrl N)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnSave.Location = new System.Drawing.Point(367, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 47);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Ruaj (Enter)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnClose.Location = new System.Drawing.Point(639, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 47);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Mbyll";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Constantia", 10F);
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Location = new System.Drawing.Point(50, 161);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(81, 17);
            this.lblUsername.TabIndex = 57;
            this.lblUsername.Text = "Pseudonimi";
            // 
            // txtStaffUsername
            // 
            this.txtStaffUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffUsername.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtStaffUsername.Location = new System.Drawing.Point(53, 181);
            this.txtStaffUsername.MaxLength = 20;
            this.txtStaffUsername.Multiline = true;
            this.txtStaffUsername.Name = "txtStaffUsername";
            this.txtStaffUsername.Size = new System.Drawing.Size(293, 40);
            this.txtStaffUsername.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(309, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Administrimi Stafit";
            // 
            // txtStaffAdress
            // 
            this.txtStaffAdress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffAdress.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtStaffAdress.Location = new System.Drawing.Point(53, 245);
            this.txtStaffAdress.Multiline = true;
            this.txtStaffAdress.Name = "txtStaffAdress";
            this.txtStaffAdress.Size = new System.Drawing.Size(305, 40);
            this.txtStaffAdress.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 58);
            this.panel1.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Constantia", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(355, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 69;
            this.label2.Text = "Paswordi";
            // 
            // txtStaffPassword
            // 
            this.txtStaffPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffPassword.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtStaffPassword.Location = new System.Drawing.Point(352, 182);
            this.txtStaffPassword.MaxLength = 20;
            this.txtStaffPassword.Multiline = true;
            this.txtStaffPassword.Name = "txtStaffPassword";
            this.txtStaffPassword.Size = new System.Drawing.Size(205, 40);
            this.txtStaffPassword.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Constantia", 10F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(560, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 17);
            this.label11.TabIndex = 105;
            this.label11.Text = "Shkalla Administrimit";
            // 
            // cmbLevelAdmin
            // 
            this.cmbLevelAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLevelAdmin.Font = new System.Drawing.Font("Calibri", 14F);
            this.cmbLevelAdmin.FormattingEnabled = true;
            this.cmbLevelAdmin.Location = new System.Drawing.Point(563, 182);
            this.cmbLevelAdmin.Name = "cmbLevelAdmin";
            this.cmbLevelAdmin.Size = new System.Drawing.Size(187, 31);
            this.cmbLevelAdmin.TabIndex = 5;
            // 
            // frmStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 540);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbLevelAdmin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStaffPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStaffId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtStaffFullName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStaffEmail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtStaffPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStaffCountry);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStaffPCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStaffCity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtStaffUsername);
            this.Controls.Add(this.txtStaffAdress);
            this.Controls.Add(this.panel1);
            this.Name = "frmStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStaff";
            this.Load += new System.EventHandler(this.frmStaff_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStaffId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStaffFullName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStaffEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStaffPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStaffCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStaffPCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStaffCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFindCl;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtStaffUsername;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStaffAdress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStaffPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbLevelAdmin;
    }
}