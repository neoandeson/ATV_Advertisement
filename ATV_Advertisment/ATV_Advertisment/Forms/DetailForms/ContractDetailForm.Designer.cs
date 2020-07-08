namespace ATV_Advertisment.Forms.DetailForms
{
    partial class ContractDetailForm
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
            this.gbCustomerInfo = new System.Windows.Forms.GroupBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblTaxCode = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.gbContractDetail = new System.Windows.Forms.GroupBox();
            this.txtDiscount = new TControls.NumberTextBox(100);
            this.btnViewDtail = new System.Windows.Forms.Button();
            this.btnDeleteDetail = new System.Windows.Forms.Button();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.lblNOProducts = new System.Windows.Forms.Label();
            this.adgv = new ADGV.AdvancedDataGridView();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new TControls.MoneyTextBox();
            this.gbContractInfo = new System.Windows.Forms.GroupBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.txtTotalCost = new TControls.MoneyTextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblContractCode = new System.Windows.Forms.Label();
            this.lblCurrency2 = new System.Windows.Forms.Label();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbCustomerInfo.SuspendLayout();
            this.gbContractDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).BeginInit();
            this.gbContractInfo.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCustomerInfo
            // 
            this.gbCustomerInfo.Controls.Add(this.txtCustomerName);
            this.gbCustomerInfo.Controls.Add(this.lblTaxCode);
            this.gbCustomerInfo.Controls.Add(this.txtCustomerCode);
            this.gbCustomerInfo.Controls.Add(this.lblCustomerCode);
            this.gbCustomerInfo.Location = new System.Drawing.Point(12, 12);
            this.gbCustomerInfo.Name = "gbCustomerInfo";
            this.gbCustomerInfo.Size = new System.Drawing.Size(787, 66);
            this.gbCustomerInfo.TabIndex = 1;
            this.gbCustomerInfo.TabStop = false;
            this.gbCustomerInfo.Text = "Khách hàng";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(359, 28);
            this.txtCustomerName.MaxLength = 10;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(408, 27);
            this.txtCustomerName.TabIndex = 3;
            // 
            // lblTaxCode
            // 
            this.lblTaxCode.AutoSize = true;
            this.lblTaxCode.Location = new System.Drawing.Point(328, 30);
            this.lblTaxCode.Name = "lblTaxCode";
            this.lblTaxCode.Size = new System.Drawing.Size(0, 19);
            this.lblTaxCode.TabIndex = 15;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCustomerCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCustomerCode.Location = new System.Drawing.Point(119, 28);
            this.txtCustomerCode.MaxLength = 20;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(158, 27);
            this.txtCustomerCode.TabIndex = 2;
            this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Location = new System.Drawing.Point(17, 30);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(52, 19);
            this.lblCustomerCode.TabIndex = 0;
            this.lblCustomerCode.Text = "Mã KH";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(635, 73);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(130, 27);
            this.dtpEndDate.TabIndex = 7;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(635, 31);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(130, 27);
            this.dtpStartDate.TabIndex = 6;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(535, 78);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(97, 19);
            this.lblEndDate.TabIndex = 0;
            this.lblEndDate.Text = "Ngày kết thúc";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(535, 36);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(96, 19);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Ngày bắt đầu";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(433, 75);
            this.txtDiscount.MaxLength = 100;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.NumberValue = 0;
            this.txtDiscount.Size = new System.Drawing.Size(50, 27);
            this.txtDiscount.TabIndex = 5;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // gbContractDetail
            // 
            this.gbContractDetail.Controls.Add(this.btnViewDtail);
            this.gbContractDetail.Controls.Add(this.btnDeleteDetail);
            this.gbContractDetail.Controls.Add(this.btnAddDetail);
            this.gbContractDetail.Controls.Add(this.lblNOProducts);
            this.gbContractDetail.Controls.Add(this.adgv);
            this.gbContractDetail.Location = new System.Drawing.Point(12, 251);
            this.gbContractDetail.Name = "gbContractDetail";
            this.gbContractDetail.Size = new System.Drawing.Size(787, 267);
            this.gbContractDetail.TabIndex = 8;
            this.gbContractDetail.TabStop = false;
            this.gbContractDetail.Text = "Nội dung";
            // 
            // btnViewDtail
            // 
            this.btnViewDtail.Location = new System.Drawing.Point(424, 229);
            this.btnViewDtail.Name = "btnViewDtail";
            this.btnViewDtail.Size = new System.Drawing.Size(98, 28);
            this.btnViewDtail.TabIndex = 9;
            this.btnViewDtail.Text = "Xem";
            this.btnViewDtail.UseVisualStyleBackColor = true;
            this.btnViewDtail.Click += new System.EventHandler(this.btnViewDtail_Click);
            // 
            // btnDeleteDetail
            // 
            this.btnDeleteDetail.Location = new System.Drawing.Point(684, 229);
            this.btnDeleteDetail.Name = "btnDeleteDetail";
            this.btnDeleteDetail.Size = new System.Drawing.Size(98, 28);
            this.btnDeleteDetail.TabIndex = 11;
            this.btnDeleteDetail.Text = "Xóa";
            this.btnDeleteDetail.UseVisualStyleBackColor = true;
            this.btnDeleteDetail.Click += new System.EventHandler(this.btnDeleteDetail_Click2);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Location = new System.Drawing.Point(553, 229);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(98, 28);
            this.btnAddDetail.TabIndex = 10;
            this.btnAddDetail.Text = "Thêm";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // lblNOProducts
            // 
            this.lblNOProducts.AutoSize = true;
            this.lblNOProducts.Location = new System.Drawing.Point(690, 21);
            this.lblNOProducts.Name = "lblNOProducts";
            this.lblNOProducts.Size = new System.Drawing.Size(91, 19);
            this.lblNOProducts.TabIndex = 0;
            this.lblNOProducts.Text = "Số sản phẩm";
            // 
            // adgv
            // 
            this.adgv.AutoGenerateContextFilters = true;
            this.adgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgv.DateWithTime = false;
            this.adgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.adgv.Location = new System.Drawing.Point(5, 43);
            this.adgv.MultiSelect = false;
            this.adgv.Name = "adgv";
            this.adgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgv.Size = new System.Drawing.Size(776, 168);
            this.adgv.TabIndex = 0;
            this.adgv.TimeFilter = false;
            this.adgv.SortStringChanged += new System.EventHandler(this.adgv_SortStringChanged);
            this.adgv.FilterStringChanged += new System.EventHandler(this.adgv_FilterStringChanged);
            this.adgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgv_CellClick);
            this.adgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.adgv_DataBindingComplete);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(17, 78);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(73, 19);
            this.lblCost.TabIndex = 0;
            this.lblCost.Text = "Giá trị HĐ";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(119, 75);
            this.txtCost.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.Size = new System.Drawing.Size(160, 27);
            this.txtCost.TabIndex = 17;
            this.txtCost.Text = "0";
            // 
            // gbContractInfo
            // 
            this.gbContractInfo.Controls.Add(this.lblPercent);
            this.gbContractInfo.Controls.Add(this.lblTotalCost);
            this.gbContractInfo.Controls.Add(this.txtTotalCost);
            this.gbContractInfo.Controls.Add(this.txtDiscount);
            this.gbContractInfo.Controls.Add(this.lblDiscount);
            this.gbContractInfo.Controls.Add(this.txtCode);
            this.gbContractInfo.Controls.Add(this.lblContractCode);
            this.gbContractInfo.Controls.Add(this.lblCurrency2);
            this.gbContractInfo.Controls.Add(this.txtCost);
            this.gbContractInfo.Controls.Add(this.dtpStartDate);
            this.gbContractInfo.Controls.Add(this.lblStartDate);
            this.gbContractInfo.Controls.Add(this.lblCost);
            this.gbContractInfo.Controls.Add(this.lblEndDate);
            this.gbContractInfo.Controls.Add(this.dtpEndDate);
            this.gbContractInfo.Location = new System.Drawing.Point(12, 84);
            this.gbContractInfo.Name = "gbContractInfo";
            this.gbContractInfo.Size = new System.Drawing.Size(787, 161);
            this.gbContractInfo.TabIndex = 4;
            this.gbContractInfo.TabStop = false;
            this.gbContractInfo.Text = "Hợp đồng";
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(488, 77);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(20, 19);
            this.lblPercent.TabIndex = 22;
            this.lblPercent.Text = "%";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(17, 120);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(78, 19);
            this.lblTotalCost.TabIndex = 0;
            this.lblTotalCost.Text = "Thành tiền";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(119, 117);
            this.txtTotalCost.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(160, 27);
            this.txtTotalCost.TabIndex = 20;
            this.txtTotalCost.Text = "0";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(356, 78);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(67, 19);
            this.lblDiscount.TabIndex = 18;
            this.lblDiscount.Text = "Giảm giá";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(119, 33);
            this.txtCode.MaxLength = 8;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(96, 27);
            this.txtCode.TabIndex = 0;
            // 
            // lblContractCode
            // 
            this.lblContractCode.AutoSize = true;
            this.lblContractCode.Location = new System.Drawing.Point(17, 36);
            this.lblContractCode.Name = "lblContractCode";
            this.lblContractCode.Size = new System.Drawing.Size(54, 19);
            this.lblContractCode.TabIndex = 0;
            this.lblContractCode.Text = "Mã HĐ";
            // 
            // lblCurrency2
            // 
            this.lblCurrency2.AutoSize = true;
            this.lblCurrency2.Location = new System.Drawing.Point(284, 77);
            this.lblCurrency2.Name = "lblCurrency2";
            this.lblCurrency2.Size = new System.Drawing.Size(38, 19);
            this.lblCurrency2.TabIndex = 0;
            this.lblCurrency2.Text = "VNĐ";
            // 
            // gbControl
            // 
            this.gbControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbControl.Controls.Add(this.btnCancel);
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new System.Drawing.Point(12, 523);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(787, 66);
            this.gbControl.TabIndex = 12;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(151, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 28);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click2);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(23, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 28);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ContractDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 598);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbContractInfo);
            this.Controls.Add(this.gbContractDetail);
            this.Controls.Add(this.gbCustomerInfo);
            this.Name = "ContractDetailForm";
            this.Text = "Thông tin hợp đồng";
            this.gbCustomerInfo.ResumeLayout(false);
            this.gbCustomerInfo.PerformLayout();
            this.gbContractDetail.ResumeLayout(false);
            this.gbContractDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).EndInit();
            this.gbContractInfo.ResumeLayout(false);
            this.gbContractInfo.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCustomerInfo;
        private System.Windows.Forms.GroupBox gbContractDetail;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblTaxCode;
        private System.Windows.Forms.Label lblCost;
        private TControls.MoneyTextBox txtCost;
        private System.Windows.Forms.GroupBox gbContractInfo;
        private System.Windows.Forms.Label lblCurrency2;
        private ADGV.AdvancedDataGridView adgv;
        private System.Windows.Forms.Label lblNOProducts;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnViewDtail;
        private System.Windows.Forms.Button btnDeleteDetail;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblContractCode;
        private System.Windows.Forms.Label lblTotalCost;
        private TControls.MoneyTextBox txtTotalCost;
        private TControls.NumberTextBox txtDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPercent;
        //this.txtDiscount = new TControls.NumberTextBox(100);
    }
}