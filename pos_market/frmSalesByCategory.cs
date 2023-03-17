using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text.pdf;

namespace Supermarkets
{
    public partial class frmSalesByCategory : Form
    {
        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");

        public frmSalesByCategory()
        {
            InitializeComponent();
        }

        private void FillingCombobox()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_category, category_name FROM product_categories", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                   cmbCategory.Items.Clear();

                    while (dr.Read() == true)
                    {
                        cmbCategory.Items.Add(dr[0].ToString() + " " + dr[1].ToString());
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
                DateTime date1 = Convert.ToDateTime(dtStartDate.Text);
                string querydate1 = date1.ToString("yyyy-MM-dd 00:00:00");

                DateTime date2 = Convert.ToDateTime(dtEndDate.Text);
                string querydate2 = date2.ToString("yyyy-MM-dd 23:59:59");


                var Category = cmbCategory.Text.ToString().Split(' ')[0];

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_category, pos.POSDate, SUM(posdetails.total_amount) FROM posdetails LEFT JOIN products ON posdetails.id_product=products.id_product LEFT JOIN pos ON posdetails.InvoiceNo=pos.InvoiceNo WHERE products.id_category = '" + Category + "' AND pos.POSDate BETWEEN '" + querydate1 + "' AND '" + querydate2 + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                Decimal findSum = 0;

                while (dr.Read() == true)
                {
                    DateTime dbDate1 = Convert.ToDateTime(querydate1);
                    string outDate = dbDate1.ToString("dd-MM-yyyy");

                    DateTime dbDate2 = Convert.ToDateTime(querydate2);
                    string outDate2 = dbDate2.ToString("dd-MM-yyyy");

                    findSum = dr.GetDecimal(2);

                    dgw.Rows.Add(dr[0], dbDate1, dbDate2, findSum);
                }

                lblTotalCost.Text = findSum.ToString();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbCategory.Text == "")
            {
                MessageBox.Show("Kategoria nuk mund te jet e zbrazet", "Error Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
            FindData();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void frmSalesByCategory_Load(object sender, EventArgs e)
        {
            FillingCombobox();
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            DateTime dbDate1 = Convert.ToDateTime(dateTimeToday);

            var firstDate = dbDate1.ToString("yyyy-MM-dd");
            var secondDate = dbDate1.AddDays(-10).ToString("yyyy-MM-dd");

            dtStartDate.Text = secondDate;
            dtEndDate.Text = firstDate;
        }
    }
}
