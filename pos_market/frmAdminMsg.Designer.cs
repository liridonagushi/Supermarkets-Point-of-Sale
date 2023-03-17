namespace Supermarkets
{
    partial class frmAdminMsg
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNext = new System.Windows.Forms.Label();
            this.lblPrevious = new System.Windows.Forms.Label();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalPages = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearMessages = new System.Windows.Forms.Button();
            this.dgw = new System.Windows.Forms.ListView();
            this.Sender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Receiver = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Copperplate Gothic Light", 9F);
            this.btnSend.Location = new System.Drawing.Point(550, 37);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(121, 39);
            this.btnSend.TabIndex = 30;
            this.btnSend.Text = "Dergo";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Courier New", 12F);
            this.txtUser.FormattingEnabled = true;
            this.txtUser.Location = new System.Drawing.Point(28, 43);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(194, 26);
            this.txtUser.TabIndex = 31;
            this.txtUser.SelectedIndexChanged += new System.EventHandler(this.txtUser_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(25, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Stafi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(254, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Mesazhi";
            // 
            // lblNext
            // 
            this.lblNext.AutoSize = true;
            this.lblNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblNext.Location = new System.Drawing.Point(408, 8);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(24, 29);
            this.lblNext.TabIndex = 1;
            this.lblNext.Text = "►";
            this.lblNext.Click += new System.EventHandler(this.lblNext_Click);
            // 
            // lblPrevious
            // 
            this.lblPrevious.AutoSize = true;
            this.lblPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblPrevious.Location = new System.Drawing.Point(307, 8);
            this.lblPrevious.Name = "lblPrevious";
            this.lblPrevious.Size = new System.Drawing.Size(24, 29);
            this.lblPrevious.TabIndex = 45;
            this.lblPrevious.Text = "◄";
            this.lblPrevious.Click += new System.EventHandler(this.lblPrevious_Click);
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblPageNumber.Font = new System.Drawing.Font("FZLanTingHeiS-UL-GB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPageNumber.Location = new System.Drawing.Point(383, 12);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(19, 18);
            this.lblPageNumber.TabIndex = 0;
            this.lblPageNumber.Text = "1";
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Location = new System.Drawing.Point(257, 37);
            this.txtMessage.MaxLength = 70;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(266, 35);
            this.txtMessage.TabIndex = 46;
            this.txtMessage.Text = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.txtMessage);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtUser);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(754, 89);
            this.panel3.TabIndex = 63;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lblTotalPages);
            this.panel1.Controls.Add(this.lblPrevious);
            this.panel1.Controls.Add(this.lblPageNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClearMessages);
            this.panel1.Controls.Add(this.lblNext);
            this.panel1.Location = new System.Drawing.Point(12, 451);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 44);
            this.panel1.TabIndex = 64;
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblTotalPages.Font = new System.Drawing.Font("FZLanTingHeiS-UL-GB", 12F);
            this.lblTotalPages.Location = new System.Drawing.Point(340, 12);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(18, 18);
            this.lblTotalPages.TabIndex = 67;
            this.lblTotalPages.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("FZLanTingHeiS-UL-GB", 12F);
            this.label1.Location = new System.Drawing.Point(364, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 18);
            this.label1.TabIndex = 66;
            this.label1.Text = "/";
            // 
            // btnClearMessages
            // 
            this.btnClearMessages.Font = new System.Drawing.Font("Copperplate Gothic Light", 9F);
            this.btnClearMessages.Location = new System.Drawing.Point(578, 6);
            this.btnClearMessages.Name = "btnClearMessages";
            this.btnClearMessages.Size = new System.Drawing.Size(164, 32);
            this.btnClearMessages.TabIndex = 47;
            this.btnClearMessages.Text = "Fshij Mesazhet";
            this.btnClearMessages.UseVisualStyleBackColor = true;
            this.btnClearMessages.Click += new System.EventHandler(this.btnClearMessages_Click);
            // 
            // dgw
            // 
            this.dgw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sender,
            this.Receiver,
            this.Message});
            this.dgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgw.FullRowSelect = true;
            this.dgw.GridLines = true;
            this.dgw.Location = new System.Drawing.Point(12, 107);
            this.dgw.Name = "dgw";
            this.dgw.Size = new System.Drawing.Size(754, 338);
            this.dgw.TabIndex = 65;
            this.dgw.UseCompatibleStateImageBehavior = false;
            this.dgw.View = System.Windows.Forms.View.Details;
            // 
            // Sender
            // 
            this.Sender.Text = "Derguesi";
            this.Sender.Width = 180;
            // 
            // Receiver
            // 
            this.Receiver.Text = "Pranuesi";
            this.Receiver.Width = 180;
            // 
            // Message
            // 
            this.Message.Text = "Mesazhi";
            this.Message.Width = 388;
            // 
            // frmAdminMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(775, 501);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmAdminMsg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdminMsg";
            this.Load += new System.EventHandler(this.frmAdminMsg_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblPrevious;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView dgw;
        private System.Windows.Forms.ColumnHeader Sender;
        private System.Windows.Forms.ColumnHeader Receiver;
        private System.Windows.Forms.ColumnHeader Message;
        private System.Windows.Forms.Button btnClearMessages;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.Label label1;
    }
}