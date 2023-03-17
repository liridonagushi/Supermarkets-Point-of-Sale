namespace Supermarkets
{
    partial class frmBalanceStockin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExpPDF = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblPayDate = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSumVat = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblImpAmount = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.btnBalanceSold = new System.Windows.Forms.Button();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.btnBrowse);
            this.panel3.Controls.Add(this.txtBarcode);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnInsert);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Location = new System.Drawing.Point(12, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(924, 66);
            this.panel3.TabIndex = 66;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.btnBrowse.Location = new System.Drawing.Point(467, 11);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(115, 47);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Gjej";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBarcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(124, 11);
            this.txtBarcode.Multiline = true;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(220, 45);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Kodi Fatures: ";
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.btnInsert.Location = new System.Drawing.Point(350, 11);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(115, 47);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Vendos";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.btnClear.Location = new System.Drawing.Point(588, 11);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 47);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Fshij";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 58);
            this.panel1.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(378, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(243, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Balanso Faturat e Importuara";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.btnClose.Location = new System.Drawing.Point(209, 485);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 34);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Mbyll";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnExpPDF);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.btnBalanceSold);
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Location = new System.Drawing.Point(942, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(330, 525);
            this.panel4.TabIndex = 68;
            // 
            // btnExpPDF
            // 
            this.btnExpPDF.BackColor = System.Drawing.Color.Transparent;
            this.btnExpPDF.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnExpPDF.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.btnExpPDF.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExpPDF.Location = new System.Drawing.Point(4, 236);
            this.btnExpPDF.Name = "btnExpPDF";
            this.btnExpPDF.Size = new System.Drawing.Size(319, 47);
            this.btnExpPDF.TabIndex = 5;
            this.btnExpPDF.Text = "Shkarko Faturen";
            this.btnExpPDF.UseVisualStyleBackColor = false;
            this.btnExpPDF.Click += new System.EventHandler(this.btnExpPDF_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.lblPayDate);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblSumVat);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.lblImpAmount);
            this.panel2.Controls.Add(this.lblQuantity);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.lblTotalCost);
            this.panel2.Location = new System.Drawing.Point(5, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 227);
            this.panel2.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Company Name";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(10, 77);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(105, 15);
            this.label21.TabIndex = 11;
            this.label21.Text = "Sasia Totale";
            // 
            // lblPayDate
            // 
            this.lblPayDate.AutoSize = true;
            this.lblPayDate.BackColor = System.Drawing.Color.Transparent;
            this.lblPayDate.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.lblPayDate.ForeColor = System.Drawing.Color.Black;
            this.lblPayDate.Location = new System.Drawing.Point(175, 42);
            this.lblPayDate.Name = "lblPayDate";
            this.lblPayDate.Size = new System.Drawing.Size(44, 15);
            this.lblPayDate.TabIndex = 19;
            this.lblPayDate.Text = "Date";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(10, 155);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 15);
            this.label18.TabIndex = 2;
            this.label18.Text = "Taksa Totale";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Data Fatures";
            // 
            // lblSumVat
            // 
            this.lblSumVat.AutoSize = true;
            this.lblSumVat.BackColor = System.Drawing.Color.Transparent;
            this.lblSumVat.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.lblSumVat.ForeColor = System.Drawing.Color.Black;
            this.lblSumVat.Location = new System.Drawing.Point(175, 155);
            this.lblSumVat.Name = "lblSumVat";
            this.lblSumVat.Size = new System.Drawing.Size(41, 15);
            this.lblSumVat.TabIndex = 8;
            this.lblSumVat.Text = "0.00";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(10, 117);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(123, 15);
            this.label22.TabIndex = 9;
            this.label22.Text = "Shuma Importit";
            // 
            // lblImpAmount
            // 
            this.lblImpAmount.AutoSize = true;
            this.lblImpAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblImpAmount.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.lblImpAmount.ForeColor = System.Drawing.Color.Black;
            this.lblImpAmount.Location = new System.Drawing.Point(175, 117);
            this.lblImpAmount.Name = "lblImpAmount";
            this.lblImpAmount.Size = new System.Drawing.Size(41, 15);
            this.lblImpAmount.TabIndex = 10;
            this.lblImpAmount.Text = "0.00";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.BackColor = System.Drawing.Color.Transparent;
            this.lblQuantity.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.lblQuantity.ForeColor = System.Drawing.Color.Black;
            this.lblQuantity.Location = new System.Drawing.Point(175, 77);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(41, 15);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "0.00";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(9, 189);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(153, 21);
            this.label24.TabIndex = 13;
            this.label24.Text = "Shuma Totale";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCost.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14F);
            this.lblTotalCost.ForeColor = System.Drawing.Color.Black;
            this.lblTotalCost.Location = new System.Drawing.Point(174, 189);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(58, 21);
            this.lblTotalCost.TabIndex = 14;
            this.lblTotalCost.Text = "0.00";
            // 
            // btnBalanceSold
            // 
            this.btnBalanceSold.BackColor = System.Drawing.Color.Transparent;
            this.btnBalanceSold.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnBalanceSold.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.btnBalanceSold.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBalanceSold.Location = new System.Drawing.Point(4, 289);
            this.btnBalanceSold.Name = "btnBalanceSold";
            this.btnBalanceSold.Size = new System.Drawing.Size(319, 47);
            this.btnBalanceSold.TabIndex = 6;
            this.btnBalanceSold.Text = "Balanso Faturen";
            this.btnBalanceSold.UseVisualStyleBackColor = false;
            this.btnBalanceSold.Click += new System.EventHandler(this.btnBalanceSold_Click);
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToResizeColumns = false;
            this.dgw.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8);
            this.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgw.BackgroundColor = System.Drawing.Color.Silver;
            this.dgw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgw.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4,
            this.Column12,
            this.Column13,
            this.Column8,
            this.Column14});
            this.dgw.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgw.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgw.EnableHeadersVisualStyles = false;
            this.dgw.Location = new System.Drawing.Point(12, 147);
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersVisible = false;
            this.dgw.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw.RowTemplate.Height = 30;
            this.dgw.Size = new System.Drawing.Size(924, 390);
            this.dgw.TabIndex = 83;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.FillWeight = 120F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Barkodi";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.FillWeight = 180F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Pershkrimi";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Sasia Import";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "Shuma Import";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Tax%";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Shuma Tax";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Cmimi Prod";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column14
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray;
            this.Column14.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column14.HeaderText = "Shuma Totale";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // frmBalanceStockin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1280, 546);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Name = "frmBalanceStockin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBalanceStockin";
            this.Load += new System.EventHandler(this.frmBalanceStockin_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblPayDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSumVat;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblImpAmount;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Button btnBalanceSold;
        private System.Windows.Forms.Button btnExpPDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
    }
}