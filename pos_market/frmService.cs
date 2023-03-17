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
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Supermarkets
{
    public partial class frmService : Form
    {
        //Tables
       // private static String randomNumber;
        //Company Info
        private static String DBCompanyName;
        private static String DBManager;
        private static String DBContactNumber;
        private static String DBAdress;
        private static String DBCity;
        private static String DBCountry;
        private static String infoCurrency;

        private static String statusLabel, searchValue, currentRow, underLine2, printerName;
        private static Int32 updatingRow, serviceStatus, idDgw, numbIncrement, fetchServiceStat, activatedPrinter, invoiceNumber;
        private static Boolean rowExists, UpdProd, error_val;
        private static Decimal productPrice, productTax, amountCurrency;
        public static string sFormIndex;

        public static String id_staff;

        //System Declarations
        private String dateTimeToday = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
       // private static String randomNumber;
        
        public frmService()
        {
            InitializeComponent();
        }

        // Returning result values
        public string FindClient
        {
            get { return txtIdClient.Text; }
            set { txtIdClient.Text = value; }
        }

        // Returning result values
        public string FindProduct
        {
            get { return txtBarcode.Text; }
            set { txtBarcode.Text = value; }
        }

        // Returning result values
        public string FindService
        {
            get { return txtIDService.Text; }
            set { txtIDService.Text = value; }
        }

        private void getCompanyDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT company.companyName, company.manager, company.contactNumber, company.CompanySN, company.BANK_Number, company.adress, company.city, company.country, sys_currency.currency FROM company LEFT JOIN sys_currency ON company.id_currency=sys_currency.id_currency WHERE company.id_company = 1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        DBCompanyName = dr[0].ToString();
                        DBManager = dr[1].ToString();
                        DBContactNumber = dr[2].ToString();
                        DBAdress = dr[5].ToString();
                        DBCity = dr[6].ToString();
                        DBCountry = dr[7].ToString();
                        infoCurrency = dr[8].ToString();
                    }
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindingRepairs()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT MAX(id_service) FROM repairing_services LIMIT 1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    int id_service = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                    
                    txtIDService.Text = (id_service + 1).ToString();
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FindinServiceDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT status_service FROM repairing_services WHERE id_service='" + txtIDService.Text + "' AND status_service='0'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    btnDelete.Enabled = true;
                }
                else {
                    btnDelete.Enabled = false;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FindingClientDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client, fullname FROM Clients WHERE id_client='" + txtIdClient.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    txtClient.Text = dr[1].ToString();
                }
                else 
                {
                    txtClient.ResetText();
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private void SearchExist() {

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

       private void findingProduct() {
           try
           {
               MySqlConnection conn = DBUtils.GetDBConnection();
               conn.Open();

               MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_product, barcode, sold_price, tax_amount FROM products WHERE barcode='" + searchValue + "'", conn);

               MySqlDataReader dr = cmdDatabase.ExecuteReader();

               if (dr.Read() == true)
               {
                   currentRow = dr.GetString(0);
                   productPrice = dr.GetDecimal(2);
                   productTax = dr.GetDecimal(3);
               }
               conn.Close();
           }

           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

        private void InsertProductDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.barcode, products.description, products.sold_price FROM products WHERE products.barcode='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                
                if (dr.Read() == true)
                {
                    searchValue = dr.GetString(1);

                    rowExists = false;
                    SearchExist();

                    if (rowExists == true)
                    {
                        Decimal totalParts = Convert.ToDecimal(txtPartsCost.Text) + dr.GetDecimal(3);
                        txtPartsCost.Text = totalParts.ToString();
                        Int32 currentQty = Convert.ToInt32(dgw.Rows[updatingRow].Cells[3].Value) + 1;
                        dgw.Rows[updatingRow].Cells[3].Value = currentQty.ToString();
                    }
                    else
                    {
                        Decimal totalParts = Convert.ToDecimal(txtPartsCost.Text) + dr.GetDecimal(3);
                        txtPartsCost.Text = totalParts.ToString();

                        idDgw = dgw.Rows.Count + 1;
                        dgw.Rows.Add(idDgw, dr.GetString(1), dr.GetString(2), 1, dr.GetString(3));
                    }

                    idDgw = 0;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearFields() {
            txtIdClient.ResetText();
            txtDescription.ResetText();
            txtDescription2.ResetText();
            txtClient.ResetText();
            txtCost.Text = "0";
            txtVatCost.Text = "0";
            txtCostCurrency.Text = "0";
            txtVatCurrency.Text="0";
            txtHeader.ResetText();
            txtPartsCost.Text = "0";
            txtTotalCost.Text = "0";
            txtTotalCostCurrency.Text = "0";
            dgw.Rows.Clear();
            lblStatusService.ResetText();
        }

        private void FindingDGWDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.barcode, products.description, repairing_products_sold.qty, products.sold_price FROM repairing_products_sold LEFT JOIN products ON repairing_products_sold.id_product=products.id_product WHERE id_service='" + txtIDService.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                dgw.Rows.Clear();
                int i = 0;
                while (dr.Read() == true)
                {
                    i = i + 1;
                    dgw.Rows.Add(i, dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4));
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disabledKeys() {
            txtDescription.Enabled = false;
            txtDescription2.Enabled = false;
            dgw.Enabled = false;
            btnSuccess.Enabled = false;
            btnNotSuccess.Enabled = false;
            btnMinus.Enabled = false;
            btnPlus.Enabled = false;
            btnFindCl.Enabled = false;
            btnDelete.Enabled = false;
            btnFindProduct.Enabled = false;
            btnRemoveProd.Enabled = false;
            txtCost.Enabled = false;
            txtCostCurrency.Enabled = false;
            txtVatCurrency.Enabled = false;
            txtVatCost.Enabled = false;
            txtIdClient.Enabled = false;
            txtClient.Enabled = false;
            btnToService.Enabled = false;
            txtHeader.Enabled = false;
            btnPrint.Enabled = false;
        }

        private void enabledKeys()
        {
            txtDescription.Enabled = true;
            txtDescription2.Enabled = true;
            dgw.Enabled = true;
            btnSuccess.Enabled = true;
            btnNotSuccess.Enabled = true;
            btnMinus.Enabled = true;
            btnPlus.Enabled = true;
            btnFindCl.Enabled = true;
            btnDelete.Enabled = true;
            btnFindProduct.Enabled = true;
            btnRemoveProd.Enabled = true;
            txtCost.Enabled = true;
            txtVatCost.Enabled = true;
            txtCostCurrency.Enabled = true;
            txtVatCurrency.Enabled = true;
            btnDelete.Enabled = true;
            txtIdClient.Enabled = true;
            txtClient.Enabled = true;
            txtHeader.Enabled = true;
            btnPrint.Enabled = true;
        }

        private void checkemptyBoxes() {
            Decimal Cost=0;

            Decimal.TryParse(txtCostCurrency.Text, out Cost);

            if (Cost <= 0){
                MessageBox.Show("Jepeni shumen e kostos !", "Error empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error_val = true;
            }
            else if ((txtClient.Text == "") || (txtIdClient.Text == ""))
            {
                 MessageBox.Show("Gjejeni klientin !", "Error empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 error_val = true;
            }
            else if (txtIDService.Text == "")
            {
                MessageBox.Show("Krijoni numrin e servisit !", "Error empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error_val = true;
            }
            else if (txtHeader.Text == "")
            {
                MessageBox.Show("Shkruani titullin e servisit !", "Error empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error_val = true;
            }
            else
            {
                error_val = false;
            }
        }

        private void FindingServiceDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_service, id_client, vat_cost, total_cost, service_details, header_service, time_service, status_service, parts_cost, service_details2 FROM repairing_services WHERE id_service='" + txtIDService.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    txtIDService.Text = dr.GetString(0);
                    txtIdClient.Text = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    txtVatCurrency.Text = dr.IsDBNull(2) ? "" : dr.GetString(2);
                    txtCostCurrency.Text = dr.IsDBNull(3) ? "" : dr.GetString(3);
                    txtDescription.Text = dr.IsDBNull(4) ? "" : dr.GetString(4);
                    txtDescription2.Text = dr.IsDBNull(9) ? "" : dr.GetString(9);
                    txtHeader.Text = dr.IsDBNull(5) ? "" : dr.GetString(5);
                    txtPartsCost.Text = dr.IsDBNull(8) ? "" : dr.GetString(8);

                    DateTime date1 = Convert.ToDateTime(dr.GetString(6));
                    lblDateTime.Text = date1.ToString("yyyy-M-dd hh:m");

                    if (dr.GetInt32(7) == 0)
                    {
                        fetchServiceStat = 0;
                        lblStatusService.ForeColor = Color.Goldenrod;
                        statusLabel = "Duke servisuar !";
                        enabledKeys();
                        btnNotSuccess.Enabled = true;
                        btnSuccess.Enabled = true;
                        btnToService.Enabled = false;
                    }
                    else if (dr.GetInt32(7) == 1)
                    {
                        fetchServiceStat = 1;
                        lblStatusService.ForeColor = Color.ForestGreen;
                        statusLabel = "Servisuar me sukses !";
                        disabledKeys();
                    }
                    else if (dr.GetInt32(7) == 2)
                    {
                        fetchServiceStat = 2;
                        lblStatusService.ForeColor = Color.Red;
                        statusLabel = "Servisuar pa sukses !";
                        disabledKeys();
                    }

                    lblStatusService.Text = statusLabel;
                    UpdProd = true;
                }
               
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error finding service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            FindingRepairs();
            disabledKeys();
            FindingCurrencyDetails();
        }

        private void txtIDService_TextChanged(object sender, EventArgs e)
        {
            clearFields();

            UpdProd = false;
            FindingServiceDetails();

            if (UpdProd == true)
            {
                FindingDGWDetails();
                btnPrint.Enabled = true;
                btnDelete.Enabled = true;
            }
            else 
            {
                disabledKeys();
            }
        }

        private void txtIdClient_TextChanged(object sender, EventArgs e)
        {
            FindingClientDetails();
        }

        private void btnFindProduct_Click(object sender, EventArgs e)
        {
            frmFindProduct.sFormIndex = "PhoneService";
            frmFindProduct frm = new frmFindProduct(this);
            frm.ShowDialog();
        }

        private void btnFindCl_Click(object sender, EventArgs e)
        {
            frmFindClient.sFormIndex = "PhoneService";
            frmFindClient frm = new frmFindClient(this);
            frm.ShowDialog();
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text != "") { 
                InsertProductDetails();
                txtBarcode.Text = "";
            }
        }

        private void txtClient_TextChanged(object sender, EventArgs e)
        {

        }
        private void startNewService(){
            btnSuccess.Enabled = false;
            btnNotSuccess.Enabled = false;
            btnDelete.Enabled = false;
            btnToService.Enabled = true;
        }

        private void btnFindService_Click(object sender, EventArgs e)
        {
            frmFindService frm = new frmFindService(this);
            frm.ShowDialog();
        }

        private void btnNewService_Click(object sender, EventArgs e)
        {
            clearFields();
            FindingRepairs();
            enabledKeys();
            startNewService();
        }

        private void UpdateServiceStatus()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE repairing_services SET id_client='" + txtIdClient.Text + "', service_details='" + txtDescription.Text + "', service_details2='" + txtDescription2.Text + "', vat_cost='" + txtVatCurrency.Text + "', total_cost='" + txtCostCurrency.Text + "', time_service='" + dateTimeToday + "', status_service='" + serviceStatus + "', header_service='" + txtHeader.Text + "', parts_cost='" + txtPartsCost.Text + "' WHERE id_service='" + txtIDService.Text + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Gjendja servisit u ndryshua me sukses !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertProductstoList()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase1 = new MySqlCommand("DELETE FROM repairing_products_sold WHERE id_service = '" + txtIDService.Text + "'", conn);
                cmdDatabase1.ExecuteNonQuery();

                for (int i = 0; i < dgw.Rows.Count; i++)
                {
                    searchValue = dgw.Rows[i].Cells[1].Value.ToString();

                    findingProduct();
                    MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO repairing_products_sold(id_service, id_product, qty) VALUES ('" + txtIDService.Text + "', '" + currentRow + "', '" + dgw.Rows[i].Cells[3].Value.ToString() + "')", conn);
                    cmdDatabase.ExecuteNonQuery();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveToReload()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                for (int i = 0; i < dgw.Rows.Count; i++)
                {
                    MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM repairing_products_sold WHERE id_service='" + txtIDService.Text + "'", conn);
                    cmdDatabase.ExecuteNonQuery();

                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveProdFromList()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase1 = new MySqlCommand("DELETE FROM repairing_services WHERE id_service='" + txtIDService.Text + "'", conn);
                int i = cmdDatabase1.ExecuteNonQuery();

                MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM repairing_products_sold WHERE id_service='" + txtIDService.Text + "'", conn);
                cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Servisi u fshi me sukses !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnNewService.PerformClick();
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateService()
        {
            try
            {
                String dateToday = DateTime.Today.ToString("yyyy-MM-dd");

                MySqlConnection conn = DBUtils.GetDBConnection();

                conn.Open();

                Decimal Cost;

                Decimal.TryParse(txtCost.Text, out Cost);

                Decimal net_amount = Cost / Convert.ToDecimal(1.2);

                Decimal vatAmount = Math.Round(Convert.ToDecimal(txtCost.Text) - net_amount, 2);

                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO repairing_services(id_client, id_staff, service_details, service_details2, vat_cost, total_cost, time_service, status_service, header_service, parts_cost) VALUES ('" + txtIdClient.Text + "', '" + id_staff + "', '" + txtDescription.Text + "', '" + txtDescription2.Text + "', '" + txtVatCurrency.Text + "', '" + txtCostCurrency.Text + "', '" + dateTimeToday + "', '0', '" + txtHeader.Text + "', '" + txtPartsCost.Text + "')", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Servisimi u fillua me sukses !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    enabledKeys();
                    btnToService.Enabled = false;
                    UpdProd = true;
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateProdQty()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();


                for (int i = 0; i < dgw.Rows.Count; i++)
                {
                    searchValue = dgw.Rows[i].Cells[1].Value.ToString();

                    Decimal qty = 0;

                    Decimal.TryParse(dgw.Rows[i].Cells[3].Value.ToString(), out qty);

                    MySqlCommand cmdDatabase = new MySqlCommand("UPDATE products SET quantity=quantity-'" + qty + "' WHERE barcode='" + searchValue + "'", conn);
                    cmdDatabase.ExecuteNonQuery();
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void findInvoiceNumber()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT MAX(InvoiceNo+5) AS InvoiceNumber FROM POS ORDER BY InvoiceNo DESC", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    invoiceNumber = dr.GetInt32(0);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNotSuccess_Click(object sender, EventArgs e)
        {
            checkemptyBoxes();
            if (error_val == false) { 
                serviceStatus = 2;
                UpdateServiceStatus();
                RemoveToReload();
                InsertProductstoList();
                FindingRepairs();
            }
        }

        private void btnSuccess_Click(object sender, EventArgs e)
        {
            checkemptyBoxes();
            if (error_val == false) {
                serviceStatus = 1;
                UpdateServiceStatus();
                RemoveToReload();
                InsertProductstoList();
                updateProdQty();
                clearFields();
                FindingRepairs();
            }
        }

        private void PrintHandler(object sender, PrintPageEventArgs ppeArgs)
        {

            getCompanyDetails();

            DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
            string dateNow = dbDate1.ToString("dd-M-yy hh:m");

            Graphics graphics = ppeArgs.Graphics;
            System.Drawing.Font font = new System.Drawing.Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 5;
            int startY = 10;
            int Offset = 20;
            graphics.DrawString(DBCompanyName + "", new System.Drawing.Font("Courier New Bold", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 15;
            graphics.DrawString(DBCity + " " + DBAdress, new System.Drawing.Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 15;

            graphics.DrawString(dateNow, new System.Drawing.Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 15;

            graphics.DrawString("Numri Servisit.: " + txtIDService.Text, new System.Drawing.Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 15;

            string underLine = "-------------------";

            graphics.DrawString("Titulli Servisit :", new System.Drawing.Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 15;

            graphics.DrawString(txtHeader.Text.ToString(), new System.Drawing.Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 15;

            graphics.DrawString(underLine, new System.Drawing.Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 15;
            graphics.DrawString("Pershkrimi :", new System.Drawing.Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 15;
            graphics.DrawString(txtDescription.Text, new System.Drawing.Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);

            if (txtDescription2.Text.Length > 0)
            {
                Offset = Offset + 15;
                graphics.DrawString(txtDescription2.Text, new System.Drawing.Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            }

            Offset = Offset + 20;

            int a = dgw.Rows.Count;

            if (a > 0)
            {
                graphics.DrawString("Produktet e perfshira : ", new System.Drawing.Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + Offset);

                Offset = Offset + 15;

                for (int i = 0; i < a; i++)
                {
                    graphics.DrawString(dgw.Rows[i].Cells[3].Value.ToString() + " x " + dgw.Rows[i].Cells[2].Value.ToString(), new System.Drawing.Font("Courier New", 9), new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 15;                   
                }

                underLine2 = "--------------------------";
                graphics.DrawString(underLine2, new System.Drawing.Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 15;
            }

            graphics.DrawString("Total " + Convert.ToString(txtCostCurrency.Text) + " " + infoCurrency, new System.Drawing.Font("Corbel", 9), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

        }

        private void PrintIntoPos(string PrinterName)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrinterSettings.PrinterName = PrinterName;
            doc.PrintPage += new PrintPageEventHandler(PrintHandler);
            doc.Print();
        }

        private void CheckEnabledPosPrinter()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT printer_name, pos_printer FROM sys_printer_devices", conn);

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

        private void btnToService_Click(object sender, EventArgs e)
        {
            checkemptyBoxes();
            if (error_val == false){ 
                serviceStatus = 0;
                CreateService();
                InsertProductstoList();
                CheckEnabledPosPrinter();
                if (activatedPrinter==1)
                {
                    PrintIntoPos(printerName);
                }
            }
        }

       private void btnRemoveProd_Click(object sender, EventArgs e)
        {
            Decimal currentPrice = Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[4].Value);
            Decimal currentQty = Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[3].Value);
            Decimal partsCost = Convert.ToDecimal(txtPartsCost.Text) - (currentPrice * currentQty);
          
           foreach (DataGridViewCell oneCell in dgw.SelectedCells)
            {
                if (oneCell.Selected) { dgw.Rows.RemoveAt(oneCell.RowIndex); }
            }

            for (numbIncrement = 1; numbIncrement <= dgw.Rows.Count; numbIncrement++)
            {
                dgw.Rows[numbIncrement - 1].Cells[0].Value = numbIncrement;
            }

            txtPartsCost.Text = partsCost.ToString();

            MessageBox.Show("Produkti u fshi me sukses nga lista !", "Item Removed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                if (Convert.ToInt32(dgw.Rows[dgw.CurrentRow.Index].Cells[3].Value) >= 2)
                {
                    Decimal totalParts = Convert.ToDecimal(txtPartsCost.Text);

                    Decimal minusParts = Math.Round(totalParts - (Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[4].Value)), 2);
                    txtPartsCost.Text = minusParts.ToString();

                    dgw.Rows[dgw.CurrentRow.Index].Cells[3].Value = Convert.ToInt32(dgw.Rows[dgw.CurrentRow.Index].Cells[3].Value) - 1;
                }
                else
                {
                    MessageBox.Show("Produkti i fundit nuk mund te minusohet !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show("Lista e zbrazet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {

            if (dgw.Rows.Count > 0)
            {
                dgw.Rows[dgw.CurrentRow.Index].Cells[3].Value = Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[3].Value) + 1;

                Decimal totalParts = Convert.ToDecimal(txtPartsCost.Text);

                Decimal plusParts = Math.Round(totalParts + (Convert.ToDecimal(dgw.Rows[dgw.CurrentRow.Index].Cells[4].Value)),2);
                txtPartsCost.Text = plusParts.ToString();
            }
            else
            {
                MessageBox.Show("Lista e zbrazet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindingCurrencyDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT sys_currency.currency, sys_currency.amount FROM company LEFT JOIN sys_currency ON company.base_currency=sys_currency.id_currency WHERE company.id_company='1'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    infoCurrency = dr.GetString(0);
                    amountCurrency = dr.GetDecimal(1);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error finding service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            Decimal Cost = 0;
            Decimal PartsCost = 0;
            Decimal.TryParse(txtCost.Text, out Cost);
            Decimal.TryParse(txtPartsCost.Text, out PartsCost);
                
                if (Cost > 0)
                {
                    Decimal.TryParse(txtCost.Text, out Cost);

                    Decimal net_amount = Cost / Convert.ToDecimal(1.2);

                    Decimal vatAmount = Math.Round(Convert.ToDecimal(txtCost.Text) - net_amount, 2);

                    Decimal AmountCurrency = Math.Round(Cost * amountCurrency, 2);

                    Decimal partsWithoutAmount = Math.Round(Cost - (PartsCost / amountCurrency), 2);

                    if (txtCost.Focused == true)
                    {
                        txtCostCurrency.Text = AmountCurrency.ToString();
                    }

                    txtTotalCost.Text = partsWithoutAmount.ToString();
                    txtVatCost.Text = vatAmount.ToString();
                }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((fetchServiceStat == 0) || (fetchServiceStat == 2))
            {
                RemoveProdFromList();
            }
            else 
            {
                MessageBox.Show("Serviset e servisuara nuk mund te fshihen", "Error removing service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
             checkemptyBoxes();
                if (error_val == false) {
                CheckEnabledPosPrinter();
                if (activatedPrinter == 1)
                {
                    PrintIntoPos(printerName);
                }
            }
        }

        private void txtCostCurrency_TextChanged(object sender, EventArgs e)
        {
            Decimal Cost=0;
            Decimal PartsCost = 0;
            Decimal TotalCostCurrency = 0;
            Decimal.TryParse(txtCostCurrency.Text, out Cost);
            Decimal.TryParse(txtPartsCost.Text, out PartsCost);
            Decimal.TryParse(txtTotalCostCurrency.Text, out TotalCostCurrency);
                
                if (Cost > 0)
                {
                    Decimal.TryParse(txtCostCurrency.Text, out Cost);

                    Decimal net_amount = Cost / Convert.ToDecimal(1.2);

                    Decimal vatAmount = Math.Round(Convert.ToDecimal(txtCostCurrency.Text) - net_amount, 2);

                    Decimal vatToCurrency = Math.Round(vatAmount / amountCurrency, 2);

                    Decimal AmountCurrency = Math.Round(Cost / amountCurrency, 2);

                    
                    if (txtCostCurrency.Focused == true) { 
                        txtCost.Text = AmountCurrency.ToString();
                    }

                    txtVatCurrency.Text = vatAmount.ToString();

                    TotalCostCurrency = Cost - PartsCost;

                    txtTotalCostCurrency.Text = TotalCostCurrency.ToString();
                }
        }

        private void txtTotalCostCurrency_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtTotalCost_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtPartsCost_TextChanged(object sender, EventArgs e)
        {
            Decimal costTotal = 0;
            Decimal.TryParse(txtCostCurrency.Text, out costTotal);

            txtCostCurrency.Text = "";
            txtCostCurrency.Text = costTotal.ToString();

        }

        private void txtVatCurrency_TextChanged(object sender, EventArgs e)
        {

        }


        private void PrintPage(object o, PrintPageEventArgs e)
        {

        }

    }
}