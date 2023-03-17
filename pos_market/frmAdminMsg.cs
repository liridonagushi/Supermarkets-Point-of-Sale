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
    public partial class frmAdminMsg : Form
    {
        private static int msgCount;
        private static int startLimit;
        private static int startNumber;
        private static int endLimit;
        private static int messagesPerPage = 15;
        private string myUsername = frmMain.myUsername;

        //finding user info
        private static string findingUser;
        private static string findingIduser;
        private static string id_sender;
        private static string id_receiver;


        public frmAdminMsg()
        {
            InitializeComponent();
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter)
            {
                btnSend.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void CountMessages()
        {

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT COUNT(*) FROM messages", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Items.Clear();

                if (dr.Read() == true)
                {
                    msgCount = dr.GetInt32(0);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindData()
        {
            try
            {
                var otherUser = txtUser.Text.ToString().Split(' ')[0];
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT sender.username As sender, receiver.username AS receiver, messages.message, messages.date_msg FROM messages LEFT JOIN users AS sender ON (messages.id_sender=sender.id_user) LEFT JOIN users AS receiver ON (messages.id_receiver=receiver.id_user) WHERE ((sender.id_user='" + otherUser + "' AND receiver.username='" + myUsername + "') OR (sender.username='" + myUsername + "' AND receiver.id_user='" + otherUser + "')) ORDER BY messages.id_message DESC LIMIT " + startLimit + ", " + endLimit + "", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Items.Clear();

                while (dr.Read() == true)
                {
                    ListViewItem item = new ListViewItem(dr[0].ToString());
                    item.SubItems.Add(dr[1].ToString());
                    item.SubItems.Add(dr[2].ToString());
                    dgw.Items.Add(item);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindAllMessages()
        {
            try
            {

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT sender.username As sender, receiver.username AS receiver, messages.message, messages.date_msg FROM messages LEFT JOIN users AS sender ON (messages.id_sender=sender.id_user) LEFT JOIN users AS receiver ON (messages.id_receiver=receiver.id_user) WHERE (sender.username='" + myUsername + "' OR receiver.username='" + myUsername + "') ORDER BY messages.id_message DESC LIMIT " + startLimit + ", " + endLimit + "", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Items.Clear();

                while (dr.Read() == true)
                {
                    ListViewItem item = new ListViewItem(dr[0].ToString());
                    item.SubItems.Add(dr[1].ToString());
                    item.SubItems.Add(dr[2].ToString());
                    dgw.Items.Add(item);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindTotal()
        {
            try
            {
                var otherUser = txtUser.Text.ToString().Split(' ')[0];

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT COUNT(*) FROM messages LEFT JOIN users AS sender ON (messages.id_sender=sender.id_user) LEFT JOIN users AS receiver ON (messages.id_receiver=receiver.id_user) WHERE ((sender.id_user='" + otherUser + "' AND receiver.username='doni') OR (sender.username='" + myUsername + "' AND receiver.id_user='" + otherUser + "')) LIMIT " + startLimit + ", " + endLimit + "", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Items.Clear();

                if (dr.Read() == true)
                {
                    msgCount = dr.GetInt32(0);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAdminMsg_Load(object sender, EventArgs e)
        {
            this.txtUser.DropDownStyle = ComboBoxStyle.DropDownList;
            
            CountMessages();

            // FindData();
            FillingCombobox();


            startLimit = 0;
            startNumber = 1;
            lblPageNumber.Text = "1";
            endLimit = messagesPerPage;

            CountMessages();

            int findingPages = (int)Math.Ceiling((double)msgCount / (double)messagesPerPage);

            lblTotalPages.Text = Convert.ToString(findingPages);

            FindAllMessages();

            if (msgCount <= messagesPerPage)
            {
                lblNext.Enabled = false;
            }
            else
            {
                lblNext.Enabled = true;
            }

            if (lblPageNumber.Text == "1")
            {
                lblPrevious.Enabled = false;
            }
            else
            {
                lblPrevious.Enabled = true;
            }
        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length > 0)
            {
                FindTotal();

                if (msgCount <= messagesPerPage)
                {
                    lblNext.Enabled = false;

                }
                else if (startNumber == msgCount / endLimit)
                {
                    lblNext.Enabled = false;
                    lblPrevious.Enabled = true;

                    startNumber = startNumber + 1;
                    lblPageNumber.Text = Convert.ToString(startNumber);
                    startLimit = startLimit + messagesPerPage;
                    endLimit = messagesPerPage;
                    FindData();
                }
                else
                {

                    lblNext.Enabled = true;
                    lblPrevious.Enabled = true;

                    startNumber = startNumber + 1;
                    lblPageNumber.Text = Convert.ToString(startNumber);
                    startLimit = startLimit + messagesPerPage;
                    endLimit = messagesPerPage;
                    FindData();
                }
            }
            else 
            {
                CountMessages();

                if (msgCount <= messagesPerPage)
                {
                    lblNext.Enabled = false;

                }
                else if (startNumber == msgCount / endLimit)
                {
                    lblNext.Enabled = false;
                    lblPrevious.Enabled = true;

                    startNumber = startNumber + 1;
                    lblPageNumber.Text = Convert.ToString(startNumber);
                    startLimit = startLimit + messagesPerPage;
                    endLimit = messagesPerPage;
                    FindAllMessages();
                }
                else
                {

                    lblNext.Enabled = true;
                    lblPrevious.Enabled = true;

                    startNumber = startNumber + 1;
                    lblPageNumber.Text = Convert.ToString(startNumber);
                    startLimit = startLimit + messagesPerPage;
                    endLimit = messagesPerPage;
                    FindAllMessages();
                }
            }
        }

        private void lblPrevious_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length > 0)
            {
                if (startNumber == 1)
                {
                    lblPrevious.Enabled = false;
                }
                else
                {
                    lblNext.Enabled = true;
                    startNumber = startNumber - 1;
                    lblPageNumber.Text = Convert.ToString(startNumber);
                    startLimit = startLimit - messagesPerPage;
                    endLimit = messagesPerPage;
                    FindData();
                }
            }
            else 
            {
                if (startNumber == 1)
                {
                    lblPrevious.Enabled = false;
                }
                else
                {
                    lblNext.Enabled = true;
                    startNumber = startNumber - 1;
                    lblPageNumber.Text = Convert.ToString(startNumber);
                    startLimit = startLimit - messagesPerPage;
                    endLimit = messagesPerPage;
                    FindAllMessages();
                }
            }
        }

        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        private void FillingCombobox()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_user, username FROM users", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        txtUser.Items.Add(dr.GetString(0) + " " + dr.GetString(1));
                    }
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsertectChanged() {
            startLimit = 0;
            startNumber = 1;
            lblPageNumber .Text = "1";
            endLimit = messagesPerPage;
            
            FindTotal();

            int findingPages = (int)Math.Ceiling((double)msgCount / (double)messagesPerPage);

            lblTotalPages.Text = Convert.ToString(findingPages);

            FindData();

            if (msgCount <= messagesPerPage)
            {
                lblNext.Enabled = false;
            }
            else
            {
                lblNext.Enabled = true;
            }

            if (lblPageNumber.Text == "1")
            {
                lblPrevious.Enabled = false;
            }
            else
            {
                lblPrevious.Enabled = true;
            }
        }
        
        private void txtUser_SelectedIndexChanged(object sender, EventArgs e){
     
            txtUsertectChanged();   
        }

        private void FindUsers()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_user, username from users WHERE username= '" + findingUser + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Items.Clear();

                while (dr.Read() == true)
                {
                    findingIduser = dr[0].ToString(); 
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
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO messages(id_sender, id_receiver, message) VALUES('" + id_sender + "', '" + id_receiver + "', '" + txtMessage.Text + "')", conn);
                cmdDatabase.ExecuteNonQuery();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text == "")
            {
                MessageBox.Show("Please write a text message ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }else if (txtUser.Text == ""){
                MessageBox.Show("Please select a user to send the message ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                findingUser = myUsername;
                FindUsers();
                id_sender = findingIduser;

                id_receiver = txtUser.Text.ToString().Split(' ')[0];
                InsertSupplier();
                 
                txtUsertectChanged();
                txtMessage.Text = "";
            }
        }

        private void RemoveMessages()
        {
            DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
            string datetimeNow = dbDate1.ToString("yyyy-M-dd HH:mm:ss");
            string timeNow = dbDate1.ToString("HH:mm");

            try
            {
                findingUser = myUsername;
                FindUsers();
                id_sender = findingIduser;

                id_receiver = txtUser.Text.ToString().Split(' ')[0];

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM messages WHERE id_sender='" + id_sender + "' AND id_receiver='" + id_receiver + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Mesazhet u fshin me sukses ", "Fshirja me sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearMessages_Click(object sender, EventArgs e)
        {
            RemoveMessages();
        }
    }
}
