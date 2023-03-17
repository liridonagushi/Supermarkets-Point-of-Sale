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
    public partial class frmFindAttachment : Form
    {
        public static string sFormIndex;
        public static Boolean UpdDoc;

        private frmAttachments mainForm = null;

        public frmFindAttachment(Form callingForm)
        {
            mainForm = callingForm as frmAttachments;

            InitializeComponent();
        }

        private void doubleClick() {
            // If there isn't any selected row, do nothing
            if (dgw.CurrentRow != null && dgw.Rows.Count > 0)
            {
                this.mainForm.FindDocument = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
                frmAttachments.UpdDoc = true;

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
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowAttachments()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT attachments.id_attachment, attachments.name_doc, attachments.name_file, attachments.date_insert FROM attachments ORDER BY attachments.name_doc", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    DateTime dbDate1 = Convert.ToDateTime(dr[3]);
                    string dateInsert = dbDate1.ToString("dd-M-yyyy");

                    dgw.Rows.Add(dr[0], dr[1], dr[2], dateInsert);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchAttachments()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT attachments.id_attachment, attachments.name_doc, attachments.name_file, attachments.date_insert FROM attachments WHERE attachments.name_doc LIKE '%" + txtSearchAttachment.Text + "%' OR attachments.name_file LIKE '%" + txtSearchAttachment.Text + "%' ORDER BY attachments.name_doc", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    DateTime dbDate1 = Convert.ToDateTime(dr[3]);
                    string dateInsert = dbDate1.ToString("dd-M-yyyy");

                    dgw.Rows.Add(dr[0], dr[1], dr[2], dateInsert);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmFindAttachment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void frmFindAttachment_Load(object sender, EventArgs e)
        {
            ShowAttachments();
        }

        private void txtSearchAttachment_TextChanged(object sender, EventArgs e)
        {
            SearchAttachments();
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleClick();
        }
    }
}
