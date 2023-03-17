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
    public partial class frmCSVexport : Form
      {
        private static string sqlQuery, file;
      
        public frmCSVexport()
        {
            InitializeComponent();
            this.cmbDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FillingCombobox()
        {
                    cmbDistributor.Items.Clear();
                    cmbDistributor.Items.Add("distributors");
                    cmbDistributor.Items.Add("products");
                    cmbDistributor.Items.Add("clients");
        }

        private void ExportToCSV()
        {
             file = @"C:\CSV\myOutput.csv";
            
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                if (cmbDistributor.Text == "clients")
                {
                    sqlQuery = "SELECT fullname, company, adress, city, p_code, country, phone, email, date_registration, active FROM clients";
                }
                else if (cmbDistributor.Text == "products")
                {
                    sqlQuery = "SELECT products.barcode, products.description, type_products.type_product, taxes.vat_perc AS Percentage, products.import_price, products.discount_perc, products.tax_amount, products.sold_price, products.quantity, products.date_insert FROM products LEFT JOIN type_products ON products.id_type=type_products.id_type LEFT JOIN taxes ON products.id_tax=taxes.id_tax";
                }
                else if (cmbDistributor.Text == "distributors")
                {
                    sqlQuery = "SELECT fullname, company, BankAccountNumber, adress, city, p_code, country, phone, email, date_registration, active FROM distributors";
                }
                else
                {
                     sqlQuery = "SELECT * FROM distributors";
                }

                MySqlCommand cmdDatabase = new MySqlCommand("" + sqlQuery + "", conn);
                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                using (var stream = File.CreateText(file))
                {
                    while (dr.Read())
                    {
                        if (cmbDistributor.Text == "clients")
                        {
                            string first = dr.IsDBNull(0) ? "" : dr.GetString(0);
                            string second = dr.IsDBNull(1) ? "" : dr.GetString(1);
                            string third = dr.IsDBNull(2) ? "" : dr.GetString(2);
                            string fourth = dr.IsDBNull(3) ? "" : dr.GetString(3);
                            string fifth = dr.IsDBNull(4) ? "" : dr.GetString(4);
                            string sixth = dr.IsDBNull(5) ? "" : dr.GetString(5);
                            string seventh = dr.IsDBNull(6) ? "" : dr.GetString(6);
                            string eightth = dr.IsDBNull(7) ? "" : dr.GetString(7);
                            DateTime dbDate1 = Convert.ToDateTime(dr[8]);
                            string ninth = dbDate1.ToString("dd-M-yyyy");
                            string tenth = dr.IsDBNull(9) ? "" : dr.GetString(9);

                            string csvRow = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", first, second, third, fourth, fifth, sixth, seventh, eightth, ninth, tenth);
                            stream.WriteLine(csvRow);
                        }
                        else if (cmbDistributor.Text == "products")
                        {
                            string first = dr.IsDBNull(0) ? "" : dr.GetString(0);
                            string second = dr.IsDBNull(1) ? "" : dr.GetString(1);
                            string third = dr.IsDBNull(2) ? "" : dr.GetString(2);
                            string fourth = dr.IsDBNull(3) ? "" : dr.GetString(3);
                            string fifth = dr.IsDBNull(4) ? "" : dr.GetString(4);
                            string sixth = dr.IsDBNull(5) ? "" : dr.GetString(5);
                            string seventh = dr.IsDBNull(6) ? "" : dr.GetString(6);
                            string eightth = dr.IsDBNull(7) ? "" : dr.GetString(7);
                            string ninth = dr.IsDBNull(8) ? "" : dr.GetString(8);
                            DateTime dbDate1 = Convert.ToDateTime(dr[9]);
                            string tenth = dbDate1.ToString("dd-M-yyyy");

                            string csvRow = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", first, second, third, fourth, fifth, sixth, seventh, eightth, ninth, tenth);
                            stream.WriteLine(csvRow);
                        }
                        else if (cmbDistributor.Text == "distributors")
                        {
                            string first = dr.IsDBNull(0) ? "" : dr.GetString(0);
                            string second = dr.IsDBNull(1) ? "" : dr.GetString(1);
                            string third = dr.IsDBNull(2) ? "" : dr.GetString(2);
                            string fourth = dr.IsDBNull(3) ? "" : dr.GetString(3);
                            string fifth = dr.IsDBNull(4) ? "" : dr.GetString(4);
                            string sixth = dr.IsDBNull(5) ? "" : dr.GetString(5);
                            string seventh = dr.IsDBNull(6) ? "" : dr.GetString(6);
                            string eightth = dr.IsDBNull(7) ? "" : dr.GetString(7);
                            string ninth = dr.IsDBNull(8) ? "" : dr.GetString(8);

                            DateTime dbDate1 = Convert.ToDateTime(dr[9]);
                            string tenth = dbDate1.ToString("dd-M-yyyy");

                            string eleventh = dr.IsDBNull(10) ? "" : dr.GetString(10);

                            string csvRow = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", first, second, third, fourth, fifth, sixth, seventh, eightth, ninth, tenth, eleventh);
                            stream.WriteLine(csvRow);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCSVexport_Load(object sender, EventArgs e)
        {
            FillingCombobox();
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            if (cmbDistributor.Text == "")
            {
                MessageBox.Show("Please choose a value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
            DialogResult dialogResult = MessageBox.Show("A jeni i sigurt te shkarkoni gjitha te dhanat !", "Download CSV File ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                {
                    if (!Directory.Exists(@"C:\CSV"))
                        Directory.CreateDirectory(@"C:\CSV");

                    if (File.Exists(@"C:\CSV\myOutput.csv"))
                    {
                        File.Delete(@"C:\CSV\myOutput.csv");
                    }

                    ExportToCSV();
                    System.Diagnostics.Process.Start(file);
                }
            }
        }

        private void cmbDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
     }
}
