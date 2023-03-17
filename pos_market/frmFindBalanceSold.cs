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
    public partial class frmFindBalanceSold : Form
    {

        public static string sFormIndex;
        private static string searchClient;
        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");

        private frmBalanceSoldInvoice mainForm = null;

        public frmFindBalanceSold()
        {
            InitializeComponent();
        }

        public frmFindBalanceSold(Form callingForm)
        {

            if (sFormIndex == "frmPDFInvoiceDetail")
            {
                mainForm = callingForm as frmBalanceSoldInvoice;
            }
           
            InitializeComponent();
        }
        private void clearSearch() {
            dgw.Rows.Clear();
            txtSearch.ResetText();
        }
        private void doubleClick() {
            // If there isn't any selected row, do nothing
            if (dgw.CurrentRow != null & dgw.SelectedRows.Count > 0)
            {
                if (sFormIndex == "frmPDFInvoiceDetail")
                {
                    this.mainForm.FindInvoiceCode = dgw.Rows[dgw.CurrentRow.Index].Cells[1].Value.ToString();
                }

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
                if (dgw.Rows.Count > 0) { 
                // Check if down key is pressed
                dgw.Focus();
                dgw.CurrentCell = dgw.Rows[0].Cells[2];
                // Display selected cell's value
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

            if (keyData == Keys.LShiftKey)
            {
                // Check if Escape is clicked
                txtSearch.Focus();
                // Display selected cell's value
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void ShowInvoices()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT clients.id_client, client_debts.InvoiceNo, clients.fullname, clients.other_details, client_debts.debtDate, client_debts.debtValue FROM client_debts LEFT JOIN clients ON client_debts.id_client=clients.id_client WHERE type_payment=2 ORDER BY client_debts.id_client", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    dgw.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchText() {
            try
            {
                if (txtSearch.Text != "") { searchClient = "AND clients.fullname LIKE '%" + txtSearch.Text + "%' OR clients.id_client LIKE '%" + txtSearch.Text + "%' OR client_debts.InvoiceNo LIKE '%" + txtSearch.Text + "%'"; } else { searchClient = ""; }

                DateTime dbDate1 = Convert.ToDateTime(dtFrom.Text);
                DateTime dbDate2 = Convert.ToDateTime(dtTo.Text);

                string startDate = dbDate1.ToString("yyyy-M-dd");
                string toDate = dbDate2.ToString("yyyy-M-dd");

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT clients.id_client, client_debts.InvoiceNo, clients.fullname, clients.other_details, client_debts.debtDate, client_debts.debtValue FROM client_debts LEFT JOIN clients ON client_debts.id_client=clients.id_client WHERE type_payment='2' AND client_debts.debtDate BETWEEN '" + startDate + "' AND '" + toDate + "' " + searchClient + " ORDER BY client_debts.id_client", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    dgw.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
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
            searchText();
        }

        private void frmFindBalanceSold_Load(object sender, EventArgs e)
        {
            DateTime dbDate1 = Convert.ToDateTime(dateTimeToday);

            var firstDate = dbDate1.ToString("yyyy-MM-dd");
            var secondDate = dbDate1.AddDays(-10).ToString("yyyy-MM-dd");
            dtFrom.Text = secondDate;
            dtTo.Text = firstDate;
            
            dgw.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgw.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ShowInvoices();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dgw.Rows.Clear();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            searchText();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            searchText();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtSearch.ResetText();
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleClick();
        }
    }
}
