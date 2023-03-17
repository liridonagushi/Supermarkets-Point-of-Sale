using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Supermarkets
{
    public partial class frmPDFInvoiceDetail : Form
    {
        //Tables
        private static String randomNumber;
        public static string sFormIndex;

        //Company Info
        private static String DBCompanyName, DBManager, DBContactNumber, DBAdress, DBCity, DBCountry, infoCurrency;

        //Distributor Info
        private static String DistCompanyName, DistManager, DistContactNumber, DistAdress, DistCity, DistCountry;

        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");

        private static Int32 id_distributor;

        public frmPDFInvoiceDetail()
        {
            InitializeComponent();
        }

        // Returning result values
        public string FindInvoiceCode
        {
            get { return txtInvoiceCode.Text; }
            set { txtInvoiceCode.Text = value; }
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                btnLoad.PerformClick();
                return true;
            }

            if (keyData == (Keys.Delete))
            {
                btnClear.PerformClick();
                return true;
            }

            if (keyData == Keys.Enter)
            {
                btnIns.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                btnExpPDF.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FindData()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT invoiceprocessing.invoice_code, products.barcode, products.description, invoiceprocessing.stockstotal, invoiceprocessing.stocks_insert, invoiceprocessing.import_amount, invoiceprocessing.vatPerc, invoiceprocessing.vat_amount,  invoiceprocessing.unit_price, invoiceprocessing.sell_amount FROM invoiceprocessing LEFT JOIN products ON invoiceprocessing.id_product=products.id_product  WHERE invoiceprocessing.invoice_code='" + txtInvoiceCode.Text + "' ORDER BY invoiceprocessing.unit_price", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();
                if (dr.HasRows)
                {
                    Decimal calcImp = 0;
                    Decimal calcTotal = 0;
                    while (dr.Read() == true)
                    {
                        Decimal totalStocks = dr.IsDBNull(3) ? 0 : dr.GetDecimal(3);
                        Decimal QtyIns = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                        Decimal totalImp = dr.IsDBNull(5) ? 0 : dr.GetDecimal(5);
                        Decimal taxPerc = dr.IsDBNull(6) ? 0 : dr.GetDecimal(6);
                        Decimal taxAmount = dr.IsDBNull(7) ? 0 : dr.GetDecimal(7);
                        Decimal unityPrice = dr.IsDBNull(8) ? 0 : dr.GetDecimal(8);
                        Decimal totalPrice = dr.IsDBNull(9) ? 0 : dr.GetDecimal(9);

                        calcImp += totalImp;
                        calcTotal += totalPrice;

                        dgw.Rows.Add(dr[0], dr[1], dr[2], totalStocks, QtyIns, totalImp, taxPerc, taxAmount, unityPrice, totalPrice);
                    }

                    lblImportAmount.Text = string.Format("{0:#,##0.##}", calcImp);
                    lblTotalCost.Text = string.Format("{0:#,##0.##}", calcTotal);
                    btnExpPDF.Enabled = true;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindInvoiceDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT imp_invoices.id_distributor, imp_invoices.date_invoice, imp_invoices.date_registration, imp_invoices.date_payment, imp_invoices.importAmount, imp_invoices.totalAmount, type_payments.type_payment FROM imp_invoices LEFT JOIN type_payments ON imp_invoices.id_type_payment=type_payments.id_type_payment WHERE imp_invoices.invoice_code='" + txtInvoiceCode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read()==true)
                {
                    id_distributor = dr.GetInt32(0);

                    DateTime date1 = Convert.ToDateTime(dr.GetString(1));
                    DateTime date2 = Convert.ToDateTime(dr.GetString(2));
                    DateTime date3 = Convert.ToDateTime(dr.GetString(3));

                    lblDateRegistration.Text = date1.ToString("dd-M-yyyy");
                    lblDateFacture.Text = date2.ToString("dd-M-yyyy");
                    lblPaymentDate.Text = date3.ToString("dd-M-yyyy");
                    lblImportAmount.Text = dr.GetString(4);
                    lblTotalCost.Text = dr.GetString(5);
                    lblType_Payments.Text = dr.GetString(6);
                }

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

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT company, fullname, phone, adress, city, country FROM distributors WHERE id_distributor='" + id_distributor + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
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

        private void exportDoc()
        {
            FindInvoiceDetails();
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
            p3.Add(new Paragraph(lblDateFacture.Text, Classes.UserFonts.FontBold12()));
            p3.Add(new Phrase("Data Pageses : ", Classes.UserFonts.GetBoldFont()));
            p3.Add(new Paragraph(lblPaymentDate.Text, Classes.UserFonts.FontBold12()));
            p3.Add(new Phrase("Menyra Pageses : ", Classes.UserFonts.GetBoldFont()));
            p3.Add(new Paragraph(lblType_Payments.Text, Classes.UserFonts.FontBold12()));
            p3.Add(new Paragraph(""));


            Tablecell3.AddElement(p3);
            pdfTable3.AddCell(Tablecell3);
            //Ending Middle Table

            //Starting Sums
            //Bottom Table
            PdfPTable pdfTable4 = new PdfPTable(2);

            pdfTable4.DefaultCell.Padding = 3;
            pdfTable4.WidthPercentage = 95;
            pdfTable4.DefaultCell.MinimumHeight = 40.0F;
            pdfTable4.DefaultCell.SetLeading(4.5F, 1);
            pdfTable4.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable4.DefaultCell.BorderWidth = 0;

            PdfPCell Tablecell42 = new PdfPCell();
            PdfPCell Tablecell44 = new PdfPCell();
            Paragraph p42 = new Paragraph();
            Paragraph p44 = new Paragraph();

            //Titles
            p42.Add(new Phrase("Shuma Importit ", Classes.UserFonts.FontBold12()));
            p42.Add(new Phrase(" " + lblImportAmount.Text + " " + infoCurrency + " ", Classes.UserFonts.FontBold12()));

            p44.Add(new Phrase("Shuma Totale ", Classes.UserFonts.FontBold12()));
            p44.Add(new Phrase(" " + lblTotalCost.Text + " " + infoCurrency + " ", Classes.UserFonts.FontBold12()));

            //Values
            //Tablecell41.BorderWidth = 0;
            // p4.Alignment = Element.ALIGN_RIGHT;
            //p5.Alignment = Element.ALIGN_LEFT;

            Tablecell42.AddElement(p42);
            pdfTable4.AddCell(Tablecell42);

            Tablecell44.AddElement(p44);
            pdfTable4.AddCell(Tablecell44);
            //Ending Sums

            //Starting Signature
            PdfPTable pdfTable6 = new PdfPTable(4);
            PdfPCell Tablecell6 = new PdfPCell();

            Paragraph p6 = new Paragraph();
            //Titles
            p6.Add(new Paragraph("Data Sot: ", Classes.UserFonts.FontBold12()));
            p6.Add(new Paragraph(dateTimeToday, Classes.UserFonts.FontBold12()));

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

        private void btnExpPDF_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni ta krijoni fajlin PDF ?", "Invoice Completed !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                exportDoc();
                System.Diagnostics.Process.Start("C:/PDFs/" + randomNumber + ".pdf");
                ClearSearch();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void ResearchTable()
        {
            lblTotalCost.ResetText();
            lblImportAmount.ResetText();
        }

        private void ClearTable()
        {
            dgw.Rows.Clear();
            lblTotalCost.ResetText();
            lblImportAmount.ResetText();
        }

        private void ClearSearch()
        {
            dgw.Rows.Clear();
            txtInvoiceCode.ResetText();
            btnExpPDF.Enabled = false;
            lblImportAmount.Text = "0.00";
            lblTotalCost.Text = "0.00";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            frmFindImpInvoices.sFormIndex = "frmPDFInvoiceDetail";
            frmFindImpInvoices frm = new frmFindImpInvoices(this);
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtInvoiceCode.Text == "")
            {
                MessageBox.Show("Ju lutem zgjedheni kodin e fatures !", "Empty Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvoiceCode.Focus();
            }
            else
            {
                FindInvoiceDetails();
                ResearchTable();
                FindData();
            }
        }

        private void frmPDFInvoiceDetail_Load(object sender, EventArgs e)
        {
            btnExpPDF.Enabled = false;
        }
    }
}