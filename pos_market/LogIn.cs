using System;
using System.IO;
using System.Data;
using System.Management;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    public partial class LogIn : Form
    {

        public static String infoUsername;
        private static string cpuInfo, volumeSerial;

        public LogIn()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if Enter is pressed
           

            if (keyData == Keys.Escape)
            {
                // Check if Escape is clicked
               this.Dispose(true);
                // Display selected cell's value
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnEnter;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnEnter;
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Jepeni pseudonimin !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Jepeni passwordin !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_user, username, password FROM users WHERE username='" + txtUsername.Text + "' && password='" + txtPassword.Text + "'", conn);

            MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

            if (dr.Read() == true)
            {
                frmMain frm = new frmMain();
                frm.txtUsername.Text = dr[1].ToString();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Gabim pseudonimi ose passwordi !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }

            conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gabim mysql serveri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void procesorID() {
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                cpuInfo = managObj.Properties["processorID"].Value.ToString();
                break;
            }
        }

        private string getUniqueID(string drive)
        {
            if (drive == string.Empty)
            {
                //Find first drive
                foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                {
                    if (compDrive.IsReady)
                    {
                        drive = compDrive.RootDirectory.ToString();
                        break;
                    }
                }
            }

            if (drive.EndsWith(":\\"))
            {
                //C:\ -> C
                drive = drive.Substring(0, drive.Length - 2);
            }

            volumeSerial = getVolumeSerial(drive);

            //Mix them up and remove some useless 0's
            return volumeSerial;
        }

        private string getVolumeSerial(string drive)
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();

            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();

            return volumeSerial;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            getUniqueID("C");

            procesorID();

            unique.Text = volumeSerial;
            cpu.Text = cpuInfo;

            lblActivation.Hide();

            if ((cpuInfo == "123") && (volumeSerial == "123"))
            {
                btnEnter.Enabled = true;
            }
            else
            {
                btnEnter.Enabled = false;
                lblActivation.Show();
            }
                btnEnter.Enabled = true;
        }
    }
}
