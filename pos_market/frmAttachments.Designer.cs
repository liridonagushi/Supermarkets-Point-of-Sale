namespace Supermarkets
{
    partial class frmAttachments
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDDoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameDoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateAdded = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnUpload = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.lblUpload = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelFile = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnDelete.Location = new System.Drawing.Point(586, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 47);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Fshij (Del)";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnFind.Location = new System.Drawing.Point(329, 10);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(126, 47);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Gjej (CTRL F)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnNew.Location = new System.Drawing.Point(10, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(143, 47);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "Krijo(CTRL N)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnSave.Location = new System.Drawing.Point(456, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 47);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Ruaj (Enter)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnClose.Location = new System.Drawing.Point(707, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 47);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Mbyll";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(12, 309);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 69);
            this.panel2.TabIndex = 0;
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnDownload.Location = new System.Drawing.Point(161, 265);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(147, 38);
            this.btnDownload.TabIndex = 10;
            this.btnDownload.Text = "Shkarko Fajl";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(295, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Administrimi Dokumenteve";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 58);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Constantia", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID Doc";
            // 
            // txtIDDoc
            // 
            this.txtIDDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDDoc.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtIDDoc.Location = new System.Drawing.Point(12, 105);
            this.txtIDDoc.MaxLength = 20;
            this.txtIDDoc.Multiline = true;
            this.txtIDDoc.Name = "txtIDDoc";
            this.txtIDDoc.Size = new System.Drawing.Size(81, 38);
            this.txtIDDoc.TabIndex = 1;
            this.txtIDDoc.TextChanged += new System.EventHandler(this.txtIDDoc_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Constantia", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(99, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Emri Doc";
            // 
            // txtNameDoc
            // 
            this.txtNameDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNameDoc.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtNameDoc.Location = new System.Drawing.Point(99, 105);
            this.txtNameDoc.MaxLength = 20;
            this.txtNameDoc.Multiline = true;
            this.txtNameDoc.Name = "txtNameDoc";
            this.txtNameDoc.Size = new System.Drawing.Size(713, 38);
            this.txtNameDoc.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Constantia", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(574, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date Update";
            // 
            // txtDateAdded
            // 
            this.txtDateAdded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateAdded.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtDateAdded.Location = new System.Drawing.Point(577, 235);
            this.txtDateAdded.MaxLength = 20;
            this.txtDateAdded.Multiline = true;
            this.txtDateAdded.Name = "txtDateAdded";
            this.txtDateAdded.ReadOnly = true;
            this.txtDateAdded.Size = new System.Drawing.Size(235, 34);
            this.txtDateAdded.TabIndex = 999;
            this.txtDateAdded.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Copperplate Gothic Light", 14F);
            this.txtDescription.Location = new System.Drawing.Point(12, 172);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(800, 38);
            this.txtDescription.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Constantia", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Description";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnUpload.Location = new System.Drawing.Point(12, 265);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(143, 38);
            this.btnUpload.TabIndex = 9;
            this.btnUpload.Text = "Upload Fajl";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // lblUpload
            // 
            this.lblUpload.AutoSize = true;
            this.lblUpload.BackColor = System.Drawing.Color.Transparent;
            this.lblUpload.Font = new System.Drawing.Font("Copperplate Gothic Light", 10F);
            this.lblUpload.ForeColor = System.Drawing.Color.Black;
            this.lblUpload.Location = new System.Drawing.Point(98, 243);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(147, 15);
            this.lblUpload.TabIndex = 1;
            this.lblUpload.Text = "Upload Directory";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Constantia", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 1000;
            this.label2.Text = "Emri Fajlit :";
            // 
            // btnDelFile
            // 
            this.btnDelFile.Font = new System.Drawing.Font("Copperplate Gothic Light", 11.25F);
            this.btnDelFile.Location = new System.Drawing.Point(320, 265);
            this.btnDelFile.Name = "btnDelFile";
            this.btnDelFile.Size = new System.Drawing.Size(147, 38);
            this.btnDelFile.TabIndex = 11;
            this.btnDelFile.Text = "Fshij Fajl";
            this.btnDelFile.UseVisualStyleBackColor = true;
            this.btnDelFile.Click += new System.EventHandler(this.btnDelFile_Click);
            // 
            // frmAttachments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 387);
            this.Controls.Add(this.btnDelFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUpload);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDateAdded);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIDDoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNameDoc);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(837, 425);
            this.Name = "frmAttachments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document Attachments";
            this.Load += new System.EventHandler(this.frmAttachments_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIDDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDateAdded;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnUpload;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelFile;
    }
}