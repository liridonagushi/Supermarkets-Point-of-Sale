namespace Supermarkets
{
    partial class frmPayment
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
            this.panel10 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtReturn = new System.Windows.Forms.TextBox();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.label15);
            this.panel10.Location = new System.Drawing.Point(8, 5);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(273, 31);
            this.panel10.TabIndex = 914;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(83, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 21);
            this.label15.TabIndex = 913;
            this.label15.Text = "Pagesat";
            // 
            // txtAmount
            // 
            this.txtAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F);
            this.txtAmount.Location = new System.Drawing.Point(8, 42);
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(273, 41);
            this.txtAmount.TabIndex = 911;
            this.txtAmount.Text = "0.00";
            // 
            // txtReturn
            // 
            this.txtReturn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtReturn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.txtReturn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReturn.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F);
            this.txtReturn.Location = new System.Drawing.Point(8, 89);
            this.txtReturn.Multiline = true;
            this.txtReturn.Name = "txtReturn";
            this.txtReturn.ReadOnly = true;
            this.txtReturn.Size = new System.Drawing.Size(273, 41);
            this.txtReturn.TabIndex = 912;
            this.txtReturn.Text = "0.00";
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPaymentAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.txtPaymentAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaymentAmount.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F);
            this.txtPaymentAmount.Location = new System.Drawing.Point(8, 136);
            this.txtPaymentAmount.Multiline = true;
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(273, 41);
            this.txtPaymentAmount.TabIndex = 1;
            this.txtPaymentAmount.Text = "0.00";
            this.txtPaymentAmount.TextChanged += new System.EventHandler(this.txtPaymentAmount_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Copperplate Gothic Light", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(172, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 41);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Anulo";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 230);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPaymentAmount);
            this.Controls.Add(this.txtReturn);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.panel10);
            this.Name = "frmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPayment";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtReturn;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtPaymentAmount;

    }
}