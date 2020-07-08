namespace ATV_Advertisment.Forms.PrintForms
{
    partial class PricingPrintForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDirectorName = new System.Windows.Forms.Label();
            this.txtDirectorName = new System.Windows.Forms.TextBox();
            this.dtpApplyDate = new System.Windows.Forms.DateTimePicker();
            this.lblApplyDate = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbCriteria.SuspendLayout();
            this.gbContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCriteria
            // 
            this.gbCriteria.Controls.Add(this.btnSave);
            this.gbCriteria.Controls.Add(this.lblDirectorName);
            this.gbCriteria.Controls.Add(this.txtDirectorName);
            this.gbCriteria.Controls.Add(this.dtpApplyDate);
            this.gbCriteria.Controls.Add(this.lblApplyDate);
            this.gbCriteria.Controls.Add(this.txtYear);
            this.gbCriteria.Controls.Add(this.label1);
            this.gbCriteria.Controls.Add(this.btnPrint);
            this.gbCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCriteria.Location = new System.Drawing.Point(0, 0);
            this.gbCriteria.Name = "gbCriteria";
            this.gbCriteria.Size = new System.Drawing.Size(800, 100);
            this.gbCriteria.TabIndex = 0;
            this.gbCriteria.TabStop = false;
            this.gbCriteria.Text = "Cấu Hình";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(582, 53);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDirectorName
            // 
            this.lblDirectorName.AutoSize = true;
            this.lblDirectorName.Location = new System.Drawing.Point(226, 19);
            this.lblDirectorName.Name = "lblDirectorName";
            this.lblDirectorName.Size = new System.Drawing.Size(77, 20);
            this.lblDirectorName.TabIndex = 6;
            this.lblDirectorName.Text = "Giám đốc";
            // 
            // txtDirectorName
            // 
            this.txtDirectorName.Location = new System.Drawing.Point(309, 16);
            this.txtDirectorName.Name = "txtDirectorName";
            this.txtDirectorName.Size = new System.Drawing.Size(269, 26);
            this.txtDirectorName.TabIndex = 5;
            // 
            // dtpApplyDate
            // 
            this.dtpApplyDate.Location = new System.Drawing.Point(126, 53);
            this.dtpApplyDate.Name = "dtpApplyDate";
            this.dtpApplyDate.Size = new System.Drawing.Size(200, 26);
            this.dtpApplyDate.TabIndex = 4;
            // 
            // lblApplyDate
            // 
            this.lblApplyDate.AutoSize = true;
            this.lblApplyDate.Location = new System.Drawing.Point(12, 55);
            this.lblApplyDate.Name = "lblApplyDate";
            this.lblApplyDate.Size = new System.Drawing.Size(107, 20);
            this.lblApplyDate.TabIndex = 3;
            this.lblApplyDate.Text = "Ngày áp dụng";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(60, 19);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(100, 26);
            this.txtYear.TabIndex = 1;
            this.txtYear.Text = "2019";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Năm";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(688, 53);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 25);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Xem";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.rptViewer);
            this.gbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbContent.Location = new System.Drawing.Point(0, 100);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(800, 350);
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
            this.rptViewer.Size = new System.Drawing.Size(794, 325);
            this.rptViewer.TabIndex = 0;
            // 
            // PricingPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbContent);
            this.Controls.Add(this.gbCriteria);
            this.Name = "PricingPrintForm";
            this.Text = "Bảng giá quảng cáo";
            this.Load += new System.EventHandler(this.PricingPrintForm_Load);
            this.gbCriteria.ResumeLayout(false);
            this.gbCriteria.PerformLayout();
            this.gbContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCriteria;
        private System.Windows.Forms.GroupBox gbContent;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
        private System.Windows.Forms.Label lblApplyDate;
        private System.Windows.Forms.DateTimePicker dtpApplyDate;
        private System.Windows.Forms.Label lblDirectorName;
        private System.Windows.Forms.TextBox txtDirectorName;
        private System.Windows.Forms.Button btnSave;
    }
}