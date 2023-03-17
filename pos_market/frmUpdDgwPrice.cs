using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Supermarkets
{
    public partial class frmUpdDgwPrice : Form
    {
        private PosFront mainForm = null;
        public static string ProductCode, ProductPrice;

        public frmUpdDgwPrice()
        {
            InitializeComponent();
        }

        public frmUpdDgwPrice(Form callingForm)
        {
            mainForm = callingForm as PosFront;
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
               this.Dispose(true);
                return true;
            }

            // Check if Enter is pressed
            if (keyData == Keys.Enter)
            {
                // If there isn't any selected row, do nothing
                if (txtNewPrice.Text != null)
                {
                    if ((txtBarcode.Text == "") || (txtNewPrice.Text == ""))
                    {
                        MessageBox.Show("Mbushni fushat para se te vazhdoni !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Convert.ToDecimal(txtNewPrice.Text) < 0)
                    {
                        MessageBox.Show("Nuk pranohen numrat ne minus !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else{

                        this.mainForm.updateProductPriceDgw = txtNewPrice.Text.ToString();
                  
                        this.Hide();
                     }
                }
                // Display first cell's value
                return true;
            }

            if (keyData == Keys.Escape)
            {
               this.Dispose(true);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

      
        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void frmUpdDgwPrice_Load(object sender, EventArgs e)
        {
            txtBarcode.Text = ProductCode;
            txtProductPrice.Text = ProductPrice;
            txtNewPrice.SelectAll();
        }
    }
}
