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
    public partial class frmClients : Form
    {
        public static string sFormIndex, ClientName;

        public static Boolean UpdClient, clientExist, findClientForm;

        private frmFindClient mainForm = null;

        public frmClients()
        {
            InitializeComponent();
        }
        public frmClients(Form callingForm)
        {
            mainForm = callingForm as frmFindClient;

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

            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave.PerformClick();
                return true;
            }

            if (keyData == (Keys.Delete))
            {
                btnDelete.PerformClick();
                return true;
            }

            if (keyData == (Keys.Escape))
            {
               this.Dispose(true);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Returning result values
        public string FindClient
        {
            get { return txtIdCl.Text; }
            set { txtIdCl.Text = value; }
        }

        private void FindingClientDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client, fullname, other_details, date_registration FROM clients WHERE id_Client='" + txtIdCl.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        txtClFullName.Text = dr[1].ToString();
                        txtDetails.Text = dr[2].ToString();
                    }
                    UpdClient = true;
                    btnDelete.Enabled = true;
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmFindClient.sFormIndex = "frmClient";
            frmFindClient frm = new frmFindClient(this);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void InsertClient()
        {
            try
            {
                String dateToday = DateTime.Today.ToString("yyyy-MM-dd");

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO clients(fullname,  other_details, date_registration) VALUES('" + txtClFullName.Text + "', '" + txtDetails.Text + "', '" + dateToday + "')", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Klienti u vendos me sukses !", "Client Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdClient = true;
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
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE Clients SET fullname='" + txtClFullName.Text + "', other_details='" + txtDetails.Text + "' WHERE id_Client='" + txtIdCl.Text + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Klienti u ndryshua me sukses !", "Client Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdClient = true;
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
            txtIdCl.Clear();
            txtClFullName.Clear();
            txtDetails.Clear();
           
            UpdClient = false;
        }

        private void FindClientNumber()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client FROM clients ORDER BY id_client DESC LIMIT 1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if ((dr.Read() == true) && (UpdClient == false))
                {
                    int idNumber;
                    idNumber = dr.GetInt32(0) + 1;
                    txtIdCl.Text = idNumber.ToString();
                }
                else
                {
                    txtIdCl.Text = "999";
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindClientSales()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client FROM pos WHERE id_client='" + txtIdCl.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if ((dr.Read() == true))
                {
                    clientExist = true;
                }
                else
                {
                    clientExist = false;
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
            if ((txtIdCl.Text == "") || (txtClFullName.Text == "") || (txtDetails.Text == ""))
            {
                MessageBox.Show("Mbushni gjitha fushat per te bere ruajtjen e produkteve !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UpdClient == true)
                {
                    UpdateClient();
                    txtIdCl.Enabled = false;
                }
                else
                {
                    InsertClient();
                    txtIdCl.Enabled = false;
                }
            }
        }

        private void txtIDCl_TextChanged(object sender, EventArgs e)
        {
            FindingClientDetails();
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnFindCl_Click(object sender, EventArgs e)
        {
            frmFindClient.sFormIndex = "frmClient";
            frmFindClient frm = new frmFindClient(this);
            frm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (findClientForm == true)
            {
                this.mainForm.ParseClientName = txtClFullName.Text;
                this.Hide();
            }
            else
            {
                this.Dispose(true);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearValues();
            FindClientNumber();
            btnDelete.Enabled = false;
            txtIdCl.Enabled = false;
            btnDelete.Enabled = false;
            txtClFullName.Focus();
        }

        private void frmClients_Load(object sender, EventArgs e)
        {
            btnNew.PerformClick();
            if (ClientName != null)
            {
                txtClFullName.Text = ClientName;
            }
            if (findClientForm == true) {
                btnFindCl.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void DeleteClient()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM clients WHERE id_client='" + txtIdCl.Text + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Klienti u fshi me sukses");
                }

                MySqlCommand cmdDatabase1 = new MySqlCommand("ALTER TABLE clients AUTO_INCREMENT = 1", conn);

                cmdDatabase1.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FindClientSales();
            if(clientExist == true){
                MessageBox.Show("Ky klient nuk mund te fshihet sepse eshte i lidhur me shitjet !", "Error Deleting Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
            DialogResult dialogResult = MessageBox.Show("A jeni i sigurt te fshini kete klient !", "Delete Client !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteClient();
                ClearValues();
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
          }
        }
    }
}