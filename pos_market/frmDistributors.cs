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
    public partial class frmDistributors : Form
    {
        public static string sFormIndex;
        public static Boolean UpdSupplier;
        public static Boolean DistributorExist;

        public frmDistributors()
        {
            InitializeComponent();
        }
        // Returning result values
        public string FindSupplier
        {
            get { return txtIDSupplier.Text; }
            set { txtIDSupplier.Text = value; }
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.F))
            {
                btnFindSupplier.PerformClick();
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

        private void FindingSupplierDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_distributor, fullname, company, adress, city, p_code, country, phone, email, BankAccountNumber, date_registration, active FROM distributors WHERE id_distributor='" + txtIDSupplier.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        txtSupplierFullName.Text = dr[1].ToString();
                        txtSupplierCompany.Text = dr[2].ToString();
                        txtSupplierAdress.Text = dr[3].ToString();
                        txtSupplierCity.Text = dr[4].ToString();
                        txtSupplierPCode.Text = dr[5].ToString();
                        txtSupplierCountry.Text = dr[6].ToString();
                        txtSupplierPhone.Text = dr[7].ToString();
                        txtSupplierEmail.Text = dr[8].ToString();
                        txtBankNumber.Text = dr[9].ToString();
                    }
                    UpdSupplier = true;
                    btnDelete.Enabled = true;
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertSupplier()
        {
            try
            {
                String dateToday = DateTime.Today.ToString("yyyy-MM-dd");

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO distributors(fullname, company, adress, city, p_code, country, phone, email, BankAccountNumber, date_registration) VALUES('" + txtSupplierFullName.Text + "', '" + txtSupplierCompany.Text + "', '" + txtSupplierAdress.Text + "', '" + txtSupplierCity.Text + "', '" + txtSupplierPCode.Text + "', '" + txtSupplierCountry.Text + "', '" + txtSupplierPhone.Text + "', '" + txtSupplierEmail.Text + "', '" + txtBankNumber.Text + "', '" + dateToday + "')", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Distributori u vendos me sukses", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdSupplier = true;
                    btnDelete.Enabled = true;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSupplier()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE distributors SET fullname='" + txtSupplierFullName.Text + "', company='" + txtSupplierCompany.Text + "', adress='" + txtSupplierAdress.Text + "', city='" + txtSupplierCity.Text + "', p_code='" + txtSupplierPCode.Text + "', country='" + txtSupplierCountry.Text + "', phone='" + txtSupplierPhone.Text + "', email='" + txtSupplierEmail.Text + "', BankAccountNumber='" + txtBankNumber.Text + "' WHERE id_distributor='" + txtIDSupplier.Text + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Distributor u ndryshua me sukses !", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdSupplier = true;
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
            txtIDSupplier.Clear();
            txtSupplierFullName.Clear();
            txtSupplierCompany.Clear();
            txtSupplierAdress.Clear();
            txtSupplierCity.Clear();
            txtSupplierPCode.Clear();
            txtSupplierCountry.Clear();
            txtSupplierPhone.Clear();
            txtSupplierEmail.Clear();
            txtBankNumber.Clear();
            UpdSupplier = false;
        }

        private void FindSupplierNumber()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_distributor FROM distributors ORDER BY id_distributor DESC LIMIT 1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if ((dr.Read() == true) && (UpdSupplier == false))
                {
                    int idNumber;
                    idNumber = dr.GetInt32(0) + 1;
                    txtIDSupplier.Text = idNumber.ToString();
                }
                else
                {
                    txtIDSupplier.Text = "999";
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
            if ((txtIDSupplier.Text == "") || (txtSupplierFullName.Text == "") || (txtSupplierCompany.Text == "") || (txtSupplierAdress.Text == "") || (txtSupplierPhone.Text == "") || (txtSupplierEmail.Text == ""))
            {
                MessageBox.Show("Mbushi fushat per te vazhduar ruajtjen !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UpdSupplier == true)
                {
                    UpdateSupplier();
                    txtIDSupplier.Enabled = false;
                }
                else
                {
                    InsertSupplier();
                    txtIDSupplier.Enabled = false;
                }
            }

        }

        private void btnFindSupplier_Click(object sender, EventArgs e)
        {
            frmFindDistributor.sFormIndex = "frmSupplier";
            frmFindDistributor frm = new frmFindDistributor(this);
            frm.Show();
        }

        private void txtIDSupplier_TextChanged(object sender, EventArgs e)
        {
            FindingSupplierDetails();
            btnSave.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearValues();
            FindSupplierNumber();
            txtSupplierFullName.Focus();
            txtIDSupplier.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void FindDistributorSales()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_distributor FROM imp_invoices WHERE id_distributor='" + txtIDSupplier.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if ((dr.Read() == true))
                {
                    DistributorExist = true;
                }
                else
                {
                    DistributorExist = false;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteDistributor()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM distributors WHERE id_distributor='" + txtIDSupplier.Text + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Distributori u fshij me sukses");
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            FindDistributorSales();
            if (DistributorExist == true)
            {
                MessageBox.Show("Ky distributor nuk mund te fshihet sepse eshte i lidhur me shitjet", "Error Deleting Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("A doni ta fshini kete distributor !", "Delete distributor !", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteDistributor();
                    ClearValues();
                    btnDelete.Enabled = false;
                    btnSave.Enabled = false;
                }
            }
        }

        private void frmDistributors_Load(object sender, EventArgs e)
        {
            txtSupplierFullName.Focus();
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.PerformClick();
        }
    }
}