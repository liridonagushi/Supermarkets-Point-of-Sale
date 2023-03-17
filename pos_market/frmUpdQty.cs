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
    public partial class frmUpdQty : Form
    {
        private PosFront mainForm = null;
        public static string ProductCode;

        public frmUpdQty()
        {
            InitializeComponent();
        }

        public frmUpdQty(Form callingForm)
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
                if (txtQty.Text != null)
                {
                    if ((txtBarcode.Text == "") || (txtQty.Text == ""))
                    {
                        MessageBox.Show("Mbushni fushat para se te vazhdoni !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else if (Convert.ToDecimal(txtQty.Text) < 0){
                        MessageBox.Show("Nuk pranohen numrat ne minus !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else{

                        this.mainForm.FindQuantity = txtQty.Text.ToString();
                        this.mainForm.FindProductCode = txtBarcode.Text.ToString();
                  
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

        private void frmUpdQty_Load(object sender, EventArgs e)
        {
            txtBarcode.Text = ProductCode;
            txtQty.SelectAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
