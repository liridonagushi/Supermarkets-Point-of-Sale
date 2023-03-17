using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    public partial class ImportInvoice : Form
    {
        public static string sFormIndex, UpdBenefit;
        private static String id_distributor, randomNumber, id_type_payment, dgw_invoicecode, dgwProductCode, dgwNewProductPrice, oldPrice, searchValue;
        private static Boolean CheckInvoiceExist, totalGotFocus, unityImportGotFocus, productPriceChange;
        private String dateToday = DateTime.Today.ToString("yyyy-MM-dd");

        private static int id_product;
        // private static int updatingRow;
        private static Boolean rowExists, qty_changed;
        private static Decimal impPrice, lbltotal_sales, lbltotal_import;

        //Company Info
        private static String DBCompanyName, DBManager, DBContactNumber, DBAdress, DBCity, DBCountry, infoCurrency;

        //Distributor Info
        private static String DistCompanyName, DistManager, DistContactNumber, DistAdress, DistCity, DistCountry;

        //Datagridview
        // private static int current_order;
        private static int id_order, current_number, previous_number, next_number;

        public static String UpdQty, UpdSoldAmount, UpdFree, UpdVatAmount, UpdSoldMajPrice, UpdImpSum;

        //Datagridview
        private static String dgwBarcode;
        private static Decimal dgwImportAmount, dgwQtyIns, dgwSellPrice, dgwFreeQty, dgwVatAmount, dgwImported_amount;
        private static Decimal dgwImportAmount_edit, dgwQtyIns_edit, dgwSellPrice_edit, dgwFreeQty_edit, dgwVatAmount_edit, dgwVatPerc_edit;

        Decimal RoundUp(Decimal toRound)
        {
            return (10 - toRound % 10) + toRound;
        }

        public ImportInvoice()
        {
            InitializeComponent();
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.F))
            {
                btnFindProducts.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.N))
            {
                btnNewDocument.PerformClick();
                return true;
            }

            if (keyData == Keys.PageDown)
            {
                btnInsert.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                btnFinish.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.O))
            {
                btnFindDist.PerformClick();
                return true;
            }

            if (keyData == (Keys.F2))
            {
                btnFinish.PerformClick();
                return true;
            }

            if (dgw.Focused != true && keyData == Keys.Down)
            {
                // Check if down key is pressed
                dgw.Focus();
                // Display selected cell's value
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Returning result values
        public string FindDistributorID
        {
            get { return id_distributor; }
            set { id_distributor = value; }
        }

        public string FindDistributorCompany
        {
            get { return txtDistributerCompany.Text; }
            set { txtDistributerCompany.Text = value; }
        }

        // Returning result values
        public string FindProduct
        {
            get { return txtBarcode.Text; }
            set { txtBarcode.Text = value; }
        }

        //Updating frmUpdateInvoiceProducts
        // Returning result values
        public string UpdProductCode
        {
            get { return txtUpdProd.Text; }
            set { txtUpdProd.Text = value; }
        }

        // Returning result values
        public String UpdQuantityImport
        {
            get { return UpdQty; }
            set { UpdQty = value; }
        }

        // Returning result values
        public String UpdFreeProducts
        {
            get { return UpdFree; }
            set { UpdFree = value; }
        }

        // Returning result values
        public String UpdProductSoldMajPrice
        {
            get { return UpdSoldMajPrice; }
            set { UpdSoldMajPrice = value; }
        }
        
        // Returning result values
        public String UpdImportPrice
        {
            get { return UpdImpSum; }
            set { UpdImpSum = value; }
        }
        
        // Returning result values
        public String UpdSoldPrice
        {
            get { return UpdSoldAmount; }
            set { UpdSoldAmount = value; }
        }

        // Returning result values
        public String UpdSoldVatAmount
        {
            get { return UpdVatAmount; }
            set { UpdVatAmount = value; }
        }

        private void FindingProduct()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.barcode, products.description, products.quantity, taxes.vat_perc, products.import_price, products.sold_price, products.total_import_amount, products.imported_qty, products.margin_perc, products.tax_amount FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.barcode='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                    
                if (dr.Read())
                    {
                        Decimal QuantityAv = dr.IsDBNull(3) ? 0 : dr.GetDecimal(3);
                        Decimal VatPercExport = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                        impPrice = dr.IsDBNull(5) ? 0 : dr.GetDecimal(5);
                        Decimal SellPrice = dr.IsDBNull(6) ? 0 : dr.GetDecimal(6);
                        Decimal TotalWithReduction = dr.IsDBNull(7) ? 0 : dr.GetDecimal(7);
                        Decimal importedQty = dr.IsDBNull(8) ? 0 : dr.GetDecimal(8);
                        Decimal margin_perc = dr.IsDBNull(9) ? 0 : dr.GetDecimal(9);
                        Decimal vatAmount = dr.IsDBNull(10) ? 0 : dr.GetDecimal(10);

                        txtBarcode.Text = dr.GetString(1);
                        txtQuantityAv.Text = QuantityAv.ToString();
                        lblVatPercExport.Text = VatPercExport.ToString();
                        txtImportPrice.Text = impPrice.ToString();
                        txtSellPrice.Text = SellPrice.ToString();
                        txtTotalWithReduction.Text = TotalWithReduction.ToString();
                        txtQty.Text = importedQty.ToString();
                        txtMargin.Text = margin_perc.ToString();
                        txtVatSell.Text = vatAmount.ToString();
                    }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillingCombobox()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_type_payment, type_payment FROM type_payments", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        cmbMethodPayment.Items.Add(dr.GetString(0) + " " + dr.GetString(1));
                    }
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
           

        private void CheckInvoiceNumber()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_invoice, invoice_code FROM imp_invoices WHERE invoice_code='" + txtInvoiceCode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    CheckInvoiceExist = true;
                }
                else {
                    CheckInvoiceExist = false;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFindDist_Click(object sender, EventArgs e)
        {
            frmFindDistributor.sFormIndex = "ImportInvoice";
            frmFindDistributor frm = new frmFindDistributor(this);
            frm.ShowDialog();
        }

        private void btnNewDist_Click(object sender, EventArgs e)
        {
            frmDistributors frm = new frmDistributors();
            frm.ShowDialog();
        }

        private void DeleteInvoiceDocument(){
            try
            {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            MySqlCommand cmdDatabase1 = new MySqlCommand("DELETE FROM invoiceprocessing WHERE InvoiceCode='" + txtInvoiceCode.Text + "'", conn);

            MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM imp_invoices WHERE invoice_code='" + txtInvoiceCode.Text + "'", conn);

            int n = cmdDatabase1.ExecuteNonQuery();
            int i = cmdDatabase.ExecuteNonQuery();

            if ((i > 0) && (n > 0))
            {
              MessageBox.Show("Dokumenti ekzistues u fshi me sukses !","Deleted Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
             conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            CheckInvoiceNumber();
            if (txtInvoiceCode.Text == "")
            {
              MessageBox.Show("Numri fatures nuk mundet te jet i zbrazet !", "Fill textboxes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }else if (CheckInvoiceExist == true){
                DialogResult dialogResult = MessageBox.Show("This Invoice Document is already completed, are you sure to open the existing invoice !", "Invoice Exists !", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteInvoiceDocument();
                }
                else
                {
                    MessageBox.Show("Ky numer i fatures ekziston ende !", "Existing Doc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Mundeni te perdorni kete numer te fatures !", "Invoice Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFindProducts_Click(object sender, EventArgs e)
        {
            frmFindProduct.sFormIndex = "frmInvoice";
            frmFindProduct fProd = new frmFindProduct(this);
            fProd.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void txtMargin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrintPrice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shkrujem Besi qe ta kry qiket funksion");
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shkrujem Besi qe ta kry qiket funksion");
        }

        private void btnNewProd_Click(object sender, EventArgs e)
        {
            frmProducts nProd = new frmProducts();
            nProd.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            KeyboardHelp keyHelp = new KeyboardHelp();
            keyHelp.Show();
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            FindingProduct();
        }

        private void txtDistributerCompany_TextChanged(object sender, EventArgs e)
        {
            getDistributorDetails();
            txtInvoiceCode.Focus();
        }

        internal void ImportInvoice_Load(object sender, EventArgs e)
        {
            getCompanyDetails();
            FillingCombobox();

            this.cmbMethodPayment.DropDownStyle = ComboBoxStyle.DropDownList;
            getSuggestCode();
            //Datagrid
            dgw.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgw.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtBarcode.Focus();

            DateTime dbDate1 = Convert.ToDateTime(dateToday);

            var firstDate = dbDate1.ToString("yyyy-MM-dd");
            var secondDate = dbDate1.AddDays(+10).ToString("yyyy-MM-dd");
            dtInvoice.Text = firstDate;
            dtPayment.Text = secondDate;
            lblCompName.Text = DBCompanyName;
        }

        private void txtSellPrice_MouseClick(object sender, EventArgs e)
        {
            txtSellPrice.SelectAll();
        }
        private void txtSellPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal ImportPrice = 0;
                Decimal TaxPerc = 0;
                Decimal SellPrice = 0;
                Decimal VatAmount = 0;
                Decimal Qty = 0;
                Decimal BenefitSum = 0;

                Decimal.TryParse(txtQty.Text, out Qty);
                Decimal.TryParse(txtImportPrice.Text, out ImportPrice);
                Decimal.TryParse(lblVatPercExport.Text, out TaxPerc);
                Decimal.TryParse(txtBenefitSum.Text, out BenefitSum);
                Decimal.TryParse(txtSellPrice.Text, out SellPrice);
                if (SellPrice < 0) { MessageBox.Show("Vlerat ne minus nuk pranohen", "Error Amount", MessageBoxButtons.OK, MessageBoxIcon.Error); txtSellPrice.Text = "0"; }
                else
                { 
                        if ((txtSellPrice.Focused) || (totalGotFocus==true))
                        {
                            if (TaxPerc > 0)
                            {
                                Decimal net_amount = SellPrice / (1 + (TaxPerc / 100));
                                VatAmount = Math.Round(SellPrice - net_amount, 2);
                                txtVatSell.Text = VatAmount.ToString();
                            }
                            else
                            {
                                VatAmount = 0;
                                txtVatSell.Text = "0";
                            }
                            
                            if (ImportPrice > 0)
                            {
                                BenefitSum = SellPrice - ImportPrice;
                                txtBenefitSum.Text = Math.Round(BenefitSum, 2).ToString();
                                txtMargin.Text = Math.Round((((SellPrice - ImportPrice) / ImportPrice) * 100), 2).ToString();
                            }
                        }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Sold price", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtImportPrice_Click(object sender, EventArgs e)
        {
            txtImportPrice.SelectAll();
        }

        private void txtImportPrice_TextChanged(object sender, EventArgs e)
        {
                    unityImportGotFocus = false;
                 if (txtImportPrice.Focused == true) 
                    {
                        unityImportGotFocus = true;
                    }

                try
                {
                    Decimal ImportPrice = 0;
                    Decimal TaxPerc = 0;
                    Decimal VatAmount = 0;
                    Decimal SellPrice = 0;
                    Decimal Qty = 0;
                    Decimal benefitSum = 0;
                    Decimal TotalWithReduction = 0;

                    Decimal.TryParse(txtQty.Text, out Qty);
                    Decimal.TryParse(lblVatPercExport.Text, out TaxPerc);
                    Decimal.TryParse(txtSellPrice.Text, out SellPrice);
                    Decimal.TryParse(txtBenefitSum.Text, out benefitSum);
                    Decimal.TryParse(txtImportPrice.Text, out ImportPrice);
                    Decimal.TryParse(txtTotalWithReduction.Text, out TotalWithReduction);
                    Decimal.TryParse(txtVatSell.Text, out VatAmount);

                    if (ImportPrice < 0) { MessageBox.Show("Vlerat ne minus nuk pranohen", "Error Amount", MessageBoxButtons.OK, MessageBoxIcon.Error); txtImportPrice.ResetText(); }
                    else
                    {
                        benefitSum = SellPrice - ImportPrice;

                    if (unityImportGotFocus == true){

                        if (SellPrice > 0 && ImportPrice > 0)
                                {
                                    txtBenefitSum.Text = Math.Round(benefitSum, 2).ToString();
                                }

                                TotalWithReduction = ImportPrice * Qty;

                                txtTotalWithReduction.Text = TotalWithReduction.ToString();

                                txtMargin.Text = Math.Round((((SellPrice - ImportPrice) / ImportPrice) * 100),2).ToString();
                            }
                            else if (totalGotFocus == true){
                            {
                                if ((SellPrice > 0) && (ImportPrice > 0))
                                {
                                    txtBenefitSum.Text = Math.Round(benefitSum, 2).ToString();
                                }
                                txtMargin.Text = Math.Round((((SellPrice - ImportPrice) / ImportPrice) * 100), 2).ToString();
                            }
                        unityImportGotFocus = false;
                        totalGotFocus = false;
                    }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtImportPrice_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }


        private void txtMinusReduction_TextChanged(object sender, EventArgs e)
        {

        }


        private void SearchExist()
        {
            //int rowIndex = -1;
            foreach (DataGridViewRow row in dgw.Rows)
            {
                //if (row.Cells[1].Value == searchValue)
                
                if (row.Cells[1].Value.ToString().Equals(searchValue))
                {
                   // updatingRow = Convert.ToInt32(row.Cells[0].Value) - 1;
                    rowExists = true;
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            rowExists = false;
            searchValue = txtBarcode.Text.ToString();
            SearchExist();

            Decimal marg_perc = 0;

            Decimal.TryParse(txtMargin.Text, out marg_perc);

            if (string.IsNullOrWhiteSpace(txtBarcode.Text) || string.IsNullOrWhiteSpace(txtImportPrice.Text) || string.IsNullOrWhiteSpace(txtSellPrice.Text) || string.IsNullOrWhiteSpace(txtQty.Text) || string.IsNullOrWhiteSpace(txtTotalWithReduction.Text))
            {
                MessageBox.Show("Mbushni te gjitha fushat e zbrazta per te vazhduar !", "Error empty boxes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (marg_perc <=0)
            {
                MessageBox.Show("Përqindja marginës duhet të jetë më e madhe se zero !", "Error Margin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(rowExists==true)
            {
                MessageBox.Show("Produkti veqse ekziston ne liste !", "Error duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.barcode, products.description, type_products.type_product, taxes.vat_perc, products.quantity, products.import_price, products.sold_price FROM products LEFT JOIN type_products ON products.id_type=type_products.id_type LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.barcode='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        Decimal SellPrice = 0;
                        Decimal VatSell = 0;
                        Decimal QtyStocking = 0;
                        Decimal TotalWithReduction = 0;
                        Decimal ImportPrice = 0;
                        Decimal FreeQty = 0;
                        Decimal ImportCost = 0;
                        Decimal TotalCost = 0;
                        Decimal taxPerc = 0;

                        //Import Price
                        Decimal.TryParse(dr.GetString(4), out taxPerc);

                        //Import Price
                        Decimal.TryParse(txtImportPrice.Text, out ImportPrice);

                        //Sell prices
                        Decimal.TryParse(txtSellPrice.Text, out SellPrice);
                        Decimal.TryParse(txtVatSell.Text, out VatSell);
                        
                        //Qty Insert
                        Decimal.TryParse(txtQty.Text, out QtyStocking);
                        Decimal.TryParse(txtFreeQty.Text, out FreeQty);

                        //Majority Insert
                        Decimal.TryParse(txtTotalWithReduction.Text, out TotalWithReduction);

                        //Bottom Sums
                        Decimal.TryParse(lblImportCost.Text, out ImportCost);
                        Decimal.TryParse(lblTotalCost.Text, out TotalCost);
                        Decimal.TryParse(txtMargin.Text, out marg_perc);

                        Decimal totalSum = Math.Round(SellPrice * QtyStocking, 3);

                        TotalCost += totalSum;
                        lblTotalCost.Text = TotalCost.ToString();

                        ImportCost += TotalWithReduction;
                        lblImportCost.Text = ImportCost.ToString();

                        
                        for(int i = 0; i <= dgw.Rows.Count; i++)
                        {
                            if (i == dgw.Rows.Count)
                            {
                                id_order = i + 1;
                            }
                        }

                        dgw.Rows.Add(id_order, dr[1], dr[2], dr[3], taxPerc, dr[5], FreeQty, VatSell, SellPrice, marg_perc, QtyStocking, TotalWithReduction, totalSum);

                        txtBarcode.Clear();
                        txtQty.Text = "1";
                        txtFreeQty.Text = "0";
                        txtImportPrice.ResetText();
                        txtMargin.ResetText();
                        txtSellPrice.ResetText();
                        txtQuantityAv.ResetText();
                        lblVatPercExport.ResetText();
                        txtTotalWithReduction.ResetText();
                        txtQuantityAv.ResetText();
                        txtVatSell.ResetText();
                        txtBenefitSum.ResetText();
                        txtBarcode.Focus();
                    }
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
        }

        private void getProductID()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_product, barcode FROM products WHERE barcode='" + dgw_invoicecode + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                    if (dr.Read()==true)
                    {
                        id_product = dr.GetInt32(0);
                    }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getSuggestCode()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_product, barcode FROM products", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

                if (dr.HasRows == true)
                {
                    while (dr.Read()==true)
                    {
                        MyCollection.Add(dr.GetString(1));
                    }

                   txtBarcode.AutoCompleteCustomSource = MyCollection;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

           private void CreateInvoiceDocument(){
            try
            {
                DateTime date1 = Convert.ToDateTime(dtInvoice.Text);
                string dateInvoice = date1.ToString("yyyy-M-dd");

                DateTime date2 = Convert.ToDateTime(dtPayment.Text);
                string datePayment = date2.ToString("yyyy-M-dd");


                //int rowIndex = -1;
                Decimal startVat = 0;
                Decimal vatIncr = 0;
                foreach (DataGridViewRow row in dgw.Rows)
                {
                    startVat = Convert.ToDecimal(row.Cells[5].Value);
                    vatIncr += startVat;
                }

                id_type_payment = cmbMethodPayment.Text.ToString().Split(' ')[0];

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                Decimal BenefitAmount = Convert.ToDecimal(lblTotalCost.Text) - Convert.ToDecimal(lblImportCost.Text);
                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO imp_invoices (id_distributor, invoice_code, date_invoice, date_payment, date_registration, vatAmount, totalAmount, benefitAmount, importAmount, payment_status, id_type_payment) VALUES ('" + id_distributor + "', '" + txtInvoiceCode.Text + "', '" + dateInvoice + "', '" + datePayment + "', '" + dateToday + "', '" + vatIncr.ToString() + "', '" + lblTotalCost.Text + "', '" + BenefitAmount + "', '" + lblImportCost.Text + "','0','" + id_type_payment + "')", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if(i > 0){
                  MessageBox.Show("Fatura u krijua me sukses !" , "Invoice Created", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                 conn.Close();
             }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create Invoice Doc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }

           private void CreateInvoiceData()
           {
               try
               {
                   MySqlConnection conn = DBUtils.GetDBConnection();

                   conn.Open();

                   for(int i=0; i<dgw.Rows.Count;i++)
                   {
                       dgw_invoicecode = dgw.Rows[i].Cells[1].Value.ToString();

                       getProductID();

                       MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO invoiceprocessing (id_order, id_distributor, id_product, invoice_code, vatPerc, maj_unit_price, unit_price, stocks_insert, stockstotal, freeQty, import_amount, vat_amount, sell_amount)VALUES('" + dgw.Rows[i].Cells[0].Value + "', '" + id_distributor + "', '" + id_product + "', '" + txtInvoiceCode.Text + "', '" + dgw.Rows[i].Cells[4].Value + "','" + dgw.Rows[i].Cells[10].Value + "', '" + dgw.Rows[i].Cells[11].Value + "', '" + dgw.Rows[i].Cells[8].Value + "', '" + dgw.Rows[i].Cells[6].Value + "', '" + dgw.Rows[i].Cells[7].Value + "', '" + dgw.Rows[i].Cells[9].Value + "', '" + dgw.Rows[i].Cells[5].Value + "', '" + dgw.Rows[i].Cells[12].Value + "')", conn);
                       cmdDatabase.ExecuteNonQuery();
                   }
                   conn.Close();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Create Invoice Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           private void CreateStockins()
           {
               try
               {
                   MySqlConnection conn = DBUtils.GetDBConnection();
                   conn.Open();
                   for (int i = 0; i < dgw.Rows.Count; i++)
                   {
                       dgw_invoicecode = dgw.Rows[i].Cells[1].Value.ToString();
                       getProductID();
                       MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO stocksin (ItemNo, ItemQuantity, SIDate, CurrentStocks, number_facture) VALUES('" + id_product + "', '" + dgw.Rows[i].Cells[8].Value + "', '" + dateToday + "', '" + dgw.Rows[i].Cells[6].Value + "', '" + txtInvoiceCode.Text + "')", conn);
                       cmdDatabase.ExecuteNonQuery();
                   }
                   conn.Close();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Create Stockins", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           private void UpdateProductPrice()
           {
               try
               {
                   MySqlConnection conn = DBUtils.GetDBConnection();

                   conn.Open();

                   for (int i = 0; i < dgw.Rows.Count; i++)
                   {
                       Decimal importPrice = Convert.ToDecimal(dgw.Rows[i].Cells[11].Value) / Convert.ToDecimal(dgw.Rows[i].Cells[10].Value);
                       Decimal TaxPerc = Convert.ToDecimal(dgw.Rows[i].Cells[4].Value);

                       Decimal MajSellPrice = Convert.ToDecimal(dgw.Rows[i].Cells[10].Value);

                       MySqlCommand cmdDatabase = new MySqlCommand("UPDATE products SET import_price='" + importPrice.ToString() + "', margin_perc='" + dgw.Rows[i].Cells[9].Value.ToString() + "', sold_price='" + dgw.Rows[i].Cells[8].Value.ToString() + "', tax_amount='" + dgw.Rows[i].Cells[7].Value.ToString() + "', imported_qty = imported_qty + '" + dgw.Rows[i].Cells[10].Value.ToString() + "', quantity = quantity + '" + dgw.Rows[i].Cells[10].Value.ToString() + "' + '" + dgw.Rows[i].Cells[6].Value.ToString() + "', total_import_amount='" + dgw.Rows[i].Cells[11].Value.ToString() + "' WHERE barcode='" + dgw.Rows[i].Cells[1].Value.ToString() + "'", conn);
                       cmdDatabase.ExecuteNonQuery();
                   }

                   conn.Close();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "UpdateProductPrice", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

        private void dgw_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
                try
                { 
                    dgwImportAmount_edit = 0;
                    dgwQtyIns_edit = 0;
                    dgwSellPrice_edit = 0;
                    dgwFreeQty_edit = 0;
                    dgwVatAmount_edit = 0;
                    dgwVatPerc_edit = 0;

                    Decimal import_price_dgw = 0;
                    Decimal margin_dgw = 0;
                    Decimal net_amount = 0;
                    Decimal dgwImportPrice_edit = 0;
                    Decimal dgwSellAmount_edit = 0;

                    Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[11].Value.ToString(), out dgwImportAmount_edit);
                    Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[10].Value.ToString(), out dgwQtyIns_edit);
                    Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[8].Value.ToString(), out dgwSellPrice_edit);
                    Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[7].Value.ToString(), out dgwVatAmount_edit);
                    Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[6].Value.ToString(), out dgwFreeQty_edit);
                    Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[4].Value.ToString(), out dgwVatPerc_edit);

                    if (dgwImportAmount != dgwImportAmount_edit)
                    {
                        import_price_dgw = Math.Round(dgwImportAmount_edit / dgwQtyIns_edit, 2);

                        margin_dgw = Math.Round((((dgwSellPrice_edit - import_price_dgw) / import_price_dgw) * 100), 2);

                        dgw.Rows[dgw.CurrentRow.Index].Cells[9].Value = margin_dgw.ToString();
                    }

                    if (dgwQtyIns != dgwQtyIns_edit)
                    {
                        dgwImportPrice_edit = Math.Round(dgwImported_amount * dgwQtyIns_edit,2);
                        dgw.Rows[dgw.CurrentRow.Index].Cells[11].Value = dgwImportPrice_edit.ToString();
                        dgwSellAmount_edit = Math.Round(dgwSellPrice_edit * dgwQtyIns_edit,2);
                        dgw.Rows[dgw.CurrentRow.Index].Cells[12].Value = dgwSellAmount_edit.ToString();
                    }

                    if (dgwSellPrice != dgwSellPrice_edit)
                    {
                        net_amount = dgwSellPrice_edit / (1 + (dgwVatPerc_edit / 100));
                        dgwVatAmount_edit = Math.Round(dgwSellPrice_edit - net_amount, 2);
                        dgw.Rows[dgw.CurrentRow.Index].Cells[7].Value = dgwVatAmount_edit.ToString();

                        dgwSellAmount_edit = Math.Round(dgwSellPrice_edit * dgwQtyIns_edit,2);
                        dgw.Rows[dgw.CurrentRow.Index].Cells[12].Value = dgwSellAmount_edit.ToString();

                        import_price_dgw = Math.Round(dgwImportAmount_edit / dgwQtyIns_edit, 2);

                        margin_dgw = Math.Round((((dgwSellPrice_edit - import_price_dgw) / import_price_dgw) * 100), 2);

                        dgw.Rows[dgw.CurrentRow.Index].Cells[9].Value = margin_dgw.ToString();
                    }
                    calcAmounts();
                }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "dgw_CellEndEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
         }

        private void calcAmounts()
        {
           Decimal calc_import = 0;
           Decimal calc_sales = 0;
            lbltotal_import = 0;
            lbltotal_sales = 0;

            foreach (DataGridViewRow row in dgw.Rows)
            {
                Decimal.TryParse(row.Cells[11].Value.ToString(), out calc_import);
                Decimal.TryParse(row.Cells[12].Value.ToString(), out calc_sales);
                lbltotal_import += calc_import;
                lbltotal_sales += calc_sales;
            }

            lblImportCost.Text = lbltotal_import.ToString();
            lblTotalCost.Text = lbltotal_sales.ToString();
        }

        private void dgw_StartEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgw.Rows.Count > 0)
              {
                dgwBarcode = dgw.Rows[dgw.CurrentRow.Index].Cells[1].Value.ToString();
                dgwImportAmount = 0;
                dgwQtyIns = 0;
                dgwSellPrice = 0;
                dgwFreeQty = 0;
                dgwVatAmount = 0;

                Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[11].Value.ToString(), out dgwImportAmount);
                Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[10].Value.ToString(), out dgwQtyIns);
                Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[8].Value.ToString(), out dgwSellPrice);
                Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[7].Value.ToString(), out dgwVatAmount);
                Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[6].Value.ToString(), out dgwFreeQty);
                dgwImported_amount = dgwImportAmount / dgwQtyIns;

              }
        }

        private void FindingProductPrice()
           {
               try
               {
                   MySqlConnection conn = DBUtils.GetDBConnection();
                   conn.Open();

                   MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.barcode, products.sold_price FROM products WHERE products.barcode='" + dgwProductCode + "' AND products.sold_price!='" + dgwNewProductPrice + "'", conn);

                   MySqlDataReader dr = cmdDatabase.ExecuteReader();
                   if (dr.Read() == true)
                   {
                       productPriceChange = true;
                       id_product = dr.GetInt32(0);
                       oldPrice = dr[2].ToString();
                   }

                   conn.Close();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           private void Create_PriceHist()
           {
               try
               {
                   MySqlConnection conn = DBUtils.GetDBConnection();
                   conn.Open();

                   for (int i = 0; i < dgw.Rows.Count; i++)
                   {
                       dgwProductCode = dgw.Rows[i].Cells[1].Value.ToString();
                       dgwNewProductPrice = dgw.Rows[i].Cells[8].Value.ToString();

                       FindingProductPrice();
                       if (productPriceChange == true) {
                           MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO price_hist (id_product, old_price, new_price, date_mod) VALUES('" + id_product + "', '" + oldPrice + "', '" + dgwNewProductPrice + "', '" + dateToday + "')", conn);
                           cmdDatabase.ExecuteNonQuery();
                       }
                   }

                   conn.Close();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Create PriceHist", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }
        
           private void getCompanyDetails()
           {
               try
               {
                   MySqlConnection conn = DBUtils.GetDBConnection();
                   conn.Open();

                   MySqlCommand cmdDatabase = new MySqlCommand("SELECT company.companyName, company.manager, company.contactNumber, company.CompanySN, company.BANK_Number, company.adress, company.city, company.country, sys_currency.currency FROM company LEFT JOIN sys_currency ON company.id_currency=sys_currency.id_currency WHERE company.id_company = 1", conn);

                   MySqlDataReader dr = cmdDatabase.ExecuteReader();
                       if (dr.Read()==true)
                       {
                           DBCompanyName = dr[0].ToString();
                           DBManager = dr[1].ToString();
                           DBContactNumber = dr[2].ToString();
                           DBAdress = dr[5].ToString();
                           DBCity = dr[6].ToString();
                           DBCountry = dr[7].ToString();
                           infoCurrency = dr[8].ToString();
                       }
                   conn.Close();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           private void getDistributorDetails()
           {
               try
               {
                   MySqlConnection conn = DBUtils.GetDBConnection();
                   conn.Open();

                   MySqlCommand cmdDatabase = new MySqlCommand("SELECT company, fullname, phone, adress, city, country FROM distributors WHERE id_distributor='" + id_distributor + "'", conn);

                   MySqlDataReader dr = cmdDatabase.ExecuteReader();
                       if (dr.Read()==true)
                       {
                           DistCompanyName = dr[0].ToString();
                           DistManager = dr[1].ToString();
                           DistContactNumber = dr[2].ToString();
                           DistAdress = dr[3].ToString();
                           DistCity = dr[4].ToString();
                           DistCountry = dr[5].ToString();
                       }
                   conn.Close();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           private void exportDoc() {
            getCompanyDetails();
            getDistributorDetails();
            
            //Header Left Table
            PdfPTable pdfTable2 = new PdfPTable(2);
            pdfTable2.DefaultCell.MinimumHeight = 20.0F;
            pdfTable2.WidthPercentage = 95;

            PdfPCell Tablecell1 = new PdfPCell();
            PdfPCell Tablecell2 = new PdfPCell();
            Paragraph p1 = new Paragraph();
            Paragraph p2 = new Paragraph();

            //   p1.Add(new Paragraph("Invoice Processing Number -  ", Classes.UserFonts.GetBoldFont()));
            p1.Alignment = Element.ALIGN_LEFT;
            p1.Add(new Paragraph("[" + DBCompanyName + "]", Classes.UserFonts.fontNeue20()));
            p1.Add(new Paragraph("Rruga, Adresa : ", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph("[" + DBAdress + ", " + DBCity + ", " + DBCountry + "]", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph("Telefoni : ", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph("[" + DBContactNumber + "]", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph(""));

            //Header Right Table
            //   p1.Add(new Paragraph("Invoice Processing Number -  ", Classes.UserFonts.GetBoldFont()));
            p2.Alignment = Element.ALIGN_RIGHT;
            p2.Add(new Paragraph("Distributor : ", Classes.UserFonts.fontNeue20()));
            p2.Add(new Paragraph("[" + DistCompanyName + "]", Classes.UserFonts.fontNeue20()));
            p2.Add(new Paragraph("Rruga, Adresa : ", Classes.UserFonts.GetBoldFont()));
            p2.Add(new Paragraph("[" + DistAdress + ", " + DistCity + ", " + DistCountry + "]", Classes.UserFonts.FontBold12()));
            p2.Add(new Paragraph("Telefoni : ", Classes.UserFonts.GetBoldFont()));
            p2.Add(new Paragraph("[" + DistContactNumber + "]", Classes.UserFonts.FontBold12()));
            p2.Add(new Paragraph(""));

            Tablecell1.AddElement(p1);
            Tablecell2.AddElement(p2);

            pdfTable2.AddCell(Tablecell1);
            pdfTable2.AddCell(Tablecell2);

            //Middle Table
            PdfPTable pdfTable3 = new PdfPTable(1);
            PdfPCell Tablecell3 = new PdfPCell();
            Paragraph p3 = new Paragraph();

            p3.Add(new Phrase("Numri Procesimit Fatures : ", Classes.UserFonts.GetBoldFont()));
            p3.Add(new Paragraph(txtInvoiceCode.Text, Classes.UserFonts.FontBold12()));
            p3.Add(new Phrase("Data Fatures : ", Classes.UserFonts.GetBoldFont()));
            p3.Add(new Paragraph(dtInvoice.Text, Classes.UserFonts.FontBold12()));
            p3.Add(new Phrase("Data Pageses : ", Classes.UserFonts.GetBoldFont()));
            p3.Add(new Paragraph(dtPayment.Text, Classes.UserFonts.FontBold12()));
            p3.Add(new Phrase("Menyra Pageses : ", Classes.UserFonts.GetBoldFont()));
            p3.Add(new Paragraph(cmbMethodPayment.Text, Classes.UserFonts.FontBold12()));
            p3.Add(new Paragraph(""));

            Tablecell3.AddElement(p3);
            pdfTable3.AddCell(Tablecell3);
            //Ending Middle Table

            //Starting Sums
            //Bottom Table
            PdfPTable pdfTable4 = new PdfPTable(4);

            pdfTable4.DefaultCell.Padding = 3;
            pdfTable4.WidthPercentage = 95;
            pdfTable4.DefaultCell.MinimumHeight = 40.0F;
            pdfTable4.DefaultCell.SetLeading(4.5F, 1);
            pdfTable4.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable4.DefaultCell.BorderWidth = 0;

            PdfPCell Tablecell41 = new PdfPCell();
            PdfPCell Tablecell42 = new PdfPCell();
            PdfPCell Tablecell43 = new PdfPCell();
            PdfPCell Tablecell44 = new PdfPCell();
            Paragraph p41 = new Paragraph();
            Paragraph p42 = new Paragraph();
            Paragraph p43 = new Paragraph();
            Paragraph p44 = new Paragraph();

            Decimal Netprofit = Convert.ToDecimal(lblTotalCost.Text) - Convert.ToDecimal(lblImportCost.Text);
            //Titles
            p42.Add(new Phrase("Shuma Importit ", Classes.UserFonts.FontBold12()));
            p42.Add(new Phrase(" " + lblImportCost.Text + " " + infoCurrency + " ", Classes.UserFonts.FontBold12()));

            p44.Add(new Phrase("Shuma Totale ", Classes.UserFonts.FontBold12()));
            p44.Add(new Phrase(" " + lblTotalCost.Text + " " + infoCurrency + " ", Classes.UserFonts.FontBold12()));
            
            //Values
            //Tablecell41.BorderWidth = 0;
            // p4.Alignment = Element.ALIGN_RIGHT;
            //p5.Alignment = Element.ALIGN_LEFT;

            Tablecell41.AddElement(p41);
            pdfTable4.AddCell(Tablecell41);

            Tablecell42.AddElement(p42);
            pdfTable4.AddCell(Tablecell42);

            Tablecell43.AddElement(p43);
            pdfTable4.AddCell(Tablecell43);

            Tablecell44.AddElement(p44);
            pdfTable4.AddCell(Tablecell44);
            //Ending Sums

            //Starting Signature
            PdfPTable pdfTable6 = new PdfPTable(4);
            PdfPCell Tablecell6 = new PdfPCell();

            Paragraph p6 = new Paragraph();
            //Titles
            p6.Add(new Paragraph("Data Sot: ", Classes.UserFonts.FontBold12()));
            p6.Add(new Paragraph(dateToday, Classes.UserFonts.FontBold12()));

            p6.Add(new Phrase("_____________________", Classes.UserFonts.FontBold12()));
    
            Tablecell6.BorderWidth = 0;

            Tablecell6.AddElement(p6);
            pdfTable6.AddCell(Tablecell6);

            pdfTable6.DefaultCell.Padding = 3;
            pdfTable6.WidthPercentage = 95;
            pdfTable6.DefaultCell.MinimumHeight = 40.0F;
            pdfTable6.DefaultCell.SetLeading(4.5F, 1);
            pdfTable6.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable6.DefaultCell.BorderWidth = 0;
            pdfTable6.AddCell("");
            pdfTable6.AddCell("");
            pdfTable6.AddCell("");
            //EndInvoke Signature

            //Result Rows
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(dgw.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 95;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dgw.Columns)
            {
               PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 8.5f, iTextSharp.text.Font.NORMAL))); 
               pdfTable.AddCell(cell); 
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        pdfTable.AddCell("");
                    }
                    else
                    {
                        pdfTable.AddCell(new Phrase(cell.Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 8.5f, iTextSharp.text.Font.NORMAL))); 
                    }
                }
            }

            randomNumber = DateTime.Now.ToString("HHmmss");

            //Exporting to PDF
            string folderPath = "C:/PDFs/";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (FileStream stream = new FileStream(folderPath + "" + randomNumber + ".PDF", FileMode.Create))
            {
                Document pdfDoc = new Document(iTextSharp.text.PageSize.A4.Rotate());
                
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable2);
                pdfDoc.Add(pdfTable3);
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(pdfTable4);
                pdfDoc.Add(pdfTable6);
                pdfDoc.Close();
                stream.Close();
            }
           }

           private void ClearDocument()
           {
               try
               {
                   dgw.Rows.Clear();
                   rowExists = false;
                   txtDistributerCompany.ResetText();
                   txtInvoiceCode.ResetText();
                   dtInvoice.ResetText();
                   dtPayment.ResetText();
                   cmbMethodPayment.Text = "0";
                   txtBenefitSum.ResetText();
                   txtSellPrice.ResetText();
                   txtImportPrice.ResetText();
                   txtQty.Text = "1";
                   txtFreeQty.Text = "0";
                   txtBarcode.ResetText();
                   lblImportCost.ResetText();
                   lblTotalCost.ResetText();
                   txtMargin.ResetText();
                   txtVatSell.ResetText();
                txtQuantityAv.ResetText();
                txtTotalWithReduction.ResetText();
            }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Decimal LblImport = 0;
            Decimal txtImport = 0;

            Decimal.TryParse(lblImportCost.Text, out LblImport);
            Decimal.TryParse(txtImportAmount.Text, out txtImport);

            if (dgw.Rows.Count == 0)
            {
                MessageBox.Show("Futni produktet ne list per te vazhduar !", "Empty String", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtInvoiceCode.Text == "")
            {
                MessageBox.Show("Jepeni numrin e fatures per te vazhduar !", "Empty String", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtDistributerCompany.Text == "")
            {
                MessageBox.Show("Gjejeni distributorin per te vazhduar !", "Empty String", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dtInvoice.Text == "")
            {
                MessageBox.Show("Gjejeni daten e fatures !", "Empty String", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dtPayment.Text == "")
            {
                MessageBox.Show("Gjejeni daten e pagese !", "Empty String", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmbMethodPayment.Text == "")
            {
                MessageBox.Show("Zgjedheni menyren e pageses !", "Empty String", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (LblImport != txtImport)
            {
                MessageBox.Show("Shuma total e importit nuk është e njejtë me vlerën e dhënë !", "Equal Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CheckInvoiceNumber();
                if (CheckInvoiceExist == true)
                {
                    MessageBox.Show("Zgjedheni nje numer tjeter te fatures qe nuk eshte perdorur me heret !", "Existing Doc", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    CheckInvoiceExist = false;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("A doni ta krijoni fajlin PDF ?", "Invoice Completed !", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        CreateStockins();
                        Create_PriceHist();
                        UpdateProductPrice();
                        CreateInvoiceDocument();
                        CreateInvoiceData();
                        exportDoc();
                        System.Diagnostics.Process.Start("C:/PDFs/" + randomNumber + ".pdf");
                        ClearDocument();
                    }
                }
            }
        }

        private void btnNewDocument_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni ta fshini dokumentin aktual ?", "Invoice Reset !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ClearDocument();
            }
        }

        private void btnCloseReset_Click(object sender, EventArgs e)
        {
                 this.Dispose(true);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count>=1) { 
                previous_number = dgw.CurrentRow.Index;
                current_number = (dgw.CurrentRow.Index) + 1;
                next_number = dgw.CurrentRow.Index + 2;
     
                if (current_number == dgw.Rows.Count)
                {
                    MessageBox.Show("Celulat nuk gjenden !", "Cells not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                   dgw.Rows[current_number].Cells[0].Value = current_number;
                   dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value = next_number;
                   dgw.Sort(dgw.Columns[0], ListSortDirection.Ascending);
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count>=1) { 
                previous_number = dgw.CurrentRow.Index;
                current_number = (dgw.CurrentRow.Index) + 1;
                next_number = dgw.CurrentRow.Index + 2;

                if (current_number == 1)
                {
                    MessageBox.Show("Celulat nuk gjenden !", "Cells not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dgw.Rows[dgw.CurrentRow.Index - 1].Cells[0].Value = current_number;
                    dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value = previous_number;
                    dgw.Sort(dgw.Columns[0], ListSortDirection.Ascending);
                }
            }
        }

        private void txtQty_MouseClick(object sender, EventArgs e) {
            txtQty.SelectAll();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Focused) { 
                    qty_changed = true;
                }

                Decimal ImportPrice = 0;
                Decimal TaxPerc = 0;
                Decimal SellPrice = 0;
                Decimal Qty = 0;
                Decimal TotalWithReduction = 0;
                Decimal VatAmount = 0;
                Decimal BenefitSum = 0;
                
                Decimal.TryParse(txtQty.Text, out Qty);
                Decimal.TryParse(txtImportPrice.Text, out ImportPrice);
                Decimal.TryParse(lblVatPercExport.Text, out TaxPerc);
                Decimal.TryParse(txtSellPrice.Text, out SellPrice);
                Decimal.TryParse(txtVatSell.Text, out VatAmount);
                Decimal.TryParse(txtTotalWithReduction.Text, out TotalWithReduction);

                if (Qty < 0) { MessageBox.Show("Vlerat ne minus nuk pranohen", "Error Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error); txtQty.Text="1"; } else {
                    if (qty_changed == true) { 
                        if (ImportPrice > 0) {
                            Decimal ImportTotal=ImportPrice * Qty;
                            txtTotalWithReduction.Text = ImportTotal.ToString();

                            if ((SellPrice > 0) && (ImportPrice > 0))
                            {
                                BenefitSum = SellPrice - ImportPrice;
                                txtBenefitSum.Text = Math.Round(BenefitSum, 2).ToString();
                            }
                            txtMargin.Text = Math.Round((((SellPrice - ImportPrice) / ImportPrice) * 100), 2).ToString();
                        }
                    }
                }
                qty_changed = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtTotalWithReduction_MouseClick(object sender, EventArgs e)
        {
            txtTotalWithReduction.SelectAll();
        }

        private void txtTotalWithReduction_TextChanged(object sender, EventArgs e)
        {
            totalGotFocus = false;
            if (txtTotalWithReduction.Focused == true)
            {
                totalGotFocus = true;
            }

            try
            {
                Decimal TotalQty = 0;
                Decimal TotalSell = 0;
                Decimal TotalVat = 0;
                Decimal TotalImport = 0;
                Decimal import_price = 0;

                Decimal TotalWithReduction = 0;

                Decimal.TryParse(txtQty.Text, out TotalQty);
                Decimal.TryParse(txtSellPrice.Text, out TotalSell);
                Decimal.TryParse(txtVatSell.Text, out TotalVat);
                Decimal.TryParse(txtImportAmount.Text, out TotalImport);

                Decimal.TryParse(txtTotalWithReduction.Text, out TotalWithReduction);

                if (TotalWithReduction < 0) { MessageBox.Show("Vlerat ne minus nuk pranohen", "Error Amount", MessageBoxButtons.OK, MessageBoxIcon.Error); txtTotalWithReduction.Text = "0"; }
                else
                { 
                    if ((totalGotFocus == true) || (qty_changed==true)){

                        //  Decimal sellPrice = Math.Round(RoundUp(TotalWithReduction / TotalQty), 2);
                        // txtSellPrice.Text = sellPrice.ToString();

                        import_price = Math.Round(TotalWithReduction / TotalQty, 2);
                        txtImportPrice.Text = import_price.ToString();
                        // txtMargin.Text = Math.Round((((TotalSell - TotalVat - TotalImport) / TotalImport) * 100),2).ToString();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "txtTotalWithReduction_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRemoveProd_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count == 0)
            {
                MessageBox.Show("Zgjedheni produktin per ta fshir !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                rowExists = false;
                //  decimal TotalImpVat = 0;
                decimal TotalCost = 0;
                decimal TotalImpCost = 0;
                decimal QtyStocking = 0;

                decimal UnitImportCost = 0;
                decimal UnitTotalCost = 0;
                decimal UnitVatPerc = 0;
                
               // decimal.TryParse(lblSumImpVat.Text, out TotalImpVat);
                decimal.TryParse(lblTotalCost.Text, out TotalCost);
                decimal.TryParse(lblImportCost.Text, out TotalImpCost);

                decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[10].Value.ToString(), out QtyStocking);

                decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[4].Value.ToString(), out UnitVatPerc);
                decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[11].Value.ToString(), out UnitImportCost);
                decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[12].Value.ToString(), out UnitTotalCost);

                lblTotalCost.Text = (TotalCost - UnitTotalCost).ToString();
                lblImportCost.Text = (TotalImpCost - UnitImportCost).ToString();

                foreach (DataGridViewCell oneCell in dgw.SelectedCells)
                {
                    if (oneCell.Selected) { dgw.Rows.RemoveAt(oneCell.RowIndex); }
                }
                for (id_order = 1; id_order <= dgw.Rows.Count; id_order++)
                {
                    dgw.Rows[id_order - 1].Cells[0].Value = id_order;
                }

                MessageBox.Show("Produkti u fshi me sukses nga lista !", "Item Removed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtUpdProd_TextChanged(object sender, EventArgs e)
        {
                if (txtUpdProd.Text != "") {

                    Decimal totalImport = 0;
                    Decimal totalCost = 0;
                    Decimal impSum = 0;
                    Decimal FreeProducts = 0;
                    Decimal soldPrice = 0;
                    Decimal qtyImp = 0;
                    Decimal sellVat = 0;
                    Decimal lbltotalCost = 0;
                    Decimal lblImport_Cost = 0;

                    Decimal.TryParse(UpdImpSum, out impSum);
                    Decimal.TryParse(UpdSoldAmount, out soldPrice);
                    Decimal.TryParse(UpdQty, out qtyImp);
                    Decimal.TryParse(UpdVatAmount, out sellVat);
                    Decimal.TryParse(UpdFree, out FreeProducts);
                    Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[12].Value.ToString(), out totalCost);
                    Decimal.TryParse(dgw.Rows[dgw.CurrentRow.Index].Cells[11].Value.ToString(), out totalImport);
                    Decimal.TryParse(lblTotalCost.Text, out lbltotalCost);
                    Decimal.TryParse(lblImportCost.Text, out lblImport_Cost);

                    Decimal totalSum = Math.Round(qtyImp * soldPrice,2);
                    //Changing Label on value change
                    lbltotalCost -= totalCost;
                    lbltotalCost += totalSum;

                    lblImport_Cost -= totalImport;
                    lblImport_Cost += impSum;

                    //Updating DatagridView
                    dgw.Rows[dgw.CurrentRow.Index].Cells[12].Value = totalSum.ToString();
                    dgw.Rows[dgw.CurrentRow.Index].Cells[11].Value = impSum.ToString();
                    dgw.Rows[dgw.CurrentRow.Index].Cells[8].Value = soldPrice.ToString();
                    dgw.Rows[dgw.CurrentRow.Index].Cells[10].Value = qtyImp.ToString();
                    dgw.Rows[dgw.CurrentRow.Index].Cells[6].Value = FreeProducts.ToString();
                    dgw.Rows[dgw.CurrentRow.Index].Cells[7].Value = sellVat.ToString();

                    lblTotalCost.Text = lbltotalCost.ToString();
                    lblImportCost.Text = lblImport_Cost.ToString();

                }

                txtUpdProd.Text = "";
        }

       
        private void txtPacketVat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBenefitPerc_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFreeQty_MouseClick(object sender, EventArgs e)
        {
            txtFreeQty.SelectAll();
        }
        private void txtFreeQty_TextChanged(object sender, EventArgs e)
        {
            Decimal FreeQty = 0;

            Decimal.TryParse(txtFreeQty.Text, out FreeQty);

            if (FreeQty < 0) { MessageBox.Show("Vlerat ne minus nuk pranohen", "Error Amount", MessageBoxButtons.OK, MessageBoxIcon.Error); txtFreeQty.Text="0"; }
        }
    }
}