using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Supermarkets
{
    public partial class frmBalanceSoldInvoice : Form
    {
        //Forms
        public static string sFormIndex;

        //Company Info
        private static String DBCompanyName;
        private static String DBManager;
        private static String DBContactNumber;
        private static String DBAdress;
        private static String DBCity;
        private static String DBCountry;
        private static String infoCurrency;

        //Distributor Info
        public static string id_client;
        private static String ClientBankaAccount;
        private static String ClientName;
        private static String otherDetails;

        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
        private static String randomNumber;

        public frmBalanceSoldInvoice()
        {
            InitializeComponent();
        }

        // Returning result values
        public string FindInvoiceCode
        {
            get { return txtBarcode.Text; }
            set { txtBarcode.Text = value; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmFindBalanceSold.sFormIndex = "frmPDFInvoiceDetail";
            frmFindBalanceSold frm = new frmFindBalanceSold(this);
            frm.Show();
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.F))
            {
                btnBrowse.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.N))
            {
                btnClear.PerformClick();
                return true;
            }

            if (keyData == Keys.Enter)
            {
                btnInsert.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                btnExportSold.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void ResearchTable()
        {
            lblTotalAmount.ResetText();
            lblSumVat.ResetText();
        }

        private void ClearTable()
        {
            dgw.Rows.Clear();
            lblTotalAmount.ResetText();
            lblSumVat.ResetText();
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

        private void getClientDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client, fullname, other_details, date_registration, active FROM clients WHERE id_client='" + id_client + "'", conn);
                
                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    ClientBankaAccount = dr[0].ToString();
                    ClientName = dr[1].ToString();
                    otherDetails = dr[2].ToString();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BalanceInvoice()
        {
            try
            {
                DateTime dbDate1 = Convert.ToDateTime(lblDebtDate.Text);
                string debtDate = dbDate1.ToString("yyyy-M-dd");

                MySqlConnection conn = DBUtils.GetDBConnection();

                conn.Open();
                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO paiddebts (InvoiceNo, StaffID, CustomerNo, debtValue, debtDate, paidDate, type_payment) VALUES('" + txtBarcode.Text + "', '" + frmMain.id_employee + "', '" + lblIdClient.Text + "', '" + lblTotalAmount.Text + "', '" + debtDate + "', '" + dateTimeToday + "', '2')", conn);
                cmdDatabase.ExecuteNonQuery();
                
                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Fatura u balansua me sukses", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      private void removeBalancedInvoice(){
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();

                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM client_debts WHERE InvoiceNo='" + txtBarcode.Text + "'", conn);
                cmdDatabase.ExecuteNonQuery();

                cmdDatabase.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindData()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.barcode, products.description, posdetails.Quantity, posdetails.discount_percentage, posdetails.vatAmount, posdetails.ProductPrice FROM posdetails LEFT JOIN client_debts ON posdetails.InvoiceNo=client_debts.InvoiceNo LEFT JOIN products ON posdetails.id_product=products.id_product LEFT JOIN clients ON client_debts.id_client=clients.id_client LEFT JOIN users ON client_debts.StaffID=users.id_user WHERE posdetails.InvoiceNo='" + txtBarcode.Text + "' ORDER BY posdetails.ProductPrice", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    dgw.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindCLient()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client FROM POS WHERE InvoiceNo='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read() == true)
                {
                    id_client = dr.IsDBNull(0) ? "0.00" : dr.GetString(0);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindTotals()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT SUM(posdetails.Quantity) AS quantity, SUM(posdetails.discount_amount) AS discount, SUM(posdetails.vatAmount) AS VatAmount, SUM(posdetails.ProductPrice) AS productprice, clients.id_client, clients.fullname, posdetails.InvoiceNo, users.username, client_debts.debtDate FROM posdetails LEFT JOIN client_debts ON posdetails.InvoiceNo=client_debts.InvoiceNo LEFT JOIN products ON posdetails.id_product=products.id_product LEFT JOIN clients ON client_debts.id_client=clients.id_client LEFT JOIN users ON client_debts.StaffID=users.id_user WHERE posdetails.InvoiceNo='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read()==true)
                {
                    string SumVat = dr.IsDBNull(2) ? "0.00" : dr.GetString(2);
                    string TotalCos = dr.IsDBNull(3) ? "0.00" : dr.GetString(3);

                    lblIdClient.Text = dr.IsDBNull(4) ? "" : dr.GetString(4);
                    lblFullName.Text = dr.IsDBNull(5) ? "" : dr.GetString(5);
                    lblEmployee.Text = dr.IsDBNull(7) ? "" : dr.GetString(7);
                    lblDebtDate.Text = dr.IsDBNull(8) ? "00-00-0000" : dr.GetString(8);

                    lblSumVat.Text = string.Format("{0:#,##0.##}", SumVat);
                    lblTotalAmount.Text = string.Format("{0:#,##0.##}", TotalCos);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text == "")
            {
                MessageBox.Show("Please choose the invoice code !", "Empty Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarcode.Focus();
                btnExportSold.Enabled = false;
                btnBalance.Enabled = false;
            }
            else
            {
                ResearchTable();
                FindData();
                FindCLient();
                FindTotals();
                btnExportSold.Enabled = true;
                btnBalance.Enabled = true;
            }
        }

        private void frmBalanceSoldInvoice_Load(object sender, EventArgs e)
        {
            btnExportSold.Enabled = false;
            btnBalance.Enabled = false;
            btnInsert.Enabled = false;
            btnClear.Enabled = false;
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text == "") { btnInsert.Enabled = false; btnClear.Enabled = false; } else { btnInsert.Enabled = true; btnClear.Enabled = true; }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnExportSold.Enabled = false;
            btnBalance.Enabled = false;
            btnInsert.Enabled = false;
            btnClear.Enabled = false;
            dgw.Rows.Clear();

            txtBarcode.Text = "";
            lblSumVat.Text = "0.00";
            lblTotalAmount.Text = "0.00";
            lblFullName.Text = "";
            lblIdClient.Text = "";
        }

        private void exportDoc()
        {
            FindCLient();
            getCompanyDetails();
            FindTotals();
            getClientDetails();

            //Header Left Table
            PdfPTable pdfTable2 = new PdfPTable(2);
            pdfTable2.DefaultCell.MinimumHeight = 20.0F;
            pdfTable2.WidthPercentage = 95;

            PdfPCell Tablecell1 = new PdfPCell();
            PdfPCell Tablecell2 = new PdfPCell();
            Paragraph p1 = new Paragraph();
            Paragraph p2 = new Paragraph();

            //   p1.Add(new Paragraph("Invoice Processing Number -  ", Classes.UserFonts.GetBoldFont()));
            p1.Add(new Paragraph("[" + DBCompanyName + "]", Classes.UserFonts.fontNeue20()));
            p1.Add(new Paragraph("Rruga, Adresa : ", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph("[" + DBAdress + ", " + DBCity + ", " + DBCountry + "]", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph("Telefoni : ", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph("[" + DBContactNumber + "]", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph(""));

            //   p1.Add(new Paragraph("Invoice Processing Number -  ", Classes.UserFonts.GetBoldFont()));
            p2.Alignment = Element.ALIGN_RIGHT;
            p2.Add(new Paragraph("[" + ClientName + "]", Classes.UserFonts.fontNeue20()));
            p2.Add(new Paragraph("Rruga, Adresa : ", Classes.UserFonts.FontBold14()));
            p2.Add(new Paragraph("[" + otherDetails + "]", Classes.UserFonts.FontBold12()));
            p2.Add(new Paragraph(""));

            Tablecell1.AddElement(p1);
            Tablecell2.AddElement(p2);

            pdfTable2.AddCell(Tablecell1);

            pdfTable2.AddCell(Tablecell2);

            //Starting Sums
            //Bottom Table
            PdfPTable pdfTable4 = new PdfPTable(6);

            pdfTable4.DefaultCell.Padding = 3;
            pdfTable4.WidthPercentage = 95;
            pdfTable4.DefaultCell.MinimumHeight = 40.0F;
            pdfTable4.DefaultCell.SetLeading(4.5F, 1);
            pdfTable4.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable4.DefaultCell.BorderWidth = 0;
            pdfTable4.AddCell("");
            pdfTable4.AddCell("");
            pdfTable4.AddCell("");
            pdfTable4.AddCell("");

            PdfPCell Tablecell4 = new PdfPCell();
            Paragraph p4 = new Paragraph();
            //Bottom
            p4.Add(new Phrase("Shuma Zbritjes ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));

            p4.Add(new Phrase("Shuma Takses ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));

            p4.Add(new Phrase("Vlera Totale ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));

            //Values
            PdfPCell Tablecell5 = new PdfPCell();
            Paragraph p5 = new Paragraph();


            p5.Add(new Phrase(" " + lblSumVat.Text + " " + infoCurrency + " ", Classes.UserFonts.FontBold14()));
            p5.Add(new Paragraph(" "));

            p5.Add(new Phrase(" " + lblTotalAmount.Text + " " + infoCurrency + " ", Classes.UserFonts.FontBold14()));
            p5.Add(new Paragraph(" "));

            Tablecell4.BorderWidth = 0;

            p4.Alignment = Element.ALIGN_RIGHT;
            p5.Alignment = Element.ALIGN_LEFT;

            Tablecell4.AddElement(p4);
            pdfTable4.AddCell(Tablecell4);

            Tablecell5.AddElement(p5);
            pdfTable4.AddCell(Tablecell5);
            //Ending Sums

            //Starting Signature
            PdfPTable pdfTable6 = new PdfPTable(4);
            PdfPCell Tablecell6 = new PdfPCell();

            Paragraph p6 = new Paragraph();
            //Titles
            p6.Add(new Paragraph(" "));
            p6.Add(new Phrase("Data Sot: ", Classes.UserFonts.FontBold14()));
            p6.Add(new Phrase(dateTimeToday, Classes.UserFonts.FontBold14()));

            p6.Add(new Paragraph(" "));
            p6.Add(new Paragraph(" "));

            p6.Add(new Phrase("____________", Classes.UserFonts.FontBold14()));
            p6.Add(new Paragraph(" "));

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
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
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
                        pdfTable.AddCell(cell.Value.ToString());
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
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable2);
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(pdfTable4);
                pdfDoc.Add(pdfTable6);
                pdfDoc.Close();
                stream.Close();
            }
        }

        private void ClearSearch()
        {
            dgw.Rows.Clear();
            txtBarcode.ResetText();
            btnBalance.Enabled = false;
            btnExportSold.Enabled = false;
            btnClear.Enabled = false;


            lblSumVat.Text = "0.00";
            lblTotalAmount.Text = "0.00";
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni ta balansoni faturën ?", "Balance invoice !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                BalanceInvoice();
                removeBalancedInvoice();

                exportDoc();
                System.Diagnostics.Process.Start("C:/PDFs/" + randomNumber + ".pdf");
                ClearSearch();
            }
        }

        private void btnExportSold_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni ta krijoni fajlin PDF ?", "Downloading invoice !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                exportDoc();
                System.Diagnostics.Process.Start("C:/PDFs/" + randomNumber + ".pdf");
            }
        }
    }
}