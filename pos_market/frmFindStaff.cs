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
    public partial class frmFindStaff : Form
    {

        public static string sFormIndex;


        private frmStaff mainForm = null;

        public static Boolean UpdStaff;

        public frmFindStaff()
        {
            InitializeComponent();
        }

        public frmFindStaff(Form callingForm)
        {
            mainForm = callingForm as frmStaff;

            InitializeComponent();
        }
        private void doubleClick() {
            // If there isn't any selected row, do nothing
            if (dgw.CurrentRow != null & dgw.SelectedRows.Count > 0)
            {
                if (sFormIndex == "frmStaff")
                {
                    this.mainForm.FindStaff = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
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
              txtSearchStaff.Focus();
                // Display selected cell's value
                return true;
            }

            if (keyData == Keys.LShiftKey)
            {
                // Check if Escape is clicked
                txtSearchStaff.Focus();
                // Display selected cell's value
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void button1_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void findStaff()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_user, username, fullname, phone, email, adress, date_registration, city, p_code, country FROM users ORDER BY id_user", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    dgw.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchStaff_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_user, username, fullname, adress, city, p_code, country, phone, email, date_registration FROM users WHERE username LIKE '%" + txtSearchStaff.Text + "%' OR fullname LIKE '%" + txtSearchStaff.Text + "%'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    dgw.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFindStaff_Load(object sender, EventArgs e)
        {
            findStaff();
            dgw.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgw.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchStaff.ResetText();
            dgw.Rows.Clear();
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleClick();
        }

    }
}
