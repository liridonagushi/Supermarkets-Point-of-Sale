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
    public partial class frmPDFexpInvoices : Form
    {
        public static string sFormIndex;
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
        private static String randomNumber;

        public frmPDFexpInvoices()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindingClientDetails();
            FindData();
            btnExp.Enabled = true;
        }

        // Returning result values
        public string FindClient
        {
            get { return lblIDClient.Text; }
            set { lblIDClient.Text = value; }
        }

        private void btnFindClient_Click(object sender, EventArgs e)
        {
            frmFindClient.sFormIndex = "pdfexpinvoice";
            frmFindClient frm = new frmFindClient(this);
            frm.ShowDialog();
        }

        private void FindingClientDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client, fullname, other_details FROM clients WHERE id_client='" + lblIDClient.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                        txtClient.Text = dr[1].ToString();
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

        private void FindData()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                var sqlstring = "";
                DateTime date1 = Convert.ToDateTime(dtStartDate.Text);
                string querydate1 = date1.ToString("yyyy-M-dd 00:00:00");

                DateTime date2 = Convert.ToDateTime(dtEndDate.Text);
                string querydate2 = date2.ToString("yyyy-M-dd 23:59:59");

                if (txtClient.Text.Length == 0)
                {
                    sqlstring = "SELECT pos.InvoiceNo, pos.POSDate, clients.fullname, type_payments.type_payment, pos.VatAmount, pos.NonVatAmount, pos.TotalAmount FROM pos LEFT JOIN users ON pos.StaffID=users.id_user LEFT JOIN type_payments ON pos.type_payment=type_payments.id_type_payment LEFT JOIN clients ON pos.id_client=clients.id_client WHERE pos.POSDate >= '" + querydate1 + "' AND pos.POSDate <= '" + querydate2 + "'";
                }
                else 
                {
                    sqlstring = "SELECT pos.InvoiceNo, pos.POSDate, clients.fullname, type_payments.type_payment, pos.VatAmount, pos.NonVatAmount, pos.TotalAmount FROM pos LEFT JOIN users ON pos.StaffID=users.id_user LEFT JOIN type_payments ON pos.type_payment=type_payments.id_type_payment LEFT JOIN clients ON pos.id_client=clients.id_client WHERE pos.POSDate >='" + querydate1 + "' AND pos.POSDate <= '" + querydate2 + "' AND pos.id_client='" + lblIDClient.Text + "'";
                }

                MySqlCommand cmdDatabase = new MySqlCommand(sqlstring, conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                Decimal SumVat = 0;
                Decimal VatAmount = 0;
                Decimal TotalCost = 0;

                while (dr.Read() == true)
                {
                    DateTime dbDate1 = Convert.ToDateTime(dr[1]);
                    string outDate = dbDate1.ToString("dd-M-yyyy");
                    
                    Decimal Vat = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                    Decimal NonVat = dr.IsDBNull(5) ? 0 : dr.GetDecimal(5);
                    Decimal Total = dr.IsDBNull(6) ? 0 : dr.GetDecimal(6);

                    SumVat += Vat;
                    VatAmount += NonVat;
                    TotalCost += Total;

                    dgw.Rows.Add(dr[0], outDate, dr[2], dr[3], Vat, NonVat, Total);
                }

                lblSumVat.Text = string.Format("{0:#,##0.##}", SumVat);
                lblNonVat.Text = string.Format("{0:#,##0.##}", VatAmount);
                lblTotalCost.Text = string.Format("{0:#,##0.##}", TotalCost);

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
            //Titles
            p4.Add(new Phrase("Shuma Tax ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));

            p4.Add(new Phrase("Shuma pa Tax ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));

            p4.Add(new Phrase("Shuma Total ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));

            //Values
            PdfPCell Tablecell5 = new PdfPCell();
            Paragraph p5 = new Paragraph();

            p5.Add(new Phrase(" " + lblSumVat.Text + " " + infoCurrency + " ", Classes.UserFonts.FontBold14()));
            p5.Add(new Paragraph(" "));

            p5.Add(new Phrase(" " + lblNonVat.Text + " " + infoCurrency + " ", Classes.UserFonts.FontBold14()));
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
            PdfPTable pdfTable6 = new PdfPTable(2);
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

        private void clearData() {
            txtClient.ResetText();
            lblIDClient.ResetText();
            btnExp.Enabled = false;
            dgw.Rows.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void lblIDClient_TextChanged(object sender, EventArgs e)
        {
            FindingClientDetails();
        }

        private void frmPDFexpInvoices_Load(object sender, EventArgs e)
        {
            DateTime dbDate1 = Convert.ToDateTime(dateTimeToday);

            var firstDate = dbDate1.ToString("yyyy-MM-dd");
            var secondDate = dbDate1.AddDays(-10).ToString("yyyy-MM-dd");

            dtStartDate.Text = secondDate;
            dtEndDate.Text = firstDate;

            lblIDClient.Hide();
            btnClear.Enabled = false;
            btnExp.Enabled = false;
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni ta krijoni fajlin PDF ?", "Invoice Completed !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                exportDoc();
                System.Diagnostics.Process.Start("C:/PDFs/" + randomNumber + ".pdf");
                //ClearSearch();
            }
        }

        private void txtClient_TextChanged(object sender, EventArgs e)
        {
            if (txtClient.Text == "")
            {
                btnClear.Enabled = false;
                btnExp.Enabled = false;
            }
            else 
            {
                btnClear.Enabled = true;
                btnExp.Enabled = true;
            }
        }
    }
}