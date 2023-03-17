namespace Supermarkets
{
    partial class frmProducts
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
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoldPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtIDProd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProdDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCreateBarcode = new System.Windows.Forms.Button();
            this.cmbTaxValues = new System.Windows.Forms.ComboBox();
            this.cmbTypeProd = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPriceCurrency = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtQtyBarcode = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtBarcode.Location = new System.Drawing.Point(97, 102);
            this.txtBarcode.MaxLength = 20;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(379, 31);
            this.txtBarcode.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 58);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(295, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Administrimi Produkteve";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Constantia", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(97, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kodi Barkodit";
            // 
            // txtSoldPrice
            // 
            this.txtSoldPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoldPrice.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtSoldPrice.Location = new System.Drawing.Point(10, 299);
            this.txtSoldPrice.MaxLength = 8;
            this.txtSoldPrice.Name = "txtSoldPrice";
            this.txtSoldPrice.Size = new System.Drawing.Size(203, 31);
            this.txtSoldPrice.TabIndex = 10;
            this.txtSoldPrice.Text = "0";
            this.txtSoldPrice.TextChanged += new System.EventHandler(this.txtSoldPrice_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Constantia", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cmimi Shitjes Pakic";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Constantia", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sasia e gatshme";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnClose.Location = new System.Drawing.Point(649, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 47);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Mbyll";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnSave.Location = new System.Drawing.Point(390, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 47);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Ruaj (CTRL S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnNew.Location = new System.Drawing.Point(6, 8);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(155, 47);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "Produkt i ri (CTRL N)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnFind.Location = new System.Drawing.Point(165, 8);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(126, 47);
            this.btnFind.TabIndex = 16;
            this.btnFind.Text = "Gjej (CTRL F)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnDelete.Location = new System.Drawing.Point(528, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 47);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Fshij (Del)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtIDProd
            // 
            this.txtIDProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDProd.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtIDProd.Location = new System.Drawing.Point(10, 102);
            this.txtIDProd.MaxLength = 20;
            this.txtIDProd.Name = "txtIDProd";
            this.txtIDProd.Size = new System.Drawing.Size(81, 31);
            this.txtIDProd.TabIndex = 1;
            this.txtIDProd.TextChanged += new System.EventHandler(this.txtIDProd_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Constantia", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Constantia", 10F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(7, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Perqindja Tax";
            // 
            // txtProdDescription
            // 
            this.txtProdDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdDescription.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtProdDescription.Location = new System.Drawing.Point(10, 165);
            this.txtProdDescription.MaxLength = 80;
            this.txtProdDescription.Name = "txtProdDescription";
            this.txtProdDescription.Size = new System.Drawing.Size(773, 31);
            this.txtProdDescription.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Constantia", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Pershkrimi Produktit";
            // 
            // btnCreateBarcode
            // 
            this.btnCreateBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCreateBarcode.Location = new System.Drawing.Point(478, 102);
            this.btnCreateBarcode.Name = "btnCreateBarcode";
            this.btnCreateBarcode.Size = new System.Drawing.Size(135, 31);
            this.btnCreateBarcode.TabIndex = 20;
            this.btnCreateBarcode.Text = "Printo Barkodin";
            this.btnCreateBarcode.UseVisualStyleBackColor = true;
            this.btnCreateBarcode.Click += new System.EventHandler(this.btnCreateBarcode_Click);
            // 
            // cmbTaxValues
            // 
            this.cmbTaxValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTaxValues.Font = new System.Drawing.Font("Calibri", 14F);
            this.cmbTaxValues.FormattingEnabled = true;
            this.cmbTaxValues.Location = new System.Drawing.Point(10, 225);
            this.cmbTaxValues.Name = "cmbTaxValues";
            this.cmbTaxValues.Size = new System.Drawing.Size(199, 31);
            this.cmbTaxValues.TabIndex = 5;
            this.cmbTaxValues.SelectedIndexChanged += new System.EventHandler(this.cmbTaxValues_SelectedIndexChanged);
            // 
            // cmbTypeProd
            // 
            this.cmbTypeProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTypeProd.Font = new System.Drawing.Font("Calibri", 14F);
            this.cmbTypeProd.FormattingEnabled = true;
            this.cmbTypeProd.Location = new System.Drawing.Point(222, 225);
            this.cmbTypeProd.Name = "cmbTypeProd";
            this.cmbTypeProd.Size = new System.Drawing.Size(188, 31);
            this.cmbTypeProd.TabIndex = 6;
            this.cmbTypeProd.SelectedIndexChanged += new System.EventHandler(this.cmbTypeProd_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Constantia", 10F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(219, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 104;
            this.label8.Text = "Tipi Produktit";
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtQuantity.Location = new System.Drawing.Point(10, 362);
            this.txtQuantity.MaxLength = 12;
            this.txtQuantity.Multiline = true;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(184, 43);
            this.txtQuantity.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(10, 420);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 66);
            this.panel2.TabIndex = 105;
            // 
            // cmbCategories
            // 
            this.cmbCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategories.Font = new System.Drawing.Font("Calibri", 14F);
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(434, 225);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(195, 31);
            this.cmbCategories.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Constantia", 10F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(431, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 107;
            this.label9.Text = "Kategoria";
            // 
            // txtPriceCurrency
            // 
            this.txtPriceCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPriceCurrency.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtPriceCurrency.Location = new System.Drawing.Point(222, 299);
            this.txtPriceCurrency.MaxLength = 10;
            this.txtPriceCurrency.Name = "txtPriceCurrency";
            this.txtPriceCurrency.Size = new System.Drawing.Size(203, 31);
            this.txtPriceCurrency.TabIndex = 12;
            this.txtPriceCurrency.Text = "0";
            this.txtPriceCurrency.TextChanged += new System.EventHandler(this.txtPriceCurrency_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Constantia", 10F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(219, 279);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 17);
            this.label11.TabIndex = 112;
            this.label11.Text = "Cmimi Shitjes Deviz";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Constantia", 10F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(705, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 114;
            this.label13.Text = "x Kopje";
            // 
            // txtQtyBarcode
            // 
            this.txtQtyBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyBarcode.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtQtyBarcode.Location = new System.Drawing.Point(618, 102);
            this.txtQtyBarcode.MaxLength = 20;
            this.txtQtyBarcode.Name = "txtQtyBarcode";
            this.txtQtyBarcode.Size = new System.Drawing.Size(81, 31);
            this.txtQtyBarcode.TabIndex = 3;
            this.txtQtyBarcode.Text = "1";
            this.txtQtyBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Constantia", 10F);
            this.chkActive.Location = new System.Drawing.Point(434, 305);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(112, 21);
            this.chkActive.TabIndex = 115;
            this.chkActive.Text = "Produkt Aktiv";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(793, 493);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtQtyBarcode);
            this.Controls.Add(this.txtPriceCurrency);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.cmbTypeProd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbTaxValues);
            this.Controls.Add(this.btnCreateBarcode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIDProd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProdDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoldPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBarcode);
            this.MinimumSize = new System.Drawing.Size(807, 450);
            this.Name = "frmProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products";
            this.Load += new System.EventHandler(this.frmProducts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoldPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtIDProd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProdDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCreateBarcode;
        private System.Windows.Forms.ComboBox cmbTaxValues;
        private System.Windows.Forms.ComboBox cmbTypeProd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPriceCurrency;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtQtyBarcode;
        private System.Windows.Forms.CheckBox chkActive;
    }
}