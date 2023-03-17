using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    public partial class frmDailySales : Form
    {
        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");

        public frmDailySales()
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
                string querydate1 = date1.ToString("yyyy-MM-dd 00:00:00");

                DateTime date2 = Convert.ToDateTime(dtEndDate.Text);
                string querydate2 = date2.ToString("yyyy-MM-dd 23:59:59");

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_category, pos.POSDate, SUM(posdetails.total_amount) FROM posdetails LEFT JOIN products ON posdetails.id_product=products.id_product LEFT JOIN pos ON posdetails.InvoiceNo=pos.InvoiceNo WHERE pos.POSDate BETWEEN '" + querydate1 + "' AND '" + querydate2 + "'", conn);

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
                MessageBox.Show(ex.Message, "FindData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSalesByCategory_Load(object sender, EventArgs e)
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
    }
}
