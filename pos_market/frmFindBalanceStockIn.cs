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
    public partial class frmFindBalanceStockIn : Form
    {
        public static string sFormIndex;
        private frmBalanceStockin mainForm = null;

        public frmFindBalanceStockIn()
        {
            InitializeComponent();
        }

        public frmFindBalanceStockIn(Form callingForm)
        {

            if (sFormIndex == "BalanceStockin")
            {
                mainForm = callingForm as frmBalanceStockin;
            }
           
            InitializeComponent();
        }

        private void doubleClick() {
            // If there isn't any selected row, do nothing
            if (dgw.CurrentRow != null & dgw.SelectedRows.Count > 0)
            {
                if (sFormIndex == "BalanceStockin")
                {
                    this.mainForm.FindInvoiceCode = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
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
                // Check if down key is pressed
                dgw.Focus();
                dgw.CurrentCell = dgw.Rows[0].Cells[2];
                // Display selected cell's value
                return true;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void ShowInvoices()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT imp_invoices.invoice_code, CONCAT(distributors.company ,' ', distributors.BankAccountNumber) AS comnpany, imp_invoices.date_invoice, imp_invoices.date_payment, imp_invoices.vatAmount, imp_invoices.totalAmount, type_payments.type_payment FROM imp_invoices LEFT JOIN distributors ON imp_invoices.id_distributor = distributors.id_distributor LEFT JOIN type_payments ON imp_invoices.id_type_payment=type_payments.id_type_payment WHERE payment_status=0 ORDER BY imp_invoices.id_invoice DESC", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read() == true)
                {
                    DateTime dbDate1 = Convert.ToDateTime(dr[2]);
                    string InvoiceDate = dbDate1.ToString("dd-M-yyyy");

                    DateTime dbDate2 = Convert.ToDateTime(dr[3]);
                    string InvoiceReg = dbDate2.ToString("dd-M-yyyy");

                    dgw.Rows.Add(dr[0], dr[1], InvoiceDate, InvoiceReg, dr[4], dr[5], dr[6]);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dgw.Rows.Clear();
        }

        private void frmFindBalanceStockIn_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            ShowInvoices();
            dgw.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgw.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT imp_invoices.invoice_code, CONCAT(distributors.company ,' ', distributors.BankAccountNumber) AS comnpany, imp_invoices.date_invoice, imp_invoices.date_payment, imp_invoices.vatAmount, imp_invoices.totalAmount, type_payments.type_payment FROM imp_invoices LEFT JOIN distributors ON imp_invoices.id_distributor = distributors.id_distributor LEFT JOIN type_payments ON imp_invoices.id_type_payment=type_payments.id_type_payment WHERE payment_status=0 AND imp_invoices.invoice_code LIKE '%" + txtSearch.Text + "%' OR distributors.company LIKE '%" + txtSearch.Text + "%'  ORDER BY imp_invoices.id_invoice DESC", conn);
                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    DateTime dbDate1 = Convert.ToDateTime(dr[2]);
                    string InvoiceDate = dbDate1.ToString("dd-M-yyyy");

                    DateTime dbDate2 = Convert.ToDateTime(dr[3]);
                    string InvoiceReg = dbDate2.ToString("dd-M-yyyy");

                    dgw.Rows.Add(dr[0], dr[1], InvoiceDate, InvoiceReg, dr[4], dr[5], dr[6]);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSearch.ResetText();
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleClick();
        }

    }
}
