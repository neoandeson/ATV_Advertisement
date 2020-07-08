namespace ATV_Advertisment.Forms.PrintForms
{
    partial class InputSchedulePrintForm
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
            this.gbCriteria = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtSendTo = new System.Windows.Forms.TextBox();
            this.lblSendTo = new System.Windows.Forms.Label();
            this.cboContractCode = new System.Windows.Forms.ComboBox();
            this.lblContract = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbCriteria.SuspendLayout();
            this.gbContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCriteria
            // 
            this.gbCriteria.Controls.Add(this.txtPhone);
            this.gbCriteria.Controls.Add(this.lblPhone);
            this.gbCriteria.Controls.Add(this.txtSendTo);
            this.gbCriteria.Controls.Add(this.lblSendTo);
            this.gbCriteria.Controls.Add(this.cboContractCode);
            this.gbCriteria.Controls.Add(this.lblContract);
            this.gbCriteria.Controls.Add(this.btnPrint);
            this.gbCriteria.Controls.Add(this.cboProduct);
            this.gbCriteria.Controls.Add(this.lblProduct);
            this.gbCriteria.Controls.Add(this.lblMonth);
            this.gbCriteria.Controls.Add(this.dtpMonth);
            this.gbCriteria.Controls.Add(this.lblCustomer);
            this.gbCriteria.Controls.Add(this.cboCustomer);
            this.gbCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCriteria.Location = new System.Drawing.Point(0, 0);
            this.gbCriteria.Name = "gbCriteria";
            this.gbCriteria.Size = new System.Drawing.Size(861, 154);
            this.gbCriteria.TabIndex = 0;
            this.gbCriteria.TabStop = false;
            this.gbCriteria.Text = "Điều kiện";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(535, 99);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhone.MaxLength = 14;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 26);
            this.txtPhone.TabIndex = 6;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(418, 105);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(120, 20);
            this.lblPhone.TabIndex = 0;
            this.lblPhone.Text = "SĐT Người xuất";
            // 
            // txtSendTo
            // 
            this.txtSendTo.Location = new System.Drawing.Point(147, 102);
            this.txtSendTo.Name = "txtSendTo";
            this.txtSendTo.Size = new System.Drawing.Size(251, 26);
            this.txtSendTo.TabIndex = 5;
            // 
            // lblSendTo
            // 
            this.lblSendTo.AutoSize = true;
            this.lblSendTo.Location = new System.Drawing.Point(20, 105);
            this.lblSendTo.Name = "lblSendTo";
            this.lblSendTo.Size = new System.Drawing.Size(90, 20);
            this.lblSendTo.TabIndex = 0;
            this.lblSendTo.Text = "Người nhận";
            // 
            // cboContractCode
            // 
            this.cboContractCode.FormattingEnabled = true;
            this.cboContractCode.Location = new System.Drawing.Point(147, 59);
            this.cboContractCode.Name = "cboContractCode";
            this.cboContractCode.Size = new System.Drawing.Size(138, 28);
            this.cboContractCode.TabIndex = 3;
            this.cboContractCode.SelectedIndexChanged += new System.EventHandler(this.cboContractCode_SelectedIndexChanged);
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = true;
            this.lblContract.Location = new System.Drawing.Point(16, 62);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(79, 20);
            this.lblContract.TabIndex = 0;
            this.lblContract.Text = "Hợp đồng";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(742, 100);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 25);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Xem";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(519, 57);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(294, 28);
            this.cboProduct.TabIndex = 4;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(418, 62);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(82, 20);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "Sản phẩm";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(418, 24);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(54, 20);
            this.lblMonth.TabIndex = 0;
            this.lblMonth.Text = "Tháng";
            // 
            // dtpMonth
            // 
            this.dtpMonth.Location = new System.Drawing.Point(519, 19);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(129, 26);
            this.dtpMonth.TabIndex = 2;
            this.dtpMonth.Validated += new System.EventHandler(this.dtpMonth_Validated);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(16, 26);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(57, 20);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Mã KH";
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(147, 21);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(251, 28);
            this.cboCustomer.TabIndex = 1;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.rptViewer);
            this.gbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbContent.Location = new System.Drawing.Point(0, 154);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(861, 397);
            this.gbContent.TabIndex = 0;
            this.gbContent.TabStop = false;
            this.gbContent.Text = "Nội dung";
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(3, 22);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ServerReport.BearerToken = null;
            this.rptViewer.Size = new System.Drawing.Size(855, 372);
            this.rptViewer.TabIndex = 0;
            // 
            // InputSchedulePrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 551);
            this.Controls.Add(this.gbContent);
            this.Controls.Add(this.gbCriteria);
            this.Name = "InputSchedulePrintForm";
            this.Text = "Lịch đăng ký quảng cáo";
            this.Load += new System.EventHandler(this.InputSchedulePrintForm_Load);
            this.gbCriteria.ResumeLayout(false);
            this.gbCriteria.PerformLayout();
            this.gbContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCriteria;
        private System.Windows.Forms.ComboBox cboContractCode;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.GroupBox gbContent;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
        private System.Windows.Forms.TextBox txtSendTo;
        private System.Windows.Forms.Label lblSendTo;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
    }
}