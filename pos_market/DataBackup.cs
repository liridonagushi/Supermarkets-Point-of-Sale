using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Net.WebClient;
using Ionic.Zip;
using System.IO;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    public partial class DataBackup : Form
    {
        private static int id_link;
        private static string localLink, serverLink;
        public static Boolean toBackUp;
        public DataBackup()
        {
            InitializeComponent();
        }

        // Constructor.
        private void FolderBrowserDialogExampleForm()
        {
            var folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        }

        public static bool HasConnection()
        {
            try
            {
                System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void FindLocal() { 
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT backupfolder FROM backuplinks WHERE id_link='" + id_link + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    if (id_link == 1) { 
                    txtSourceBackup.Text = dr[0].ToString();
                    }
                    else if (id_link == 2)
                    {
                        txtSourceBackup2.Text = dr[0].ToString();
                    }
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindDates()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT name_backup FROM backup_db WHERE id_backup='" + id_link + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    if (id_link == 1)
                    {
                        dtBackup.Text = dr[0].ToString();
                    }
                    else if (id_link == 2)
                    {
                        dtBackup2.Text = dr[0].ToString();
                    }

                    else if (id_link == 3)
                    {
                        dtBackup3.Text = dr[0].ToString();
                    }
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBackup1()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();

                conn.Open();
                string sourcebackup = txtSourceBackup.Text.ToString();
                var query = sourcebackup.Replace(@"\", @"\\");

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE backuplinks SET backupfolder='" + query + "' WHERE id_link=1", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Lokacioni i backup lokal u regjistrua !", "Local Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBackup2()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                string sourcebackup = txtSourceBackup2.Text.ToString();
                var query = sourcebackup.Replace(@"\", @"\\");

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE backuplinks SET backupfolder='" + query + "' WHERE id_link=2", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Lokacioni i backup server u regjistrua !", "Server Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDate1()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE backup_db SET name_backup='" + dtBackup.Text + "' WHERE id_backup=1", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Data e parë e backup u ruajt për cdo " + dtBackup.Text + " të muajit !", "Server Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDate2()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE backup_db SET name_backup='" + dtBackup2.Text + "' WHERE id_backup=2", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Data e dytë e backup u ruajt për cdo " + dtBackup2.Text + " të muajit !", "Server Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDate3()
        {

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE backup_db SET name_backup='" + dtBackup3.Text + "' WHERE id_backup=3", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Data e tretë e backup u ruajt për cdo " + dtBackup3.Text + " të muajit !", "Server Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void BackupDatabase()
            {
                DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
                string dateNow = dbDate1.ToString("yyyy-M-dd");
                string datetimeNow = dbDate1.ToString("yyyy-M-dd HH:mm:ss");
                string nameBackup = dbDate1.ToString("dd");

                try
                {
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    conn.Open();

                    MySqlCommand cmdDatabase = new MySqlCommand("UPDATE backup_db SET date_backup='" + dateNow + "' WHERE name_backup='" + nameBackup + "'", conn);

                    int i = cmdDatabase.ExecuteNonQuery();

                    if (i > 0)
                    {
                        MessageBox.Show("Databaza u bë backup me sukses !", "Server Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;

                this.txtSourceBackup.Text = path + @"\";
            }
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                var path2 = folderBrowserDialog2.SelectedPath;

                this.txtSourceBackup2.Text = path2 + @"\";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void DataBackup_Load(object sender, EventArgs e)
        {
            getlocallink();
            getserverllink();

            id_link=1;
            FindLocal();
            FindDates();
            id_link = 2;
            FindDates();
            FindLocal();
            id_link = 3;
            FindDates();

            if (toBackUp == true) { btnBackup.PerformClick(); toBackUp = false; }
        }

        private void getlocallink()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_link, type_backup, backupfolder FROM backuplinks WHERE id_link=1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                        localLink = dr[2].ToString();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getserverllink()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_link, type_backup, backupfolder FROM backuplinks WHERE id_link=2", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                        serverLink = dr[2].ToString();
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
            UpdateBackup1();
            UpdateBackup2();
            UpdateDate1();
            UpdateDate2();
            UpdateDate3();
        }

        private void LocalBackUp()
        {
            try
            {
                DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
            string nameBackup = dbDate1.ToString("dd") + ".sql";

            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            string file = localLink + "" + nameBackup;
            MySqlCommand cmdDatabase = new MySqlCommand("", conn);
            MySqlBackup mb = new MySqlBackup(cmdDatabase);
            mb.ExportToFile(file);
        }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LocalBackUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
        
        private void OnlineBackUp()
        {
            try
            {
            DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
            string nameBackup = dbDate1.ToString("dd") + ".sql";

            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            string file = serverLink + "" + nameBackup;
            MySqlCommand cmdDatabase = new MySqlCommand("", conn);
            MySqlBackup mb = new MySqlBackup(cmdDatabase);
            mb.ExportToFile(file);
}

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OnlineBackUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CompressLocalDb() {
            try
            {
                DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
            string nameBackup = dbDate1.ToString("dd") + ".sql";
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(localLink + "" + nameBackup);
                zip.Save(localLink + "" + nameBackup + ".zip");
            }
}

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CompressLocalDb", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CompressServerlDb()
        {
            try
            {
                DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
            string nameBackup = dbDate1.ToString("dd") + ".sql";
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(serverLink + "" + nameBackup);
                zip.Save(serverLink + "" + nameBackup + ".zip");
            }
}

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CompressServerlDb", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSourceBackup_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSourceBackup2_TextChanged(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog2_HelpRequest(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (HasConnection() == false) {
                MessageBox.Show("Backup nuk mundet të bëhet në server, nuk ka konektim me internet !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else{

                getlocallink();
                getserverllink();

                LocalBackUp();
                OnlineBackUp();
                CompressLocalDb();
               // CompressServerlDb();
                BackupDatabase();

                string folderPath = "C:/BarcodeImgs/";
                System.IO.DirectoryInfo di = new DirectoryInfo(folderPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }

                string folderPath1 = "C:/PDFs/";
                System.IO.DirectoryInfo di1 = new DirectoryInfo(folderPath1);

                foreach (FileInfo file in di1.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo dir in di1.GetDirectories())
                {
                    dir.Delete(true);
                }

                if (toBackUp == true) {
                    MessageBox.Show("Databaza u bë backup me sukses !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClose.PerformClick();
                }
            }
        }
    }
}