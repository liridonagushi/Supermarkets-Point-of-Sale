namespace Supermarkets
{
    partial class frmUpdateProductPrice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFindProd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDProd = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProdDescription = new System.Windows.Forms.TextBox();
            this.txtSoldPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMajSoldPrice = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(334, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(242, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ndrysho Cmimet  e produkteve";
            // 
            // btnFindProd
            // 
            this.btnFindProd.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnFindProd.Location = new System.Drawing.Point(689, 5);
            this.btnFindProd.Name = "btnFindProd";
            this.btnFindProd.Size = new System.Drawing.Size(130, 47);
            this.btnFindProd.TabIndex = 6;
            this.btnFindProd.Text = "Gjej (CTRL F)";
            this.btnFindProd.UseVisualStyleBackColor = true;
            this.btnFindProd.Click += new System.EventHandler(this.btnFindProd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnSave.Location = new System.Drawing.Point(798, 94);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Ruaj (Enter)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnClose.Location = new System.Drawing.Point(825, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 47);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Mbyll";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Constantia", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 89;
            this.label1.Text = "ID";
            // 
            // txtIDProd
            // 
            this.txtIDProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDProd.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtIDProd.Location = new System.Drawing.Point(11, 94);
            this.txtIDProd.MaxLength = 10;
            this.txtIDProd.Multiline = true;
            this.txtIDProd.Name = "txtIDProd";
            this.txtIDProd.ReadOnly = true;
            this.txtIDProd.Size = new System.Drawing.Size(46, 40);
            this.txtIDProd.TabIndex = 1;
            this.txtIDProd.TextChanged += new System.EventHandler(this.txtProdID_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Constantia", 10F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(60, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 17);
            this.label10.TabIndex = 88;
            this.label10.Text = "Kodi Produktit";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtBarcode.Location = new System.Drawing.Point(63, 94);
            this.txtBarcode.MaxLength = 20;
            this.txtBarcode.Multiline = true;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(177, 40);
            this.txtBarcode.TabIndex = 2;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btnFindProd);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(12, 449);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(945, 55);
            this.panel2.TabIndex = 80;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 45);
            this.panel1.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Constantia", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(243, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 91;
            this.label2.Text = "Pershkrimi";
            // 
            // txtProdDescription
            // 
            this.txtProdDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdDescription.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtProdDescription.Location = new System.Drawing.Point(246, 94);
            this.txtProdDescription.MaxLength = 20;
            this.txtProdDescription.Multiline = true;
            this.txtProdDescription.Name = "txtProdDescription";
            this.txtProdDescription.ReadOnly = true;
            this.txtProdDescription.Size = new System.Drawing.Size(188, 40);
            this.txtProdDescription.TabIndex = 3;
            // 
            // txtSoldPrice
            // 
            this.txtSoldPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoldPrice.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtSoldPrice.Location = new System.Drawing.Point(440, 94);
            this.txtSoldPrice.MaxLength = 20;
            this.txtSoldPrice.Multiline = true;
            this.txtSoldPrice.Name = "txtSoldPrice";
            this.txtSoldPrice.Size = new System.Drawing.Size(173, 40);
            this.txtSoldPrice.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Constantia", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(437, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 93;
            this.label3.Text = "Cmimi Ri Pakic";
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw.ColumnHeadersHeight = 50;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5});
            this.dgw.Location = new System.Drawing.Point(12, 188);
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersVisible = false;
            this.dgw.Size = new System.Drawing.Size(943, 255);
            this.dgw.TabIndex = 94;
            this.dgw.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "ID Renditja";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Barkodi";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Pershkrimi";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 150F;
            this.Column4.HeaderText = "Cmimi Vjeter";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 150F;
            this.Column6.HeaderText = "Cmimi Ri";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 150F;
            this.Column5.HeaderText = "Data ndryshimit";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Copperplate Gothic Light", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(384, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "Shfaqja e modifikimeve";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Constantia", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(616, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 96;
            this.label5.Text = "Cmimi Ri Shumic";
            // 
            // txtMajSoldPrice
            // 
            this.txtMajSoldPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMajSoldPrice.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtMajSoldPrice.Location = new System.Drawing.Point(619, 94);
            this.txtMajSoldPrice.MaxLength = 20;
            this.txtMajSoldPrice.Multiline = true;
            this.txtMajSoldPrice.Name = "txtMajSoldPrice";
            this.txtMajSoldPrice.Size = new System.Drawing.Size(173, 40);
            this.txtMajSoldPrice.TabIndex = 95;
            // 
            // frmUpdateProductPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(962, 516);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMajSoldPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSoldPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProdDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIDProd);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(782, 504);
            this.Name = "frmUpdateProductPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Product";
            this.Load += new System.EventHandler(this.frmUpdateProductPrice_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFindProd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDProd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProdDescription;
        private System.Windows.Forms.TextBox txtSoldPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMajSoldPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}