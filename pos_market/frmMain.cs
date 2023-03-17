using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    public partial class frmMain : Form
    {
        public static string myUsername;
        public static string id_employee;
        public static string day_started;
        public static string timeDiff;
        public static string timeDiffString;
        
        //count messages
        private static Int32 msgCount;

        
        public static string id_stat;
        private static Boolean work_continue;
        public static Boolean toBackUp;
        public static int id_user_type;

        private static Decimal NonVatAmount, VatAmount, TotalAmount, TotalDebtAmount, totalServiceAmount, gjithsejt, totalBuyAmount, DebtReturnedAmount;

        //Company
        public static string infoCompanyName;
        public static string infoCurrency;
        public static string infomanager;

        //User Details
        private static string EmpUsername;
        private static string EmpFullName;
        private static string EmpAdress;
        private static string EmpCity;
        private static string EmpCountry;
        private static string EmpContactNumber;

        string dateToday = DateTime.Now.ToString("dd-M-yyyy");

        //PDF Creation
        public static string randomNumber;
        
        private void CreateStat()
        {
            DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
            string datetimeNow = dbDate1.ToString("yyyy-M-dd HH:mm:ss");
            string timeNow = dbDate1.ToString("HH:mm");

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("INSERT INTO employee_stats(id_employee, time_start) VALUES ('" + id_employee + "', '" + datetimeNow + "')", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("E keni filluar sesionin e punes, sot ne ora : " + timeNow + "", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CreateStat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateAmount()
        {
           // FindHoursWorked();
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT StaffID, POSDate, SUM(NonVatAmount), SUM(VatAmount), SUM(TotalAmount) FROM pos WHERE StaffID='" + id_employee + "' AND (type_payment='1' OR type_payment='2') AND end_session='0'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    NonVatAmount = dr.IsDBNull(2) ? 0 : dr.GetDecimal(2);
                    VatAmount = dr.IsDBNull(3) ? 0 : dr.GetDecimal(3);
                    TotalAmount = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CalculateAmount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateDebtSalesAmount()
        {
            // FindHoursWorked();
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT SUM(TotalAmount) FROM pos WHERE StaffID='" + id_employee + "' AND type_payment='3' AND end_session='0'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    TotalDebtAmount = dr.IsDBNull(0) ? 0 : dr.GetDecimal(0);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CalculateDebtSalesAmount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateReturnedAmount()
        {
            // FindHoursWorked();
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT SUM(debtValue) As calcAmount FROM paiddebts WHERE StaffID='" + id_employee + "' AND end_session='0'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    DebtReturnedAmount = dr.IsDBNull(0) ? 0 : dr.GetDecimal(0);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CalculateReturnedAmount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateReturnedAmount()
        {
            // FindHoursWorked();
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE paiddebts SET end_session='1' WHERE StaffID='" + id_employee + "' AND end_session='0'", conn);

                cmdDatabase.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error UpdateReturnedAmount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateRepairingStuff()
        {
            // FindHoursWorked();
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT SUM(total_cost) AS totalcost FROM repairing_services WHERE end_session='0' AND status_service='1' AND id_staff='" + id_employee + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    totalServiceAmount = dr.IsDBNull(0) ? 0 : dr.GetDecimal(0);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CalculateRepairingStuff", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateBuyStuff()
        {
            // FindHoursWorked();
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT SUM(total_buy) AS totalcost FROM bought_ocassion WHERE end_session='0' AND id_staff='" + id_employee + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                     totalBuyAmount = dr.IsDBNull(0) ? 0 : dr.GetDecimal(0);
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CalculateBuyStuff", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FindCompany()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT company.companyName, sys_currency.currency, company.manager, company.contactNumber, company.CompanySN, company.BANK_Number, company.adress, company.city, company.country FROM company LEFT JOIN sys_currency ON company.id_currency=sys_currency.id_currency WHERE company.id_company = 1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                    infoCompanyName = dr[0].ToString();
                    infoCurrency = dr[1].ToString();
                    infomanager = dr[2].ToString();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FindCompany", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getUserDetails()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_user, username, fullname, adress, city, country, phone, user_type FROM users WHERE username='" + txtUsername.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.Read() == true)
                {
                        EmpUsername = dr[1].ToString();
                        EmpFullName = dr[2].ToString();
                        EmpAdress = dr[3].ToString();
                        EmpCity = dr[4].ToString();
                        EmpCountry = dr[5].ToString();
                        EmpContactNumber = dr[6].ToString();
                        id_user_type = dr.GetInt32(7);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getUserDetails", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EndStat()
        {
            try
            {
                FindCompany();
                CalculateAmount();
                CalculateDebtSalesAmount();
                CalculateReturnedAmount();
                UpdateReturnedAmount();

                DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
                string datetimeNow = dbDate1.ToString("yyyy-M-dd HH:mm:ss");
                string timeNow = dbDate1.ToString("HH:mm:ss");
                gjithsejt = Math.Round(TotalAmount + DebtReturnedAmount - TotalDebtAmount, 2);

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE employee_stats SET time_end='" + datetimeNow + "', hours_worked = '" + timeDiff + "', NonVatAmount='" + NonVatAmount + "' , VatAmount ='" + VatAmount + "' , TotalAmount ='" + TotalAmount + "', TotalDebtAmount='" + TotalDebtAmount + "', returned_debts='" + DebtReturnedAmount + "', total_sum ='" + gjithsejt + "' WHERE id_stat='" + id_stat + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Keni mbaruar punen ne ora: " + timeNow + " dhe punuat per: " + timeDiff + " orë, dhe mblodhet " + gjithsejt + " " + infoCurrency + " !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error EndStat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EndSession()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("UPDATE pos SET end_session='1' WHERE StaffID = '" + id_employee + "'", conn);

                MySqlCommand cmdDatabase1 = new MySqlCommand("UPDATE repairing_services SET end_session='1' WHERE id_staff = '" + id_employee + "'", conn);

                MySqlCommand cmdDatabase2 = new MySqlCommand("UPDATE bought_ocassion SET end_session='1' WHERE id_staff = '" + id_employee + "'", conn);

                int i = cmdDatabase.ExecuteNonQuery();

                if (i > 0)
                {
                    cmdDatabase1.ExecuteNonQuery();
                    cmdDatabase2.ExecuteNonQuery();
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error EndSession", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindHoursWorked()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_stat, time_start FROM employee_stats WHERE id_employee='" + id_employee + "' AND hours_worked=0", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    id_stat = dr[0].ToString();
                    DateTime dbDate1 = Convert.ToDateTime(dr[1]);
                    lblDateStarted.Text = dbDate1.ToString("dd-M-yyyy");
                    lblTimeStarted.Text = dbDate1.ToString("HH:mm");
                    day_started = dbDate1.ToString("yyyy-M-dd HH:mm:s");

                    work_continue = true;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FindHoursWorked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindEmployee()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_user, username FROM users WHERE username='" + txtUsername.Text + "'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        id_employee = dr.GetString(0);
                    }
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FindEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindBackupDates()
        {
            try
            {
                DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
                string dateToday = dbDate1.ToString("dd");
                string shortdateToday = dbDate1.ToString("yyyy-M-dd");

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT name_backup, date_backup FROM backup_db WHERE name_backup='" + dateToday + "' AND date_backup<>'" + shortdateToday + "'", conn);
                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    toBackUp = true;
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FindBackupDates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindNonBalancedImported()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT COUNT(*) FROM imp_invoices WHERE payment_status='0'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        lblNonBalancedImported.Text = dr.GetString(0);
                    }
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FindNonBalancedImported", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindNonBalancedSold()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT COUNT(*) FROM client_debts WHERE type_payment='2'", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        lblNonBalancedSold.Text = dr.GetString(0);
                    }
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FindNonBalancedSold", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmClients frm = new frmClients();
            frm.ShowDialog();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            //     frmAdminMsg frm = new frmAdminMsg();
            //   frm.ShowDialog();
            //   PosFront.
            PosFront frm = new PosFront();
            frm.txtusername.Text = txtUsername.Text;
            frm.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmProducts.findProductForm=false;
            frmFindProduct.myUsername = txtUsername.Text;
            frmProducts frm = new frmProducts();
            frm.ShowDialog();
        }

        private void CountMessages()
        {

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT COUNT(*) FROM messages", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.Read() == true)
                {
                    msgCount = dr.GetInt32(0);
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CountMessages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Exporting to PDF
            getUserDetails();
            FindCompany();
            if (id_user_type != 1){
                btnImportInvoice.Enabled = false;
                btnClients.Enabled = false;
                btnProducts.Enabled = false;
                btnDistributors.Enabled = false;
                btnStaff.Enabled = false;
                btnUpdatePrices.Enabled = false;
                btnBalanceStockOut.Enabled = false;
                btnBalanceStockIn.Enabled = false;
                btnPDFImportedInvoice.Enabled = false;
                btnPDFImport.Enabled = false;
                btnPDFExport.Enabled = false;
                btnEmpHist.Enabled = false;
                btnAvailableStocks.Enabled = false;
                btnConsumedStocks.Enabled = false;
                btnCSVClients.Enabled = false;
                btnAttachments.Enabled = false;
                btnSystem.Enabled = false;
                btnPrices.Enabled = false;
                btnPDFExportedInvoice.Enabled = false;
                lblBackup.Enabled = false;
                lblNonBalancedImp.Enabled = false;
                lblNonBalancedImported.Enabled = false;
                lblNonBalanced.Enabled = false;
                lblNonBalancedSold.Enabled = false;
                btnPOS.Enabled = false;
                btnDebt.Enabled = false;
                btnSuggestedProducts.Enabled = false;
                btnDailyBook.Enabled = false;
                btnSalesCat.Enabled = false;
                btnPDFExport.Enabled = false;
                btnBuysSpends.Enabled = false;
            }
            
            if (id_user_type == 2)
            {
                btnImportInvoice.Enabled = true;
                btnPDFImportedInvoice.Enabled = true;
                btnPrices.Enabled = true;
                btnAvailableStocks.Enabled = true;
                btnConsumedStocks.Enabled = true;
                btnMessage.Enabled = true;
            }

            if (id_user_type == 3)
            {
                btnPOS.Enabled = true;
                btnMessage.Enabled = true;
            }

            CountMessages();
            
            lblNewMessages.Text = msgCount.ToString();

            DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);

            string timeNow = dbDate1.ToString("HH:mm:ss");

            lblUsername.Text = txtUsername.Text;
            lblCompName.Text = infoCompanyName;
            txtUsername.Visible = false;
            lblTime.Text = timeNow;
            //frmMain frm = new frmMain();
            
            FindNonBalancedSold();
            FindNonBalancedImported();
            
            FindEmployee();
            FindHoursWorked();

            if (work_continue == false)
            {
                CreateStat();
                FindHoursWorked();
            }
            else 
            {
                MessageBox.Show("Nuk keni mbaruar punen qe nga data: " + lblDateStarted.Text + " ora: " + lblTimeStarted.Text + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (id_user_type == 1){
                FindBackupDates();
                if (toBackUp == true)
                {
                    MessageBox.Show("Pritni disa sekonda te kryhet Backup i Databazes !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                    DataBackup.toBackUp = true;
                    DataBackup frm = new DataBackup();
                    frm.Show();
                }
            }

            // MessageBox.Show("Jeni duke e përdorur beta versionin Supermarketeve, mos filloni shitjen para se të verifikohet nga administratori !");

            //     string dateNow = Convert.ToDateTime(DateTime.Now).ToString("yyyy-M-dd");
            //   if (dateNow == "2017-2-28") {
            //    File.Delete("C://Windows/System32/dtr/dat.dll");
            // }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmDistributors frm = new frmDistributors();
            frm.ShowDialog();
        }
        public static bool FormIsOpen(FormCollection application, Type formType)
        {
            //usage sample: FormIsOpen(Application.OpenForms,typeof(Form2)
            return Application.OpenForms.Cast<Form>().Any(openForm => openForm.GetType() == formType);
        }

        private void btnImportInvoice_Click(object sender, EventArgs e)
        {
            if (FormIsOpen(Application.OpenForms, typeof(ImportInvoice)) == true)
            {
                MessageBox.Show("Dritarja e importimit te mallit eshte e hapur !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                ImportInvoice frm = new ImportInvoice();
                frm.Show();
            }
        }

        private void btnBalanceStockOut_Click(object sender, EventArgs e)
        {
            frmBalanceSoldInvoice frm = new frmBalanceSoldInvoice();
            frm.ShowDialog();
        }

        private void btnBalanceStockIn_Click(object sender, EventArgs e)
        {
            frmBalanceStockin frm = new frmBalanceStockin();
            frm.ShowDialog();
        }

        private void btnPDFImportedInvoice_Click(object sender, EventArgs e)
        {
            frmPDFInvoiceDetail frm = new frmPDFInvoiceDetail();
            frm.ShowDialog();
        }

        private void btnPDFImport_Click(object sender, EventArgs e)
        {
            frmPDFimpInvoices frm = new frmPDFimpInvoices();
            frm.ShowDialog();
        }

        private void btnPDFExport_Click(object sender, EventArgs e)
        {
            frmPDFexpInvoices frm = new frmPDFexpInvoices();
            frm.ShowDialog();
        }

        private void CSVStockins_Click(object sender, EventArgs e)
        {
        }

        private void btnCSVClients_Click(object sender, EventArgs e)
        {
                frmCSVexport frm = new frmCSVexport();
                frm.ShowDialog();
        }

        private void btnCSVProducts_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni te shkarkoni produktet ne CSV format !", "Cancel Payment ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Download CSV File !");
            }
        }

        private void btnCSVDistributors_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni te shkarkoni distributoret ne CSV format !", "Cancel Payment ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Shkarko CSV Fajlin !");
            }
        }

        private void btnPDFExportedInvoice_Click(object sender, EventArgs e)
        {
            frmPDFSoldInvoice frm = new frmPDFSoldInvoice();
            frm.ShowDialog();
        }

        private void btnCSVStocksIn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A doni te shkarkoni produktet ne CSV format !", "Cancel Payment ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Shkarko CSV Fajlin !");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPDFSalesEmployees frm = new frmPDFSalesEmployees();
            frm.ShowDialog();
        }

        private void lblNonBalancedImported_Click(object sender, EventArgs e)
        {
            frmBalanceStockin frm = new frmBalanceStockin();
            frm.ShowDialog();
        }

        private void lblNonBalancedSold_Click(object sender, EventArgs e)
        {
            frmBalanceSoldInvoice frm = new frmBalanceSoldInvoice();
            frm.ShowDialog();
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            myUsername = txtUsername.Text;
            frmAdminMsg frm = new frmAdminMsg();
            frm.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            frmBalanceSoldInvoice frm = new frmBalanceSoldInvoice();
            frm.ShowDialog();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            frmBalanceStockin frm = new frmBalanceStockin();
            frm.ShowDialog();
        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
            frmPrintPrices frm = new frmPrintPrices();
            frm.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DataBackup frm = new DataBackup();
            frm.ShowDialog();
        }

        private void exportDoc()
        {
            
            //Header Left Table
            PdfPTable pdfTable = new PdfPTable(1);
            pdfTable.DefaultCell.MinimumHeight = 20.0F;
            pdfTable.WidthPercentage = 85;

            PdfPCell Tablecell = new PdfPCell();
            Paragraph p = new Paragraph();
            getUserDetails();

            //   p1.Add(new Paragraph("Invoice Processing Number -  ", Classes.UserFonts.GetBoldFont()));
            p.Add(new Paragraph("[" + EmpUsername + "]", Classes.UserFonts.fontNeue20()));
            p.Add(new Paragraph("Rruga, Adresa : ", Classes.UserFonts.FontBold14()));
            p.Add(new Paragraph("[" + EmpAdress + ", " + EmpCity + ", " + EmpCountry + "]", Classes.UserFonts.FontBold14()));
            p.Add(new Paragraph("Telefoni : ", Classes.UserFonts.FontBold14()));
            p.Add(new Paragraph("[" + EmpContactNumber + "]", Classes.UserFonts.FontBold14()));
            p.Add(new Paragraph(""));

            Tablecell.AddElement(p);

            pdfTable.AddCell(Tablecell);

            //Starting Sums
            //Bottom Table
            PdfPTable pdfTable8 = new PdfPTable(2);

            pdfTable8.DefaultCell.Padding = 3;
            pdfTable8.WidthPercentage = 85;
            pdfTable8.DefaultCell.MinimumHeight = 40.0F;
            pdfTable8.DefaultCell.SetLeading(4.5F, 1);
            pdfTable8.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable8.DefaultCell.BorderWidth = 0;

            PdfPCell Tablecell8 = new PdfPCell();
            Paragraph p8 = new Paragraph();
            //Titles
            p8.Add(new Phrase("Oret Punoi ", Classes.UserFonts.fontNeue12()));
            p8.Add(new Paragraph(" "));

            p8.Add(new Phrase("Shuma Shitjeve ", Classes.UserFonts.fontNeue12()));
            p8.Add(new Paragraph(" "));

            p8.Add(new Phrase("Shuma Shitjeve Borxh ", Classes.UserFonts.fontNeue12()));
            p8.Add(new Paragraph(" "));

            p8.Add(new Phrase("Kthimi Borxheve ", Classes.UserFonts.fontNeue12()));
            p8.Add(new Paragraph(" "));

            p8.Add(new Phrase("Gjithsejt ", Classes.UserFonts.fontNeue12()));
            p8.Add(new Paragraph(" "));

            CalculateAmount();
            CalculateDebtSalesAmount();
            CalculateRepairingStuff();
            CalculateBuyStuff();
            CalculateReturnedAmount();

            //Amounts end of the table
            PdfPCell Tablecell9 = new PdfPCell();
            Paragraph p9 = new Paragraph();
            p9.Add(new Phrase(timeDiffString, Classes.UserFonts.fontNeue12()));
            p9.Add(new Paragraph(" "));

            p9.Add(new Phrase("+ " + TotalAmount + " " + infoCurrency + " ", Classes.UserFonts.fontNeue12()));
            p9.Add(new Paragraph(" "));

            p9.Add(new Phrase("- " + TotalDebtAmount + " " + infoCurrency + " ", Classes.UserFonts.fontNeue12()));
            p9.Add(new Paragraph(" "));

            p9.Add(new Phrase("+ " + DebtReturnedAmount + " " + infoCurrency + " ", Classes.UserFonts.fontNeue12()));
            p9.Add(new Paragraph(" "));

            gjithsejt = Math.Round(TotalAmount + DebtReturnedAmount - TotalDebtAmount, 2);

            p9.Add(new Phrase(gjithsejt + " " + infoCurrency + " ", Classes.UserFonts.fontNeue12()));

            p9.Add(new Paragraph(" "));
            p9.Add(new Paragraph(dateToday));

            Tablecell8.BorderWidth = 0;

            p8.Alignment = Element.ALIGN_RIGHT;
            p9.Alignment = Element.ALIGN_LEFT;

            Tablecell8.AddElement(p8);
            Tablecell9.AddElement(p9);
            pdfTable8.AddCell(Tablecell8);
            pdfTable8.AddCell(Tablecell9);
            //Ending Sums

            randomNumber = DateTime.Now.ToString("HHmmss");

            //Exporting to PDF
            string folderPath = "C:/PDFs/";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "" + randomNumber + ".PDF", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(pdfTable8);
                pdfDoc.Close();
                stream.Close();
            }
        }

        private void lblEndWork_Click(object sender, EventArgs e)
        {
             DialogResult dialogResult = MessageBox.Show("A doni ta mbaroni punen per sot ?", "Closing Account !", MessageBoxButtons.YesNo);
             if (dialogResult == DialogResult.Yes)
             {
                 DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
                 string datetimeNow = dbDate1.ToString("yyyy-M-dd HH:mm:ss");
                 string timeNow = dbDate1.ToString("HH:mm:ss");

                 DateTime dFrom;
                 DateTime dTo;

                 string sDateFrom = day_started;
                 string sDateTo = datetimeNow;

                 if (DateTime.TryParse(sDateFrom, out dFrom) && DateTime.TryParse(sDateTo, out dTo))
                 {
                     getUserDetails();

                     TimeSpan TS = dTo - dFrom;
                     int hour = TS.Hours;
                     int mins = TS.Minutes;
                     timeDiffString = hour.ToString("00") + " orë dhe " + mins.ToString("00") + " minuta";
                     timeDiff = hour.ToString("0") + "." + mins.ToString("0");

                    //if ((id_user_type == 1) || (id_user_type == 3)) { 
                    //   DialogResult dialogResult1 = MessageBox.Show("A doni ta shkarkoni raportin e punes ?", "Downloading Report !", MessageBoxButtons.YesNo);
                    //if (dialogResult1 == DialogResult.Yes)
                    //{
                    //exportDoc();
                    //System.Diagnostics.Process.Start("C:/PDFs/" + randomNumber + ".pdf");
                    //}
                    //}

                    EndStat();
                     EndSession();
                 }
                 this.Dispose(true);
                 Application.ExitThread();
             }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dbDate1 = Convert.ToDateTime(DateTime.Now);
            string timeNow = dbDate1.ToString("HH:mm:ss");
            lblTime.Text = timeNow;
        }

        private void btnAvailableStocks_Click(object sender, EventArgs e)
        {
            frmAvailableStocks frm = new frmAvailableStocks();
            frm.ShowDialog();
        }

        private void btnConsumedStocks_Click(object sender, EventArgs e)
        {
            frmConsumedProducts frm = new frmConsumedProducts();
            frm.ShowDialog();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            frmStaff frm = new frmStaff();
            frm.ShowDialog();
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            frmSystem frm = new frmSystem();
            frm.ShowDialog();
        }

        private void btnAttachments_Click(object sender, EventArgs e)
        {
            frmAttachments frm = new frmAttachments();
            frm.ShowDialog();
        }

        private void btnUpdatePrices_Click(object sender, EventArgs e)
        {
            frmUpdateProductPrice frm = new frmUpdateProductPrice();
            frm.ShowDialog();
        }

        private void btnPoints_Click(object sender, EventArgs e)
        {
            frmClientPoints frm = new frmClientPoints();
            frm.ShowDialog();
        }

        private void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            frmGenerateBarcode frm = new frmGenerateBarcode();
            frm.ShowDialog();
        }

        private void btnDebt_Click(object sender, EventArgs e)
        {
            frmDebts frm = new frmDebts();
            frm.ShowDialog();
        }

        private void findPOSPrinter()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                MySqlCommand cmdDatabase = new MySqlCommand("SELECT printer_name FROM sys_printer_devices WHERE id_printer=1", conn);

                MySqlDataReader dr = cmdDatabase.ExecuteReader();

                if (dr.Read() == true)
                {
                    string printerName = dr[0].ToString();
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }


        private void btnServiceProds_Click(object sender, EventArgs e)
        {
            frmService.id_staff = id_employee;
            frmService frm = new frmService();
            frm.ShowDialog();
        }

        private void btnBuyProd_Click(object sender, EventArgs e)
        {
            frmBuyOcassion.id_user = id_employee;
            frmBuyOcassion frm = new frmBuyOcassion();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmStatsServices frm = new frmStatsServices();
            frm.ShowDialog();
        }

        private void btnBuysSpends_Click(object sender, EventArgs e)
        {
            frmBuySpend frm = new frmBuySpend();
            frm.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frmStatsLocalBuys frm = new frmStatsLocalBuys();
            frm.ShowDialog();
        }

        private void btnSuggestedProducts_Click(object sender, EventArgs e)
        {
            frmSuggestedProducts frm = new frmSuggestedProducts();
            frm.ShowDialog();
        }

        private void btnSalesCat_Click(object sender, EventArgs e)
        {
            frmSalesByCategory frm = new frmSalesByCategory();
            frm.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frmOffersProducts frm = new frmOffersProducts();
            frm.ShowDialog();
        }
    }
}