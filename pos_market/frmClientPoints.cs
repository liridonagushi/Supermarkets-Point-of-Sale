using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    public partial class frmClientPoints : Form
    {
        public static string sFormIndex;

        public frmClientPoints()
        {
            InitializeComponent();
        }

        // Returning result values
        public string FindClient
        {
            get { return txtIdClient.Text; }
            set { txtIdClient.Text = value; }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            frmFindClient.sFormIndex = "ClientPoints";
            frmFindClient frm = new frmFindClient(this);
            frm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void FindingClientPoints()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client, fullname, total_points FROM Clients WHERE id_Client='" + txtIdClient.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        txtIdClient.Text = dr[0].ToString();
                        txtCLient.Text = dr[1].ToString();
                        txtTotalPoints.Text = dr[2].ToString();
                    }
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtIdClient_TextChanged(object sender, EventArgs e)
        {
            FindingClientPoints();
        }

        private void ExportToCSV()
        {
            string folderPath = "C:/files/";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var file = @"C:/files/myOutput.csv";
            try
            {
                File.Delete(file);

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_client, fullname, company, total_points FROM clients", conn);
                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                using (var stream = File.CreateText(file))
                {
                    string csvRow = string.Format("{0},{1},{2},{3}", "Id Client", "Name", "company", "Total Points");
                    stream.WriteLine(csvRow);
                    while (dr.Read())
                    {
                            string first = dr.IsDBNull(0) ? "" : dr.GetString(0);
                            string second = dr.IsDBNull(1) ? "" : dr.GetString(1);
                            string third = dr.IsDBNull(2) ? "" : dr.GetString(2);
                            string fourth = dr.IsDBNull(3) ? "0" : dr.GetString(3);

                            csvRow = string.Format("{0},{1},{2},{3}", first, second, third, fourth);
                            stream.WriteLine(csvRow);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni ti shkarkoni gjitha piket per gjith klientet ?", "CSV File Download !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string folderPath = "C:/files/";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                ExportToCSV();
                var file = "C:/files/myOutput.csv";
                System.Diagnostics.Process.Start(file);
            }
        }
    }
}