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
    public partial class frmDebts : Form
    {
        //Tables
          private static String randomNumber;
        private static String userSearch;

        //Company Info
        private static String DBCompanyName;
        private static String DBManager;
        private static String DBContactNumber;
        private static String DBAdress;
        private static String DBCity;
        private static String DBCountry;
        private static String infoCurrency;

        private static String SQLQuery;

        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
        //    private static String firstDate;

        public frmDebts()
        {
            InitializeComponent();
        }

        private void FillingCombobox()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client, fullname FROM clients", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    cmbClient.Items.Clear();

                    cmbClient.Items.Add("");

                    while (dr.Read() == true)
                    {
                        cmbClient.Items.Add(dr[0].ToString() + " " + dr[1].ToString());
                    }
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDebts_Load(object sender, EventArgs e)
        {
            FillingCombobox();
            btnExport.Enabled = false;
            this.cmbClient.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FindData()
        {
            if (cmbClient.Text.Length > 0)
            {
                FillingCombobox();
                var selectedText = cmbClient.SelectedText;

                var SearchClient = cmbClient.Text.ToString().Split(' ')[0];

                userSearch = "clients.id_client='" + SearchClient + "'";
            }
            else
            {
                userSearch = "1=1";
                lblFullName.Text = "All Clients";
            }

            if (chkPaid.Checked == true)
            {
                DateTime dbDate1 = Convert.ToDateTime(dtStartDate.Text);
                DateTime dbDate2 = Convert.ToDateTime(dtEndDate.Text);

                var firstDate = dbDate1.ToString("yyyy-M-dd");
                var secondDate = dbDate2.ToString("yyyy-M-dd");

                SQLQuery = "SELECT DISTINCT paiddebts.CustomerNo, clients.fullname, clients.other_details, paiddebts.paidDate, paiddebts.debtValue FROM paiddebts LEFT JOIN clients ON paiddebts.CustomerNo=clients.id_client LEFT JOIN users ON paiddebts.StaffID=users.id_user WHERE " + userSearch + " AND ((paiddebts.paidDate >= '" + firstDate + "') AND (paiddebts.paidDate <= '" + secondDate + "')) ORDER BY paiddebts.paidDate DESC";
            }
            else
            {
                SQLQuery = "SELECT DISTINCT client_debts.id_client, clients.fullname, clients.other_details, client_debts.debtDate, client_debts.debtValue FROM client_debts LEFT JOIN clients ON client_debts.id_client=clients.id_client WHERE " + userSearch + " AND client_debts.type_payment='3'";
            }

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand(SQLQuery, conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                lblTotalCost.Text = "0.00";
                decimal totalAmount = 0;
                    while (dr.Read() == true)
                    {
                        DateTime debtDate = Convert.ToDateTime(dr[3]);

                        string zero = dr.IsDBNull(0) ? null : dr[0].ToString();
                        string first = dr.IsDBNull(1) ? "0" : dr[1].ToString();
                        string second = dr.IsDBNull(2) ? "0" : dr[2].ToString();
                        string third = dr.IsDBNull(3) ? null : debtDate.ToString("dd-M-yyyy");
                        int fourth = dr.IsDBNull(4) ? 0 : dr.GetInt32(4);
                        totalAmount += fourth;
                        dgw.Rows.Add(zero, first, second, third, fourth);
                    }

                    lblTotalCost.Text = totalAmount.ToString();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if ((chkPaid.Checked == false) && (chkUnPaid.Checked == false))
            {
                MessageBox.Show("Zgjedheni borxhet e paguara apo pa paguara !", "Empty Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (chkPaid.Checked == true) { lblStatusDebt.Text = "Borxhet e Paguara"; }
                else if (chkUnPaid.Checked == true) { lblStatusDebt.Text = "Borxhet e Pa paguara"; }
                FindData();
                btnExport.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chkUnPaid_CheckedChanged(object sender, EventArgs e)
        {
            dtStartDate.Enabled = false;
            dtEndDate.Enabled = false;
        }

        private void chkPaid_CheckedChanged(object sender, EventArgs e)
        {
            dtStartDate.Enabled = true;
            dtEndDate.Enabled = true;
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

            p4.Add(new Phrase("Shuma Totale ", Classes.UserFonts.FontBold14()));
            p4.Add(new Paragraph(" "));

            //Values
            PdfPCell Tablecell5 = new PdfPCell();
            Paragraph p5 = new Paragraph();

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
            p6.Add(new Phrase("Tipi Borxhit: ", Classes.UserFonts.FontBold14()));
            p6.Add(new Paragraph(lblStatusDebt.Text, Classes.UserFonts.FontBold14()));
            p6.Add(new Phrase("Data Sot: ", Classes.UserFonts.FontBold14()));
            p6.Add(new Paragraph(dateTimeToday, Classes.UserFonts.FontBold14()));

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

        private void btnExport_Click(object sender, EventArgs e)
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

        private void ClearSearch(){
            dgw.Rows.Clear();
            lblTotalCost.Text = "0.00";
            lblStatusDebt.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            ClearSearch();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
