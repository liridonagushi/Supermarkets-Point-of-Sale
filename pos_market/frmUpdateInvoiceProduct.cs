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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Supermarkets
{
    public partial class frmUpdateInvoiceProduct : Form
    {
        public static String dgwProdCode;
        public static Decimal dgwQty, dgwSellPrice, dgwFreeProducts, dgwSoldMajPrice, dgwImpSum, dgwSellAmount, dgwMargin;
        private static Boolean totalGotFocus;

        Decimal RoundUp(Decimal toRound)
        {
            return (10 - toRound % 10) + toRound;
        }

        private ImportInvoice mainForm = null;

        public frmUpdateInvoiceProduct()
        {
            InitializeComponent();
        }

        public frmUpdateInvoiceProduct(Form callingForm)
        {
            mainForm = callingForm as ImportInvoice;
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if Enter is pressed
            if (keyData == Keys.Enter)
            {
                // If there isn't any selected row, do nothing
                if (txtBarcode.Text != null)
                {

                    this.mainForm.UpdFreeProducts = txtFreeProducts.Text;
                    this.mainForm.UpdImportPrice = txtImportAmount.Text;
                    this.mainForm.UpdSoldVatAmount = txtVatAmount.Text;
                    this.mainForm.UpdSoldPrice = txtSellPrice.Text;
                    this.mainForm.UpdQuantityImport = txtQuantity.Text;
                    this.mainForm.UpdProductCode = txtBarcode.Text;
                   this.Dispose(true);
                }
                // Display first cell's value
                return true;
            }

            // Check if Enter is pressed
            if (keyData == Keys.Escape)
            {
               this.Dispose(true);

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmUpdateInvoiceProduct_Load(object sender, EventArgs e)
        {
            txtBarcode.Text = dgwProdCode.ToString();
            txtFreeProducts.Text = dgwFreeProducts.ToString();
            txtImportAmount.Text = dgwImpSum.ToString();
            txtSellPrice.Text = dgwSellPrice.ToString();
            txtQuantity.Text = dgwQty.ToString();
            txtSellAmount.Text = dgwSellAmount.ToString();
            txtMargin.Text = dgwMargin.ToString();
        }

        private void txtSoldPrice_MouseClick(object sender, EventArgs e)
        {
            txtSellPrice.SelectAll();
        }

        private void txtSellPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSellPrice.Focused) { 
                    Decimal ImportPrice = 0;
                    Decimal TaxPerc = 0;
                    Decimal SellPrice = 0;
                    Decimal TotalQty = 0;
                    Decimal VatAmount = 0;

                    Decimal.TryParse(txtQuantity.Text, out TotalQty);
                    Decimal.TryParse(txtUnityImportAmount.Text, out ImportPrice);
                    Decimal.TryParse(txtVatPerc.Text, out TaxPerc);
                    Decimal.TryParse(txtSellPrice.Text, out SellPrice);
                    if (SellPrice < 0) { MessageBox.Show("Vlerat ne minus nuk pranohen !", "Error Import Amount", MessageBoxButtons.OK, MessageBoxIcon.Error); txtSellPrice.ResetText(); }
                    else
                    { 

                        if (TaxPerc > 0)
                        {
                            Decimal net_amount = SellPrice / (1 + (TaxPerc / 100));
                            VatAmount = Math.Round(SellPrice - net_amount, 2);
                            txtVatAmount.Text = VatAmount.ToString();
                        }
                        else
                        {
                            txtVatAmount.Text = "0";
                        }

                            Decimal totalSum = Math.Round(SellPrice * TotalQty, 2);
                            txtSellAmount.Text = totalSum.ToString();
                            txtMargin.Text = Math.Round((((SellPrice - VatAmount - ImportPrice) / ImportPrice) * 100), 2).ToString();
                    }
                }
            }

            catch (Exception ex)
            {
              MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtImportAmount_MouseClick(object sender, EventArgs e)
        {
            txtImportAmount.SelectAll();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtImportAmount_TextChanged(object sender, EventArgs e)
        {
            
            totalGotFocus = false;
            if (txtImportAmount.Focused == true)
            {
                totalGotFocus = true;
            }

            try
            {
                Decimal TotalQty = 0;

                Decimal TotalImportAmount = 0;

                Decimal UnityImportAmount = 0;


                Decimal.TryParse(txtQuantity.Text, out TotalQty);

                Decimal.TryParse(txtImportAmount.Text, out TotalImportAmount);

                Decimal.TryParse(txtUnityImportAmount.Text, out UnityImportAmount);
                if (TotalImportAmount < 0) { MessageBox.Show("Vlerat ne minus nuk pranohen !", "Error Import Amount", MessageBoxButtons.OK, MessageBoxIcon.Error); txtImportAmount.ResetText(); }
                else
                { 
                    if (totalGotFocus == true)
                    {
                        Decimal calcImp = Math.Round(TotalImportAmount / TotalQty, 2);

                        txtUnityImportAmount.Text = calcImp.ToString();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT products.id_product, products.barcode, products.description, taxes.vat_perc FROM products LEFT JOIN taxes ON products.id_tax=taxes.id_tax WHERE products.barcode='" + txtBarcode.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                    if (dr.Read()==true)
                    {
                        txtDescription.Text = dr.GetString(2);
                        txtVatPerc.Text = dr.GetString(3);
                    }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFreeProducts_MouseClick(object sender, EventArgs e)
        {
            txtFreeProducts.SelectAll();
        }
        
        private void txtQuantity_MouseClick(object sender, EventArgs e)
        {
            txtQuantity.SelectAll();
        }


        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            totalGotFocus = false;
            if (txtQuantity.Focused == true)
            {
                totalGotFocus = true;
            }

            try
            {
                Decimal Qty = 0;

                Decimal TotalImportAmount = 0;

                Decimal ImportPrice = 0;
                Decimal SellPrice = 0;
                Decimal VatAmount = 0;

                Decimal.TryParse(txtQuantity.Text, out Qty);

                Decimal.TryParse(txtImportAmount.Text, out TotalImportAmount);
                Decimal.TryParse(txtSellPrice.Text, out SellPrice);
                Decimal.TryParse(txtVatAmount.Text, out VatAmount);
                
                Decimal.TryParse(txtUnityImportAmount.Text, out ImportPrice);

                if (Qty < 0) { MessageBox.Show("Vlerat ne minus nuk pranohen !", "Error Import Amount", MessageBoxButtons.OK, MessageBoxIcon.Error); txtQuantity.ResetText(); }
                else
                { 
                if (totalGotFocus == true)
                {
                    Decimal calcImp = Math.Round(TotalImportAmount / Qty, 2);

                    txtUnityImportAmount.Text = calcImp.ToString();


                        if (ImportPrice > 0)
                        {
                            Decimal ImportTotal = ImportPrice * Qty;
                            txtImportAmount.Text = ImportTotal.ToString();

                            txtMargin.Text = Math.Round((((SellPrice - VatAmount - ImportPrice) / ImportPrice) * 100), 2).ToString();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSellAmount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}