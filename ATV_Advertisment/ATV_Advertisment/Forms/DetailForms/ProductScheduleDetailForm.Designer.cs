using TControls;

namespace ATV_Advertisment.Forms.DetailForms
{
    partial class ProductScheduleDetailForm
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
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.ckbPosition = new System.Windows.Forms.CheckBox();
            this.cboPosition = new System.Windows.Forms.ComboBox();
            this.txtSumCost = new TControls.MoneyTextBox();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.mpShowDate = new System.Windows.Forms.MonthCalendar();
            this.lblSecond = new System.Windows.Forms.Label();
            this.txtTimeSlotLength = new System.Windows.Forms.TextBox();
            this.cboTimeSlot = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtCost = new TControls.MoneyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTimeSlot = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblShowDate = new System.Windows.Forms.Label();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbDetail.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.ckbPosition);
            this.gbDetail.Controls.Add(this.cboPosition);
            this.gbDetail.Controls.Add(this.txtSumCost);
            this.gbDetail.Controls.Add(this.lblTotalCost);
            this.gbDetail.Controls.Add(this.mpShowDate);
            this.gbDetail.Controls.Add(this.lblSecond);
            this.gbDetail.Controls.Add(this.txtTimeSlotLength);
            this.gbDetail.Controls.Add(this.cboTimeSlot);
            this.gbDetail.Controls.Add(this.txtQuantity);
            this.gbDetail.Controls.Add(this.txtCost);
            this.gbDetail.Controls.Add(this.label5);
            this.gbDetail.Controls.Add(this.lblTimeSlot);
            this.gbDetail.Controls.Add(this.lbl);
            this.gbDetail.Controls.Add(this.label2);
            this.gbDetail.Controls.Add(this.lblShowDate);
            this.gbDetail.Location = new System.Drawing.Point(12, 12);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(655, 435);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Thông tin lịch";
            // 
            // ckbPosition
            // 
            this.ckbPosition.AutoSize = true;
            this.ckbPosition.Location = new System.Drawing.Point(378, 124);
            this.ckbPosition.Name = "ckbPosition";
            this.ckbPosition.Size = new System.Drawing.Size(110, 23);
            this.ckbPosition.TabIndex = 3;
            this.ckbPosition.Text = "Vị trí ưu tiên";
            this.ckbPosition.UseVisualStyleBackColor = true;
            this.ckbPosition.CheckedChanged += new System.EventHandler(this.ckbPosition_CheckedChanged);
            // 
            // cboPosition
            // 
            this.cboPosition.Enabled = false;
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.Location = new System.Drawing.Point(494, 120);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(64, 27);
            this.cboPosition.TabIndex = 4;
            // 
            // txtSumCost
            // 
            this.txtSumCost.Location = new System.Drawing.Point(138, 166);
            this.txtSumCost.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSumCost.Name = "txtSumCost";
            this.txtSumCost.ReadOnly = true;
            this.txtSumCost.Size = new System.Drawing.Size(212, 27);
            this.txtSumCost.TabIndex = 0;
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(19, 169);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(69, 19);
            this.lblTotalCost.TabIndex = 0;
            this.lblTotalCost.Text = "Tổng tiền";
            // 
            // mpShowDate
            // 
            this.mpShowDate.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.mpShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mpShowDate.Location = new System.Drawing.Point(21, 270);
            this.mpShowDate.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.mpShowDate.MaxSelectionCount = 120;
            this.mpShowDate.Name = "mpShowDate";
            this.mpShowDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mpShowDate.TabIndex = 5;
            this.mpShowDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mpShowDate_MouseDown);
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(532, 83);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(26, 19);
            this.lblSecond.TabIndex = 0;
            this.lblSecond.Text = "(s)";
            // 
            // txtTimeSlotLength
            // 
            this.txtTimeSlotLength.Location = new System.Drawing.Point(463, 80);
            this.txtTimeSlotLength.Name = "txtTimeSlotLength";
            this.txtTimeSlotLength.ReadOnly = true;
            this.txtTimeSlotLength.Size = new System.Drawing.Size(64, 27);
            this.txtTimeSlotLength.TabIndex = 0;
            // 
            // cboTimeSlot
            // 
            this.cboTimeSlot.FormattingEnabled = true;
            this.cboTimeSlot.Location = new System.Drawing.Point(138, 34);
            this.cboTimeSlot.Name = "cboTimeSlot";
            this.cboTimeSlot.Size = new System.Drawing.Size(390, 27);
            this.cboTimeSlot.TabIndex = 1;
            this.cboTimeSlot.SelectedIndexChanged += new System.EventHandler(this.cboTimeSlot_SelectedIndexChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(138, 77);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(64, 27);
            this.txtQuantity.TabIndex = 0;
            this.txtQuantity.Text = "1";
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(138, 122);
            this.txtCost.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.Size = new System.Drawing.Size(212, 27);
            this.txtCost.TabIndex = 2;
            this.txtCost.TextChanged += new System.EventHandler(this.txtCost_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thời lượng";
            // 
            // lblTimeSlot
            // 
            this.lblTimeSlot.AutoSize = true;
            this.lblTimeSlot.Location = new System.Drawing.Point(19, 34);
            this.lblTimeSlot.Name = "lblTimeSlot";
            this.lblTimeSlot.Size = new System.Drawing.Size(108, 19);
            this.lblTimeSlot.TabIndex = 0;
            this.lblTimeSlot.Text = "Thời điểm phát";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(19, 124);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(117, 19);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Giá tiền 1 đơn vị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số lượng";
            // 
            // lblShowDate
            // 
            this.lblShowDate.AutoSize = true;
            this.lblShowDate.Location = new System.Drawing.Point(18, 242);
            this.lblShowDate.Name = "lblShowDate";
            this.lblShowDate.Size = new System.Drawing.Size(81, 19);
            this.lblShowDate.TabIndex = 0;
            this.lblShowDate.Text = "Ngày chiếu";
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new System.Drawing.Point(12, 453);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(656, 59);
            this.gbControl.TabIndex = 0;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ProductScheduleDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 523);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbDetail);
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "ProductScheduleDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết lịch";
            this.Load += new System.EventHandler(this.ProductScheduleDetailForm_Load);
            this.Shown += new System.EventHandler(this.ProductScheduleDetailForm_Shown);
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTimeSlot;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblShowDate;
        private TControls.MoneyTextBox txtCost;
        private System.Windows.Forms.ComboBox cboTimeSlot;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTimeSlotLength;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.MonthCalendar mpShowDate;
        private TControls.MoneyTextBox txtSumCost;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.ComboBox cboPosition;
        private System.Windows.Forms.CheckBox ckbPosition;
    }
}