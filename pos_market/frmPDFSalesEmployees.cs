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
    public partial class frmPDFSalesEmployees : Form
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
        private static String firstDate;

        public frmPDFSalesEmployees()
        {
            InitializeComponent();
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.S))
            {
                btnExport.PerformClick();
                return true;
            }

            if (keyData == Keys.Enter)
            {
                btnSearch.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FindData()
        {
            if (cmbUsername.Text.Length > 0)
            {
                userSearch = "users.username ='" + cmbUsername.Text + "'";
            }
            else
            {
                userSearch = "1=1";
                lblFullName.Text = "All Users";
            }

            if (chkDaily.Checked == true)
            {
                DateTime dbDate1 = Convert.ToDateTime(dtStartDate.Text);

                var firstDate12 = dbDate1.ToString("dd-MM-yyyy");

                var firstDate = dbDate1.ToString("yyyy-MM-dd 00:00:00");
                var secondDate = dbDate1.ToString("yyyy-MM-dd 23:59:59");

                lblDateStart.Text = firstDate12;

                SQLQuery = "SELECT users.username, employee_stats.time_start, employee_stats.time_end, employee_stats.hours_worked, employee_stats.VatAmount, employee_stats.TotalAmount, employee_stats.returned_debts, employee_stats.total_sum FROM employee_stats LEFT JOIN users ON employee_stats.id_employee=users.id_user WHERE (" + userSearch + " AND employee_stats.time_end BETWEEN '" + firstDate + "' AND '" + secondDate + "')  AND hours_worked>0 ORDER BY employee_stats.time_end DESC";
           
            }else{

                DateTime dbDate1 = Convert.ToDateTime(dtStartDate.Text);
               // string outDate = dbDate1.ToString("dd-M-yyyy");

                var fromDate = new DateTime(dbDate1.Year, dbDate1.Month, 1);
                var toDate = fromDate.AddMonths(1).AddDays(-1);

                var SysDate1 = fromDate.ToString("yyyy-MM-dd 00:00:00");
                var SysDate2 = toDate.ToString("yyyy-MM-dd 23:59:59");

                var SysDate12 = fromDate.ToString("dd-MM-yyyy");
                var SysDate22 = toDate.ToString("dd-MM-yyyy");

                lblDateStart.Text = SysDate12 + " - " + SysDate22;

                SQLQuery = "SELECT users.username, employee_stats.time_start, employee_stats.time_end, employee_stats.hours_worked, employee_stats.VatAmount, employee_stats.TotalAmount, employee_stats.returned_debts, employee_stats.total_sum FROM employee_stats LEFT JOIN users ON employee_stats.id_employee=users.id_user WHERE ((" + userSearch + ") AND employee_stats.time_end BETWEEN '" + SysDate1 + "' AND '" + SysDate2 + "')  AND hours_worked>0 ORDER BY employee_stats.time_end DESC";
            }

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand(SQLQuery, conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                Decimal HoursWorked = 0;
                Decimal TotalCost = 0;
                Decimal TotalSale = 0;
                Decimal SumReturnedDebts = 0;
                    while (dr.Read() == true)
                    {
                        DateTime dbDate1 = Convert.ToDateTime(dr[1]);
                        DateTime dbDate2 = Convert.ToDateTime(dr[2]);

                        string zero = dr.IsDBNull(0) ? null : dr[0].ToString();
                        string outDate = dr.IsDBNull(1) ? null : dbDate1.ToString("dd-M-yyyy");
                        string outTimeStart = dr.IsDBNull(1) ? null : dbDate1.ToString("dd-M / HH:s");
                        string outTimeEnd = dr.IsDBNull(2) ? "" : dbDate2.ToString("dd-M / HH:s");

                        Decimal third = dr.IsDBNull(3) ? 0 : dr.GetDecimal(3);
                        Decimal fourth = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                        Decimal fifth = dr.IsDBNull(5) ? 0 : dr.GetDecimal(5);

                        Decimal returnedDebt = dr.IsDBNull(6) ? 0 : dr.GetDecimal(6);
                        Decimal total_sum = dr.IsDBNull(7) ? 0 : dr.GetDecimal(7);

                         HoursWorked += dr.IsDBNull(3) ? 0 : dr.GetDecimal(3);
                         TotalSale += fifth;
                         SumReturnedDebts += returnedDebt;

                         TotalCost += total_sum;

                         dgw.Rows.Add(zero, outDate, outTimeStart, outTimeEnd, third, fourth, fifth, returnedDebt, total_sum);
                    }

                    lblHoursWorked.Text = HoursWorked.ToString();
                    lblSalesAmount.Text = TotalSale.ToString();
                    lblReturnedDebts.Text = SumReturnedDebts.ToString();

                    lblTotalCost.Text = TotalCost.ToString();
                    enable_buttons();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void ResearchTable()
        {
            lblTotalCost.ResetText();
            lblSalesAmount.Text="0.00";
            lblHoursWorked.Text = "0.00";
        }

        private void ClearTable()
        {
            dgw.Rows.Clear();
            cmbUsername.ResetText();
            dtStartDate.ResetText();
            lblTotalCost.ResetText();
            lblSalesAmount.Text = "0.00";
            lblHoursWorked.Text = "0.00";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if((chkDaily.Checked == false) && (chkMonthly.Checked == false)) {
                MessageBox.Show("Selektojeni butonin ditor apo mujor !", "Empty Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {             
                ResearchTable();
                DateTime StartDate = Convert.ToDateTime(dtStartDate.Text);
                firstDate = StartDate.ToString("yyyy-MM-dd");
                FindData();
            }
        }

        private void FillingCombobox()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_user, username FROM users", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.HasRows == true)
                {
                    cmbUsername.Items.Add("");
                    while (dr.Read())
                    {
                        cmbUsername.Items.Add(dr[1].ToString());
                    }
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

        private void disable_buttons() 
        { 
          btnExport.Enabled = false;
          btnClear.Enabled = false;
        }

        private void enable_buttons()
        {
            btnExport.Enabled = true;
            btnClear.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTable();
            disable_buttons();
        }

        private void frmCSVSalesEmployees_Load(object sender, EventArgs e)
        {
            FillingCombobox();
            this.cmbUsername.DropDownStyle = ComboBoxStyle.DropDownList;
            disable_buttons();

            DateTime dbDate1 = Convert.ToDateTime(dateTimeToday);

            var firstDate = dbDate1.ToString("yyyy-MM-dd");

            dtStartDate.Text = firstDate;            
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
            p4.Add(new Phrase("Oret e Punes: ", Classes.UserFonts.fontNeue12()));
            p4.Add(new Paragraph(" "));

            p4.Add(new Phrase("Shuma Blerjeve ", Classes.UserFonts.fontNeue12()));
            p4.Add(new Paragraph(" "));

            p4.Add(new Phrase("Shuma Servisimeve ", Classes.UserFonts.fontNeue12()));
            p4.Add(new Paragraph(" "));

            p4.Add(new Phrase("Shuma Shitjeve ", Classes.UserFonts.fontNeue12()));
            p4.Add(new Paragraph(" "));

            p4.Add(new Phrase("Shuma Total ", Classes.UserFonts.fontNeue12()));
            p4.Add(new Paragraph(" "));

            //Values
            PdfPCell Tablecell5 = new PdfPCell();
            Paragraph p5 = new Paragraph();
            p5.Add(new Phrase(" " + lblHoursWorked.Text + " ", Classes.UserFonts.fontNeue12()));
            p5.Add(new Paragraph(" "));

            p5.Add(new Phrase(" " + lblSalesAmount.Text + " " + infoCurrency + " ", Classes.UserFonts.fontNeue12()));
            p5.Add(new Paragraph(" "));

            p5.Add(new Phrase(" " + lblTotalCost.Text + " " + infoCurrency + " ", Classes.UserFonts.fontNeue12()));
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
    }
}
