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
    public partial class frmBuySpend : Form
    {
        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");

        private static Decimal totalImp = 0, totalSells = 0;

        public frmBuySpend()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FindTotalSells()
        {
                DateTime dbDate1 = Convert.ToDateTime(dtStartDate.Text);
                DateTime dbDate2 = Convert.ToDateTime(dtEndDate.Text);

                var firstDate = dbDate1.ToString("yyyy-M-dd 00:00:00");
                var secondDate = dbDate2.ToString("yyyy-M-dd 23:59:59");

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT SUM(totalAmount) FROM pos WHERE pos.POSDate BETWEEN '" + firstDate + "' AND '" + secondDate + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);


                lblTotalSells.ResetText();

                if (dr.Read() == true)
                {
                    totalSells = dr.IsDBNull(0) ? 0 : dr.GetDecimal(0);
                }

                lblTotalSells.Text = totalSells.ToString();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindTotalImports()
        {
            DateTime dbDate1 = Convert.ToDateTime(dtStartDate.Text);
            DateTime dbDate2 = Convert.ToDateTime(dtEndDate.Text);

            var firstDate = dbDate1.ToString("yyyy-MM-dd");
            var secondDate = dbDate2.ToString("yyyy-MM-dd");

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT SUM(imp_invoices.totalAmount) FROM imp_invoices WHERE imp_invoices.date_invoice BETWEEN '" + firstDate + "' AND '" + secondDate + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);


                lblTotalImports.ResetText();

                if (dr.Read() == true)
                {
                    totalImp = dr.IsDBNull(0) ? 0 : dr.GetDecimal(0);
                }

                lblTotalImports.Text = totalImp.ToString();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindTotalImports();
            FindTotalSells();

            lblTotalProfit.ResetText();

            if ((totalSells) > 0)
            {
                decimal totalProfit = totalSells - totalImp;
                lblTotalProfit.Text = totalProfit.ToString();
            }
        }

        private void frmBuySpend_Load(object sender, EventArgs e)
        {

            DateTime dbDate1 = Convert.ToDateTime(dateTimeToday);

            var firstDate = dbDate1.ToString("yyyy-MM-dd");
            var secondDate = dbDate1.AddDays(-10).ToString("yyyy-MM-dd");

            dtStartDate.Text = secondDate;
            dtEndDate.Text = firstDate;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblTotalImports.Text = "0.00";
            lblTotalSells.Text = "0.00";
            lblTotalProfit.Text = "0.00";
        }
    }
}
