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
    public partial class frmStatsLocalBuys : Form
    {
        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");

        public frmStatsLocalBuys()
        {
            InitializeComponent();
        }

        private void FindData()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                DateTime date1 = Convert.ToDateTime(dtStartDate.Text);
                string querydate1 = date1.ToString("yyyy-M-dd");

                DateTime date2 = Convert.ToDateTime(dtEndDate.Text);
                string querydate2 = date2.ToString("yyyy-M-dd");

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT bought_ocassion.id_product, products.barcode, products.description, bought_ocassion.unity_price, bought_ocassion.qty, bought_ocassion.date_buy FROM bought_ocassion LEFT JOIN products ON bought_ocassion.id_product=products.id_product WHERE bought_ocassion.date_buy BETWEEN '" + querydate1 + "' AND '" + querydate2 + "' ORDER BY bought_ocassion.id_ocassion DESC", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                Decimal findSum = 0;
                Decimal findQty = 0;
                while (dr.Read() == true)
                {
                    DateTime dbDate1 = Convert.ToDateTime(dr[5]);
                    string outDate = dbDate1.ToString("dd-M-yyyy");

                    findSum += dr.GetDecimal(3);
                    findQty += dr.GetDecimal(4);

                    dgw.Rows.Add(dr[0], dr[1], dr[2], outDate, dr[4], dr[3]);
                }
                lblTotalCost.Text = findSum.ToString();
                lblQty.Text = findQty.ToString();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmStatsLocalBuys_Load(object sender, EventArgs e)
        {

            DateTime dbDate1 = Convert.ToDateTime(dateTimeToday);

            var firstDate = dbDate1.ToString("yyyy-MM-dd");
            var secondDate = dbDate1.AddDays(-10).ToString("yyyy-MM-dd");

            dtStartDate.Text = secondDate;
            dtEndDate.Text = firstDate;
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
            lblQty.ResetText();
            lblTotalCost.ResetText();
            dtStartDate.ResetText();
            dtEndDate.ResetText();
        }
    }
}
