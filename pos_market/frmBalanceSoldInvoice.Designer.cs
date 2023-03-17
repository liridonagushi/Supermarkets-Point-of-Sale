namespace Supermarkets
{
    partial class frmBalanceSoldInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExportSold = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnBalance = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblIdClient = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblSumVat = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDebtDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportSold
            // 
            this.btnExportSold.BackColor = System.Drawing.Color.Transparent;
            this.btnExportSold.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnExportSold.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.btnExportSold.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExportSold.Location = new System.Drawing.Point(5, 252);
            this.btnExportSold.Name = "btnExportSold";
            this.btnExportSold.Size = new System.Drawing.Size(319, 47);
            this.btnExportSold.TabIndex = 6;
            this.btnExportSold.Text = "Shkarko PDF";
            this.btnExportSold.UseVisualStyleBackColor = false;
            this.btnExportSold.Click += new System.EventHandler(this.btnExportSold_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.btnBrowse.Location = new System.Drawing.Point(479, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(115, 47);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Gjej";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBarcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(136, 8);
            this.txtBarcode.Multiline = true;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(220, 45);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.btnClose.Location = new System.Drawing.Point(209, 484);
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
            this.panel4.Controls.Add(this.btnBalance);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.btnExportSold);
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Location = new System.Drawing.Point(791, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(332, 525);
            this.panel4.TabIndex = 72;
            // 
            // btnBalance
            // 
            this.btnBalance.BackColor = System.Drawing.Color.Transparent;
            this.btnBalance.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnBalance.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.btnBalance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBalance.Location = new System.Drawing.Point(5, 199);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(319, 47);
            this.btnBalance.TabIndex = 5;
            this.btnBalance.Text = "Balanso Faturen";
            this.btnBalance.UseVisualStyleBackColor = false;
            this.btnBalance.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblEmployee);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblDebtDate);
            this.panel2.Controls.Add(this.lblFullName);
            this.panel2.Controls.Add(this.lblIdClient);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.lblSumVat);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.lblTotalAmount);
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 189);
            this.panel2.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Puntori";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.BackColor = System.Drawing.Color.Transparent;
            this.lblEmployee.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.lblEmployee.ForeColor = System.Drawing.Color.Black;
            this.lblEmployee.Location = new System.Drawing.Point(131, 13);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(17, 15);
            this.lblEmployee.TabIndex = 26;
            this.lblEmployee.Text = "0";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.lblFullName.ForeColor = System.Drawing.Color.Black;
            this.lblFullName.Location = new System.Drawing.Point(131, 36);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(17, 15);
            this.lblFullName.TabIndex = 22;
            this.lblFullName.Text = "0";
            // 
            // lblIdClient
            // 
            this.lblIdClient.AutoSize = true;
            this.lblIdClient.BackColor = System.Drawing.Color.Transparent;
            this.lblIdClient.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.lblIdClient.ForeColor = System.Drawing.Color.Black;
            this.lblIdClient.Location = new System.Drawing.Point(82, 36);
            this.lblIdClient.Name = "lblIdClient";
            this.lblIdClient.Size = new System.Drawing.Size(17, 15);
            this.lblIdClient.TabIndex = 21;
            this.lblIdClient.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Klienti";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(3, 121);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(117, 15);
            this.label18.TabIndex = 2;
            this.label18.Text = "Taksat Totale";
            // 
            // lblSumVat
            // 
            this.lblSumVat.AutoSize = true;
            this.lblSumVat.BackColor = System.Drawing.Color.Transparent;
            this.lblSumVat.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.lblSumVat.ForeColor = System.Drawing.Color.Black;
            this.lblSumVat.Location = new System.Drawing.Point(168, 121);
            this.lblSumVat.Name = "lblSumVat";
            this.lblSumVat.Size = new System.Drawing.Size(41, 15);
            this.lblSumVat.TabIndex = 8;
            this.lblSumVat.Text = "0.00";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(2, 155);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(153, 21);
            this.label24.TabIndex = 13;
            this.label24.Text = "Shuma Totale";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14F);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(167, 155);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(58, 21);
            this.lblTotalAmount.TabIndex = 14;
            this.lblTotalAmount.Text = "0.00";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.btnBrowse);
            this.panel3.Controls.Add(this.txtBarcode);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnInsert);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Location = new System.Drawing.Point(12, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(773, 66);
            this.panel3.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Kodi Fatures: ";
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.btnInsert.Location = new System.Drawing.Point(362, 8);
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
            this.btnClear.Location = new System.Drawing.Point(652, 9);
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
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 58);
            this.panel1.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(289, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(214, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Balanso Faturat e shitura";
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToResizeColumns = false;
            this.dgw.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(8);
            this.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
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
            this.Column13,
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
            this.dgw.Size = new System.Drawing.Size(773, 390);
            this.dgw.TabIndex = 84;
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
            this.dataGridViewTextBoxColumn5.HeaderText = "Sasia";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Shuma Tax";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Cmimi Shitjes";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // lblDebtDate
            // 
            this.lblDebtDate.AutoSize = true;
            this.lblDebtDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDebtDate.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.lblDebtDate.ForeColor = System.Drawing.Color.Black;
            this.lblDebtDate.Location = new System.Drawing.Point(168, 70);
            this.lblDebtDate.Name = "lblDebtDate";
            this.lblDebtDate.Size = new System.Drawing.Size(93, 15);
            this.lblDebtDate.TabIndex = 24;
            this.lblDebtDate.Text = "00-00-0000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Data Borxhit";
            // 
            // frmBalanceSoldInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1131, 542);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmBalanceSoldInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balance Sold Invoices";
            this.Load += new System.EventHandler(this.frmBalanceSoldInvoice_Load);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportSold;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblSumVat;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblIdClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDebtDate;
    }
}