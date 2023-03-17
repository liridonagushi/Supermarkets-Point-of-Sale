namespace Supermarkets
{
    partial class frmRemoveDebt
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
            this.lblClient = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClearDebtAmount = new System.Windows.Forms.TextBox();
            this.lblIdClient = new System.Windows.Forms.Label();
            this.txtIDCLient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDebtAmount = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.BackColor = System.Drawing.Color.Transparent;
            this.lblClient.Font = new System.Drawing.Font("Constantia", 10F);
            this.lblClient.ForeColor = System.Drawing.Color.Black;
            this.lblClient.Location = new System.Drawing.Point(99, 77);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(49, 17);
            this.lblClient.TabIndex = 61;
            this.lblClient.Text = "Klienti";
            // 
            // txtClientName
            // 
            this.txtClientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClientName.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F);
            this.txtClientName.Location = new System.Drawing.Point(101, 97);
            this.txtClientName.MaxLength = 10;
            this.txtClientName.Multiline = true;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.ReadOnly = true;
            this.txtClientName.Size = new System.Drawing.Size(204, 40);
            this.txtClientName.TabIndex = 60;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 58);
            this.panel1.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(64, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Borxhet e Klienteve";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnClose.Location = new System.Drawing.Point(209, 293);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 43);
            this.btnClose.TabIndex = 63;
            this.btnClose.Text = "Mbyll";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnSubmit.Location = new System.Drawing.Point(12, 293);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(136, 43);
            this.btnSubmit.TabIndex = 62;
            this.btnSubmit.Text = "Fshij Borxhin";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Constantia", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 59;
            this.label2.Text = "Fshij Sasin";
            // 
            // txtClearDebtAmount
            // 
            this.txtClearDebtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClearDebtAmount.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtClearDebtAmount.Location = new System.Drawing.Point(12, 237);
            this.txtClearDebtAmount.MaxLength = 20;
            this.txtClearDebtAmount.Multiline = true;
            this.txtClearDebtAmount.Name = "txtClearDebtAmount";
            this.txtClearDebtAmount.Size = new System.Drawing.Size(293, 40);
            this.txtClearDebtAmount.TabIndex = 57;
            this.txtClearDebtAmount.TextChanged += new System.EventHandler(this.txtClearDebtAmount_TextChanged);
            // 
            // lblIdClient
            // 
            this.lblIdClient.AutoSize = true;
            this.lblIdClient.BackColor = System.Drawing.Color.Transparent;
            this.lblIdClient.Font = new System.Drawing.Font("Constantia", 10F);
            this.lblIdClient.ForeColor = System.Drawing.Color.Black;
            this.lblIdClient.Location = new System.Drawing.Point(11, 77);
            this.lblIdClient.Name = "lblIdClient";
            this.lblIdClient.Size = new System.Drawing.Size(24, 17);
            this.lblIdClient.TabIndex = 65;
            this.lblIdClient.Text = "ID";
            // 
            // txtIDCLient
            // 
            this.txtIDCLient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDCLient.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F);
            this.txtIDCLient.Location = new System.Drawing.Point(17, 97);
            this.txtIDCLient.MaxLength = 10;
            this.txtIDCLient.Multiline = true;
            this.txtIDCLient.Name = "txtIDCLient";
            this.txtIDCLient.ReadOnly = true;
            this.txtIDCLient.Size = new System.Drawing.Size(82, 40);
            this.txtIDCLient.TabIndex = 64;
            this.txtIDCLient.TextChanged += new System.EventHandler(this.txtIDCLient_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Constantia", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 67;
            this.label1.Text = "Vlera Borxhit";
            // 
            // txtDebtAmount
            // 
            this.txtDebtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDebtAmount.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F);
            this.txtDebtAmount.Location = new System.Drawing.Point(12, 169);
            this.txtDebtAmount.MaxLength = 10;
            this.txtDebtAmount.Multiline = true;
            this.txtDebtAmount.Name = "txtDebtAmount";
            this.txtDebtAmount.ReadOnly = true;
            this.txtDebtAmount.Size = new System.Drawing.Size(293, 40);
            this.txtDebtAmount.TabIndex = 66;
            this.txtDebtAmount.TextChanged += new System.EventHandler(this.txtDebtAmount_TextChanged);
            // 
            // frmRemoveDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(316, 348);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDebtAmount);
            this.Controls.Add(this.lblIdClient);
            this.Controls.Add(this.txtIDCLient);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClearDebtAmount);
            this.MaximumSize = new System.Drawing.Size(332, 386);
            this.MinimumSize = new System.Drawing.Size(332, 386);
            this.Name = "frmRemoveDebt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRemoveDebt";
            this.Load += new System.EventHandler(this.frmRemoveDebt_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClient;
        public System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtClearDebtAmount;
        private System.Windows.Forms.Label lblIdClient;
        public System.Windows.Forms.TextBox txtIDCLient;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtDebtAmount;
    }
}