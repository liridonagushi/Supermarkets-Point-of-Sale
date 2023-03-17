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
    public partial class frmStatsServices : Form
    {
        private static String SQLQuery, statusLabel, searchServices;

        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");

        public frmStatsServices()
        {
            InitializeComponent();
        }

        private void FindData()
        {
            if (cmbStatus.Text == "")
            {
                DateTime dbDate1 = Convert.ToDateTime(dtStartDate.Text);
                DateTime dbDate2 = Convert.ToDateTime(dtEndDate.Text);

                var firstDate = dbDate1.ToString("yyyy-MM-dd 00:00:00");
                var secondDate = dbDate2.ToString("yyyy-MM-dd 23:59:59");

                SQLQuery = "SELECT repairing_services.status_service, SUM(repairing_services.total_cost) FROM repairing_services WHERE ((repairing_services.time_service BETWEEN '" + firstDate + "' AND '" + secondDate + "')) ORDER BY repairing_services.id_service DESC";
                
            }
            else
            {
                DateTime dbDate1 = Convert.ToDateTime(dtStartDate.Text);
                DateTime dbDate2 = Convert.ToDateTime(dtEndDate.Text);

                var firstDate = dbDate1.ToString("yyyy-MM-dd 00:00:00");
                var secondDate = dbDate2.ToString("yyyy-MM-dd 23:59:59");

                searchServices = cmbStatus.Text.ToString().Split(' ')[0];

                string searchStatus = " AND repairing_services.status_service='" + searchServices + "'";

                SQLQuery = "SELECT repairing_services.status_service, SUM(repairing_services.total_cost) FROM repairing_services WHERE ((repairing_services.time_service BETWEEN '" + firstDate + "' AND '" + secondDate + "')) " + searchStatus + " ORDER BY repairing_services.id_service DESC";
            }

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand(SQLQuery, conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                lblSumVat.ResetText();
                
                lblTotalCost.ResetText();

                Decimal totalcost = 0;

                while (dr.Read() == true)
                {
                    statusLabel = "Gjitha Opsionet !";
                    if (searchServices == "0")
                    {
                        if (cmbStatus.Text == "") { statusLabel = "Gjitha Opsionet !"; } else { statusLabel = "Duke servisuar !"; }
                    }

                    else if (searchServices == "1")
                    {
                        statusLabel = "Servisuar me sukses !";
                    }

                    else if (searchServices == "2")
                    {
                        statusLabel = "Servisuar pa sukses !";
                    }
                    

                    int third = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);

                    totalcost += third;

                    dgw.Rows.Add(statusLabel, third);
                }

                Decimal calcvatAmount = totalcost - (totalcost * Convert.ToDecimal(0.2));

                lblSumVat.Text = calcvatAmount.ToString();
                lblTotalCost.Text = totalcost.ToString();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPDFServicesBuys_Load(object sender, EventArgs e)
        {
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }
    }
}
