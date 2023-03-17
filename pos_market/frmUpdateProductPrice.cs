using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    public partial class frmUpdateProductPrice : Form
    {
        public static string sFormIndex;
        private static string id_product;
        private static decimal oldPrice;
        private static int countIncrement, vatPerc;
        public static Boolean UpdProd;
        public static Boolean UpdatedPrice;
        
        public frmUpdateProductPrice()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text == "") {
                MessageBox.Show("Se pari gjejeni produktin !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
                DialogResult dialogResult = MessageBox.Show("A jeni i sigurt te ndrroni cmimin e ketij produkti " + txtBarcode.Text + "", "Update price !", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    InsertProduct();
                    if (UpdatedPrice == true)
                    {
                        UpdatePrice();
                        UpdatedPrice = false;
                    }
                    else 
                    {
                        MessageBox.Show("Cmimi i produktit nuk u ndryshua me sukses !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                btnFindProd.PerformClick();
                return true;
            }

            if (keyData == Keys.Enter)
            {
                btnSave.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Returning result values
        public string FindProduct
        {
            get { return txtIDProd.Text; }
            set { txtIDProd.Text = value; }
        }

        private void btnFindProd_Click(object sender, EventArgs e)
        {
            frmFindProduct.sFormIndex = "UpdatePrice";
            frmFindProduct frm = new frmFindProduct(this);
            frm.ShowDialog();
        }

        private void txtProdID_TextChanged(object sender, EventArgs e)
        {
            FindingProductDetails();
            ShowModifications();
        }

        private void FindingProductPrice()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.barcode, products.sold_price, taxes.vat_perc FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.barcode='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    id_product = dr.GetString(0);
                    oldPrice = dr.GetDecimal(2);
                    vatPerc = dr.GetInt32(3);
                }
                
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePrice()
        {
            try
            {
                FindingProductPrice();
                Decimal net_amount = Convert.ToDecimal(txtSoldPrice.Text) / (1 + (Convert.ToDecimal(vatPerc) / 100));

                Decimal vatAmount = Math.Round(Convert.ToDecimal(txtSoldPrice.Text) - net_amount, 2);

                    MySqlConnection conn = DBUtils.GetDBConnection();
                    conn.Open();

                    MySqlCommand cmdDatabase = new MySqlCommand("UPDATE products SET sold_price='" + txtSoldPrice.Text + "', majority_price='" + txtMajSoldPrice.Text + "', tax_amount='" + vatAmount + "' WHERE id_product='" + txtIDProd.Text + "'", conn);

                    int i = cmdDatabase.ExecuteNonQuery();

                    if (i > 0)
                    {
                        MessageBox.Show("Cmimi produktit u ndryshua me sukses !", "Success modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgw.Rows.Clear();
                        txtIDProd.ResetText();
                        txtIDProd.Text = id_product;
                    }
                    conn.Close();
                }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertProduct()
        {
            try
            {
                FindingProductPrice();

                if ((txtIDProd.Text == "") || (txtIDProd.Text == "") || (txtIDProd.Text == "") || (txtIDProd.Text == "")) {
                    MessageBox.Show("Mbushni fushat e zbrazta per te bere modifikimet !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else if (txtSoldPrice.Text == "" + oldPrice + ""){
                    MessageBox.Show("Cmimi i ri nuk mundet te jet i njejt me te vjetrin !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else 
                { 
                    DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
                    string datenow = dbDate1.ToString("yyyy-M-dd");

                    MySqlConnection conn = DBUtils.GetDBConnection();
                    conn.Open();

                    MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO price_hist(id_product, old_price, new_price, date_mod) VALUES ('" + id_product + "', '" + oldPrice + "' , '" + txtSoldPrice.Text + "', '" + datenow + "')", conn);

                    int i = cmdDatabase.ExecuteNonQuery();

                    if (i > 0)
                    {
                        UpdatedPrice = true;
                    }

                    conn.Close();
                 }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindingProductDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.quantity, products.barcode, products.description, products.sold_price, products.majority_price FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.id_product='" + txtIDProd.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read() == true)
                    {
                        txtIDProd.Text = dr[0].ToString();
                        txtBarcode.Text = dr[2].ToString();
                        txtProdDescription.Text = dr[3].ToString();
                        txtSoldPrice.Text = dr[4].ToString();
                        txtMajSoldPrice.Text = dr[5].ToString();
                    }

                    UpdProd = true;
                }
                else
                {
                    UpdProd = false;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindingProductCodeDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.quantity, products.barcode, products.description, products.sold_price, products.majority_price FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.barcode='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read() == true)
                    {
                        txtIDProd.Text = dr[0].ToString();
                        txtBarcode.Text = dr[2].ToString();
                        txtProdDescription.Text = dr[3].ToString();
                        txtSoldPrice.Text = dr[4].ToString();
                        txtMajSoldPrice.Text = dr[5].ToString();
                    }
                    UpdProd = true;
                }
                else
                {
                    UpdProd = false;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowModifications()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.barcode, products.description, price_hist.old_price, price_hist.new_price, price_hist.date_mod FROM price_hist LEFT JOIN products ON price_hist.id_product=products.id_product WHERE products.id_product='" + txtIDProd.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                countIncrement=0;
                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    DateTime dbDate1 = Convert.ToDateTime(dr[5]);
                  
                    string datenow = dbDate1.ToString("dd-M-yyyy");
                    countIncrement++;
                    dgw.Rows.Add(countIncrement, dr[1], dr[2], dr[3], dr[4], datenow);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowModificationsCode()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.barcode, products.description, price_hist.old_price, price_hist.new_price, price_hist.date_mod FROM price_hist LEFT JOIN products ON price_hist.id_product=products.id_product WHERE products.barcode='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                countIncrement = 0;
                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    DateTime dbDate1 = Convert.ToDateTime(dr[5]);

                    string datenow = dbDate1.ToString("dd-M-yyyy");
                    countIncrement++;
                    dgw.Rows.Add(countIncrement, dr[1], dr[2], dr[3], dr[4], datenow);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUpdateProductPrice_Load(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            FindingProductCodeDetails();
            ShowModificationsCode();
        }
    }
}
