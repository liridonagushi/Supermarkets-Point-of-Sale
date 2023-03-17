using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Supermarkets
{
    public partial class frmPayment : Form
    {
        //private static decimal calculations;
        public static decimal reqAmount;

        public static String FindSourcePayment;
        public static int totalPoints;

        private PosFront mainForm = null;

        public frmPayment()
        {
            InitializeComponent();
        }

        public frmPayment(Form callingForm)
        {
            mainForm = callingForm as PosFront;
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if Enter is clicked
            if (keyData == (Keys.Control | Keys.A))
            {
                txtPaymentAmount.SelectAll();
            }

            // Check if Escape is clicked
            if (keyData == Keys.Escape)
            {
               this.Dispose(true);
            }

            // Check if Enter is clicked
            if (keyData == Keys.Enter)
            {
                if (Convert.ToDecimal(txtReturn.Text) >= 0 && (Convert.ToDecimal(txtPaymentAmount.Text) >= Convert.ToDecimal(txtAmount.Text)))
                {
                    // If there isn't any selected row, do nothing
                    if (FindSourcePayment == "cash_payment")
                    {
                        PosFront.FindSourcePayment = "cash_payment";
                    }

                    // If there isn't any selected row, do nothing
                    if (FindSourcePayment == "debt_payment")
                    {
                        PosFront.FindSourcePayment = "debt_payment";
                    }

                    // If there isn't any selected row, do nothing
                    if (FindSourcePayment == "points_payment")
                    {
                        PosFront.FindSourcePayment = "points_payment";
                    }

                    // If there isn't any selected row, do nothing
                    if (FindSourcePayment == "bank_payment")
                    {
                        PosFront.FindSourcePayment = "bank_payment";
                    }

                    this.mainForm.frmMakePayment = txtPaymentAmount.Text;

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Shuma e dhene nuk eshte valide !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Display first cell's value
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtPaymentAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal PaymentAmount = 0;
                Decimal totalAmount = 0;
                Decimal.TryParse(txtPaymentAmount.Text, out PaymentAmount);
                Decimal.TryParse(txtAmount.Text, out totalAmount);
                txtReturn.Text = (PaymentAmount - totalAmount).ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            txtAmount.Text = reqAmount.ToString();
            txtPaymentAmount.Focus();
            txtPaymentAmount.SelectAll();
        }
    }
}