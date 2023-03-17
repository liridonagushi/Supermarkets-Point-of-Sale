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
    public partial class frmSuggestedProducts : Form
    {
        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
        private static String randomNumber;

        public frmSuggestedProducts()
        {
            InitializeComponent();
        }

        private void findSugestedProds()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT suggested_products.id_suggest, suggested_products.keyword, suggested_products.date, users.username FROM suggested_products LEFT JOIN users ON suggested_products.id_user=users.id_user ORDER BY suggested_products.id_suggest DESC", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    dgw.Rows.Add(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3));
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM suggested_products", conn);

                MySqlCommand cmdDatabase1 = new MySqlCommand("ALTER TABLE suggested_products", conn);
               

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0) {

                    MessageBox.Show("Lista e produkteve te sugjeruara u fshij me sukses !", "Success Deleting Suggested", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cmdDatabase1.ExecuteNonQuery();
                    dgw.Rows.Clear();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni ta krijoni fajlin PDF ?", "Suggested Words !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                exportDoc();
                System.Diagnostics.Process.Start("C:/PDFs/" + randomNumber + ".pdf");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void exportDoc()
        {
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
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(pdfTable6);
                pdfDoc.Close();
                stream.Close();
            }
        }

        private void frmSuggestedWords_Load(object sender, EventArgs e)
        {
            findSugestedProds();
        }
    }
}
