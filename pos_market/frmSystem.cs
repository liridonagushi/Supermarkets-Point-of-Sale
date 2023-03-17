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

namespace Supermarkets
{
    public partial class frmSystem : Form
    {
      //  public static PrinterSettings.StringCollection InstalledPrinters { get; }
        private static string id_currency;
        private static string CheckPos;
        private static string CheckXml;
        private static string CheckTxt;
        private static string CheckFiscalActivate;
        private static string EnablePoints;

        public frmSystem()
        {
            InitializeComponent();
        }

        private void Showsys_currency()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_currency, name_currency FROM sys_currency", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                cmbCurrency.Items.Clear();

                while (dr.Read() == true)
                {
                  cmbCurrency.Items.Add(dr[1]);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void FindInstalledPrinter()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_printer, printer_name, paper_size, pos_printer FROM sys_printer_devices WHERE id_printer=1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read() == true)
                {
                    txtPrinterName.Text = dr[1].ToString();
                    txtPaperSize.Text = dr[2].ToString();
                    cmbFindPrinter.Text = dr[1].ToString();
                    comboPaperSize.Text = dr[2].ToString();
                    if (dr[3].ToString() == "1") { ChkPOS.Checked = true; } else { ChkPOS.Checked = false;  }
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindInputDirectory()
        {
            try
            {

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_fiscal, input_directory, output_directory, activate_fiscal, render_txt_catalog, render_xml_catalog FROM sys_fiscal_customization WHERE id_fiscal=1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read() == true)
                {
                    txtFiscalInpDir.Text = dr[1].ToString();
                    txtFiscalOutPutDir.Text = dr[2].ToString();
                    if (dr[3].ToString() == "1") { ChkFiscal.Checked = true; } else { ChkFiscal.Checked = false; }
                    if (dr[4].ToString() == "1") { ChkXML.Checked = true; } else { ChkXML.Checked = false; }
                    if (dr[5].ToString() == "1") { ChkTXT.Checked = true; } else { ChkTXT.Checked = false; }
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindCurrency()
        {
            try
            {
                FindCompany();
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_currency, name_currency, currency, amount FROM sys_currency WHERE id_currency='" + id_currency + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read() == true)
                {
                    cmbCurrency.Text = dr.GetString(1);
                    txtCurrency.Text = dr.GetString(3);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindCompany()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT company.id_currency FROM company WHERE company.id_company='1'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read() == true)
                {
                    id_currency = dr.GetString(0);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateInstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cmbFindPrinter.Items.Add(pkInstalledPrinters);
            }
        }

        private void frmSystem_Load(object sender, EventArgs e)
        {
            PopulateInstalledPrintersCombo();
            Showsys_currency();
            lblCurrencyValue.Text = cmbCurrency.Text;
            FindInstalledPrinter();
            FindInputDirectory();
            FindPoints();
            FindCompany();
            FindCurrency();
            this.cmbFindPrinter.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmbFindPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the printer to a printer in the combo box when the selection changes.
            if (cmbFindPrinter.SelectedIndex != -1)
            {
                // The combo box's Text property returns the selected item's text, which is the printer name.
                txtPrinterName.Text = cmbFindPrinter.Text;
            }
        }

        private void comboPaperSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the printer to a printer in the combo box when the selection changes.
            if (comboPaperSize.SelectedIndex != -1)
            {
                // The combo box's Text property returns the selected item's text, which is the printer name.
                txtPaperSize.Text = comboPaperSize.Text;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;
                this.txtFiscalInpDir.Text = path + @"\";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog2.SelectedPath;
                this.txtFiscalOutPutDir.Text = path + @"\";
            }
        }


        private void UpdateInputDir()
        {
            try
            {
                string sourcebackup = txtFiscalInpDir.Text.ToString();
                var query = sourcebackup.Replace(@"\", @"\\");

                string sourcebackup1 = txtFiscalOutPutDir.Text.ToString();
                var query1 = sourcebackup1.Replace(@"\", @"\\");
                
                if (ChkXML.Checked == true) { CheckXml = "1"; } else { CheckXml = "0"; }
                if (ChkTXT.Checked == true) { CheckTxt = "1"; } else { CheckTxt = "0"; }
                if (ChkFiscal.Checked == true) { CheckFiscalActivate = "1"; } else { CheckFiscalActivate = "0"; }

                MySqlConnection conn = DBUtils.GetDBConnection();

                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE sys_fiscal_customization SET input_directory='" + query + "', output_directory='" + query1 + "', render_xml_catalog='" + CheckXml + "', render_txt_catalog='" + CheckTxt + "', activate_fiscal='" + CheckFiscalActivate + "' WHERE id_fiscal=1", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Input directory updated successfully", "Printer Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindPoints()
        {
            try
            {

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_points, id_company, amountToPoint, active FROM sys_points WHERE id_company = '1'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read() == true)
                {
                    txtPoints.Text = dr[2].ToString();
                    if (dr[3].ToString() == "1") { chkEnablePoints.Checked = true; } else { chkEnablePoints.Checked = false; }
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindCurrencyID()
        {
            try
            {

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_currency, name_currency, currency FROM sys_currency WHERE name_currency = '" + cmbCurrency.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read() == true)
                {
                    id_currency = dr[0].ToString();
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCurrency()
        {
            FindCurrencyID();

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();

                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE company SET id_currency='" + id_currency + "' WHERE id_company=1", conn);

                MySqlCommand cmdDatabase1 = new MySqlCommand("UPDATE sys_currency SET amount='" + txtCurrency.Text + "' WHERE id_currency='" + id_currency + "'", conn);

                cmdDatabase1.ExecuteNonQuery();

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Currency updated successfully", "Printer Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePrinterName()
        {
            try
            {
                if (ChkPOS.Checked == true) { CheckPos = "1"; } else { CheckPos = "0"; }
                
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE sys_printer_devices SET printer_name='" + txtPrinterName.Text + "', paper_size='" + txtPaperSize.Text + "', pos_printer='" + CheckPos + "' WHERE id_printer=1", conn);
               
                int i = cmdDatabase.ExecuteNonQuery();

                if(i>0){
                    MessageBox.Show("Printer updated successfully", "Printer Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePointsOptions()
        {
            try
            {
                if (chkEnablePoints.Checked == true) { EnablePoints = "1"; } else { EnablePoints = "0"; }

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE sys_points SET active='" + EnablePoints + "' WHERE id_company='1'", conn);

                cmdDatabase.ExecuteNonQuery();
               
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePointsAmount()
        {
            try
            {

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE sys_points SET amountToPoint='" + txtPoints.Text + "' WHERE id_company=1", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Amount to points activated successfully", "Printer Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCurrencyValue.Text = cmbCurrency.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((ChkPOS.Checked == true) && ((txtPrinterName.Text.Length == 0) || (txtPaperSize.Text.Length == 0)))
            {
                ChkPOS.Checked = false;
                MessageBox.Show("Please choose the POS Printer installed in your system !", "POS Printer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((ChkFiscal.Checked == true) && ((txtFiscalInpDir.Text.Length == 0) || (txtFiscalOutPutDir.Text.Length == 0)))
            {
                ChkFiscal.Checked = false;
                MessageBox.Show("Please choose the Fiscal Printer directory !", "Fiscal Printer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UpdateCurrency();
                UpdatePrinterName();
                UpdateInputDir();
                UpdatePrinterName();
                MessageBox.Show("Changes made successfully", "System Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
         //   btnSave.PerformClick();
           this.Dispose(true);
        }

        private void ChkTXT_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFiscal.Checked == false)
            {
                if (ChkTXT.Checked == true)
                {
                    ChkTXT.Checked = false;
                    MessageBox.Show("If 'Activate Fiscal Printer' checkbox is not activated, you can not enable text price catalog !", "Fiscal Operations", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ChkFiscal_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInputDir();
        }

        private void ChkPOS_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrinterName();
        }

        private void btnSaveCurrency_Click(object sender, EventArgs e)
        {
            if (cmbCurrency.Text == "") 
            {
                MessageBox.Show("Please choose the currency value !", "POS Printer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
              UpdateCurrency();
            }
        }

        private void btnSavePoints_Click(object sender, EventArgs e)
        {
            UpdatePointsAmount();
        }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            UpdatePrinterName();
            UpdateInputDir();
            UpdatePointsOptions();
        }

        private void btnSaveFiscal_Click(object sender, EventArgs e)
        {
            UpdateInputDir();
        }

        private void btnSavePos_Click(object sender, EventArgs e)
        {
            UpdatePrinterName();
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnClosePos_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnCloseFiscal_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnCloseCurrency_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void btnCloseOptions_Click(object sender, EventArgs e)
        {
           this.Dispose(true);
        }

        private void ChkXML_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFiscal.Checked == false)
            {
                if (ChkXML.Checked == true)
                {
                    ChkXML.Checked = false;
                    MessageBox.Show("If 'Activate Fiscal Printer' checkbox is not activated, you can not enable XML price catalog !", "Fiscal Operations", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void chkEnablePoints_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePointsOptions();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void delSales()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();

                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM pos", conn);
                MySqlCommand cmdDatabase1 = new MySqlCommand("DELETE FROM posdetails", conn);
                MySqlCommand cmdDatabase2 = new MySqlCommand("DELETE FROM client_debts", conn);
                MySqlCommand cmdDatabase3 = new MySqlCommand("DELETE FROM employee_stats", conn);
                MySqlCommand cmdDatabase4 = new MySqlCommand("DELETE FROM imp_invoices", conn);
                MySqlCommand cmdDatabase5 = new MySqlCommand("DELETE FROM invoiceprocessing", conn);
                MySqlCommand cmdDatabase6 = new MySqlCommand("DELETE FROM paiddebts", conn);
                MySqlCommand cmdDatabase7 = new MySqlCommand("DELETE FROM repairing_products_sold", conn);
                MySqlCommand cmdDatabase8 = new MySqlCommand("DELETE FROM repairing_services", conn);
                MySqlCommand cmdDatabase9 = new MySqlCommand("DELETE FROM bought_ocassion", conn);
                MySqlCommand cmdDatabase10 = new MySqlCommand("DELETE FROM stocksin", conn);
                MySqlCommand cmdDatabase11 = new MySqlCommand("ALTER TABLE pos AUTO_INCREMENT = 1", conn);
                MySqlCommand cmdDatabase12 = new MySqlCommand("ALTER TABLE posdetails AUTO_INCREMENT = 1", conn);
                MySqlCommand cmdDatabase13 = new MySqlCommand("ALTER TABLE repairing_services AUTO_INCREMENT = 1", conn);
                MySqlCommand cmdDatabase14 = new MySqlCommand("DELETE FROM price_hist", conn);

                cmdDatabase1.ExecuteNonQuery();
                cmdDatabase2.ExecuteNonQuery();
                cmdDatabase3.ExecuteNonQuery();
                cmdDatabase4.ExecuteNonQuery();
                cmdDatabase5.ExecuteNonQuery();
                cmdDatabase6.ExecuteNonQuery();
                cmdDatabase7.ExecuteNonQuery();
                cmdDatabase8.ExecuteNonQuery();
                cmdDatabase9.ExecuteNonQuery();
                cmdDatabase10.ExecuteNonQuery();
                cmdDatabase11.ExecuteNonQuery();
                cmdDatabase10.ExecuteNonQuery();
                cmdDatabase12.ExecuteNonQuery();
                cmdDatabase13.ExecuteNonQuery();
                cmdDatabase14.ExecuteNonQuery();

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Tabelat shitjes dhe servisit u fshin me sukses", "Reset Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void delProds()
        {
            try
            {
                string sourcebackup = txtFiscalInpDir.Text.ToString();
                var query = sourcebackup.Replace(@"\", @"\\");

                MySqlConnection conn = DBUtils.GetDBConnection();

                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("DELETE FROM products", conn);
                MySqlCommand cmdDatabase1 = new MySqlCommand("ALTER TABLE products AUTO_INCREMENT = 1", conn);
                cmdDatabase1.ExecuteNonQuery();

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    delSales();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelSales_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult1 = MessageBox.Show("A doni ti fshini shitjet e databazes ?", "Reset Sales !", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes)
            {
                delSales();
            }
        }

        private void btnDelProds_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult1 = MessageBox.Show("A doni ti fshini produktet e databazes ?", "Reset Products !", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes)
            {
                delProds();
            }
        }
    }
}