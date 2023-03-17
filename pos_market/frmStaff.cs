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
    public partial class frmStaff : Form
    {
        public static string sFormIndex;
        public static Boolean UpdStaff;
        public static Boolean StaffExist;

        public frmStaff()
        {
            InitializeComponent();
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.F))
            {
                btnFindCl.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.N))
            {
                btnNew.PerformClick();
                return true;
            }

            if (keyData == Keys.Enter)
            {
                btnSave.PerformClick();
                return true;
            }

            if (keyData == Keys.Escape)
            {
               this.Dispose(true);
                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Returning result values
        public string FindStaff
        {
            get { return txtStaffId.Text; }
            set { txtStaffId.Text = value; }
        }

        private void FindingUserDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT users.id_user, users.username, users.fullname, users.adress, users.city, users.p_code, users.country, users.phone, users.email, users.date_registration, users.password, users.user_type, user_types.type FROM users LEFT JOIN user_types ON users.user_type=user_types.id_type WHERE id_user='" + txtStaffId.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    cmbLevelAdmin.ResetText();

                    while (dr.Read() == true)
                    {
                        txtStaffUsername.Text = dr[1].ToString();
                        txtStaffFullName.Text = dr[2].ToString();
                        txtStaffAdress.Text = dr[3].ToString();
                        txtStaffCity.Text = dr[4].ToString();
                        txtStaffPCode.Text = dr[5].ToString();
                        txtStaffCountry.Text = dr[6].ToString();
                        txtStaffPhone.Text = dr[7].ToString();
                        txtStaffEmail.Text = dr[8].ToString();
                        txtStaffPassword.Text = dr[10].ToString();
                        cmbLevelAdmin.Text = dr[11].ToString() + " " + dr[12].ToString();;
                    }

                    UpdStaff = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFindCl_Click(object sender, EventArgs e)
        {
            frmFindStaff.sFormIndex = "frmStaff";
            frmFindStaff frm = new frmFindStaff(this);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void InsertStaff()
        {
            try
            {
                String dateToday = DateTime.Today.ToString("yyyy-MM-dd");
                var SearchTypeStaff = cmbLevelAdmin.Text.ToString().Split(' ')[0];

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO users(fullname, username, adress, city, p_code, country, phone, email, password, user_type, date_registration) VALUES('" + txtStaffFullName.Text + "', '" + txtStaffUsername.Text + "', '" + txtStaffAdress.Text + "', '" + txtStaffCity.Text + "', '" + txtStaffPCode.Text + "', '" + txtStaffCountry.Text + "', '" + txtStaffPhone.Text + "', '" + txtStaffEmail.Text + "', '" + txtStaffPassword.Text + "', '" + SearchTypeStaff + "', '" + dateToday + "')", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Stafi u vendos  me sukses", "Staff Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdStaff = true;
                    btnDelete.Enabled = true;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateClient()
        {
            try
            {
                var SearchTypeStaff = cmbLevelAdmin.Text.ToString().Split(' ')[0];

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE users SET fullname='" + txtStaffFullName.Text + "', username='" + txtStaffUsername.Text + "', password='" + txtStaffPassword.Text + "', adress='" + txtStaffAdress.Text + "', city='" + txtStaffCity.Text + "', p_code='" + txtStaffPCode.Text + "', country='" + txtStaffCountry.Text + "', phone='" + txtStaffPhone.Text + "', email='" + txtStaffEmail.Text + "', user_type='" + SearchTypeStaff + "' WHERE id_user='" + txtStaffId.Text + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Stafi u ndryshua me sukses","Staff updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdStaff = true;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearValues()
        {
            txtStaffId.ResetText();
            txtStaffFullName.ResetText();
            txtStaffUsername.ResetText();
            txtStaffPassword.ResetText();
            txtStaffAdress.ResetText();
            txtStaffCity.ResetText();
            txtStaffPCode.ResetText();
            txtStaffCountry.ResetText();
            txtStaffPhone.ResetText();
            txtStaffEmail.ResetText();
            cmbLevelAdmin.ResetText();
            UpdStaff = false;
        }

        private void FindStaffNumber()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_user FROM users ORDER BY id_user DESC LIMIT 1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if ((dr.Read() == true) && (UpdStaff == false))
                {
                    int idNumber;
                    idNumber = dr.GetInt32(0) + 1;
                    txtStaffId.Text = idNumber.ToString();
                }
                else
                {
                    txtStaffId.Text = "999";
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtStaffId.Text == "") || (txtStaffFullName.Text == "") || (txtStaffUsername.Text == "") || (txtStaffAdress.Text == "") || (txtStaffPhone.Text == "") || (txtStaffEmail.Text == "") || (cmbLevelAdmin.Text == ""))
            {
                MessageBox.Show("Mbushni fushat e zbrazta para se ta beni ruajtjen !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UpdStaff == true)
                {
                    UpdateClient();
                    txtStaffId.Enabled = false;
                }
                else
                {
                    InsertStaff();
                    txtStaffId.Enabled = false;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearValues();
            FindStaffNumber();
            btnDelete.Enabled = false;
            txtStaffId.Enabled = false;
            btnSave.Enabled = true;
            txtStaffFullName.Focus();
        }

        private void FillingCombobox()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_type, type FROM user_types", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                    while (dr.Read()==true)
                    {
                        cmbLevelAdmin.Items.Add(dr[0].ToString() + " " + dr[1].ToString());
                    }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            FillingCombobox();
            btnNew.PerformClick();
        }

        private void FindStaffSales()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT StaffID FROM pos WHERE StaffID='" + txtStaffId.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if ((dr.Read() == true))
                {
                    StaffExist = true;
                }
                else
                {
                    StaffExist = false;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteStaff()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM users WHERE id_user='" + txtStaffId.Text + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Stafi u fshi me sukses !", "Deleted Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                MySqlCommand cmdDatabase1 = new MySqlCommand("ALTER TABLE users AUTO_INCREMENT = 1", conn);

                cmdDatabase1.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FindStaffSales();
            if (StaffExist == true)
            {
                MessageBox.Show("Ky staf nuk mund te fshihet sepse eshte i lidhur me shitjet !", "Error Deleting user", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("A doni ta fshini kete staf !", "Delete user !", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteStaff();
                    ClearValues();
                    btnDelete.Enabled = false;
                    btnSave.Enabled = false;
                }
            }
        }

        private void txtStaffId_TextChanged(object sender, EventArgs e)
        {
            FindingUserDetails();
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
        }

    }
}
