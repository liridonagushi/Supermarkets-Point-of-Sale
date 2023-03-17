namespace Supermarkets
{
    partial class frmBuyOcassion
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProdDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDProd = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFindProd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSellPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBuyPrice = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Copperplate Gothic Light", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(210, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(334, 14);
            this.label4.TabIndex = 100;
            this.label4.Text = "Shfaqja e blerjeve te produkteve nga klientet";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnSave.Location = new System.Drawing.Point(409, 157);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 40);
            this.btnSave.TabIndex = 99;
            this.btnSave.Text = "Blej (Enter)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgw.ColumnHeadersHeight = 30;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column4,
            this.Column5,
            this.Column2});
            this.dgw.Location = new System.Drawing.Point(12, 229);
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersVisible = false;
            this.dgw.Size = new System.Drawing.Size(744, 226);
            this.dgw.TabIndex = 107;
            this.dgw.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Constantia", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(210, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 106;
            this.label3.Text = "Sasia e blerjes";
            // 
            // txtQty
            // 
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtQty.Location = new System.Drawing.Point(213, 163);
            this.txtQty.MaxLength = 5;
            this.txtQty.Multiline = true;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(190, 32);
            this.txtQty.TabIndex = 98;
            this.txtQty.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Constantia", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(236, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 105;
            this.label2.Text = "Pershkrimi";
            // 
            // txtProdDescription
            // 
            this.txtProdDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdDescription.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtProdDescription.Location = new System.Drawing.Point(239, 86);
            this.txtProdDescription.MaxLength = 20;
            this.txtProdDescription.Multiline = true;
            this.txtProdDescription.Name = "txtProdDescription";
            this.txtProdDescription.ReadOnly = true;
            this.txtProdDescription.Size = new System.Drawing.Size(377, 40);
            this.txtProdDescription.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Constantia", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 104;
            this.label1.Text = "ID";
            // 
            // txtIDProd
            // 
            this.txtIDProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDProd.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtIDProd.Location = new System.Drawing.Point(17, 86);
            this.txtIDProd.MaxLength = 10;
            this.txtIDProd.Multiline = true;
            this.txtIDProd.Name = "txtIDProd";
            this.txtIDProd.Size = new System.Drawing.Size(72, 40);
            this.txtIDProd.TabIndex = 95;
            this.txtIDProd.TextChanged += new System.EventHandler(this.txtIDProd_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Constantia", 10F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(92, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 17);
            this.label10.TabIndex = 103;
            this.label10.Text = "Kodi Produktit";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtBarcode.Location = new System.Drawing.Point(95, 86);
            this.txtBarcode.MaxLength = 20;
            this.txtBarcode.Multiline = true;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(138, 40);
            this.txtBarcode.TabIndex = 96;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btnFindProd);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(12, 466);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(747, 55);
            this.panel2.TabIndex = 102;
            // 
            // btnFindProd
            // 
            this.btnFindProd.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnFindProd.Location = new System.Drawing.Point(386, 5);
            this.btnFindProd.Name = "btnFindProd";
            this.btnFindProd.Size = new System.Drawing.Size(229, 47);
            this.btnFindProd.TabIndex = 6;
            this.btnFindProd.Text = "Gjej Produktin (CTRL F)";
            this.btnFindProd.UseVisualStyleBackColor = true;
            this.btnFindProd.Click += new System.EventHandler(this.btnFindProd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnClose.Location = new System.Drawing.Point(621, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 47);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Mbyll";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 45);
            this.panel1.TabIndex = 101;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(241, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(260, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Blerja e produkteve te perdorur";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Constantia", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(619, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 109;
            this.label5.Text = "Cmimi Shitjes";
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSellPrice.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtSellPrice.Location = new System.Drawing.Point(622, 86);
            this.txtSellPrice.MaxLength = 20;
            this.txtSellPrice.Multiline = true;
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.ReadOnly = true;
            this.txtSellPrice.Size = new System.Drawing.Size(131, 40);
            this.txtSellPrice.TabIndex = 108;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Constantia", 10F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(14, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 17);
            this.label6.TabIndex = 111;
            this.label6.Text = "Cmimi Blerjes / cop";
            // 
            // txtBuyPrice
            // 
            this.txtBuyPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuyPrice.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtBuyPrice.Location = new System.Drawing.Point(17, 163);
            this.txtBuyPrice.MaxLength = 8;
            this.txtBuyPrice.Multiline = true;
            this.txtBuyPrice.Name = "txtBuyPrice";
            this.txtBuyPrice.Size = new System.Drawing.Size(190, 32);
            this.txtBuyPrice.TabIndex = 110;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID Renditja";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Sasia";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Cmimi Blerjes";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Total";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Data";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // frmBuyOcassion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 528);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBuyPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSellPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProdDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIDProd);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmBuyOcassion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buy Occassion";
            this.Load += new System.EventHandler(this.frmBuyOcassion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProdDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDProd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFindProd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSellPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;

    }
}