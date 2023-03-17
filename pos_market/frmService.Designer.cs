namespace Supermarkets
{
    partial class frmService
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFindService = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNewService = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIDService = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIdClient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVatCost = new System.Windows.Forms.TextBox();
            this.btnSuccess = new System.Windows.Forms.Button();
            this.btnNotSuccess = new System.Windows.Forms.Button();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.Button();
            this.btnRemoveProd = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnFindCl = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStatusService = new System.Windows.Forms.Label();
            this.btnToService = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCostCurrency = new System.Windows.Forms.TextBox();
            this.txtVatCurrency = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPartsCost = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalCostCurrency = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.txtDescription2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btnFindService);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnNewService);
            this.panel2.Location = new System.Drawing.Point(8, 574);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 53);
            this.panel2.TabIndex = 124;
            // 
            // btnFindService
            // 
            this.btnFindService.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindService.Location = new System.Drawing.Point(216, 3);
            this.btnFindService.Name = "btnFindService";
            this.btnFindService.Size = new System.Drawing.Size(169, 47);
            this.btnFindService.TabIndex = 9;
            this.btnFindService.Text = "Gjej Servisin (CTRL F)";
            this.btnFindService.UseVisualStyleBackColor = true;
            this.btnFindService.Click += new System.EventHandler(this.btnFindService_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.btnPrint.Location = new System.Drawing.Point(525, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(136, 47);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Printo Detajet";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.btnClose.Location = new System.Drawing.Point(814, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 47);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Mbyll";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.btnDelete.Location = new System.Drawing.Point(667, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 47);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Fshij Servisin";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNewService
            // 
            this.btnNewService.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.btnNewService.Location = new System.Drawing.Point(9, 3);
            this.btnNewService.Name = "btnNewService";
            this.btnNewService.Size = new System.Drawing.Size(169, 47);
            this.btnNewService.TabIndex = 8;
            this.btnNewService.Text = "Servis i ri (CTRL N)";
            this.btnNewService.UseVisualStyleBackColor = true;
            this.btnNewService.Click += new System.EventHandler(this.btnNewService_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(384, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Servisimi i Produkteve";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 58);
            this.panel1.TabIndex = 113;
            // 
            // txtIDService
            // 
            this.txtIDService.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDService.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtIDService.Location = new System.Drawing.Point(17, 97);
            this.txtIDService.MaxLength = 20;
            this.txtIDService.Name = "txtIDService";
            this.txtIDService.Size = new System.Drawing.Size(93, 31);
            this.txtIDService.TabIndex = 1;
            this.txtIDService.TextChanged += new System.EventHandler(this.txtIDService_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Constantia", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 108;
            this.label4.Text = "Numri Servisit";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Constantia", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(572, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 110;
            this.label2.Text = "Kostoja Total :";
            // 
            // txtCost
            // 
            this.txtCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCost.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtCost.Location = new System.Drawing.Point(677, 363);
            this.txtCost.MaxLength = 8;
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(135, 31);
            this.txtCost.TabIndex = 6;
            this.txtCost.Text = "0.00";
            this.txtCost.TextChanged += new System.EventHandler(this.txtCost_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Constantia", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(591, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 112;
            this.label5.Text = "Detajet 1";
            // 
            // txtClient
            // 
            this.txtClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClient.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtClient.Location = new System.Drawing.Point(225, 97);
            this.txtClient.MaxLength = 50;
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(554, 31);
            this.txtClient.TabIndex = 116;
            this.txtClient.TextChanged += new System.EventHandler(this.txtClient_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Constantia", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(224, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 109;
            this.label1.Text = "Klienti";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Constantia", 10F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(113, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 127;
            this.label10.Text = "ID Klienti";
            // 
            // txtIdClient
            // 
            this.txtIdClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdClient.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtIdClient.Location = new System.Drawing.Point(116, 97);
            this.txtIdClient.MaxLength = 20;
            this.txtIdClient.Name = "txtIdClient";
            this.txtIdClient.ReadOnly = true;
            this.txtIdClient.Size = new System.Drawing.Size(103, 31);
            this.txtIdClient.TabIndex = 2;
            this.txtIdClient.TextChanged += new System.EventHandler(this.txtIdClient_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Constantia", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(674, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 130;
            this.label3.Text = "Euro";
            // 
            // txtVatCost
            // 
            this.txtVatCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVatCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVatCost.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtVatCost.Location = new System.Drawing.Point(677, 422);
            this.txtVatCost.MaxLength = 8;
            this.txtVatCost.Name = "txtVatCost";
            this.txtVatCost.ReadOnly = true;
            this.txtVatCost.Size = new System.Drawing.Size(134, 31);
            this.txtVatCost.TabIndex = 131;
            this.txtVatCost.Text = "0";
            // 
            // btnSuccess
            // 
            this.btnSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuccess.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.btnSuccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuccess.Font = new System.Drawing.Font("Corbel", 10F);
            this.btnSuccess.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSuccess.Location = new System.Drawing.Point(399, 444);
            this.btnSuccess.Name = "btnSuccess";
            this.btnSuccess.Size = new System.Drawing.Size(135, 39);
            this.btnSuccess.TabIndex = 13;
            this.btnSuccess.Text = "Servis me sukses !";
            this.btnSuccess.UseVisualStyleBackColor = true;
            this.btnSuccess.Click += new System.EventHandler(this.btnSuccess_Click);
            // 
            // btnNotSuccess
            // 
            this.btnNotSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotSuccess.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnNotSuccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotSuccess.Font = new System.Drawing.Font("Corbel", 10F);
            this.btnNotSuccess.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnNotSuccess.Location = new System.Drawing.Point(399, 402);
            this.btnNotSuccess.Name = "btnNotSuccess";
            this.btnNotSuccess.Size = new System.Drawing.Size(135, 39);
            this.btnNotSuccess.TabIndex = 14;
            this.btnNotSuccess.Text = "Servis pa sukses !";
            this.btnNotSuccess.UseVisualStyleBackColor = true;
            this.btnNotSuccess.Click += new System.EventHandler(this.btnNotSuccess_Click);
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToResizeColumns = false;
            this.dgw.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.Padding = new System.Windows.Forms.Padding(8);
            this.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgw.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.dgw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgw.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column3,
            this.Column5});
            this.dgw.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgw.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgw.EnableHeadersVisualStyles = false;
            this.dgw.Location = new System.Drawing.Point(17, 189);
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersVisible = false;
            this.dgw.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw.RowTemplate.Height = 30;
            this.dgw.Size = new System.Drawing.Size(376, 375);
            this.dgw.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 70F;
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Barkodi";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Emri Pjeses";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Sasia";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Cmimi";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindProduct.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnFindProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindProduct.Font = new System.Drawing.Font("Corbel", 10F);
            this.btnFindProduct.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnFindProduct.Location = new System.Drawing.Point(17, 155);
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Size = new System.Drawing.Size(376, 31);
            this.btnFindProduct.TabIndex = 134;
            this.btnFindProduct.Text = "Gjej Produktin";
            this.btnFindProduct.UseVisualStyleBackColor = true;
            this.btnFindProduct.Click += new System.EventHandler(this.btnFindProduct_Click);
            // 
            // btnRemoveProd
            // 
            this.btnRemoveProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveProd.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnRemoveProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveProd.Font = new System.Drawing.Font("Corbel", 9F);
            this.btnRemoveProd.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRemoveProd.Location = new System.Drawing.Point(399, 310);
            this.btnRemoveProd.Name = "btnRemoveProd";
            this.btnRemoveProd.Size = new System.Drawing.Size(98, 39);
            this.btnRemoveProd.TabIndex = 16;
            this.btnRemoveProd.Text = "Fshij Produktin";
            this.btnRemoveProd.UseVisualStyleBackColor = true;
            this.btnRemoveProd.Click += new System.EventHandler(this.btnRemoveProd_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlus.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnPlus.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnPlus.Location = new System.Drawing.Point(399, 222);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(56, 38);
            this.btnPlus.TabIndex = 18;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinus.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnMinus.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnMinus.Location = new System.Drawing.Point(399, 266);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(56, 38);
            this.btnMinus.TabIndex = 17;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnFindCl
            // 
            this.btnFindCl.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnFindCl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindCl.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindCl.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnFindCl.Location = new System.Drawing.Point(784, 97);
            this.btnFindCl.Name = "btnFindCl";
            this.btnFindCl.Size = new System.Drawing.Size(167, 31);
            this.btnFindCl.TabIndex = 19;
            this.btnFindCl.Text = "Gjej Klientin";
            this.btnFindCl.UseVisualStyleBackColor = true;
            this.btnFindCl.Click += new System.EventHandler(this.btnFindCl_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtBarcode.Location = new System.Drawing.Point(399, 156);
            this.txtBarcode.MaxLength = 20;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(56, 31);
            this.txtBarcode.TabIndex = 140;
            this.txtBarcode.Visible = false;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Constantia", 10F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(572, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 17);
            this.label6.TabIndex = 141;
            this.label6.Text = "Statusi Servisit:";
            // 
            // lblStatusService
            // 
            this.lblStatusService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusService.AutoSize = true;
            this.lblStatusService.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusService.Font = new System.Drawing.Font("Constantia", 10F);
            this.lblStatusService.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblStatusService.Location = new System.Drawing.Point(674, 294);
            this.lblStatusService.Name = "lblStatusService";
            this.lblStatusService.Size = new System.Drawing.Size(16, 17);
            this.lblStatusService.TabIndex = 142;
            this.lblStatusService.Text = "0";
            // 
            // btnToService
            // 
            this.btnToService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToService.BackColor = System.Drawing.Color.CadetBlue;
            this.btnToService.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnToService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToService.Font = new System.Drawing.Font("Corbel", 10F);
            this.btnToService.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnToService.Location = new System.Drawing.Point(399, 359);
            this.btnToService.Name = "btnToService";
            this.btnToService.Size = new System.Drawing.Size(135, 39);
            this.btnToService.TabIndex = 15;
            this.btnToService.Text = "Fillo Servisimin";
            this.btnToService.UseVisualStyleBackColor = false;
            this.btnToService.Click += new System.EventHandler(this.btnToService_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Constantia", 10F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(591, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 144;
            this.label9.Text = "Titulli";
            // 
            // txtHeader
            // 
            this.txtHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtHeader.Location = new System.Drawing.Point(591, 156);
            this.txtHeader.MaxLength = 30;
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(360, 31);
            this.txtHeader.TabIndex = 3;
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.Black;
            this.lblDateTime.Location = new System.Drawing.Point(672, 314);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(71, 15);
            this.lblDateTime.TabIndex = 146;
            this.lblDateTime.Text = "0000/00/00";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Constantia", 10F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(814, 402);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 17);
            this.label11.TabIndex = 148;
            this.label11.Text = "Dinar";
            // 
            // txtCostCurrency
            // 
            this.txtCostCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCostCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostCurrency.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtCostCurrency.Location = new System.Drawing.Point(817, 363);
            this.txtCostCurrency.MaxLength = 8;
            this.txtCostCurrency.Name = "txtCostCurrency";
            this.txtCostCurrency.Size = new System.Drawing.Size(135, 31);
            this.txtCostCurrency.TabIndex = 7;
            this.txtCostCurrency.Text = "0.00";
            this.txtCostCurrency.TextChanged += new System.EventHandler(this.txtCostCurrency_TextChanged);
            // 
            // txtVatCurrency
            // 
            this.txtVatCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVatCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVatCurrency.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtVatCurrency.Location = new System.Drawing.Point(817, 422);
            this.txtVatCurrency.MaxLength = 8;
            this.txtVatCurrency.Name = "txtVatCurrency";
            this.txtVatCurrency.ReadOnly = true;
            this.txtVatCurrency.Size = new System.Drawing.Size(134, 31);
            this.txtVatCurrency.TabIndex = 152;
            this.txtVatCurrency.Text = "0";
            this.txtVatCurrency.TextChanged += new System.EventHandler(this.txtVatCurrency_TextChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Constantia", 10F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(813, 343);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 17);
            this.label12.TabIndex = 153;
            this.label12.Text = "Dinar";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Corbel", 14F);
            this.txtDescription.Location = new System.Drawing.Point(591, 210);
            this.txtDescription.MaxLength = 30;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(360, 30);
            this.txtDescription.TabIndex = 4;
            // 
            // txtPartsCost
            // 
            this.txtPartsCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartsCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartsCost.Font = new System.Drawing.Font("Corbel", 14.25F);
            this.txtPartsCost.Location = new System.Drawing.Point(399, 530);
            this.txtPartsCost.MaxLength = 8;
            this.txtPartsCost.Multiline = true;
            this.txtPartsCost.Name = "txtPartsCost";
            this.txtPartsCost.ReadOnly = true;
            this.txtPartsCost.Size = new System.Drawing.Size(135, 38);
            this.txtPartsCost.TabIndex = 155;
            this.txtPartsCost.Text = "0.00";
            this.txtPartsCost.TextChanged += new System.EventHandler(this.txtPartsCost_TextChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Constantia", 10F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(399, 510);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 17);
            this.label13.TabIndex = 156;
            this.label13.Text = "Kosto Pjeseve";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Constantia", 10F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(814, 510);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 17);
            this.label14.TabIndex = 158;
            this.label14.Text = "Kosto Punes Din";
            // 
            // txtTotalCostCurrency
            // 
            this.txtTotalCostCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalCostCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCostCurrency.Font = new System.Drawing.Font("Constantia", 14F);
            this.txtTotalCostCurrency.Location = new System.Drawing.Point(817, 530);
            this.txtTotalCostCurrency.MaxLength = 8;
            this.txtTotalCostCurrency.Multiline = true;
            this.txtTotalCostCurrency.Name = "txtTotalCostCurrency";
            this.txtTotalCostCurrency.ReadOnly = true;
            this.txtTotalCostCurrency.Size = new System.Drawing.Size(134, 38);
            this.txtTotalCostCurrency.TabIndex = 157;
            this.txtTotalCostCurrency.Text = "0.00";
            this.txtTotalCostCurrency.TextChanged += new System.EventHandler(this.txtTotalCostCurrency_TextChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Constantia", 10F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(672, 510);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 17);
            this.label15.TabIndex = 160;
            this.label15.Text = "Kosto Punes Euro";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCost.Font = new System.Drawing.Font("Constantia", 14F);
            this.txtTotalCost.Location = new System.Drawing.Point(676, 530);
            this.txtTotalCost.MaxLength = 8;
            this.txtTotalCost.Multiline = true;
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(135, 38);
            this.txtTotalCost.TabIndex = 159;
            this.txtTotalCost.Text = "0.00";
            this.txtTotalCost.TextChanged += new System.EventHandler(this.txtTotalCost_TextChanged);
            // 
            // txtDescription2
            // 
            this.txtDescription2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription2.Font = new System.Drawing.Font("Corbel", 14F);
            this.txtDescription2.Location = new System.Drawing.Point(591, 261);
            this.txtDescription2.MaxLength = 30;
            this.txtDescription2.Name = "txtDescription2";
            this.txtDescription2.Size = new System.Drawing.Size(360, 30);
            this.txtDescription2.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Constantia", 10F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(588, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 161;
            this.label8.Text = "Detajet 2";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Constantia", 10F);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(674, 343);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 17);
            this.label16.TabIndex = 162;
            this.label16.Text = "Euro";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Constantia", 10F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(618, 424);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 17);
            this.label17.TabIndex = 163;
            this.label17.Text = "Taksa :";
            // 
            // frmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 634);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtDescription2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtTotalCost);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTotalCostCurrency);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPartsCost);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtVatCurrency);
            this.Controls.Add(this.txtCostCurrency);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtHeader);
            this.Controls.Add(this.btnToService);
            this.Controls.Add(this.lblStatusService);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.btnFindCl);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnRemoveProd);
            this.Controls.Add(this.btnFindProduct);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.btnNotSuccess);
            this.Controls.Add(this.btnSuccess);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVatCost);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtIdClient);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIDService);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtClient);
            this.MinimumSize = new System.Drawing.Size(988, 672);
            this.Name = "frmService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Services";
            this.Load += new System.EventHandler(this.frmService_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNewService;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIdClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVatCost;
        private System.Windows.Forms.Button btnSuccess;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnNotSuccess;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.Button btnFindProduct;
        private System.Windows.Forms.Button btnRemoveProd;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnFindCl;
        private System.Windows.Forms.Button btnFindService;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblStatusService;
        private System.Windows.Forms.Button btnToService;
        public System.Windows.Forms.TextBox txtIDService;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCostCurrency;
        private System.Windows.Forms.TextBox txtVatCurrency;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPartsCost;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalCostCurrency;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.TextBox txtDescription2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}