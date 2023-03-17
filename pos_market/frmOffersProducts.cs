using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text.pdf;

namespace Supermarkets
{
    public partial class frmOffersProducts : Form
    {
        //System Declarations
        private String dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");

        private static String findFreeProd, finddiscountProd, findShumicProd, findUpdatedPrice;

        public frmOffersProducts()
        {
            InitializeComponent();
        }

        private void FindData()
        {
            try
            {
                findFreeProd = "";
                finddiscountProd = "";
                findShumicProd = "";
                findUpdatedPrice = "";

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                DateTime dbDate1 = Convert.ToDateTime(dtStartDate.Text);

                var firstDate = dbDate1.ToString("yyyy-MM-dd 00:00:00");
                var secondDate = dbDate1.AddDays(+1).ToString("yyyy-MM-dd 23:59:59");

                if (chkFree.Checked == true) {
                    findFreeProd = " AND posdetails.total_amount='0'";
                }

                if (chkDiscount.Checked == true) {
                    finddiscountProd = " AND posdetails.discount_percentage>0";
                }

                if (chkShumic.Checked == true) {
                    findShumicProd = " AND pos.majority_bool='1'";
                }

                if (chkOtherPrice.Checked == true)
                {
                    findUpdatedPrice = " AND pos.updatedPrice='1'";
                }

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT posdetails.InvoiceNo, products.barcode, posdetails.ProductPrice, posdetails.Quantity, posdetails.discount_percentage, posdetails.total_amount, pos.majority_bool, pos.POSDate FROM posdetails JOIN pos On posdetails.InvoiceNo=pos.InvoiceNo LEFT JOIN products ON posdetails.id_product=products.id_product WHERE pos.POSDate BETWEEN '" + firstDate + "' AND '" + secondDate + "' " + findFreeProd + " " + finddiscountProd + " " + findShumicProd + " " + findUpdatedPrice + "", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                Decimal prodPrice = 0;
                Decimal prodQty = 0;
                Decimal proddiscPerc = 0;
                Decimal prodTotalAmount = 0;
                Decimal findSum = 0;

                while (dr.Read() == true)
                {
                    DateTime posDate = Convert.ToDateTime(dr.GetString(7));
                    string outDate = posDate.ToString("dd-MM-yyyy");

                    prodPrice = dr.GetDecimal(2);
                    prodQty = dr.GetDecimal(3);
                    proddiscPerc = dr.GetDecimal(4);
                    prodTotalAmount = dr.GetDecimal(5);
                    findSum += prodTotalAmount;

                    dgw.Rows.Add(dr[0], dr[1], prodPrice, prodQty, proddiscPerc, prodTotalAmount, outDate);
                }

                lblTotalCost.Text = findSum.ToString();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindData();
        }

        private void chkFree_CheckedChanged(object sender, EventArgs e)
        {
            chkDiscount.Checked = false;
            chkShumic.Checked = false;
            chkOtherPrice.Checked = false;
        }

        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            chkFree.Checked = false;
            chkShumic.Checked = false;
            chkOtherPrice.Checked = false;
        }

        private void chkShumic_CheckedChanged(object sender, EventArgs e)
        {
            chkFree.Checked = false;
            chkDiscount.Checked = false;
            chkOtherPrice.Checked = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgw.Rows.Clear();
            chkFree.Checked = false;
            chkDiscount.Checked = false;
            chkShumic.Checked = false;
            lblTotalCost.Text = "0.00";
        }

        private void frmOffersProducts_Load(object sender, EventArgs e)
        {
            DateTime dbDate1 = Convert.ToDateTime(dateTimeToday);

            var firstDate = dbDate1.ToString("yyyy-MM-dd");

            dtStartDate.Text = firstDate;  
        }

        private void chkOtherPrice_CheckedChanged(object sender, EventArgs e)
        {
            chkFree.Checked = false;
            chkShumic.Checked = false;
            chkDiscount.Checked = false;
        }
    }
}
