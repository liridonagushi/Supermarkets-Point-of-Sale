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
    public partial class frmFindDocuments : Form
    {

        public static string sFormIndex;

        private frmAttachments mainForm = null;

        public frmFindDocuments()
        {
            InitializeComponent();
        }

        public frmFindDocuments(Form callingForm)
        {
            mainForm = callingForm as frmAttachments;

            InitializeComponent();
        }
        private void doubleClick() {
            // If there isn't any selected row, do nothing
            if (dgw.CurrentRow != null & dgw.SelectedRows.Count > 0)
            {
                this.mainForm.FindDocument = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();

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
                txtSearchDoc.Focus();
                // Display selected cell's value
                return true;
            }

            if (keyData == Keys.LShiftKey)
            {
                // Check if Escape is clicked
                txtSearchDoc.Focus();
                // Display selected cell's value
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void ShowAttachments()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT attachments.id_attachment, attachments.name_doc, type_documents.type_document, attachments.date_insert FROM attachments LEFT JOIN type_documents ON attachments.id_type_doc=type_documents.id_type_document", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    dgw.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFindDocuments_Load(object sender, EventArgs e)
        {
            txtSearchDoc.Focus();
            dgw.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgw.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchDoc.Clear();
            dgw.Rows.Clear();
        }

        private void frmFindDocuments_Load_1(object sender, EventArgs e)
        {
            txtSearchDoc.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void txtSearchDoc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT attachments.id_attachment, attachments.name_doc, type_documents.type_document, attachments.date_insert FROM attachments LEFT JOIN type_documents ON attachments.id_type_doc=type_documents.id_type_document WHERE attachments.name_doc LIKE '%" + txtSearchDoc.Text + "%'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    dgw.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleClick();
        }

    }
}
