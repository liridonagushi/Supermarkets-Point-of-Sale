using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
using System.Web;
using System.Drawing.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Supermarkets
{
    public partial class frmProducts : Form
    {
        public static string sFormIndex;
        public static Boolean UpdProd, findProductForm;
        private Boolean ProductExist;
        private static string id_taxVal, amountCurrency, pngName, printerName, firstProd;
        private static int activatedPrinter;

        public frmProducts()
        {
            InitializeComponent();
            this.cmbTaxValues.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTypeProd.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
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

            if (keyData == (Keys.Delete))
            {
               btnDelete.PerformClick();
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

        private void FindingProductDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.quantity, products.barcode, products.description, products.sold_price, taxes.vat_perc, products.id_type, type_products.type_product, product_categories.id_category, product_categories.category_name, products.active FROM products LEFT JOIN type_products ON products.id_type=type_products.id_type LEFT JOIN taxes ON products.id_tax=taxes.id_tax LEFT JOIN product_categories ON products.id_category=product_categories.id_category WHERE products.id_product='" + txtIDProd.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read()==true)
                {
                    Decimal soldPrice = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                    Decimal soldMajPrice = dr.IsDBNull(10) ? 0 : dr.GetDecimal(10);
                    int findIdCat = dr.IsDBNull(8) ? 0 : dr.GetInt32(8);
                    int findActive;
                    String findCatName = dr.IsDBNull(9) ? " " : dr.GetString(9);

                        cmbTypeProd.ResetText();
                        txtIDProd.Text = dr.GetString(0);
                        txtQuantity.Text = dr.GetString(1);
                        txtBarcode.Text = dr.GetString(2);
                        txtProdDescription.Text = dr.GetString(3);
                        txtSoldPrice.Text = soldPrice.ToString();
                        cmbTaxValues.Text = dr.GetString(5);
                        cmbTypeProd.Text = dr.GetString(6) + " " + dr.GetString(7);
                        cmbCategories.Text = findIdCat + " " + findCatName;
                        findActive = dr.IsDBNull(10) ? 0 : dr.GetInt32(10);
                        if (findActive == 1) { chkActive.Checked = true; } else { chkActive.Checked = false; }
                        txtQuantity.Enabled = false;

                    UpdProd = true;
                }else{
                    UpdProd = false;
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckInsertDuplicates()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_product, barcode FROM products WHERE barcode='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Produkti ekziston ne databaz !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ProductExist = true;
                }
                else {
                    ProductExist = false;
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckUpdDuplicates()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_product, barcode FROM products WHERE barcode='" + txtBarcode.Text + "' AND id_product<>'" + txtIDProd.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Barkodi produktit ekziston", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ProductExist = true;
                }
                else
                {
                    ProductExist = false;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillingCombobox()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_tax, vat_perc FROM taxes ORDER BY id_tax DESC", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    int i = 0;
                    cmbTaxValues.Items.Add("");
                    while (dr.Read())
                    {
                        i += 1;
                        if (i == 1)
                        {
                            firstProd = dr[1].ToString();
                        }

                        cmbTaxValues.Items.Add(dr[1].ToString());
                    }
                    cmbTaxValues.Text = firstProd;
                    cmbTaxValues.Text = "20";
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillingCategories()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_category, category_name FROM product_categories ORDER BY id_category", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    int i = 0;
                    cmbCategories.Items.Add(" ");
                    while (dr.Read())
                    {
                        i += 1;
                        if (i == 1)
                        {
                            firstProd = dr.GetInt32(0) + " " + dr.GetString(1);
                        }
                        cmbCategories.Items.Add(dr.GetInt32(0) + " " + dr.GetString(1));
                    }
                        cmbCategories.Text = firstProd;
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FillingCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillingTypeProd()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_type, type_product FROM type_products", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.HasRows == true)
                {
                    cmbTypeProd.Items.Add(" ");
                    int i=0;
                    
                    while (dr.Read())
                    {
                        i +=1;
                        if (i == 1)
                        {
                            firstProd = dr.GetInt32(0) + " " + dr.GetString(1);
                        }
                        cmbTypeProd.Items.Add(dr.GetInt32(0) + " " + dr.GetString(1));
                    }
                    cmbTypeProd.Text = firstProd;
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FillingTypeProd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmFindProduct.sFormIndex = "frmProduct";
            frmFindProduct frm = new frmFindProduct(this);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void InsertProduct()
        {
            try
            {
                FindTaxIDNumber();
                String dateToday = DateTime.Today.ToString("yyyy-MM-dd");

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                Decimal net_amount = Convert.ToDecimal(txtSoldPrice.Text) / (1 + (Convert.ToDecimal(cmbTaxValues.Text) / 100));

                Decimal vatAmount = Convert.ToDecimal(txtSoldPrice.Text) - net_amount;

                Decimal vatAmountD = Math.Round(vatAmount,2);

                var SearchTypeProd = cmbTypeProd.Text.ToString().Split(' ')[0];

                var SearchCatProd = cmbCategories.Text.ToString().Split(' ')[0];

                int ActiveProd;

                if (chkActive.Checked == true) { ActiveProd = 1; }else { ActiveProd = 0; }

                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO products(barcode, description, sold_price, id_tax, tax_amount, id_type, date_insert, quantity, id_category, active) VALUES ('" + txtBarcode.Text + "', '" + txtProdDescription.Text + "', '" + txtSoldPrice.Text + "', '" + id_taxVal + "', '" + vatAmountD.ToString() + "', '" + SearchTypeProd + "', '" + dateToday + "', '" + txtQuantity.Text + "', '" + SearchCatProd + "', '" + ActiveProd + "')", conn);

              int i = cmdDatabase.ExecuteNonQuery();

              if (i > 0){

                    MessageBox.Show("Produkti u vendos me sukses !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdProd = true;
                    txtSoldPrice.Enabled = false;
                    txtPriceCurrency.Enabled = false;
                    btnDelete.Enabled = true;
                    btnNew.Enabled = true;
                    btnCreateBarcode.Enabled = true;
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "InsertProduct", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProduct()
        {
            try
            {
                FindTaxIDNumber();

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                Decimal net_amount = Convert.ToDecimal(txtSoldPrice.Text) / (1 + (Convert.ToDecimal(cmbTaxValues.Text) / 100));

                Decimal vatAmount = Convert.ToDecimal(txtSoldPrice.Text) - net_amount;

                Decimal vatAmountD = Math.Round(vatAmount, 2);

                var SearchTypeProd = cmbTypeProd.Text.ToString().Split(' ')[0];
                var SearchCatProd = cmbCategories.Text.ToString().Split(' ')[0];

                Decimal SoldPrice = 0;
                Decimal.TryParse(txtSoldPrice.Text, out SoldPrice);


                Decimal soldPriceProd = Math.Round(SoldPrice, 2);

                int ActiveProd;

                if (chkActive.Checked == true) { ActiveProd = 1; }else { ActiveProd = 0; }

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE products SET barcode='" + txtBarcode.Text + "', description='" + txtProdDescription.Text + "', sold_price='" + soldPriceProd + "', id_tax='" + id_taxVal + "', tax_amount='" + vatAmountD.ToString() + "', id_type='" + SearchTypeProd + "', id_category='" + SearchCatProd + "', active='" + ActiveProd + "' WHERE id_product='" + txtIDProd.Text + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Produkti u ndryshua me sukses !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdProd = true;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UpdateProduct", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearValues()
        {
            txtIDProd.Clear();
            txtBarcode.Clear();
            txtProdDescription.Clear();
            txtSoldPrice.Text = "0";
            txtQuantity.Text = "0";
            txtPriceCurrency.Text = "0";
            chkActive.Checked = true;
            UpdProd = false;
        }

        private void ClearFields()
        {
            txtBarcode.Clear();
            txtProdDescription.Clear();
            txtSoldPrice.Text = "0";
            txtQuantity.Text="0";
            btnDelete.Enabled = false;
            btnCreateBarcode.Enabled = false;
        }

        private void FindProductNumber()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_product FROM products ORDER BY id_product DESC LIMIT 1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if ((dr.Read() == true) && (UpdProd == false))
                    {
                            int idNumber;
                            idNumber = dr.GetInt32(0)+1;
                            txtIDProd.Text = idNumber.ToString();
                    }
                else
                {
                    txtIDProd.Text = "999";
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindTaxIDNumber()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_tax, vat_perc FROM taxes WHERE vat_perc = '" + cmbTaxValues.Text + "' ORDER BY vat_perc DESC", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                    if (dr.Read() == true){

                       id_taxVal = dr[0].ToString();
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
            if ((txtIDProd.Text == "") || (txtBarcode.Text == "") || (txtProdDescription.Text == "") || (txtSoldPrice.Text == "") || (cmbTaxValues.Text == "") || (cmbTypeProd.Text == "") || (cmbCategories.Text == ""))
            {
                MessageBox.Show("Mbushi fushat e zbrazta para se te ruani !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UpdProd == true)
                {
                    CheckUpdDuplicates();
                    if (ProductExist != true)
                    {
                        UpdateProduct();
                        txtIDProd.Enabled = false;
                        txtQuantity.Enabled = false;
                        txtBarcode.Focus();
                    }
                }
                else
                {
                    CheckInsertDuplicates();
                    if (ProductExist != true) {
                        InsertProduct();
                        txtQuantity.Enabled = false;
                        txtIDProd.Enabled = false;
                        txtBarcode.Focus();
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearValues();
            txtIDProd.Enabled=false;
            FindProductNumber();
            btnDelete.Enabled = false;
            btnCreateBarcode.Enabled = false;
            btnSave.Enabled = true;
            txtBarcode.Focus();
        }

        private void txtIDProd_TextChanged(object sender, EventArgs e)
        {
            ClearFields();
            FindingProductDetails();
            if (UpdProd == true){

                txtSoldPrice.Enabled = false;
                txtPriceCurrency.Enabled = false;
                txtQuantity.Enabled = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                btnNew.Enabled = true;
                
                btnCreateBarcode.Enabled = true;

            }else{

                txtSoldPrice.Enabled = true;
                txtQuantity.Enabled = true;
                txtPriceCurrency.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnCreateBarcode.Enabled = false;
                btnCreateBarcode.Enabled = false;
                ClearFields();
            }
        }

        private void FindProductSales()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_product FROM posdetails WHERE id_product='" + txtIDProd.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if ((dr.Read() == true))
                {
                    ProductExist = true;
                }
                else
                {
                    ProductExist = false;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteProduct()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM products WHERE id_product='" + txtIDProd.Text + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Produkti u fshi me sukses !");
                }

                MySqlCommand cmdDatabase1 = new MySqlCommand("ALTER TABLE products AUTO_INCREMENT = 1", conn);

                cmdDatabase1.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FindProductSales();
            if (ProductExist == true)
            {
                MessageBox.Show("Ky produkt nuk mund te fshihet sepse eshte i lidhur me shitjet !", "Error Deleting Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("A jeni i sigurt te fshini kete produkt !", "Delete product !", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteProduct();
                    ClearValues();
                    btnDelete.Enabled = false;
                    btnSave.Enabled = false;
                }
            }
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            btnNew.PerformClick();
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnCreateBarcode.Enabled = false;
            FillingCombobox();
            FillingTypeProd();
            FillingCategories();
            txtBarcode.Focus();
            chkActive.Checked = true;
            if (findProductForm == true)
            {
                btnFind.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void printBarcode(){

            string barcode = txtBarcode.Text;
            Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                System.Drawing.Font font = new System.Drawing.Font("IDAutomationHC39M", 15);
                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);

                graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                graphics.DrawString("*" + barcode + "*", font, black, point);
            }

            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
            }

            bitmap.Save(@"C:/BarcodeImgs/" + pngName + ".png", ImageFormat.Png);
        }

        private void printBarcode1(object sender, PrintPageEventArgs ppeArgs)
    {
     Graphics graphics = ppeArgs.Graphics;
     System.Drawing.Font font = new System.Drawing.Font("Courier New", 10);
     float fontHeight = font.GetHeight();
     int startX = 0;
     int startY = 0;
     int Offset = 20;
     graphics.DrawString("testbarcode", new System.Drawing.Font("IDAutomationHC39M", 12), new SolidBrush(Color.Black), startX, startY + Offset);
     Offset = Offset + 60;
     graphics.DrawString("testbarcode", new System.Drawing.Font("IDAutomationHC39M", 12), new SolidBrush(Color.Black), startX, startY + Offset);
    }

        private void PrintHandler(object sender, PrintPageEventArgs ppeArgs)
        {
            string barcode = txtBarcode.Text;
            Graphics graphics_Print = ppeArgs.Graphics;

            // Create image.
            System.Drawing.Image newImage = System.Drawing.Image.FromFile(@"C:/BarcodeImgs/" + pngName + ".png");

            // Create coordinates for upper-left corner.
            // of image and for size of image.
            int nrCopies = 0;

            Int32.TryParse(txtQtyBarcode.Text, out nrCopies);

            int x = 10;
            int y = 5;
            int width = 40;
            int Offset = 0;
            int height = 160;
            int CountChar = txtBarcode.Text.Length;
            // Draw image to screen.

            int a = nrCopies;

            for (int i = 0; i < a; i++)
            {
                graphics_Print.DrawImage(newImage, x, y + Offset, width * CountChar, height);
                Offset = Offset + 100;
            }
        }

        private void PrintHandler1(object sender, PrintPageEventArgs ppeArgs)
        {
            printBarcode();
        }

        private void PrintIntoPos(string PrinterName)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrinterSettings.PrinterName = PrinterName;
            doc.PrintPage += new PrintPageEventHandler(PrintHandler);
            doc.Print();
        }

        private void btnCreateBarcode_Click(object sender, EventArgs e)
        {
            int nrCopies = 0;

            Int32.TryParse(txtQtyBarcode.Text, out nrCopies);
            if (nrCopies < 1)
            {
                MessageBox.Show("Numri i kopjeve nuk mund te jet me e vogel se 1", "Error duplicates !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (nrCopies > 10)
            {
                MessageBox.Show("Numri i kopjeve nuk mund te jet me i madh se 10", "Error duplicates !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Exporting to PDF
                string folderPath = "C:/BarcodeImgs/";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                pngName = DateTime.Now.Ticks.ToString();
                printBarcode();

                CheckEnabledPosPrinter();
                if (activatedPrinter == 1)
                {
                    PrintIntoPos(printerName);
                }
            }
        }

        private void CheckEnabledPosPrinter()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT printer_name, pos_printer FROM sys_printer_devices", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    printerName = dr[0].ToString();
                    activatedPrinter = dr.GetInt32(1);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTaxValues_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTypeProd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FindingCurrencyDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT sys_currency.currency, sys_currency.amount FROM company LEFT JOIN sys_currency ON company.base_currency=sys_currency.id_currency WHERE company.id_company='1'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    amountCurrency = dr.GetString(1);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error finding service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txtPriceCurrency_TextChanged(object sender, EventArgs e)
        {
            if (txtPriceCurrency.Focused == true)
            { 
            FindingCurrencyDetails();

            Decimal PriceCurrency = 0;
            Decimal findCurrency = 0;

            Decimal.TryParse(txtPriceCurrency.Text, out PriceCurrency);
            Decimal.TryParse(amountCurrency, out findCurrency);

            Decimal value1 = Math.Round(PriceCurrency * findCurrency,2);

            txtSoldPrice.Text = value1.ToString();
            }
        }

        private void txtSoldPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtSoldPrice.Focused == true)
            { 
                FindingCurrencyDetails();

                Decimal PriceCurrency = 0;
                Decimal findCurrency = 0;

                Decimal.TryParse(txtSoldPrice.Text, out PriceCurrency);
                Decimal.TryParse(amountCurrency, out findCurrency);

                Decimal value1 = Math.Round(PriceCurrency / findCurrency,2);

                txtPriceCurrency.Text = value1.ToString();
             }
        }


    }
}
