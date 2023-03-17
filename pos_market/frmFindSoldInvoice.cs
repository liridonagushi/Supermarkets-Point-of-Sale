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
    public partial class frmFindSoldInvoice : Form
    {
        public static string sFormIndex;
        private static String searchKey;
        private frmPDFSoldInvoice fifthForm = null;

        public frmFindSoldInvoice(Form callingForm)
        {
            if (sFormIndex == "frmPDFSoldInvoice")
            {
                fifthForm = callingForm as frmPDFSoldInvoice;
            }

            InitializeComponent();
        }

        private void doubleClick()
        {
            // If there isn't any selected row, do nothing
            if (dgw.CurrentRow != null & dgw.SelectedRows.Count > 0)
            {
                if (sFormIndex == "frmPDFSoldInvoice")
                {
                    this.fifthForm.FindInvoiceCode = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
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

        private void findInvoice() {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                if (txtSearchInvoice.Text != "")
                {
                    searchKey = "SELECT pos.InvoiceNo, type_payments.type_payment, clients.fullname, pos.POSDate, pos.VatAmount, pos.TotalAmount FROM pos LEFT JOIN clients ON pos.id_client=clients.id_client LEFT JOIN type_payments ON pos.type_payment=type_payments.id_type_payment LEFT JOIN users ON pos.StaffID=users.id_user WHERE 1=1 AND pos.InvoiceNo LIKE '%" + txtSearchInvoice.Text + "%' ORDER BY pos.POSDate DESC";
                }
                else {
                    searchKey = " SELECT * FROM pos LIMIT 0";
                }

                MySqlCommand cmdDatabase = new MySqlCommand(searchKey, conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                if (dr.HasRows) {
                    while (dr.Read() == true)
                    {
                        Decimal SumVat = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                        Decimal totalAmount = dr.IsDBNull(5) ? 0 : dr.GetDecimal(5);

                        dgw.Rows.Add(dr[0], dr[1], dr[2], dr[3], SumVat, totalAmount);
                    }
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchInvoice_TextChanged(object sender, EventArgs e)
        {
            findInvoice();
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

        private void frmFindSoldInvoice_Load(object sender, EventArgs e)
        {
            dgw.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgw.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleClick();
        }
    }
}
