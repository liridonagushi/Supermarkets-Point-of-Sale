using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    public partial class frmBalanceStockin : Form
    {
        //Tables
        private static String randomNumber;
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
        public static string id_distributor;
        private static String DistBankAccount;
        private static String DistCompanyName;
        private static String DistContactNumber;
        private static String DistAdress;
        private static String DistCity;
        private static String DistCountry;

        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
        
        public frmBalanceStockin()
        {
            InitializeComponent();
        }

        // Returning result values
        public string FindInvoiceCode
        {
            get { return txtBarcode.Text; }
            set { txtBarcode.Text = value; }
        }

        private void FindData()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.barcode, products.description, invoiceprocessing.stocks_insert, invoiceprocessing.import_amount, invoiceprocessing.vatPerc, invoiceprocessing.vat_amount, invoiceprocessing.unit_price, invoiceprocessing.sell_amount, invoiceprocessing.id_distributor FROM invoiceprocessing LEFT JOIN distributors ON invoiceprocessing.id_distributor=distributors.id_distributor LEFT JOIN products ON invoiceprocessing.id_product=products.id_product WHERE invoiceprocessing.invoice_code='" + txtBarcode.Text + "' ORDER BY invoiceprocessing.id_order", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                Decimal Qty = 0;
                Decimal SumVat = 0;
                Decimal TotalCos = 0;
                Decimal TotalImpAmount = 0;

                while (dr.Read() == true)
                {
                    Decimal QtyIns = dr.IsDBNull(2) ? 0 : dr.GetDecimal(2);
                    Decimal ImpAmount = dr.IsDBNull(3) ? 0 : dr.GetDecimal(3);
                    Decimal VatPerc = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                    Decimal VatIns = dr.IsDBNull(5) ? 0 : dr.GetDecimal(5);
                    Decimal PriceIns = dr.IsDBNull(6) ? 0 : dr.GetDecimal(6);
                    Decimal TotalIns = dr.IsDBNull(7) ? 0 : dr.GetDecimal(7);

                    Qty += QtyIns;
                    SumVat += VatIns;
                    TotalCos += TotalIns;
                    TotalImpAmount += ImpAmount;

                    Qty += QtyIns;

                    id_distributor = dr.GetString(8);
                    dgw.Rows.Add(dr[0], dr[1], QtyIns, ImpAmount, VatPerc, VatIns, PriceIns, TotalIns);
                }
                lblImpAmount.Text = string.Format("{0:#,##0.##}", TotalImpAmount);
                lblQuantity.Text = string.Format("{0:#,##0.##}", Qty);
                lblSumVat.Text = string.Format("{0:#,##0.##}", SumVat);
                lblTotalCost.Text = string.Format("{0:#,##0.##}", TotalCos);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void getDistributorDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT BankAccountNumber, company, adress, city, country, phone FROM distributors WHERE id_distributor='" + id_distributor + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                        DistBankAccount = dr[0].ToString();
                        DistCompanyName = dr[1].ToString();
                        DistAdress = dr[2].ToString();
                        DistCity = dr[3].ToString();
                        DistCountry = dr[4].ToString();
                        DistContactNumber = dr[5].ToString();
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportDoc()
        {
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
            p1.Add(new Paragraph("[" + DBCompanyName + "]", Classes.UserFonts.fontNeue20()));
            p1.Add(new Paragraph("Rruga, Adresa : ", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph("[" + DBAdress + ", " + DBCity + ", " + DBCountry + "]", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph("Telefoni : ", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph("[" + DBContactNumber + "]", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph(""));

            //   p1.Add(new Paragraph("Invoice Processing Number -  ", Classes.UserFonts.GetBoldFont()));
            p2.Alignment = Element.ALIGN_RIGHT;
            p2.Add(new Paragraph("[" + DistCompanyName + "]", Classes.UserFonts.fontNeue20()));
            p2.Add(new Paragraph("Rruga, Adresa : ", Classes.UserFonts.FontBold14()));
            p2.Add(new Paragraph("[" + DistAdress + ", " + DistCity + ", " + DistCountry + "]", Classes.UserFonts.FontBold14()));
            p2.Add(new Paragraph("Telefoni : ", Classes.UserFonts.FontBold14()));
            p2.Add(new Paragraph("[" + DistContactNumber + "]", Classes.UserFonts.FontBold14()));
            p2.Add(new Paragraph(""));

            Tablecell1.AddElement(p1);
            Tablecell2.AddElement(p2);

            pdfTable2.AddCell(Tablecell1);


            pdfTable2.AddCell(Tablecell2);

            //Starting Sums
            //Bottom Table
            PdfPTable pdfTable4 = new PdfPTable(5);

            pdfTable4.DefaultCell.Padding = 3;
            pdfTable4.WidthPercentage = 95;
            pdfTable4.DefaultCell.MinimumHeight = 40.0F;
            pdfTable4.DefaultCell.SetLeading(4.5F, 1);
            pdfTable4.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable4.DefaultCell.BorderWidth = 0;
            pdfTable4.AddCell("");
            pdfTable4.AddCell("");
            pdfTable4.AddCell("");

            PdfPCell Tablecell4 = new PdfPCell();
            Paragraph p4 = new Paragraph();
            //Bottom
            p4.Add(new Phrase("Sasia Produkteve ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));

            p4.Add(new Phrase("Shuma Importit ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));
            
            p4.Add(new Phrase("Shuma Takses ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));

            p4.Add(new Phrase("Shuma Totale ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));

            //Values
            PdfPCell Tablecell5 = new PdfPCell();
            Paragraph p5 = new Paragraph();
            p5.Add(new Phrase(" " + lblQuantity.Text + " ", Classes.UserFonts.FontBold14()));
            p5.Add(new Paragraph(" "));
            p5.Add(new Phrase(" " + lblImpAmount.Text + " " + infoCurrency + "", Classes.UserFonts.FontBold14()));
            p5.Add(new Paragraph(" "));
            p5.Add(new Phrase(" " + lblSumVat.Text + " " + infoCurrency + "", Classes.UserFonts.FontBold14()));
            p5.Add(new Paragraph(" "));
            p5.Add(new Phrase(" " + lblTotalCost.Text + " " + infoCurrency + "", Classes.UserFonts.FontBold14()));
            p5.Add(new Paragraph(" "));

            Tablecell4.BorderWidth = 0;

            p4.Alignment = Element.ALIGN_RIGHT;
            p5.Alignment = Element.ALIGN_LEFT;

            Tablecell4.AddElement(p4);
            Tablecell5.AddElement(p5);
            pdfTable4.AddCell(Tablecell4);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void ResearchTable()
        {
            lblTotalCost.ResetText();
            lblSumVat.ResetText();
        }

        private void ClearTable()
        {
            dgw.Rows.Clear();
            lblTotalCost.ResetText();
            lblSumVat.ResetText();
        }

        private void ClearSearch()
        {
            dgw.Rows.Clear();
            txtBarcode.ResetText();
            btnExpPDF.Enabled = false;
            btnBalanceSold.Enabled = false;
            btnInsert.Enabled = false;
            btnClear.Enabled = false;

            lblSumVat.Text = "0.00";
            lblTotalCost.Text = "0.00";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            frmFindBalanceStockIn.sFormIndex = "BalanceStockin";
            frmFindBalanceStockIn frm = new frmFindBalanceStockIn(this);
            frm.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text == "")
            {
                MessageBox.Show("Ju lutem zgjedheni numrin e faturës !", "Empty Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarcode.Focus();
            }
            else
            {
                ResearchTable();
                FindData();
                btnExpPDF.Enabled = true;
                btnBalanceSold.Enabled = true;
            }
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
                btnExpPDF.PerformClick();
                return true;
            }

            if (keyData == Keys.F5)
            {
                btnBalanceSold.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmBalanceStockin_Load(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            btnBalanceSold.Enabled = false;
            btnExpPDF.Enabled = false;
            btnInsert.Enabled = false;
            btnClear.Enabled = false;

        }

        private void btnExpPDF_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni ta krijoni fajlin PDF ?", "Downloading invoice !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                exportDoc();
                System.Diagnostics.Process.Start("C:/PDFs/" + randomNumber + ".pdf");
            }
        }

        private void UpdateBalance()
        {

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE imp_invoices SET payment_status=1 WHERE invoice_code='" + txtBarcode.Text + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Numri fatures: " + txtBarcode.Text + " u balansua me sukses !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBalanceSold_Click(object sender, EventArgs e)
        {
             DialogResult dialogResult = MessageBox.Show("A doni ta balansoni kete fatur ?", "Balancing invoice !", MessageBoxButtons.YesNo);
             if (dialogResult == DialogResult.Yes)
             {
                 UpdateBalance();
                 exportDoc();
                 System.Diagnostics.Process.Start("C:/PDFs/" + randomNumber + ".pdf");
                 ClearSearch();
             }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text == "") { btnInsert.Enabled = false; btnClear.Enabled = false; } else { btnInsert.Enabled = true; btnClear.Enabled = true; }
        }

  
    }
}