namespace Supermarkets
{
    partial class frmFindAttachment
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
            this.dgw = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearchAttachment = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgw.ColumnHeadersHeight = 30;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column2,
            this.Column1,
            this.Column4});
            this.dgw.Location = new System.Drawing.Point(12, 111);
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersVisible = false;
            this.dgw.Size = new System.Drawing.Size(484, 361);
            this.dgw.TabIndex = 3;
            this.dgw.TabStop = false;
            this.dgw.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellContentClick);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ID";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 70;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Emri Dok";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 210;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Emri Fajlit";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Data vendosjes";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(166, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Kerkimi i fajleve";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 58);
            this.panel1.TabIndex = 0;
            // 
            // txtSearchAttachment
            // 
            this.txtSearchAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchAttachment.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtSearchAttachment.Location = new System.Drawing.Point(12, 76);
            this.txtSearchAttachment.Name = "txtSearchAttachment";
            this.txtSearchAttachment.Size = new System.Drawing.Size(353, 31);
            this.txtSearchAttachment.TabIndex = 1;
            this.txtSearchAttachment.TextChanged += new System.EventHandler(this.txtSearchAttachment_TextChanged);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnClear.Location = new System.Drawing.Point(371, 76);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 29);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Fshij";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.button1.Location = new System.Drawing.Point(371, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Mbyll";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmFindAttachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 514);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSearchAttachment);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(524, 552);
            this.Name = "frmFindAttachment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Attachments";
            this.Load += new System.EventHandler(this.frmFindAttachment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtSearchAttachment;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}