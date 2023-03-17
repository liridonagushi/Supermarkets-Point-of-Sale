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
    public partial class frmDiscount : Form
    {
        private PosFront mainForm = null;
        public static string ProductCode;

        public frmDiscount()
        {
            InitializeComponent();
        }

        public frmDiscount(Form callingForm)
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
                if (txtPerc.Text != null)
                {
                    if ((txtBarcode.Text == "") || (txtPerc.Text == ""))
                    {
                        MessageBox.Show("Jepe perqindjen e zbritjes ose barkodin !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Convert.ToDecimal(txtPerc.Text) < 0)
                    {
                        MessageBox.Show("Nuk lejohet perqindja me e vogel se zero !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.mainForm.FindDiscount = txtPerc.Text.ToString();

                       this.Dispose(true);
                    }
                }

                // Display first cell's value
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmDiscount_Load(object sender, EventArgs e)
        {
            txtBarcode.Text = ProductCode;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {

        }

    }
}
