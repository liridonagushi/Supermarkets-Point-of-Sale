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
    public partial class frmFindProduct : Form
    {
        public static String myUsername;

        public static String sFormIndex;

        private static String typeSearch, searchLimit;

        private frmProducts secondForm = null;

        private PosFront mainForm = null;

        private ImportInvoice thirdForm = null;

        private frmPrintPrices fourthForm = null;

        private frmUpdateProductPrice fifthForm = null;

        private frmService sixthForm = null;

        private frmBuyOcassion seventhForm = null;

        public static Boolean UpdProd;

        private static int id_user;

        public frmFindProduct()
        {
            InitializeComponent();
        }

        public frmFindProduct(Form callingForm)
        {
            if (sFormIndex == "frmProduct")
            {
                secondForm = callingForm as frmProducts;
            }
            else if (sFormIndex == "frmPOS")
            {
                mainForm = callingForm as PosFront;
            }
            else if (sFormIndex == "frmInvoice")
            {
                thirdForm = callingForm as ImportInvoice;
            }
            else if (sFormIndex == "PrintPrices")
            {
                fourthForm = callingForm as frmPrintPrices;
            }
            else if (sFormIndex == "UpdatePrice")
            {
                fifthForm = callingForm as frmUpdateProductPrice;
            }
            else if (sFormIndex == "PhoneService")
            {
                sixthForm = callingForm as frmService;
            }
            else if (sFormIndex == "buyOcassion")
            {
                seventhForm = callingForm as frmBuyOcassion;
            }
            
            InitializeComponent();
        }

        private void doubleClick() {
            // If there isn't any selected row, do nothing
            if (dgw.CurrentRow != null & dgw.SelectedRows.Count > 0)
            {
                if (sFormIndex == "frmProduct")
                {
                    this.secondForm.FindProduct = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
                    frmProducts.UpdProd = true;
                }
                else if (sFormIndex == "frmPOS")
                {
                    this.mainForm.FindProduct = dgw.Rows[dgw.CurrentRow.Index].Cells[1].Value.ToString();
                }
                else if (sFormIndex == "frmInvoice")
                {
                    this.thirdForm.FindProduct = dgw.Rows[dgw.CurrentRow.Index].Cells[1].Value.ToString();
                }
                else if (sFormIndex == "PrintPrices")
                {
                    this.fourthForm.FindProduct = dgw.Rows[dgw.CurrentRow.Index].Cells[1].Value.ToString();
                }
                else if (sFormIndex == "UpdatePrice")
                {
                    this.fifthForm.FindProduct = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
                }
                else if (sFormIndex == "PhoneService")
                {
                    this.sixthForm.FindProduct = dgw.Rows[dgw.CurrentRow.Index].Cells[1].Value.ToString();
                }
                else if (sFormIndex == "buyOcassion")
                {
                    this.seventhForm.FindProduct = dgw.Rows[dgw.CurrentRow.Index].Cells[0].Value.ToString();
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
                    // Display selected cell's value
                    dgw.Focus();
                    dgw.CurrentCell = dgw.Rows[0].Cells[2];
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
                txtSearchProd.Focus();
                // Display selected cell's value
                return true;
            }

            if (keyData == Keys.LShiftKey)
            {
                // Check if Escape is clicked
                txtSearchProd.Focus();
                // Display selected cell's value
                return true;
            }

            if (keyData == Keys.F1)
            {
                btnCreateProduct.PerformClick();
                // Display selected cell's value
                return true;
            }

            if (keyData == Keys.F2)
            {
                if (txtSearchProd.Text == "")
                {
                    MessageBox.Show("Shkruani tekstin te cilin doni ta kerkoni", "Error Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else { 
                DialogResult dialogResult = MessageBox.Show("A doni ta shtoni kerkimin te produktet e sugjeruara ?", "Insert Suggests !", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    createSuggest();
                }
                }

                // Display selected cell's value
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void FindingIduser()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_user FROM users WHERE username='" + myUsername + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                if (dr.Read() == true)
                {
                    id_user = dr.GetInt32(0);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createSuggest()
        {
            try
            {
                FindingIduser();

                string DateNow = DateTime.Now.ToString("yyyy-M-dd");

                MySqlConnection conn = DBUtils.GetDBConnection();

                conn.Open();
                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO suggested_products (keyword, date, id_user) VALUES('" + txtSearchProd.Text + "', '" + DateNow + "', '" + id_user + "')", conn);
                
                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Produkti u sugjerua me sukses", "Sukses Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            try
            {

                searchLimit = "";
                typeSearch = "";
                
                if (sFormIndex == "PhoneService"){
                    typeSearch = " AND products.id_category = '2'";
                }

                if(txtSearchProd.Text.Length < 3)
                {
                    searchLimit = " LIMIT 0";
                }

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.barcode, products.description,  products.quantity, taxes.vat_perc, products.sold_price, products.majority_price FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.barcode LIKE '%" + txtSearchProd.Text + "%' OR products.description LIKE '%" + txtSearchProd.Text + "%' " + typeSearch + " " + searchLimit + "", conn);
              
                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();
                           
                while (dr.Read() == true)
                {
                    Decimal qty = dr.IsDBNull(3) ? 0 : dr.GetDecimal(3);
                    Decimal vatPerc = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                    Decimal soldPrice = dr.IsDBNull(5) ? 0 : dr.GetDecimal(5);
                    Decimal soldMajPrice = dr.IsDBNull(6) ? 0 : dr.GetDecimal(6);

                    dgw.Rows.Add(dr[0], dr[1], dr[2], qty, vatPerc, soldPrice, soldMajPrice);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSearchProd.Clear();
            dgw.Rows.Clear();
        }

        private void frmFindProduct_Load(object sender, EventArgs e)
        {
            dgw.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgw.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            txtSearchProd.ResetText();
            frmProducts.findProductForm = true;
            frmProducts frm = new frmProducts();
            frm.Show();
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleClick();
        }
    }
}
