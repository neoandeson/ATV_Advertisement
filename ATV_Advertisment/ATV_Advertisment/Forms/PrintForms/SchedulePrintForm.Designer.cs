namespace ATV_Advertisment.Forms.PrintForms
{
    partial class SchedulePrintForm
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
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFromPassword = new System.Windows.Forms.TextBox();
            this.btnSaveEmailInfo = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.txtToEmail = new System.Windows.Forms.TextBox();
            this.txtFromEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbControl.SuspendLayout();
            this.gbContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.label3);
            this.gbControl.Controls.Add(this.txtFromPassword);
            this.gbControl.Controls.Add(this.btnSaveEmailInfo);
            this.gbControl.Controls.Add(this.btnSendEmail);
            this.gbControl.Controls.Add(this.txtToEmail);
            this.gbControl.Controls.Add(this.txtFromEmail);
            this.gbControl.Controls.Add(this.label2);
            this.gbControl.Controls.Add(this.label1);
            this.gbControl.Controls.Add(this.lblDay);
            this.gbControl.Controls.Add(this.dtpDate);
            this.gbControl.Controls.Add(this.btnPrint);
            this.gbControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbControl.Location = new System.Drawing.Point(0, 0);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(870, 122);
            this.gbControl.TabIndex = 0;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password";
            // 
            // txtFromPassword
            // 
            this.txtFromPassword.Location = new System.Drawing.Point(453, 53);
            this.txtFromPassword.MaxLength = 100;
            this.txtFromPassword.Name = "txtFromPassword";
            this.txtFromPassword.PasswordChar = '*';
            this.txtFromPassword.Size = new System.Drawing.Size(249, 26);
            this.txtFromPassword.TabIndex = 3;
            // 
            // btnSaveEmailInfo
            // 
            this.btnSaveEmailInfo.Location = new System.Drawing.Point(22, 53);
            this.btnSaveEmailInfo.Name = "btnSaveEmailInfo";
            this.btnSaveEmailInfo.Size = new System.Drawing.Size(160, 25);
            this.btnSaveEmailInfo.TabIndex = 6;
            this.btnSaveEmailInfo.Text = "Lưu thông tin email";
            this.btnSaveEmailInfo.UseVisualStyleBackColor = true;
            this.btnSaveEmailInfo.Click += new System.EventHandler(this.btnSaveEmailInfo_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(196, 53);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(100, 25);
            this.btnSendEmail.TabIndex = 7;
            this.btnSendEmail.Text = "Gửi Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // txtToEmail
            // 
            this.txtToEmail.Location = new System.Drawing.Point(453, 88);
            this.txtToEmail.MaxLength = 100;
            this.txtToEmail.Name = "txtToEmail";
            this.txtToEmail.Size = new System.Drawing.Size(393, 26);
            this.txtToEmail.TabIndex = 4;
            // 
            // txtFromEmail
            // 
            this.txtFromEmail.Location = new System.Drawing.Point(453, 19);
            this.txtFromEmail.MaxLength = 100;
            this.txtFromEmail.Name = "txtFromEmail";
            this.txtFromEmail.Size = new System.Drawing.Size(393, 26);
            this.txtFromEmail.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Email nhận";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email gửi";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(18, 25);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(45, 20);
            this.lblDay.TabIndex = 0;
            this.lblDay.Text = "Ngày";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(79, 20);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(102, 26);
            this.dtpDate.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(196, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 25);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Xem";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.rptViewer);
            this.gbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gbContent.Location = new System.Drawing.Point(0, 122);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(870, 461);
            this.gbContent.TabIndex = 1;
            this.gbContent.TabStop = false;
            this.gbContent.Text = "Nội dung";
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(3, 22);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ServerReport.BearerToken = null;
            this.rptViewer.Size = new System.Drawing.Size(864, 436);
            this.rptViewer.TabIndex = 0;
            // 
            // SchedulePrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 583);
            this.Controls.Add(this.gbContent);
            this.Controls.Add(this.gbControl);
            this.Name = "SchedulePrintForm";
            this.Text = "In lịch phát sóng";
            this.Load += new System.EventHandler(this.SchedulePrintForm_Load);
            this.gbControl.ResumeLayout(false);
            this.gbControl.PerformLayout();
            this.gbContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.GroupBox gbContent;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
        private System.Windows.Forms.TextBox txtToEmail;
        private System.Windows.Forms.TextBox txtFromEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnSaveEmailInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFromPassword;
    }
}