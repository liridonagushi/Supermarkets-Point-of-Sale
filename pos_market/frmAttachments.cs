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
    public partial class frmAttachments : Form
    {
        public static Boolean UpdDoc;
        private static Boolean rowExist;
        public static string sFormIndex, nameFile;


        public frmAttachments()
        {
            InitializeComponent();
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.F))
            {
              btnFind.PerformClick();
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

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void FindingDocumentDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT attachments.id_attachment, attachments.name_doc, attachments.name_file, attachments.date_insert, attachments.description FROM attachments WHERE attachments.id_attachment='" + txtIDDoc.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                        txtIDDoc.Text = dr[0].ToString();
                        txtNameDoc.Text = dr[1].ToString();
                        lblUpload.Text = dr[2].ToString();
                        txtDateAdded.Text = dr[3].ToString();
                        txtDescription.Text = dr[4].ToString();

                        rowExist = true;
                        if (lblUpload.Text == "") { btnDownload.Enabled = false; btnDelFile.Enabled = false; } else { btnDownload.Enabled = true; btnDelFile.Enabled = true; }
                }
                
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Returning result values
        public string FindDocument
        {
            get { return txtIDDoc.Text; }                    
            set { txtIDDoc.Text = value; }
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
             frmFindAttachment.sFormIndex = "frmDocument";
             frmFindAttachment frm = new frmFindAttachment(this);
             frm.Show();
        }

        private void InsertDocument()
        {
            try
            {
                DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
                string datenow = dbDate1.ToString("yyyy-M-dd");
                txtDateAdded.Text = datenow;

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO attachments(name_doc, description, date_insert) VALUES('" + txtNameDoc.Text + "', '" + txtDescription.Text + "', '" + datenow + "')", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Dokumenti u insertua me sukses");
                    UpdDoc = true;
                    btnUpload.Enabled = true;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteFile()
        {
            try
            {
                DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
                string datenow = dbDate1.ToString("yyyy-M-dd");
                txtDateAdded.Text = datenow;

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE attachments SET name_file='' WHERE id_attachment='" + txtIDDoc.Text + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    lblUpload.Text = "";
                    btnDownload.Enabled = false;
                    btnDelete.Enabled = false;
                    UpdDoc = true;

                    MessageBox.Show("Fajli u fshi me sukses", "File deleted !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDocument()
        {
            try
            {
                DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
                string datenow = dbDate1.ToString("yyyy-M-dd");
                txtDateAdded.Text = datenow;
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE attachments SET name_doc='" + txtNameDoc.Text + "', name_file='" + nameFile + "', description='" + txtDescription.Text + "', date_insert='" + datenow + "' WHERE id_attachment = '" + txtIDDoc.Text + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Dokumenti u ndryshua me sukses");
                    UpdDoc = true;
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
           txtIDDoc.ResetText();
           txtNameDoc.ResetText();
           lblUpload.Text = "";
           txtDescription.ResetText();
           txtDateAdded.Clear();
           UpdDoc = false;
           btnSave.Enabled = false;
           btnDelete.Enabled = false;
        }

        private void FindDocumentNumber()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_attachment FROM attachments ORDER BY id_attachment DESC LIMIT 1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if ((dr.Read() == true) && (UpdDoc == false))
                {
                    int idNumber;
                    idNumber = dr.GetInt32(0) + 1;
                    txtIDDoc.Text = idNumber.ToString();
                }
                else
                {
                    txtIDDoc.Text = "999";
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindDocumentExist()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT name_doc FROM attachments WHERE name_doc = '" + txtNameDoc.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                    rowExist = false;
                if ((dr.Read() == true))
                {
                    rowExist = true;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindUpdDocumentExist()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT name_doc FROM attachments WHERE name_doc = '" + txtNameDoc.Text + "' AND id_attachment<>" + txtIDDoc.Text + "", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                    rowExist = false;
                if (dr.Read())
                {
                    rowExist = true;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAttachments_Load(object sender, EventArgs e)
        {
            txtIDDoc.Focus();
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnDownload.Enabled = false;
            btnDelFile.Enabled = false;
            btnUpload.Enabled = false;
        }

        private void txtIDDoc_TextChanged(object sender, EventArgs e)
        {
            FindingDocumentDetails();
            if (rowExist == true)
            {
                btnUpload.Enabled = true;
                btnSave.Enabled = true;
                rowExist = false;
            }
            else {
                btnUpload.Enabled = false;
                btnDownload.Enabled = false;
                btnDelFile.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearValues();
            FindDocumentNumber();
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnDelFile.Enabled = false;
            btnUpload.Enabled = false;
            btnDownload.Enabled = false;
            lblUpload.ResetText();
            txtNameDoc.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtIDDoc.Text == "") || (txtNameDoc.Text == "") || (txtDescription.Text == ""))
            {
                MessageBox.Show("Mbushni fushat e zbrazta para se të ruani !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UpdDoc == true)
                {
                    FindUpdDocumentExist();
                    if (rowExist == true)
                    {
                        MessageBox.Show("Emri ekziston ne databaz !", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rowExist = false;
                    }
                    else { 
                        UpdateDocument();
                    }
                }
                else
                {
                 FindDocumentExist();

                 if (rowExist == true)
                 {
                     MessageBox.Show("Emri ekziston ne databaz !", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     rowExist = false;
                 }
                 else { 
                    InsertDocument();
                    btnUpload.Enabled = true;
                 }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/files/" + lblUpload.Text);
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
        }

        private void DBUpdateUpload()
        {
            try
            {
                DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
                string datenow = dbDate1.ToString("yyyy-M-dd");

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE attachments SET name_file='" + nameFile + "' WHERE id_attachment = " + txtIDDoc.Text + "", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    UpdDoc = true;

                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DBUpdateUpload", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string folderPath = "C:/files/";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                DBUpdateUpload();
                if (UpdDoc == true)
                {
                    btnDownload.Enabled = true;
                    btnDelFile.Enabled = true;

                    DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);

                    string file = @"" + openFileDialog1.FileName + "";

                    string filename = dbDate1.ToString("hhmmss");
                    string extension = Path.GetExtension(file);
                    nameFile = filename + "" + extension;
                    lblUpload.Text = nameFile;

                    string moveTo = @"C:/files/" + lblUpload.Text;
                    System.IO.File.Copy(file, moveTo);
                    UpdateDocument();
                }
                else
                {
                    MessageBox.Show("Nje gabim ndodhi pergjat uplodimit te fajlit", "Error Upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDownload.Enabled = false;
                    btnDelFile.Enabled = false;
                }
            }
        }

        private void btnDelFile_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A jeni i sigurt te fshini fajlin ?", "Remove File ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFile();
            }
        }
    }
}