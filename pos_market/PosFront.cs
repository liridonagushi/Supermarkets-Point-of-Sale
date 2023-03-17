using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    public partial class PosFront : Form
    {
        private static String searchValue;
        private static Decimal SumPrice, sumVAT;
        private static Boolean rowExists, saved_pos, updProd;
        public static Boolean indexedPayment, hasDebt;
        public static int activatedPrinter, invoiceNR;
        private static string printerName, infoCompanyName;

       // private static string print_line1;

        private const byte ESC = 0x1B;
      //  private const byte[] CutPaper = { ESC, 0x69 };

        //source frmPayment
        public static String FindSourcePayment;

        //payment methods
        private static int type_payment;
        private static string paymentMethod;

        public static string FindProductKey;
        public static string FindProductQuantity;
        public static string ProductCode;
        public static int updatingQty;
        private static int idDgw;
        private static int updatingRow;
        public static string myUsername;
        private string id_employee;
        private static int numbIncrement;
        
        //FindingProduct
        //search code in dgw
        private static string search_Code, ProductDescription;
        private static int searchIDprod, searchVatprod, searchPriceprod, searchVatperc;
        private static decimal searchQtyprod;
        private static Boolean productExist;
        
        //Pos Detail Calc
        private static decimal posNonVatAmount, posVatAmount, posProductPrice, posTotal_amount;
        private static string item, path;
        private static decimal qty, price;
        private static string fiscalBarcode;
        private static int fiscalID, fiscalActive;

        public PosFront()
        {
            InitializeComponent();
        }

        // Returning result values
        public string FindProduct
        {
            get { return txtBarcode.Text; }
            set { txtBarcode.Text = value; }
        }

        // Returning result values
        public string FindDiscount
        {
            get { return txtDiscount.Text; }
            set { txtDiscount.Text = value; }
        }

        // Returning result values
        public string updateProductPriceDgw
        {
            get { return txtUpdDgwPrice.Text; }
            set { txtUpdDgwPrice.Text = value; }
        }

        //Finding Products
        private void btnFindProd_Click(object sender, EventArgs e)
        {
            frmFindProduct.myUsername = lblUsername.Text;
            frmFindProduct.sFormIndex = "frmPOS";
            frmFindProduct frm = new frmFindProduct(this);
            frm.ShowDialog();
            txtBarcode.Focus();
        }

        // Returning Client values
        public string FindClient
        {
            get { return txtIDClient.Text; }
            set { txtIDClient.Text = value; }
        }

        public string FindCode
        {
            get { return txtBarcode.Text; }
            set { txtBarcode.Text = value; }
        }

        public string FindProductCode
        {
            get { return txtProductCode.Text; }
            set { txtProductCode.Text = value; }
        }

        public string FindQuantity
        {
            get { return txtQty.Text; }
            set { txtQty.Text = value; }
        }
        public Boolean getUpdateStatus
        {
            get { return updProd; }
            set { updProd = value; }
        }

        public string frmMakePayment
        {
            get { return txtPayment.Text; }
            set { txtPayment.Text = value; }
        }

        private void BtnFindCl_Click(object sender, EventArgs e)
        {
            frmFindClient.sFormIndex = "frmPOS";
            frmFindClient frm = new frmFindClient(this);
            frm.ShowDialog();
            txtBarcode.Focus();
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                btnCancel.PerformClick();
                return true;
            }

            if (keyData == (Keys.Space))
            {
                txtQty.Focus();
                return true;
            }

            if (keyData == (Keys.Tab))
            {
                txtBarcode.Focus();
                return true;
            }

            if (keyData == Keys.Enter)
            {
                btnInsert.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                btnCashPayment.PerformClick();
                return true;
            }

            if (keyData == Keys.Delete)
            {
                btnRemoveProd.PerformClick();
                return true;
            }

            if (keyData == Keys.F1)
            {
                btnFindProd.PerformClick();
                return true;
            }

            if (keyData == Keys.F2)
            {
                btnCashPayment.PerformClick();
                return true;
            }

            if (keyData == Keys.F3)
            {
                btnDebtPayment.PerformClick();
                return true;
            }

            if (keyData == Keys.F4)
            {
                btnUpdQty.PerformClick();
                return true;
            }

            if (keyData == Keys.F5)
            {
               BtnFindCl.PerformClick();
               return true;
            }

            if (dgw.Focused != true && keyData == Keys.Down)
            {
               if (dgw.CurrentRow != null & dgw.SelectedRows.Count>0)
                {
                    // Check if down key is pressed
                    // Display selected cell's value
                    dgw.Focus();
                    dgw.CurrentCell = dgw.Rows[0].Cells[2];
                    return true;
                }
            }

            if (keyData == (Keys.F6))
            {
                BtnFindCl.PerformClick();
                return true;
            }

             return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchExist() {

            //int rowIndex = -1;

            foreach (DataGridViewRow row in dgw.Rows)
            {
                //if (row.Cells[1].Value == searchValue)

                if (row.Cells[1].Value.ToString().Equals(searchValue))
                {
                    updatingRow = Convert.ToInt32(row.Cells[0].Value) - 1;
                    rowExists = true;
                }
            }
        }

        private void FindData()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.barcode, products.description, products.sold_price, products.quantity, taxes.vat_perc, products.tax_amount, products.id_category FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.barcode='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                decimal quantity = 1;

                if ((txtQty.Text == "") || (txtQty.Text == " ") || (txtQty.Text == "0")) { quantity = 1; } else { quantity = Convert.ToDecimal(txtQty.Text); }

                    while (dr.Read() == true){

                    if (dr.GetInt32(3) <= -100)
                    {
                        MessageBox.Show("Shitja eshte bllokuar per produktet me sasine minus 100, importoni produktet ne databaz !", "Error Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                    else
                    {
                        if (dr.GetInt32(3) <= -10)
                        {
                            MessageBox.Show("Kujdes, sasia e produktit eshte nen minus 10 !", "Error Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        if (quantity <= 0){ MessageBox.Show("Nuk lejohet perdorimi i numrave ne minus !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                        Decimal TotalVat = 0;
                        Decimal.TryParse(lblVatAmount.Text, out TotalVat);

                        Decimal TotalPrice = 0;
                        Decimal.TryParse(lblTotalCost.Text, out TotalPrice);
         
                        SumPrice = dr.GetDecimal(2);

                        if (getUpdateStatus == true)
                        {
                            SumPrice = Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[4].Value);
                        }

                        Decimal net_amount = SumPrice / (1 + (dr.GetDecimal(4) / 100));

                        sumVAT = SumPrice - net_amount;

                        Decimal newVat = Math.Round(TotalVat + (sumVAT * quantity), 2);
                        Decimal newPrice = Math.Round(TotalPrice + (SumPrice * quantity), 2);

                        lblVatAmount.Text = newVat.ToString();

                        lblTotalCost.Text = newPrice.ToString();

                        searchValue = dr.GetString(0);

                        SearchExist();

                        if (rowExists == true)
                        {
                            if (updProd == true)
                            {
                                Decimal minusRowSum = Convert.ToDecimal(lblTotalCost.Text) - Convert.ToDecimal(dgw.Rows[updatingRow].Cells[5].Value);
                                Decimal minusRowTax = Convert.ToDecimal(lblVatAmount.Text) - ((Convert.ToDecimal(dgw.Rows[updatingRow].Cells[3].Value) * sumVAT));

                                lblVatAmount.Text = Math.Round(minusRowTax,2).ToString();
                                lblTotalCost.Text = Math.Round(minusRowSum,2).ToString();

                                dgw.Rows[updatingRow].Cells[3].Value = quantity;
                                dgw.Rows[updatingRow].Cells[5].Value = SumPrice * quantity;
                            }
                            else
                            {
                                dgw.Rows[updatingRow].Cells[3].Value = Convert.ToDecimal(dgw.Rows[updatingRow].Cells[3].Value) + quantity;
                                dgw.Rows[updatingRow].Cells[5].Value = Convert.ToDecimal(dgw.Rows[updatingRow].Cells[5].Value) + (SumPrice * quantity);
                            }
                        }
                        else
                        {
                            idDgw = dgw.Rows.Count + 1;

                            dgw.Rows.Add(idDgw, dr[0], dr[1], quantity, dr[2], SumPrice * quantity);
                        }
                    }

                    getUpdateStatus = false;
                    rowExists = false;
                    idDgw = 0;
                    enableButtons();
                    txtQty.Text = "1";
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FindData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindingProduct()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.barcode, products.sold_price, products.tax_amount, taxes.vat_perc FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.barcode='" + search_Code + "'", conn);
                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    searchIDprod = dr.GetInt32(0);

                    searchPriceprod = dr.GetInt32(2);

                    searchVatprod = dr.GetInt32(3);

                    searchVatperc = dr.GetInt32(4);

                    productExist = true;

                }else{
                    productExist = false;
                    MessageBox.Show("Produkti nuk u gjet !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FindingProduct", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculatingPosDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT InvoiceNo, SUM(vatAmount) As vatAmount, SUM(ProductPrice) AS ProductPrice, SUM(total_amount) AS total_amount FROM posdetails WHERE InvoiceNo='" + lblInvoiceNumber.Text + "'", conn);
                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    posVatAmount = Convert.ToDecimal(dr.IsDBNull(1) ? "0.00" : dr.GetString(1));
                    posProductPrice = Convert.ToDecimal(dr.IsDBNull(2) ? "0.00" : dr.GetString(2));
                    posTotal_amount = Convert.ToDecimal(dr.IsDBNull(3) ? "0.00" : dr.GetString(3));
                    posNonVatAmount = posTotal_amount - posVatAmount;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CalculatingPosDetails", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindEmployee()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_user, fullname, username FROM users WHERE username='" + txtusername.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        id_employee = dr.GetString(0);
                        lblName.Text = dr.GetString(1);
                    }
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FindEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void findInvoiceNumber()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT MAX(InvoiceNo) AS InvoiceNumber FROM POS ORDER BY InvoiceNo DESC", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    int id_Invoice = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);

                    lblInvoiceNumber.Text = (id_Invoice + 1).ToString();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void findPaymentMethod()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_type_payment, type_payment FROM type_payments WHERE id_type_payment= '" + type_payment + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    paymentMethod = dr.GetString(1);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "findPaymentMethod", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreatePoints()
        {
            try
            {
                decimal numberPoints =  posTotal_amount / 100;

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE clients SET total_points=total_points + '" + numberPoints + "' WHERE id_client = '" + txtIDClient.Text + "'", conn);

                cmdDatabase.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CreatePoints", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MakePOSPayment()
        {
          
            try
            {
                FindingProduct();
                FindEmployee();
                CalculatingPosDetails();
                findPaymentMethod();

                DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
                string datetimeNow = dbDate1.ToString("yyyy-MM-dd HH:mm:ss");
                string timeNow = dbDate1.ToString("HH:mm");

                int idClient = Convert.ToInt32(lblIDClient.Text);

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO pos (InvoiceNo, StaffID, id_client, type_payment, POSDate, NonVatAmount, VatAmount, TotalAmount) VALUES('" + lblInvoiceNumber.Text + "','" + id_employee + "','" + idClient + "','" + type_payment + "','" + datetimeNow + "','" + posNonVatAmount + "','" + posVatAmount + "', '" + posTotal_amount + "')", conn);
                
                int i = cmdDatabase.ExecuteNonQuery();

                if(i > 0){
                    MessageBox.Show(paymentMethod + " pagesa u be me sukses !", "Pagesa me sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    findInvoiceNumber();
                    CreatePoints();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MakePOSPayment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavePOSDetailsPayment()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                foreach (DataGridViewRow row in dgw.Rows)
                {
                    search_Code = row.Cells[1].Value.ToString();

                    searchQtyprod = Convert.ToDecimal(row.Cells[3].Value);

                    FindingProduct();

                    Decimal findVat = searchVatprod * searchQtyprod;

                    MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO saved_posdetails (id_product, vatAmount, ProductPrice, Quantity, total_amount) VALUES('" + searchIDprod + "', '" + findVat + "', '" + searchPriceprod + "', '" + searchQtyprod + "', '" + row.Cells[5].Value.ToString() + "')", conn);

                    cmdDatabase.ExecuteNonQuery();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error SavePOSDetailsPayment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDebt()
        {
            try
            {
                DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
                string datetimeNow = dbDate1.ToString("yyyy-M-dd");

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO client_debts (StaffID, id_client, InvoiceNo, debtValue, debtDate, type_payment) VALUES('" + id_employee + "','" + txtIDClient.Text + "','" + lblInvoiceNumber.Text + "','" + lblTotalCost.Text + "','" + datetimeNow + "', '" + type_payment + "')", conn);

                cmdDatabase.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CreateDebt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReducePoints()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE clients SET total_points=total_points - '" + posTotal_amount + "' WHERE id_client='" + lblIDClient.Text + "'", conn);

                cmdDatabase.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ReducePoints", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MakePOSDetailsPayment()
        {
            try
            {
                findInvoiceNumber();

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();


                foreach (DataGridViewRow row in dgw.Rows)
                {
                    search_Code = row.Cells[1].Value.ToString();


                    searchQtyprod = Convert.ToDecimal(row.Cells[3].Value);

                    FindingProduct();
                    
                    Decimal net_amount = Convert.ToDecimal(row.Cells[5].Value) / (1 + (Convert.ToDecimal(searchVatperc) / 100));

                    Decimal findVat = Math.Round(Convert.ToDecimal(row.Cells[5].Value) - net_amount,2);

                    MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO posdetails (InvoiceNo, id_product, vatAmount, ProductPrice, quantity, total_amount) VALUES('" + lblInvoiceNumber.Text + "', '" + searchIDprod + "', '" + findVat + "', '" + searchPriceprod + "', '" + searchQtyprod + "', '" + row.Cells[5].Value.ToString() + "')", conn);
                    cmdDatabase.ExecuteNonQuery();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MakePOSDetailsPayment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateQtyProd()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                foreach (DataGridViewRow row in dgw.Rows)
                {
                    search_Code = row.Cells[1].Value.ToString();

                    searchQtyprod = Convert.ToDecimal(row.Cells[3].Value);

                    FindingProduct();

                    MySqlCommand cmdDatabase = new MySqlCommand("UPDATE products SET quantity=quantity - '" + searchQtyprod + "' WHERE barcode='" + search_Code + "'", conn);
                    cmdDatabase.ExecuteNonQuery();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error UpdateQtyProd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDebt()
        {
            try
            {
                decimal debtAmount = Convert.ToDecimal(lblTotalCost.Text) + Convert.ToDecimal(lblCashDebt.Text);
                
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE client_debts SET debtValue='" + debtAmount + "' WHERE id_client='" + txtIDClient.Text + "' AND type_payment=3", conn);
                cmdDatabase.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Updating Debt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewInvoice() {
            dgw.Rows.Clear();
            lblVatAmount.Text = "0.00";
            lblTotalCost.Text = "0.00";
            txtIDClient.Text = "";
            txtPayment.Text = "0";
            indexedPayment = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            decimal Qty = 0;

            decimal.TryParse(txtQty.Text, out Qty);

            if ((txtBarcode.Text == "") || (txtQty.Text == ""))
            {
                MessageBox.Show("Barkodi zbrazet nuk pranohet !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Qty <= 0)
            {
                MessageBox.Show("Kuantiteti nen minus nuk pranohet !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                search_Code = txtBarcode.Text;
                FindingProduct();
                if (productExist==true) { 
                    FindData();
                    txtBarcode.Text = "";
                    txtQty.Text = "1";
                    productExist = false;

                    FindLoadSaved();
                    if (saved_pos == true)
                    {
                        btnSaveLater.Enabled = false;
                        btnLoadSaved.Enabled = true;
                    }
                    else
                    {
                        btnSaveLater.Enabled = true;
                        btnLoadSaved.Enabled = false;
                    }
                }
            }
        }

        private void btnCloseChange_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni ta fshini kete list te produkteve !", "Cancel Payment ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                NewInvoice();
                disableButtons();
            }
            txtBarcode.Focus();
        }

        private void ClearClientData()
        {
            lblIDClient.ResetText();
            lblClName.ResetText();
            lblOtherInfo.ResetText();
            lblPoints.ResetText();
        }

        private void FindingClient()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client, fullname, other_details, total_points FROM clients WHERE id_client='" + txtIDClient.Text + "'", conn);
                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    lblIDClient.Text = dr[0].ToString();
                    lblClName.Text = dr[1].ToString();
                    lblOtherInfo.Text = dr[2].ToString();
                    lblPoints.Text = dr[3].ToString();
                }
                else 
                {
                    lblIDClient.Text = "0";
                    lblClName.Text = "";
                    lblOtherInfo.Text = "";
                    lblPoints.Text = "";
                }
                    conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Finding Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindingCashDebts()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client, SUM(debtValue), type_payment FROM client_debts WHERE id_client='" + txtIDClient.Text + "' AND type_payment='3'", conn);
                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read()==true)
                {
                    lblCashDebt.Text = dr.IsDBNull(1) ? "0" : dr.GetString(1);

                    if (Convert.ToDecimal(lblCashDebt.Text) > 0)
                    {
                        btnRemoveDebt.Enabled = true;
                        hasDebt = true;
                    }
                    else
                    {
                        btnRemoveDebt.Enabled = false;
                        hasDebt = false;
                    }
                }
             
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Finding Debt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindingBankDebts()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client, SUM(debtValue), type_payment FROM client_debts WHERE id_client='" + txtIDClient.Text + "' AND type_payment = '2'", conn);
                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    lblClBankDebt.Text = dr.IsDBNull(1) ? "0" : dr.GetString(1);

                    if (Convert.ToDecimal(lblClBankDebt.Text) == 0)
                    {
                        lblClBankDebt.Text = "0";
                    }
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Finding Bank Debt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdQty_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgw.RowCount > 0)
                {
                    frmUpdQty.ProductCode = dgw.Rows[dgw.CurrentRow.Index].Cells[1].Value.ToString();
                    frmUpdQty frm = new frmUpdQty(this);
                    frm.ShowDialog();
                }
                else 
                {
                    MessageBox.Show("Produkti nuk u gjet ne liste !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtBarcode.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error btnUpdQty_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindHoursWorked()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_stat, time_start FROM employee_stats WHERE id_employee='" + id_employee + "' AND hours_worked=0", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    DateTime dbDate1 = Convert.ToDateTime(dr[1]);
                    lblDateStarted.Text = dbDate1.ToString("dd-M-yyyy");
                    lblTimeStarted.Text = dbDate1.ToString("HH:mm");
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FindHoursWorked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enableButtons()
        {
            btnBankPaymnet.Enabled = true;
            btnCancel.Enabled = true;
            btnCashPayment.Enabled = true;
            btnCashTicket.Enabled = true;
            btnDebtPayment.Enabled = true;
            btnPoints.Enabled = true;
            btnUpdQty.Enabled = true;
            btnRemoveProd.Enabled = true;
        }

        private void disableButtons()
        {
            btnBankPaymnet.Enabled = false;
            btnCashTicket.Enabled = false;
            btnCashPayment.Enabled = false;
            btnDebtPayment.Enabled = false;
            btnPoints.Enabled = false;
            btnUpdQty.Enabled = false;
            btnRemoveDebt.Enabled = false;
            btnRemoveProd.Enabled = false;
            btnSaveLater.Enabled = false;
        }

        public static void FindCompany()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT company.companyName, sys_currency.currency, company.manager, company.contactNumber, company.CompanySN, company.BANK_Number, company.adress, company.city, company.country FROM company LEFT JOIN sys_currency ON company.id_currency=sys_currency.id_currency WHERE company.id_company = 1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    infoCompanyName = dr[0].ToString();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FindCompany", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void FindLoadSaved()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT * FROM saved_posdetails", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    saved_pos = true;
                }
                else
                {
                    saved_pos = false;
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FindLoadSaved", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    while (dr.Read() == true)
                    {
                        MyCollection.Add(dr.GetString(1));
                    }

                    txtBarcode.AutoCompleteCustomSource = MyCollection;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getSuggestCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PosFront_Load(object sender, EventArgs e)
        {
            FindCompany();
            disableButtons();
            FindHoursWorked();
            findInvoiceNumber();
            txtIDClient.Visible = false;
            txtusername.Visible = false;
            txtDiscount.Visible = false;
            txtPayment.Visible = false;
            btnLoadSaved.Enabled = false;

            getSuggestCode();

            dgw.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgw.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            deleteSavedPos();

            lblUsername.Text = txtusername.Text;
            lblCompanyName.Text = infoCompanyName;
            txtBarcode.Focus();
        }

        private void txtIDClient_TextChanged(object sender, EventArgs e)
        {
            FindingClient();
            FindingCashDebts();
            FindingBankDebts();
            txtBarcode.Focus();
        }

        private void lblMessages_Click(object sender, EventArgs e)
        {
            myUsername = txtusername.Text;
            
            frmAdminMsg frm = new frmAdminMsg();
            
            frm.ShowDialog();
        }

        private void lblNewMessages_Click(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            FindEmployee();
            txtBarcode.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
            string timeNow = dbDate1.ToString("HH:mm:ss");
            lblTimeNow.Text = timeNow;
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void RemoveData()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.barcode, products.description, products.sold_price, products.quantity, taxes.vat_perc, products.tax_amount, products.majority_price, products.tax_majority FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.barcode='" + dgw.Rows[dgw.CurrentRow.Index].Cells[1].Value.ToString() + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read() == true)
                {

                    Decimal quantity = Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[3].Value.ToString());

                    Decimal TotalVat = 0;

                    Decimal.TryParse(lblVatAmount.Text, out TotalVat);

                    Decimal TotalPrice = 0;

                    Decimal.TryParse(lblTotalCost.Text, out TotalPrice);

                    SumPrice = Math.Round(Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[5].Value), 2);
                   
                    Decimal net_amount = SumPrice / (1 + (dr.GetDecimal(4) / 100));

                    Decimal vatAmount = SumPrice - net_amount;

                    sumVAT = Math.Round(vatAmount, 2);

                    Decimal newVat = TotalVat - sumVAT;
                    Decimal newPrice = TotalPrice - SumPrice;

                    lblVatAmount.Text = newVat.ToString();

                    lblTotalCost.Text = newPrice.ToString();

                    rowExists = false;
                    idDgw = 0;
                    txtBarcode.Text = "";
                    txtQty.Text = "1";
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error RemoveData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePrice()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.barcode, products.description, products.sold_price, products.quantity, taxes.vat_perc, products.tax_amount FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.barcode='" + dgw.Rows[dgw.CurrentRow.Index].Cells[1].Value.ToString() + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read() == true)
                {
                    Decimal net_amount = Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[5].Value) / (1 + (dr.GetDecimal(4) / 100));
                    Decimal OldvatAmount = Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[5].Value) - net_amount;

                    Decimal quantity = Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[3].Value.ToString());
                    Decimal oldPrice = Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[4].Value.ToString());
                    Decimal newProdPrice = Math.Round(Convert.ToDecimal(txtUpdDgwPrice.Text), 2);

                    Decimal currentTotal = Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[5].Value);

                    Decimal sumTotal = Math.Round(quantity * newProdPrice, 2);

                    Decimal TotalVat = 0;
                    Decimal.TryParse(lblVatAmount.Text, out TotalVat);

                    Decimal TotalPrice = 0;
                    Decimal.TryParse(lblTotalCost.Text, out TotalPrice);

                    dgw.Rows[dgw.CurrentRow.Index].Cells[5].Value = sumTotal.ToString();
                    dgw.Rows[dgw.CurrentRow.Index].Cells[4].Value = newProdPrice.ToString();

                    //New Vat Amount
                    Decimal newnet_amount = sumTotal / (1 + (dr.GetDecimal(4) / 100));

                    Decimal newvatAmount = Math.Round(sumTotal - newnet_amount,2);

                    Decimal totalMinusOldAmount = TotalPrice - currentTotal;

                    Decimal totalPlusNewAmount = Math.Round(totalMinusOldAmount + sumTotal,2);

                    Decimal VatMinusOldAmount = Math.Round(TotalVat - OldvatAmount,2);

                    Decimal VatPlusNewAmount = VatMinusOldAmount + newvatAmount;

                    lblVatAmount.Text = Math.Round(VatPlusNewAmount, 2).ToString();

                    lblTotalCost.Text = Math.Round(totalPlusNewAmount, 2).ToString();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveProd_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count == 0) {
                MessageBox.Show("Selektoni produktet per te vazhduar fshirjen !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RemoveData();

                foreach (DataGridViewCell oneCell in dgw.SelectedCells)
                {
                    if (oneCell.Selected) { dgw.Rows.RemoveAt(oneCell.RowIndex); }
                }
                for (numbIncrement = 1; numbIncrement <= dgw.Rows.Count; numbIncrement++)
                {
                    dgw.Rows[numbIncrement - 1].Cells[0].Value = numbIncrement;
                }
                MessageBox.Show("Produkti u fshi me sukses nga lista !", "Item Removed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (dgw.RowCount == 0)
                {
                    disableButtons();
                }
            }
            txtBarcode.Focus();
       }

        private void findPOSPrinter()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT printer_name FROM sys_printer_devices WHERE id_printer=1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    printerName = dr[0].ToString();
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckEnabledPosPrinter()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT printer_name, pos_printer FROM sys_printer_devices WHERE id_printer=1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    printerName = dr[0].ToString();
                    activatedPrinter = dr.GetInt32(1);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintHandler(object sender, PrintPageEventArgs ppeArgs)
        {
            FindingClient();

            DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
            string dateNow = dbDate1.ToString("dd-M-yy hh:m");

            frmMain.FindCompany();

            Graphics graphics = ppeArgs.Graphics;
            Font font = new Font("Courier New", 12);
            float fontHeight = font.GetHeight();
            int startX = 5;
            int startY = 10;
            int Offset = 20;
            graphics.DrawString(frmMain.infoCompanyName + " Preshevë ", new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            string underLine = "---------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            int a = dgw.Rows.Count;
            for (int i = 0; i < a; i++)
            {
                graphics.DrawString(Convert.ToString(dgw.Rows[i].Cells[2].Value), new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(Convert.ToInt32(dgw.Rows[i].Cells[3].Value) + "x " + Convert.ToInt32(dgw.Rows[i].Cells[4].Value) + "=" + Convert.ToInt32(dgw.Rows[i].Cells[5].Value), new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 10;
                string underLine2 = "---------------------------------------";
                graphics.DrawString(underLine2, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
            }

            graphics.DrawString("Total " + lblTotalCost.Text + " " + frmMain.infoCurrency, new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            if (lblIDClient.Text != "0")
            {
                graphics.DrawString(lblClName.Text, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 15;
            }

            graphics.DrawString(dateNow, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
        }

        private void Print(string PrinterName)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrinterSettings.PrinterName = PrinterName;
            doc.PrintPage += new PrintPageEventHandler(PrintHandler);
            doc.Print();
        }

        private void btnBankPaymnet_Click(object sender, EventArgs e)
        {
            if (dgw.RowCount == 0)
            {
                MessageBox.Show("Duhet te gjeni produktet per te bere pagesen !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtIDClient.Text.Length == 0)
            {
                MessageBox.Show("Duhet te gjeni klientet te beni pagesen bankare !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (indexedPayment == true)
                {
                    type_payment = 2;

                    CheckEnabledPosPrinter();
                    if (activatedPrinter == 1)
                    {
                        findPOSPrinter();
                        Print(printerName);
                    }

                    CreateDebt();
                    CalculatingPosDetails();
                    MakePOSDetailsPayment();
                    MakePOSPayment();

                    //fiscal printer
                    writeFile();
                    writeFile2();
                    move_files();

                    NewInvoice();
                }
                else
                {
                    frmPayment.FindSourcePayment = "bank_payment";
                    frmPayment.reqAmount = Convert.ToDecimal(lblTotalCost.Text);
                    frmPayment frm = new frmPayment(this);
                    frm.Show();
                }
            }
        }

        private void btnDebtPayment_Click(object sender, EventArgs e)
        {
            if (dgw.RowCount == 0)
            {
                MessageBox.Show("Duhet te gjeni produktet per te bere pagesen !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtIDClient.Text.Length == 0)
            {
                MessageBox.Show("Duhet te gjeni klientet te beni pagesen borxh !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (indexedPayment == true)
                {
                    type_payment = 3;

                    CheckEnabledPosPrinter();
                    if (activatedPrinter == 1)
                    {
                        findPOSPrinter();
                        Print(printerName);
                    }

                    CalculatingPosDetails();
                    MakePOSDetailsPayment();
                    MakePOSPayment();
                    FindingCashDebts();

                    if(hasDebt == true){
                        UpdateDebt();
                    }
                    else
                    {
                        CreateDebt();
                    }
                    NewInvoice();
                }
                else
                {
                    frmPayment.FindSourcePayment = "debt_payment";
                    frmPayment.reqAmount = Convert.ToDecimal(lblTotalCost.Text);
                    frmPayment frm = new frmPayment(this);
                    frm.Show();
                }
            }
        }

        private void btnPoints_Click(object sender, EventArgs e)
        {
            if (dgw.RowCount == 0)
            {
                MessageBox.Show("Duhet te gjeni produktet per te bere pagesen !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtIDClient.Text.Length == 0)
            {
                MessageBox.Show("Duhet te gjeni klientet te beni pagesen me Pikat !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToDecimal(lblPoints.Text) < Convert.ToDecimal(lblTotalCost.Text))
            {
                MessageBox.Show("Numri i pikave nuk ka arritur ende per pagesen aktuale !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (indexedPayment == true)
                {
                    type_payment = 4;

                    CheckEnabledPosPrinter();
                    if (activatedPrinter == 1)
                    {
                        findPOSPrinter();
                        Print(printerName);
                    }

                    CalculatingPosDetails();
                    MakePOSDetailsPayment();
                    MakePOSPayment();
                    ReducePoints();
                    //fiscal printer
                    writeFile();
                    writeFile2();
                    move_files();
                    NewInvoice();
                }
                else
                {
                    frmPayment.FindSourcePayment = "points_payment";
                    frmPayment.reqAmount = Convert.ToDecimal(lblTotalCost.Text);
                    frmPayment frm = new frmPayment(this);
                    frm.Show();
                }
            }
        }

        private void btnCashPayment_Click(object sender, EventArgs e)
        {
            if (dgw.RowCount > 0)
            {
              //  if (indexedPayment == true)
                //   {
                    type_payment = 1;

                //   CheckEnabledPosPrinter();
                //  if(activatedPrinter == 1){
                //          findPOSPrinter();
                //        Print(printerName);
                //}
                
                    UpdateQtyProd();

                    CalculatingPosDetails();
                    MakePOSDetailsPayment();
                    MakePOSPayment();

                    //fiscal printer
                    writeFile();
                    writeFile2();
                    move_files();

                    NewInvoice();

                    //  }else{                    
                    //     frmPayment.FindSourcePayment = "cash_payment";
                    //    frmPayment.reqAmount = Convert.ToDecimal(lblTotalCost.Text);
               //     //     frmPayment frm = new frmPayment(this);
                    //    frm.Show();
               // }
            }
            else
            {
                MessageBox.Show("Nuk mund te beni pagesen nese lista eshte e zbrazet !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCashTicket_Click(object sender, EventArgs e)
        {
            if (dgw.RowCount > 0)
            {
                  if (indexedPayment == true)
                   {
                type_payment = 1;

                   CheckEnabledPosPrinter();
                  if(activatedPrinter == 1){
                          findPOSPrinter();
                        Print(printerName);
                }

                UpdateQtyProd();

                CalculatingPosDetails();
                MakePOSDetailsPayment();
                MakePOSPayment();
                NewInvoice();

                  }else{                    
                    frmPayment.FindSourcePayment = "cash_payment";
                    frmPayment.reqAmount = Convert.ToDecimal(lblTotalCost.Text);
                     frmPayment frm = new frmPayment(this);
                   frm.Show();
                }
            }
            else
            {
                MessageBox.Show("Nuk mund te beni pagesen nese lista eshte e zbrazet !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveDebt_Click(object sender, EventArgs e)
        {
            if (txtIDClient.Text == "") { MessageBox.Show("Klienti nuk gjendet !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                FindEmployee();
                frmRemoveDebt.id_employee = id_employee;
                frmRemoveDebt.id_client = txtIDClient.Text;
                txtIDClient.Text = "0";
                frmRemoveDebt frm = new frmRemoveDebt(this);
                frm.ShowDialog();
            }
            txtBarcode.Focus();
        }

        private void FindFiscalProduct()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_product, barcode, active FROM products WHERE barcode='" + fiscalBarcode + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read())
                {
                    fiscalID = dr.GetInt32(0);
                    fiscalActive = dr.IsDBNull(2) ? 0 : dr.GetInt32(2);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FindProductDetails", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void writeFile()
        {
            try
            {
                path = @"IN/" + lblInvoiceNumber.Text + ".dat";
                File.Create(path).Dispose();

                foreach (DataGridViewRow row in dgw.Rows)
                {
                    fiscalBarcode = row.Cells[1].Value.ToString();
                    FindFiscalProduct();
                        item = row.Cells[2].Value.ToString();
                        Decimal.TryParse(row.Cells[3].Value.ToString(), out qty);
                        Decimal.TryParse(row.Cells[4].Value.ToString(), out price);

                        search_Code = row.Cells[1].Value.ToString();

                        path = @"IN/" + lblInvoiceNumber.Text + ".dat";
                        File.AppendAllText(@path, fiscalID + " 0" + item + " " + price + " " + qty + "" + Environment.NewLine);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "writeFile", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void writeFile2()
        {
            try
            {
                path = @"IN/" + lblInvoiceNumber.Text + ".dat";
                // Create a file to write to.
                File.AppendAllText(@path, "END_OF_SALE" + Environment.NewLine + "PAY_CASH 0Prvo placanje " + Convert.ToDecimal(lblTotalCost.Text) + "" + Environment.NewLine + "END_OF_PAY" + Environment.NewLine + "USER_NAME 0" + lblUsername.Text + "" + Environment.NewLine + "FOOTER_1 0Br Fakture: " + lblInvoiceNumber.Text + "");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "writeFile2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void move_files()
        {
            try
            {
                string sourceFile = @"IN/" + lblInvoiceNumber.Text + ".dat";
                string destinationFile = @"C:/galeb/IN/" + lblInvoiceNumber.Text + ".dat";

                System.IO.File.Move(sourceFile, destinationFile);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "move_files", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            indexedPayment = true;
            if (Convert.ToDecimal(txtPayment.Text) > 0)
            {
                if (FindSourcePayment == "cash_payment")
                {
                    btnCashPayment.PerformClick();
                }
                else if (FindSourcePayment == "bank_payment")
                {
                    btnBankPaymnet.PerformClick();
                }
                else if (FindSourcePayment == "debt_payment")
                {
                    btnDebtPayment.PerformClick();
                }
                else if (FindSourcePayment == "points_payment")
                {
                    btnPoints.PerformClick();
                }
            }
            txtBarcode.Focus();
        }

        private void btnSaveLater_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                deleteSavedPos();
                SavePOSDetailsPayment();
                NewInvoice();
                disableButtons();
                MessageBox.Show("Tiketa u ruajt me sukses !", "Ticket saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSaveLater.Enabled = false;
                btnLoadSaved.Enabled = true;
            }
            else 
            {
                MessageBox.Show("Lista pa produkte nuk mund te ruhet !","Lista zbrazet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtBarcode.Focus();
        }

        private void FindProductDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_product, barcode, description FROM products WHERE id_product='" + searchIDprod + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                       ProductCode = dr.GetString(1);
                       ProductDescription = dr.GetString(2);
                    }
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void findSavedInvoice()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_product, vatAmount, ProductPrice, Quantity, total_amount FROM saved_posdetails", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                    int i = 0;
                    int vat = 0;
                    int total = 0;
                    dgw.Rows.Clear();

                    while (dr.Read()==true)
                    {
                        searchIDprod = dr.GetInt32(0);

                        FindProductDetails();

                        i = i + 1;

                        vat = vat + dr.GetInt32(1);
                        total = total + dr.GetInt32(4);
                        lblVatAmount.Text = vat.ToString();
                        lblTotalCost.Text = total.ToString();

                        dgw.Rows.Add(i, ProductCode, ProductDescription, dr[3], dr[2], dr[4]);
                    }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "findSavedInvoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteSavedPos()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM saved_posdetails", conn);

                cmdDatabase.ExecuteNonQuery();

                MySqlCommand cmdDatabase1 = new MySqlCommand("ALTER TABLE saved_posdetails AUTO_INCREMENT = 1", conn);
                cmdDatabase1.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "deleteSavedPos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadSaved_Click(object sender, EventArgs e)
        {
            findInvoiceNumber();
            findSavedInvoice();
            deleteSavedPos();
            enableButtons();
            btnLoadSaved.Enabled = false;
            txtBarcode.Focus();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            KeyBoardPos frm = new KeyBoardPos();
            frm.ShowDialog();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (txtProductCode.Text != ""){
            search_Code = txtProductCode.Text;
            FindingProduct();
                if (productExist == true)
                {
                    updProd = true;
                    txtBarcode.Text = search_Code;
                    FindData();
                    txtProductCode.Text = "";
                    txtBarcode.Text = "";
                    txtQty.Text = "1";
                    search_Code = "";
                    productExist = false;
                }
            }
        }

        private void findfreeOffer()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("select products.id_product, products.barcode, products.free_offer from products WHERE products.barcode='" + dgw.Rows[dgw.CurrentRow.Index].Cells[1].Value + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                   
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgw.Rows.Count == 0) { MessageBox.Show("Lista eshte e zbrazet !", "Empty Invoice", MessageBoxButtons.OK, MessageBoxIcon.Warning); } else {
                frmUpdDgwPrice.ProductCode = dgw.Rows[dgw.CurrentRow.Index].Cells[1].Value.ToString();
                frmUpdDgwPrice.ProductPrice = dgw.Rows[dgw.CurrentRow.Index].Cells[4].Value.ToString();

                frmUpdDgwPrice frm = new frmUpdDgwPrice(this);
                frm.ShowDialog();
            }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnUpdatePrice_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUpdDgwPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtUpdDgwPrice.Text != "")
            {
                UpdatePrice();
            }
            txtQty.Focus();
            txtUpdDgwPrice.Text = "";
        }
    }
}