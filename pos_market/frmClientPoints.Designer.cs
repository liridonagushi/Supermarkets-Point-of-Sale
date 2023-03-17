namespace Supermarkets
{
    partial class frmClientPoints
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
            this.txtCLient = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalPoints = new System.Windows.Forms.TextBox();
            this.txtIdClient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAllClients = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Constantia", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(73, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 61;
            this.label1.Text = "Klienti";
            // 
            // txtCLient
            // 
            this.txtCLient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCLient.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F);
            this.txtCLient.Location = new System.Drawing.Point(76, 101);
            this.txtCLient.MaxLength = 10;
            this.txtCLient.Multiline = true;
            this.txtCLient.Name = "txtCLient";
            this.txtCLient.ReadOnly = true;
            this.txtCLient.Size = new System.Drawing.Size(303, 40);
            this.txtCLient.TabIndex = 60;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 58);
            this.panel1.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(126, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Pikat e klienteve";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnClose.Location = new System.Drawing.Point(155, 217);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 43);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Mbyll";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnSubmit.Location = new System.Drawing.Point(10, 217);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(139, 43);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Gjej Klientin";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Constantia", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 59;
            this.label2.Text = "Pikat Totale";
            // 
            // txtTotalPoints
            // 
            this.txtTotalPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalPoints.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtTotalPoints.Location = new System.Drawing.Point(10, 171);
            this.txtTotalPoints.MaxLength = 20;
            this.txtTotalPoints.Multiline = true;
            this.txtTotalPoints.Name = "txtTotalPoints";
            this.txtTotalPoints.ReadOnly = true;
            this.txtTotalPoints.Size = new System.Drawing.Size(369, 40);
            this.txtTotalPoints.TabIndex = 57;
            // 
            // txtIdClient
            // 
            this.txtIdClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdClient.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F);
            this.txtIdClient.Location = new System.Drawing.Point(10, 101);
            this.txtIdClient.MaxLength = 10;
            this.txtIdClient.Multiline = true;
            this.txtIdClient.Name = "txtIdClient";
            this.txtIdClient.ReadOnly = true;
            this.txtIdClient.Size = new System.Drawing.Size(60, 40);
            this.txtIdClient.TabIndex = 64;
            this.txtIdClient.TextChanged += new System.EventHandler(this.txtIdClient_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Constantia", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 65;
            this.label3.Text = "ID";
            // 
            // lblAllClients
            // 
            this.lblAllClients.AutoSize = true;
            this.lblAllClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAllClients.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllClients.Location = new System.Drawing.Point(266, 242);
            this.lblAllClients.Name = "lblAllClients";
            this.lblAllClients.Size = new System.Drawing.Size(126, 15);
            this.lblAllClients.TabIndex = 3;
            this.lblAllClients.Text = "Gjith Klientet / Piket ?";
            this.lblAllClients.Click += new System.EventHandler(this.label4_Click);
            // 
            // frmClientPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(391, 266);
            this.Controls.Add(this.lblAllClients);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCLient);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalPoints);
            this.MinimumSize = new System.Drawing.Size(407, 304);
            this.Name = "frmClientPoints";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Points";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCLient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtTotalPoints;
        public System.Windows.Forms.TextBox txtIdClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAllClients;


    }
}