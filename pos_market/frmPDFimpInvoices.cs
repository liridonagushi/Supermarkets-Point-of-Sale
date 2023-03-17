using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    public partial class frmPDFimpInvoices : Form
    {

        //Company Info
        private static String DBCompanyName;
        private static String DBManager;
        private static String DBContactNumber;
        private static String DBAdress;
        private static String DBCity;
        private static String DBCountry;
        private static String infoCurrency;

        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
        private static String randomNumber, firstDate, secondDate, searchDistribut;

        public frmPDFimpInvoices()
        {
            InitializeComponent();
        }

        private void getCompanyDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT company.companyName, company.manager, company.contactNumber, company.CompanySN, company.BANK_Number, company.adress, company.city, company.country, sys_currency.currency FROM company LEFT JOIN sys_currency ON company.id_currency=sys_currency.id_currency WHERE company.id_company = 1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows)
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

        private void FillingCombobox()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT BankAccountNumber, company FROM distributors", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows)
                {
                    txtDistributor.Items.Clear();

                    txtDistributor.Items.Add("");

                    while (dr.Read() == true)
                    {
                        txtDistributor.Items.Add(dr[0].ToString() + " " + dr[1].ToString());
                    }
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

            //Header Left Table
            PdfPTable pdfTable2 = new PdfPTable(1);
            pdfTable2.DefaultCell.MinimumHeight = 20.0F;
            pdfTable2.WidthPercentage = 95;

            PdfPCell Tablecell1 = new PdfPCell();
            Paragraph p1 = new Paragraph();

            //   p1.Add(new Paragraph("Invoice Processing Number -  ", Classes.UserFonts.GetBoldFont()));
            p1.Add(new Paragraph("[" + DBCompanyName + "]", Classes.UserFonts.fontNeue20()));
            p1.Add(new Paragraph("Rruga, Adresa : ", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph("[" + DBAdress + ", " + DBCity + ", " + DBCountry + "]", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph("Telefoni : ", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph("[" + DBContactNumber + "]", Classes.UserFonts.FontBold14()));
            p1.Add(new Paragraph(""));


            Tablecell1.AddElement(p1);

            pdfTable2.AddCell(Tablecell1);

            //Starting Sums
            //Bottom Table
            PdfPTable pdfTable4 = new PdfPTable(4);

            pdfTable4.DefaultCell.Padding = 3;
            pdfTable4.WidthPercentage = 95;
            pdfTable4.DefaultCell.MinimumHeight = 40.0F;
            pdfTable4.DefaultCell.SetLeading(4.5F, 1);
            pdfTable4.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable4.DefaultCell.BorderWidth = 0;
            pdfTable4.AddCell("");
            pdfTable4.AddCell("");

            PdfPCell Tablecell4 = new PdfPCell();
            Paragraph p4 = new Paragraph();
            //Titles
            p4.Add(new Phrase("Shuma Importit ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));


            p4.Add(new Phrase("Shuma Total ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));

            //Values
            PdfPCell Tablecell5 = new PdfPCell();
            Paragraph p5 = new Paragraph();

            p5.Add(new Phrase(" " + lblImportAmount.Text + " " + infoCurrency + " ", Classes.UserFonts.FontBold14()));
            p5.Add(new Paragraph(" "));

            p5.Add(new Phrase(" " + lblTotalCost.Text + " " + infoCurrency + " ", Classes.UserFonts.FontBold14()));
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni ta krijoni fajlin PDF ?", "Invoice Completed !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                exportDoc();
                System.Diagnostics.Process.Start("C:/PDFs/" + randomNumber + ".pdf");
                //ClearSearch();
            }
        }

        private void FindData() {
            //FillingCombobox();
            searchDistribut = "";
            var sqlstring = "";
            DateTime date1 = Convert.ToDateTime(dtStartDate.Text);
            string querydate1 = date1.ToString("yyyy-M-dd");

            DateTime date2 = Convert.ToDateTime(dtEndDate.Text);
            string querydate2 = date2.ToString("yyyy-M-dd");

            if (txtDistributor.Text != "")
            {
                var SearchDistributor = txtDistributor.Text.ToString().Split(' ')[0];
                searchDistribut = " AND distributors.BankAccountNumber = '" + SearchDistributor + "'";
            }

            sqlstring = "SELECT imp_invoices.invoice_code, distributors.company, imp_invoices.date_invoice, imp_invoices.importAmount, imp_invoices.vatAmount, imp_invoices.totalAmount, type_payments.type_payment, imp_invoices.payment_status FROM imp_invoices LEFT JOIN distributors ON imp_invoices.id_distributor = distributors.id_distributor LEFT JOIN type_payments ON imp_invoices.id_type_payment=type_payments.id_type_payment WHERE (imp_invoices.date_invoice >= '" + firstDate + "' AND imp_invoices.date_invoice <= '" + secondDate + "') " + searchDistribut + "";

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand(sqlstring, conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                Decimal totalImport = 0;
                Decimal totalAmount = 0;

                Decimal totalImportSum = 0;
                Decimal totalAmountSum = 0;
                String payStat = "";

                    while (dr.Read() == true)
                    {
                            DateTime dbDate1 = Convert.ToDateTime(dr[2]);
                            string outDate = dbDate1.ToString("dd-M-yyyy");

                            totalImport = dr.IsDBNull(3) ? 0 : dr.GetDecimal(3);
                            totalAmount = dr.IsDBNull(5) ? 0 : dr.GetDecimal(5);
                            string paymentMethod = dr.IsDBNull(6) ? "" : dr.GetString(6);
                            int paymentStatus = dr.IsDBNull(7) ? 0 : dr.GetInt32(7);
                            if (paymentStatus == 0)
                            {
                                payStat = "Pa Paguar";
                            }
                            else {
                                 payStat = "Paguar";
                            }

                            totalAmountSum += totalAmount;
                            totalImportSum += totalImport;
                            dgw.Rows.Add(dr.GetString(0), dr.GetString(1), outDate, totalImport, totalAmount, paymentMethod, payStat);
                    }

                    lblImportAmount.Text = totalImportSum.ToString();
                    lblTotalCost.Text = totalAmount.ToString();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTable() {
            dgw.Rows.Clear();
            txtDistributor.ResetText();
            dtEndDate.ResetText();
            lblTotalCost.Text="0.00";
            lblImportAmount.Text = "0.00";
            btnExport.Enabled = false;
        }

        private void ResearchTable()
        {
            lblTotalCost.Text = "0.00";
            lblImportAmount.Text = "0.00";
            btnExport.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ResearchTable();
            DateTime StartDate = Convert.ToDateTime(dtStartDate.Text);
            firstDate = StartDate.ToString("yyyy-MM-dd");

            DateTime EndDate = Convert.ToDateTime(dtEndDate.Text);
            secondDate = EndDate.ToString("yyyy-MM-dd");

            FindData();
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter)
            {
                btnSearch.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                btnExport.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTable();
        }

        private void frmPDFimpInvoices_Load(object sender, EventArgs e)
        {
            FillingCombobox();

            this.txtDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            
            btnExport.Enabled = false;

            DateTime dbDate1 = Convert.ToDateTime(dateTimeToday);

            var firstDate = dbDate1.ToString("yyyy-MM-dd");
            var secondDate = dbDate1.AddDays(-10).ToString("yyyy-MM-dd");

            dtStartDate.Text = secondDate;
            dtEndDate.Text = firstDate;
        }

        private void txtDistributor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
