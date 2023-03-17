using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    public partial class frmFindDistributor : Form
    {
        public static string sFormIndex;

        private frmDistributors thirdForm = null;
        private ImportInvoice fourthForm = null;

        public frmFindDistributor()
        {
            InitializeComponent();
        }

        public frmFindDistributor(Form callingForm)
        {
            if (sFormIndex == "frmSupplier")
            {
                thirdForm = callingForm as frmDistributors;
            }

            if (sFormIndex == "ImportInvoice")
            {
                fourthForm = callingForm as ImportInvoice;
            }
            InitializeComponent();
        }
        private void doubleClick() {
            // If there isn't any selected row, do nothing
            if (dgw.CurrentRow != null & dgw.SelectedRows.Count > 0)
            {
                if (sFormIndex == "frmSupplier")
                {
                    this.thirdForm.FindSupplier = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
                }
                else if (sFormIndex == "ImportInvoice")
                {
                    this.fourthForm.FindDistributorID = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
                    this.fourthForm.FindDistributorCompany = dgw.Rows[dgw.CurrentRow.Index].Cells[2].Value.ToString();
                }
                this.Hide();
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
               txtSearchSupplier.Focus();
                // Display selected cell's value
                return true;
            }

            if (keyData == Keys.LShiftKey)
            {
                // Check if Escape is clicked
                txtSearchSupplier.Focus();
                // Display selected cell's value
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void findDistributor() {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_distributor, fullname, company, adress, city, p_code, country, phone, email, date_registration, active FROM distributors ORDER BY id_distributor", conn);

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

        private void findTextChanged()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_distributor, fullname, company, adress, city, p_code, country, phone, email, date_registration, active FROM distributors WHERE company LIKE '%" + txtSearchSupplier.Text + "%' OR fullname LIKE '%" + txtSearchSupplier.Text + "%' ORDER BY id_distributor", conn);

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

        private void txtSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            findTextChanged();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void frmFindDistributor_Load(object sender, EventArgs e)
        {
            findDistributor();
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
