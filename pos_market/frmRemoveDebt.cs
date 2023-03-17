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
    public partial class frmRemoveDebt : Form
    {
        private PosFront mainForm = null;
        public static string ProductCode;
        public static string id_client, id_employee;

        string dateNow = DateTime.Now.ToString("yyyy-MM-dd");

        public frmRemoveDebt()
        {
            InitializeComponent();
        }

        public frmRemoveDebt(Form callingForm)
        {
            mainForm = callingForm as PosFront;
            InitializeComponent();
        }

        private void FindClient()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT client_debts.id_client, clients.fullname, client_debts.debtValue FROM client_debts LEFT JOIN clients ON client_debts.id_client=clients.id_client WHERE clients.id_client = '" + txtIDCLient.Text + "' AND client_debts.type_payment='3'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read() == true)
                {
                    txtIDCLient.Text = dr[0].ToString();
                    txtClientName.Text = dr[1].ToString();
                    txtDebtAmount.Text = dr[2].ToString();
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
               this.Dispose(true);
                return true;
            }

            // Check if Enter is pressed
            if (keyData == Keys.Enter)
            {
                // If there isn't any selected row, do nothing
                if (txtClearDebtAmount.Text != null)
                {
                    if ((txtIDCLient.Text == "") || (txtClearDebtAmount.Text == ""))
                    {
                        MessageBox.Show("Mbushni fushat e zbrazta per te vazhduar !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Convert.ToDecimal(txtClearDebtAmount.Text) < 0)
                    {
                        MessageBox.Show("Numrat ne minus nuk pranohen !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else{
                        btnSubmit.PerformClick();
                        return true;
                     }
                }
                // Display first cell's value
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UpdateDebt()
        {
            try
            {
                Decimal debtCalc = Convert.ToDecimal(txtDebtAmount.Text) - Convert.ToDecimal(txtClearDebtAmount.Text);

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE client_debts SET debtValue = '" + debtCalc + "' WHERE id_client ='" + txtIDCLient.Text + "' AND type_payment=3", conn);
              
                int i = cmdDatabase.ExecuteNonQuery();

                if(i>0){
                    MessageBox.Show("Shuma borxhit " + txtClearDebtAmount.Text + " u fshij me sukses !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InsertPaidDebts();
                    txtClearDebtAmount.ResetText();
                    txtDebtAmount.Text = debtCalc.ToString();
                }
                 
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertPaidDebts()
        {
            try
            {
                Decimal debtCalc = Convert.ToDecimal(txtDebtAmount.Text);

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO paiddebts (StaffID, CustomerNo, debtValue, paidDate, type_payment)VALUES('" + id_employee + "', '" + id_client + "', '" + txtClearDebtAmount.Text + "', '" + dateNow + "', '1')", conn);

                cmdDatabase.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveDebt()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM client_debts WHERE id_client='" + txtIDCLient.Text + "' AND type_payment=3", conn);
                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Shuma borxhit " + txtClearDebtAmount.Text + " u fshi me sukses !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InsertPaidDebts();
                    txtClearDebtAmount.ResetText();
                    txtDebtAmount.Text = "0";
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRemoveDebt_Load(object sender, EventArgs e)
        {
            txtIDCLient.Text = id_client;
        }

        private void txtIDCLient_TextChanged(object sender, EventArgs e)
        {
            FindClient();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.mainForm.FindClient = id_client;
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e){

            if (txtClearDebtAmount.Text.Length == 0 || Convert.ToDecimal(txtClearDebtAmount.Text) < 0)
            {
                MessageBox.Show("Shuma e dhene duhet te jet me e madhe se zero !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtDebtAmount.Text.Length == 0)
            {
                MessageBox.Show("Shuma  e borxhit eshte zero dhe nuk mund te llogaritet !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            { 
                if (Convert.ToDecimal(txtClearDebtAmount.Text) - Convert.ToDecimal(txtDebtAmount.Text) == 0) { RemoveDebt(); } else { UpdateDebt(); }
            }
        }

        private void txtClearDebtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDebtAmount_TextChanged(object sender, EventArgs e)
        {
        }
    }
}