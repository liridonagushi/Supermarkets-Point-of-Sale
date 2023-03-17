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
    public partial class frmBuyOcassion : Form
    {
        public static string sFormIndex, id_user;
        private static int countIncrement;
        public static Boolean UpdProd;
        public static Boolean UpdatedPrice;

        public frmBuyOcassion()
        {
            InitializeComponent();
        }

        // Returning result values
        public string FindProduct
        {
            get { return txtIDProd.Text; }
            set { txtIDProd.Text = value; }
        }

        private void FindingProductCodeDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.quantity, products.barcode, products.description, products.sold_price, taxes.vat_perc FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.barcode='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read() == true)
                    {
                        txtIDProd.Text = dr[0].ToString();
                        txtBarcode.Text = dr[2].ToString();
                        txtProdDescription.Text = dr[3].ToString();
                        txtSellPrice.Text = dr[4].ToString();
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

        // Handle the KeyDown event to determine the type of character entered into the control.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.F))
            {
                btnFindProd.PerformClick();
                return true;
            }

        
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave.PerformClick();
                return true;
            }

            if (keyData == (Keys.Enter))
            {
                btnSave.PerformClick();
                return true;
            }

            if (keyData == (Keys.Escape))
            {
               this.Dispose(true);
                return true;
            }
      
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FindingProductIDDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.quantity, products.barcode, products.description, products.sold_price, taxes.vat_perc FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.id_product='" + txtIDProd.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read() == true)
                    {
                        txtIDProd.Text = dr[0].ToString();
                        txtBarcode.Text = dr[2].ToString();
                        txtProdDescription.Text = dr[3].ToString();
                        txtSellPrice.Text = dr[4].ToString();
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

        private void ShowModificationsCode()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, bought_ocassion.qty, bought_ocassion.unity_price, bought_ocassion.total_buy, bought_ocassion.date_buy FROM bought_ocassion LEFT JOIN products ON bought_ocassion.id_product=products.id_product WHERE bought_ocassion.id_product='" + txtIDProd.Text + "' ORDER BY bought_ocassion.id_ocassion DESC", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                countIncrement = 0;
                dgw.Rows.Clear();

                while (dr.Read() == true)
                {
                    DateTime dbDate1 = Convert.ToDateTime(dr[4]);

                    string datenow = dbDate1.ToString("dd-M-yyyy");

                    countIncrement++;

                    dgw.Rows.Add(countIncrement, dr[1], dr[2], dr[3], datenow);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFindProd_Click(object sender, EventArgs e)
        {
            frmFindProduct.sFormIndex = "buyOcassion";
            frmFindProduct frm = new frmFindProduct(this);
            frm.ShowDialog();
        }

        private void frmBuyOcassion_Load(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            FindingProductCodeDetails();
            ShowModificationsCode();
        }

        private void FindingProductDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.barcode, products.description, products.sold_price, taxes.vat_perc FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.barcode='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    txtBarcode.Text = dr.GetString(1);
                    txtProdDescription.Text = dr.GetString(2);
                    txtSellPrice.Text = dr.GetString(3);
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
                    DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
                    string datenow = dbDate1.ToString("yyyy-MM-dd");

                    MySqlConnection conn = DBUtils.GetDBConnection();
                    conn.Open();
                    Decimal totalBuy=Convert.ToDecimal(txtBuyPrice.Text) * Convert.ToDecimal(txtQty.Text);

                    MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO bought_ocassion(id_product, id_staff, unity_price, qty, total_buy, date_buy) VALUES ('" + txtIDProd.Text + "', '" + id_user + "' , '" + txtBuyPrice.Text + "', '" + txtQty.Text + "', '" + totalBuy + "', '" + datenow + "')", conn);

                    MySqlCommand cmdDatabase1 = new MySqlCommand("UPDATE products SET quantity = quantity+'" + txtQty.Text + "', import_price='" + txtBuyPrice.Text + "' WHERE products.barcode='" + txtBarcode.Text + "'", conn);

                    int i = cmdDatabase.ExecuteNonQuery();

                    if (i > 0)
                    {
                        UpdatedPrice = true;

                        string idprod = txtIDProd.Text;
                        txtIDProd.ResetText();
                        txtIDProd.Text = idprod;

                        cmdDatabase1.ExecuteNonQuery();

                        MessageBox.Show("Produkti u ble me sukses !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int Qty;
            Int32.TryParse(txtQty.Text, out Qty);

            int buyPrice;
            Int32.TryParse(txtBuyPrice.Text, out buyPrice);

            if ((txtBarcode.Text == "") || (txtQty.Text == ""))
            {
                MessageBox.Show("Se pari gjejeni produktin !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((buyPrice <= 0) || (Qty<=0))
            {
                MessageBox.Show("Jepeni vleren e cmimit ose sasis !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("A jeni i sigurt te bleni produktin " + txtBarcode.Text + "", "Update price !", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    InsertProduct();
                }
            }
        }
        private void ResetFields() {
            txtBarcode.ResetText();
            txtProdDescription.ResetText();
            txtSellPrice.ResetText();
            txtBuyPrice.ResetText();
            txtQty.Text="1";
            dgw.Rows.Clear();
        }

        private void txtIDProd_TextChanged(object sender, EventArgs e)
        {
            ResetFields();
            FindingProductIDDetails();
            ShowModificationsCode();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }
    }
}
