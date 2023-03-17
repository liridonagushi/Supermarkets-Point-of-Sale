namespace Supermarkets
{
    partial class DataBackup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtNameBackup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSourceBackup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSourceBackup2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameBackup2 = new System.Windows.Forms.TextBox();
            this.btnBrowse2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtBackup3 = new System.Windows.Forms.ComboBox();
            this.dtBackup2 = new System.Windows.Forms.ComboBox();
            this.dtBackup = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 58);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(186, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(247, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Konfigurimi i Backup automatik";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnClose.Location = new System.Drawing.Point(537, 319);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 36);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Mbyll";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtNameBackup
            // 
            this.txtNameBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNameBackup.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtNameBackup.Location = new System.Drawing.Point(189, 33);
            this.txtNameBackup.MaxLength = 20;
            this.txtNameBackup.Name = "txtNameBackup";
            this.txtNameBackup.ReadOnly = true;
            this.txtNameBackup.Size = new System.Drawing.Size(205, 28);
            this.txtNameBackup.TabIndex = 0;
            this.txtNameBackup.TabStop = false;
            this.txtNameBackup.Text = "Local";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(186, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "I Backup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Datat e Backup";
            // 
            // txtSourceBackup
            // 
            this.txtSourceBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSourceBackup.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtSourceBackup.Location = new System.Drawing.Point(400, 33);
            this.txtSourceBackup.MaxLength = 20;
            this.txtSourceBackup.Name = "txtSourceBackup";
            this.txtSourceBackup.ReadOnly = true;
            this.txtSourceBackup.Size = new System.Drawing.Size(205, 28);
            this.txtSourceBackup.TabIndex = 0;
            this.txtSourceBackup.TabStop = false;
            this.txtSourceBackup.TextChanged += new System.EventHandler(this.txtSourceBackup_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(397, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "I Source Backup";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Copperplate Gothic Light", 9F);
            this.btnBrowse.Location = new System.Drawing.Point(19, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(138, 38);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Gjej lokacionin";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtSourceBackup);
            this.panel2.Controls.Add(this.btnBrowse);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtNameBackup);
            this.panel2.Location = new System.Drawing.Point(12, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(646, 70);
            this.panel2.TabIndex = 59;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.txtSourceBackup2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtNameBackup2);
            this.panel3.Controls.Add(this.btnBrowse2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(12, 163);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(646, 72);
            this.panel3.TabIndex = 69;
            // 
            // txtSourceBackup2
            // 
            this.txtSourceBackup2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSourceBackup2.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtSourceBackup2.Location = new System.Drawing.Point(400, 33);
            this.txtSourceBackup2.MaxLength = 20;
            this.txtSourceBackup2.Name = "txtSourceBackup2";
            this.txtSourceBackup2.ReadOnly = true;
            this.txtSourceBackup2.Size = new System.Drawing.Size(205, 28);
            this.txtSourceBackup2.TabIndex = 0;
            this.txtSourceBackup2.TabStop = false;
            this.txtSourceBackup2.TextChanged += new System.EventHandler(this.txtSourceBackup2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(397, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "II Source Backup";
            // 
            // txtNameBackup2
            // 
            this.txtNameBackup2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNameBackup2.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtNameBackup2.Location = new System.Drawing.Point(189, 33);
            this.txtNameBackup2.MaxLength = 20;
            this.txtNameBackup2.Name = "txtNameBackup2";
            this.txtNameBackup2.ReadOnly = true;
            this.txtNameBackup2.Size = new System.Drawing.Size(205, 28);
            this.txtNameBackup2.TabIndex = 0;
            this.txtNameBackup2.TabStop = false;
            this.txtNameBackup2.Text = "Server";
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.Font = new System.Drawing.Font("Copperplate Gothic Light", 9F);
            this.btnBrowse2.Location = new System.Drawing.Point(19, 23);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(138, 38);
            this.btnBrowse2.TabIndex = 2;
            this.btnBrowse2.Text = "Gjej lokacionin";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(186, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "II Backup";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(154, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "I Date";
            // 
            // folderBrowserDialog2
            // 
            this.folderBrowserDialog2.HelpRequest += new System.EventHandler(this.folderBrowserDialog2_HelpRequest);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.dtBackup3);
            this.panel4.Controls.Add(this.dtBackup2);
            this.panel4.Controls.Add(this.dtBackup);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(12, 250);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(646, 63);
            this.panel4.TabIndex = 0;
            // 
            // dtBackup3
            // 
            this.dtBackup3.FormattingEnabled = true;
            this.dtBackup3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28"});
            this.dtBackup3.Location = new System.Drawing.Point(464, 31);
            this.dtBackup3.Name = "dtBackup3";
            this.dtBackup3.Size = new System.Drawing.Size(71, 21);
            this.dtBackup3.TabIndex = 5;
            // 
            // dtBackup2
            // 
            this.dtBackup2.FormattingEnabled = true;
            this.dtBackup2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28"});
            this.dtBackup2.Location = new System.Drawing.Point(311, 31);
            this.dtBackup2.Name = "dtBackup2";
            this.dtBackup2.Size = new System.Drawing.Size(71, 21);
            this.dtBackup2.TabIndex = 4;
            // 
            // dtBackup
            // 
            this.dtBackup.FormattingEnabled = true;
            this.dtBackup.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28"});
            this.dtBackup.Location = new System.Drawing.Point(157, 31);
            this.dtBackup.Name = "dtBackup";
            this.dtBackup.Size = new System.Drawing.Size(71, 21);
            this.dtBackup.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(461, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "I I I Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(308, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "I I Date";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnSave.Location = new System.Drawing.Point(12, 319);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(193, 36);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Ruaj Konfigurimin";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnBackup.Location = new System.Drawing.Point(359, 319);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(172, 36);
            this.btnBackup.TabIndex = 7;
            this.btnBackup.Text = "Backup Tash";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // DataBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 362);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.MinimumSize = new System.Drawing.Size(684, 400);
            this.Name = "DataBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Back Up";
            this.Load += new System.EventHandler(this.DataBackup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNameBackup;
        private System.Windows.Forms.TextBox txtSourceBackup;
        private System.Windows.Forms.TextBox txtSourceBackup2;
        private System.Windows.Forms.TextBox txtNameBackup2;
        private System.Windows.Forms.ComboBox dtBackup;
        private System.Windows.Forms.ComboBox dtBackup3;
        private System.Windows.Forms.ComboBox dtBackup2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBackup;
    }
}