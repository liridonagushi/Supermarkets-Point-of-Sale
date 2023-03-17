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
    public partial class frmFindClient : Form
    {
        public static string sFormIndex;

        private frmPDFexpInvoices thirdForm = null;

        private frmClients secondForm = null;

        private PosFront mainForm = null;

        private frmClientPoints fourthForm = null;

        private frmService fifthForm = null;

        public static Boolean UpdClient;

        public frmFindClient()
        {
            InitializeComponent();
        }
        public string ParseClientName
        {
            get { return txtSearchCl.Text; }
            set { txtSearchCl.Text = value; }
        }

        public frmFindClient(Form callingForm)
        {
            if (sFormIndex == "frmClient")
            {
                secondForm = callingForm as frmClients;
            }
            else if (sFormIndex == "frmPOS")
            {
                mainForm = callingForm as PosFront;
            }
            else if (sFormIndex == "pdfexpinvoice")
            {
                thirdForm = callingForm as frmPDFexpInvoices;
            }
            else if(sFormIndex == "ClientPoints")
            {
                fourthForm = callingForm as frmClientPoints;
            }
            else if (sFormIndex == "PhoneService")
            {
                fifthForm = callingForm as frmService;
            }

            InitializeComponent();
        }

        private void doubleClick() {
            // If there isn't any selected row, do nothing
            if (dgw.CurrentRow != null & dgw.SelectedRows.Count > 0)
            {
                if (sFormIndex == "frmClient")
                {
                    this.secondForm.FindClient = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
                    frmClients.UpdClient = true;
                }
                else if (sFormIndex == "frmPOS")
                {
                    this.mainForm.FindClient = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
                }
                else if (sFormIndex == "pdfexpinvoice")
                {
                    this.thirdForm.FindClient = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
                }
                else if (sFormIndex == "ClientPoints")
                {
                    this.fourthForm.FindClient = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
                }
                else if (sFormIndex == "PhoneService")
                {
                    this.fifthForm.FindClient = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
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
                txtSearchCl.Focus();
                // Display selected cell's value
                return true;
            }

            if (keyData == Keys.F1)
            {
                btnNewClient.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void ShowClients()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT clients.id_client, clients.fullname, clients.other_details, SUM(client_debts.debtValue) AS debts, SUM(clients.total_points) AS points FROM clients LEFT JOIN client_debts ON clients.id_client=client_debts.id_client GROUP BY clients.id_client", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read())
                {
                    string first = dr.IsDBNull(0) ? "" : dr.GetString(0);
                    string second = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    string third = dr.IsDBNull(2) ? "" : dr.GetString(2);
                    int fourth = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);
                    int fifth = dr.IsDBNull(4) ? 0 : dr.GetInt32(4);

                    dgw.Rows.Add(first, second, third, fourth, fifth);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchCl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT clients.id_client, clients.fullname, clients.other_details, SUM(client_debts.debtValue) AS debts, SUM(clients.total_points) AS points FROM clients LEFT JOIN client_debts ON clients.id_client=client_debts.id_client WHERE clients.other_details LIKE '%" + txtSearchCl.Text + "%' OR clients.fullname LIKE '%" + txtSearchCl.Text + "%' GROUP BY clients.id_client", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                    dgw.Rows.Clear();
                    while (dr.Read() == true)
                    {
                        string first = dr.IsDBNull(0) ? "" : dr.GetString(0);
                        string second = dr.IsDBNull(1) ? "" : dr.GetString(1);
                        string third = dr.IsDBNull(2) ? "" : dr.GetString(2);
                        int fourth = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);
                        int fifth = dr.IsDBNull(4) ? 0 : dr.GetInt32(4);

                        dgw.Rows.Add(first, second, third, fourth, fifth);
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
            txtSearchCl.Clear();
            dgw.Rows.Clear();
        }

        private void frmFindClient_Load(object sender, EventArgs e)
        {
            ShowClients();
            txtSearchCl.Focus();
            dgw.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgw.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            if (txtSearchCl.Text != "")
            {
                frmClients.ClientName = txtSearchCl.Text;
                txtSearchCl.ResetText();
                frmClients.findClientForm = true;
                frmClients frm = new frmClients(this);
                frm.Show();
            }
            else
            {

                frmClients.findClientForm = true;
                frmClients frm = new frmClients(this);
                frm.Show();
            }
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleClick();
        }
    }
}