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
    public partial class frmAvailableStocks : Form
    {
        //Tables
        private static String randomNumber, searchCategory;
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

        public frmAvailableStocks()
        {
            InitializeComponent();
        }

        private void FindData()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.barcode, products.description, type_products.type_product, products.date_insert, products.quantity, products.sold_price FROM products LEFT JOIN type_products ON products.id_type=type_products.id_type LEFT JOIN taxes on products.id_tax=taxes.id_tax WHERE products.quantity > 0", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                Decimal prodQty = 0;
                Decimal prodPrice = 0;
                dgw.Rows.Clear();
                    while (dr.Read() == true)
                    {
                       // DateTime dbDate1 = Convert.ToDateTime(dr[3]);
                        // string outDate = dbDate1.ToString("dd-M-yyyy");
                        string first = dr.IsDBNull(0) ? "0" : dr.GetString(0);
                        string second = dr.IsDBNull(1) ? "0" : dr.GetString(1);
                        string third = dr.IsDBNull(2) ? "0" : dr.GetString(2);
                        string outDate = dr.IsDBNull(3) ? "00-00-0000" : Convert.ToDateTime(dr[3]).ToString("dd-M-yyyy");
                        Decimal fourth = dr.IsDBNull(4) ? 0 : dr.GetInt32(4);
                        Decimal fifth = dr.IsDBNull(5) ? 0 : dr.GetInt32(5);
                        prodQty += fourth;
                        Decimal sixth = fourth * fifth;
                        prodPrice += sixth;
                        dgw.Rows.Add(first, second, third, outDate, fourth, fifth, sixth);
                    }

                    lblTotalCost.Text = prodPrice.ToString();
                    lblTotalQty.Text = prodQty.ToString();

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

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_category, category_name FROM product_categories", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows)
                {
                    cmbCategories.Items.Clear();

                    cmbCategories.Items.Add("");

                    while (dr.Read() == true)
                    {
                        cmbCategories.Items.Add(dr[0].ToString() + " " + dr[1].ToString());
                    }
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FindDataBarcode()
        {
            try
            {
                if (cmbCategories.Text != "")
                {
                    var SearchCategories = cmbCategories.Text.ToString().Split(' ')[0];
                    searchCategory = " OR products.id_category = '" + SearchCategories + "'";
                }

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.barcode, products.description, product_categories.category_name, products.date_insert, products.quantity, products.sold_price FROM products LEFT JOIN product_categories ON products.id_category=product_categories.id_category LEFT JOIN taxes on products.id_tax=taxes.id_tax WHERE products.barcode= '" + txtBarcode.Text + "' " + searchCategory + "", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                Decimal prodQty = 0;
                Decimal prodPrice = 0;

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    // DateTime dbDate1 = Convert.ToDateTime(dr[3]);
                    // string outDate = dbDate1.ToString("dd-M-yyyy");
                    string first = dr.IsDBNull(0) ? "0" : dr.GetString(0);
                    string second = dr.IsDBNull(1) ? "0" : dr.GetString(1);
                    string third = dr.IsDBNull(2) ? "0" : dr.GetString(2);
                    string outDate = dr.IsDBNull(3) ? "00-00-0000" : Convert.ToDateTime(dr[3]).ToString("dd-M-yyyy");
                    Decimal fourth = dr.IsDBNull(4) ? 0 : dr.GetInt32(4);
                    Decimal fifth = dr.IsDBNull(5) ? 0 : dr.GetInt32(5);
                    prodQty += fourth;
                    Decimal sixth = fourth * fifth;
                    prodPrice += sixth;
                    dgw.Rows.Add(first, second, third, outDate, fourth, fifth, sixth);
                }

                lblTotalCost.Text = prodPrice.ToString();
                lblTotalQty.Text = prodQty.ToString();

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

            p4.Add(new Phrase("Shuma Total ", Classes.UserFonts.FontBold14()));
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

        private void frmAvailableStocks_Load(object sender, EventArgs e)
        {
            FindData();
            this.cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            FillingCombobox();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni te krijoni fajlin PDF ?", "Invoice Completed !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                exportDoc();
                System.Diagnostics.Process.Start("C:/PDFs/" + randomNumber + ".pdf");
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            FindDataBarcode();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBarcode.ResetText();
            FindData();
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindDataBarcode();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindData();
        }
    }
}
