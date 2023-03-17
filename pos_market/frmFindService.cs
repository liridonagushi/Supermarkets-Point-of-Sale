using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    public partial class frmFindService : Form
    {
        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");

        public static string myUsername;

        private frmService mainForm = null;

        private static int id_user;

        private static String serviceStatus, statusLabel, searchQuery;
        
        public frmFindService()
        {
            InitializeComponent();
        }

        public frmFindService(Form callingForm)
        {
            mainForm = callingForm as frmService;

            InitializeComponent();
        }

        private void doubleClick() {
            // If there isn't any selected row, do nothing
            if (dgw.CurrentRow != null & dgw.SelectedRows.Count > 0)
            {

                this.mainForm.FindService = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();

               this.Dispose(true);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if Enter is pressed
            if (keyData == Keys.Enter)
            {
                doubleClick();
                // Display first cell's value
                return true;
            }

            if (dgw.Focused != true && keyData == Keys.Down)
            {
                if (dgw.Rows.Count > 0)
                {
                    // Check if down key is pressed
                    // Display selected cell's value
                    dgw.Focus();
                    dgw.CurrentCell = dgw.Rows[0].Cells[2];
                    return true;
                }
            }

            if (keyData == Keys.Escape)
            {
                // Check if Escape is clicked
               this.Dispose(true);
                // Display selected cell's value
                return true;
            }

            if (keyData == Keys.Tab)
            {
                // Check if Escape is clicked
                txtSearch.Focus();
                // Display selected cell's value
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowServices()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT repairing_services.id_service, clients.fullname, repairing_services.time_service, repairing_services.header_service, repairing_services.total_cost, repairing_services.status_service FROM repairing_services LEFT JOIN clients ON repairing_services.id_client=clients.id_client ORDER BY repairing_services.status_service ASC, repairing_services.id_service DESC", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    if (dr.GetInt32(5) == 0)
                    {
                        statusLabel = "Duke servisuar !";
                    }
                    else if (dr.GetInt32(5) == 1)
                    {
                        statusLabel = "Me sukses !";
                    }
                    else if (dr.GetInt32(5) == 2)
                    {
                        statusLabel = "Pa sukses !";
                    }

                    dgw.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], statusLabel);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindingIduser()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_user FROM users WHERE username='" + myUsername + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                if (dr.Read() == true)
                {
                    id_user = dr.GetInt32(0);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchKeys() {

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                DateTime date1 = Convert.ToDateTime(dtStartDate.Text);
                string querydate1 = date1.ToString("yyyy-MM-dd 00:00:00");

                DateTime date2 = Convert.ToDateTime(dtEndDate.Text);
                string querydate2 = date2.ToString("yyyy-MM-dd 23:59:59");

                if (toServicing.Checked == true)
                {
                    serviceStatus = " AND repairing_services.status_service='0'";
                }

                if (toServiced.Checked == true)
                {
                    serviceStatus = " AND repairing_services.status_service='1'";
                }

                if ((toServicing.Checked == false) && (toServiced.Checked == false))
                {
                    serviceStatus = "";
                }

                if (txtSearch.Text != "")
                {
                    searchQuery = "AND (clients.fullname LIKE '%" + txtSearch.Text + "%' OR clients.other_details LIKE '%" + txtSearch.Text + "%' OR repairing_services.header_service LIKE '%" + txtSearch.Text + "%' OR repairing_services.id_service LIKE '%" + txtSearch.Text + "%')";
                }
                else {
                    searchQuery = "";
                }

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT repairing_services.id_service, clients.fullname, repairing_services.time_service, repairing_services.header_service, repairing_services.total_cost, repairing_services.status_service FROM repairing_services LEFT JOIN clients ON repairing_services.id_client=clients.id_client WHERE 1=1 " + searchQuery + " AND (repairing_services.time_service BETWEEN '" + querydate1 + "' AND '" + querydate2 + "') " + serviceStatus + " ORDER BY repairing_services.status_service ASC, repairing_services.id_service DESC", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    if (dr.GetInt32(5) == 0)
                    {
                        statusLabel = "Duke servisuar !";
                    }
                    else if (dr.GetInt32(5) == 1)
                    {
                        statusLabel = "Me sukses !";
                    }
                    else if (dr.GetInt32(5) == 2)
                    {
                        statusLabel = "Pa sukses !";
                    }

                    dgw.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], statusLabel);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchKeys();
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dgw.Rows.Clear();
        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            frmProducts frm = new frmProducts();
            frm.Show();
        }

        private void frmFindService_Load(object sender, EventArgs e)
        {
            ShowServices();

            DateTime dbDate1 = Convert.ToDateTime(dateTimeToday);

            var firstDate = dbDate1.ToString("yyyy-MM-dd");
            var secondDate = dbDate1.AddDays(-10).ToString("yyyy-MM-dd");

            dtStartDate.Text = secondDate;
            dtEndDate.Text = firstDate;
            
            dgw.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgw.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
         }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            searchKeys();
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            searchKeys();
        }

        private void toServiced_CheckedChanged(object sender, EventArgs e)
        {
            if (toServicing.Checked == true) { toServicing.Checked = false; }
            searchKeys();
        }

        private void toServicing_CheckedChanged(object sender, EventArgs e)
        {
            if (toServiced.Checked == true) { toServiced.Checked = false; }
            searchKeys();
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleClick();
        }

    }
}
