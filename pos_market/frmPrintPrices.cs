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
    public partial class frmPrintPrices : Form
    {
        public static string sFormIndex;

        //Tables
        private static String randomNumber;

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

        public frmPrintPrices()
        {
            InitializeComponent();
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

        // Returning result values
        public string FindProduct
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

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.barcode, products.description, products.sold_price FROM products LEFT JOIN type_products ON products.id_type=type_products.id_type WHERE products.barcode='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.HasRows) { btnExpPDF.Enabled = true; }
                while (dr.Read() == true)
                {
                    dgw.Rows.Add(dr[0], dr[1], dr[2]);
                }
                txtBarcode.Text = "";

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            frmFindProduct.sFormIndex = "PrintPrices";
            frmFindProduct frm = new frmFindProduct(this);
            frm.ShowDialog();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FindData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgw.Rows.Clear();
            txtBarcode.ResetText();
            btnExpPDF.Enabled = false;
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
            //Result Rows
            //Creating iTextSharp Table from the DataTable data
            getCompanyDetails();
            //Header Left Table
            PdfPTable pdfTable = new PdfPTable(1);
            pdfTable.DefaultCell.Padding = 20;
            pdfTable.DefaultCell.MinimumHeight = 20.0F;
            pdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            pdfTable.DefaultCell.Colspan = 1;
            pdfTable.DefaultCell.Rowspan = 1;

            if (Chk120.Checked == true){

                pdfTable.WidthPercentage = 15;

                //Adding DataRow
                foreach (DataGridViewRow row in dgw.Rows)
                {
                    PdfPCell Tablecell1 = new PdfPCell();

                    Paragraph p1 = new Paragraph();
                    p1.Add(new Paragraph(row.Cells[0].Value.ToString(), Classes.UserFonts.fontNeue14()));
                    p1.Add(new Paragraph(""));
                    p1.Add(new Paragraph(row.Cells[1].Value.ToString(), Classes.UserFonts.fontNeue14()));
                    p1.Add(new Paragraph(""));
                    p1.Add(new Paragraph(row.Cells[2].Value.ToString() + " " + infoCurrency, Classes.UserFonts.fontNeue18()));
                    p1.Add(new Paragraph(""));

                    Tablecell1.AddElement(p1);

                    pdfTable.AddCell(Tablecell1);
                }
            }
            
            if (Chk320.Checked == true)
            {
                pdfTable.WidthPercentage = 20;

                //Adding DataRow
                foreach (DataGridViewRow row in dgw.Rows)
                {
                    PdfPCell Tablecell1 = new PdfPCell();
                    Paragraph p1 = new Paragraph();
                    p1.Add(new Paragraph(row.Cells[0].Value.ToString(), Classes.UserFonts.fontNeue16()));
                    p1.Add(new Paragraph(""));
                    p1.Add(new Paragraph(row.Cells[1].Value.ToString(), Classes.UserFonts.fontNeue16()));
                    p1.Add(new Paragraph(""));
                    p1.Add(new Paragraph(row.Cells[2].Value.ToString() + " " + infoCurrency, Classes.UserFonts.fontNeue18()));
                    p1.Add(new Paragraph(""));

                    Tablecell1.AddElement(p1);
                    pdfTable.AddCell(Tablecell1);
                }
            }

            if (Chk420.Checked == true)
            {
                pdfTable.WidthPercentage = 30;

                //Adding DataRow
                foreach (DataGridViewRow row in dgw.Rows)
                {
                    PdfPCell Tablecell1 = new PdfPCell();
                    Paragraph p1 = new Paragraph();
                    p1.Add(new Paragraph(row.Cells[0].Value.ToString(), Classes.UserFonts.fontNeue20()));
                    p1.Add(new Paragraph(""));
                    p1.Add(new Paragraph(row.Cells[1].Value.ToString(), Classes.UserFonts.fontNeue20()));
                    p1.Add(new Paragraph(""));
                    p1.Add(new Paragraph(row.Cells[2].Value.ToString() + " " + infoCurrency, Classes.UserFonts.fontNeue18()));
                    p1.Add(new Paragraph(""));

                    Tablecell1.AddElement(p1);
                    pdfTable.AddCell(Tablecell1);
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
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }

        private void btnExpPDF_Click(object sender, EventArgs e)
        {
            if ((Chk120.Checked == false) && (Chk320.Checked == false) && (Chk420.Checked == false))
            {
                MessageBox.Show("Se pari selektojeni formatin per printim !", "Error format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else{
                DialogResult dialogResult = MessageBox.Show("A doni ta krijoni fajlin PDF ?", "Invoice Completed !", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    exportDoc();
                    System.Diagnostics.Process.Start("C:/PDFs/" + randomNumber + ".pdf");
                    //ClearSearch();
                }
            }
        }

        private void frmPrintPrices_Load(object sender, EventArgs e)
        {
            btnExpPDF.Enabled = false;
        }
    }
}
