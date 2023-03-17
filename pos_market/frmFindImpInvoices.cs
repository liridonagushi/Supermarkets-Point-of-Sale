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


namespace Supermarkets
{
    public partial class frmFindImpInvoices : Form
    {
        public static string sFormIndex;
        private static string searchQuery;
        private frmPDFInvoiceDetail firstForm = null;

        public frmFindImpInvoices()
        {
            InitializeComponent();
        }

        public frmFindImpInvoices(Form callingForm)
        {
            if (sFormIndex == "frmPDFInvoiceDetail")
            {
                firstForm = callingForm as frmPDFInvoiceDetail;
            }

            InitializeComponent();
        }

        private void doubleClick() {
            // If there isn't any selected row, do nothing
            if (dgw.CurrentRow != null & dgw.SelectedRows.Count > 0)
            {
                if (sFormIndex == "frmPDFInvoiceDetail")
                {
                    this.firstForm.FindInvoiceCode = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
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
                txtSearchInvoice.Focus();
                // Display selected cell's value
                return true;
            }

            if (keyData == Keys.LShiftKey)
            {
                // Check if Escape is clicked
                txtSearchInvoice.Focus();
                // Display selected cell's value
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void findInvoice(){
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                searchQuery = "";
                if (txtSearchInvoice.Text == "") { searchQuery = " LIMIT 0"; }
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT imp_invoices.invoice_code, distributors.company, imp_invoices.date_invoice, imp_invoices.importAmount, imp_invoices.totalAmount, type_payments.type_payment, imp_invoices.payment_status FROM imp_invoices LEFT JOIN distributors ON imp_invoices.id_distributor = distributors.id_distributor LEFT JOIN type_payments ON imp_invoices.id_type_payment=type_payments.id_type_payment WHERE imp_invoices.invoice_code LIKE '%" + txtSearchInvoice.Text + "%' OR imp_invoices.importAmount LIKE '%" + txtSearchInvoice.Text + "%' ORDER BY imp_invoices.id_invoice DESC " + searchQuery + "", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                Decimal totalImport = 0;
                Decimal totalAmount = 0;

                Decimal totalImportSum = 0;
                Decimal totalAmountSum = 0;
                String payStat = "";

                while (dr.Read() == true)
                {
                    DateTime dbDate1 = Convert.ToDateTime(dr[2]);
                    string outDate = dbDate1.ToString("dd-M-yyyy");

                    totalImport = dr.IsDBNull(3) ? 0 : dr.GetDecimal(3);
                    totalAmount = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                    string paymentMethod = dr.IsDBNull(5) ? "" : dr.GetString(5);
                    int paymentStatus = dr.IsDBNull(6) ? 0 : dr.GetInt32(6);
                    if (paymentStatus == 0)
                    {
                        payStat = "Pa Paguar";
                    }
                    else
                    {
                        payStat = "Paguar";
                    }

                    totalAmountSum += totalAmount;
                    totalImportSum += totalImport;
                    dgw.Rows.Add(dr.GetString(0), dr.GetString(1), outDate, totalImport, totalAmount, paymentMethod, payStat);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgw.Rows.Clear();
            txtSearchInvoice.ResetText();
        }

        private void txtSearchInvoice_TextChanged(object sender, EventArgs e)
        {
            dgw.Rows.Clear();
            findInvoice();
        }

        private void frmFindImpInvoices_Load(object sender, EventArgs e)
        {
            dgw.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgw.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleClick();
        }
    }
}
