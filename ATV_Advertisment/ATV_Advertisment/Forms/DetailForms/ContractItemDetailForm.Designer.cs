namespace ATV_Advertisment.Forms.DetailForms
{
    partial class ContractItemDetailForm
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
            this.gbContractDetail = new System.Windows.Forms.GroupBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.cboShowType = new System.Windows.Forms.ComboBox();
            this.lblShowType = new System.Windows.Forms.Label();
            this.txtNumberOfShow = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtTotalCost = new TControls.MoneyTextBox();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.cboDuration = new System.Windows.Forms.ComboBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbRegisterSchedule = new System.Windows.Forms.GroupBox();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDeleteSchedule = new System.Windows.Forms.Button();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.adgv = new ADGV.AdvancedDataGridView();
            this.gbContractDetail.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.gbRegisterSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).BeginInit();
            this.SuspendLayout();
            // 
            // gbContractDetail
            // 
            this.gbContractDetail.Controls.Add(this.txtFileName);
            this.gbContractDetail.Controls.Add(this.labelFileName);
            this.gbContractDetail.Controls.Add(this.cboShowType);
            this.gbContractDetail.Controls.Add(this.lblShowType);
            this.gbContractDetail.Controls.Add(this.txtNumberOfShow);
            this.gbContractDetail.Controls.Add(this.lblQuantity);
            this.gbContractDetail.Controls.Add(this.txtTotalCost);
            this.gbContractDetail.Controls.Add(this.lblTotalCost);
            this.gbContractDetail.Controls.Add(this.lblDuration);
            this.gbContractDetail.Controls.Add(this.cboDuration);
            this.gbContractDetail.Controls.Add(this.lblProductName);
            this.gbContractDetail.Controls.Add(this.txtProductName);
            this.gbContractDetail.Location = new System.Drawing.Point(11, 11);
            this.gbContractDetail.Name = "gbContractDetail";
            this.gbContractDetail.Size = new System.Drawing.Size(1132, 111);
            this.gbContractDetail.TabIndex = 0;
            this.gbContractDetail.TabStop = false;
            this.gbContractDetail.Text = "Thông tin sản phẩm";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(130, 66);
            this.txtFileName.MaxLength = 200;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(307, 27);
            this.txtFileName.TabIndex = 3;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(18, 68);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(88, 19);
            this.labelFileName.TabIndex = 0;
            this.labelFileName.Text = "Mô tả Video";
            // 
            // cboShowType
            // 
            this.cboShowType.FormattingEnabled = true;
            this.cboShowType.Location = new System.Drawing.Point(590, 29);
            this.cboShowType.Name = "cboShowType";
            this.cboShowType.Size = new System.Drawing.Size(213, 27);
            this.cboShowType.TabIndex = 2;
            this.cboShowType.SelectedIndexChanged += new System.EventHandler(this.cboShowType_SelectedIndexChanged);
            // 
            // lblShowType
            // 
            this.lblShowType.AutoSize = true;
            this.lblShowType.Location = new System.Drawing.Point(490, 32);
            this.lblShowType.Name = "lblShowType";
            this.lblShowType.Size = new System.Drawing.Size(69, 19);
            this.lblShowType.TabIndex = 0;
            this.lblShowType.Text = "Loại phát";
            // 
            // txtNumberOfShow
            // 
            this.txtNumberOfShow.Location = new System.Drawing.Point(938, 68);
            this.txtNumberOfShow.Name = "txtNumberOfShow";
            this.txtNumberOfShow.ReadOnly = true;
            this.txtNumberOfShow.Size = new System.Drawing.Size(41, 27);
            this.txtNumberOfShow.TabIndex = 0;
            this.txtNumberOfShow.Text = "0";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(826, 71);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(100, 19);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Số lượng phát";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(938, 32);
            this.txtTotalCost.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(178, 27);
            this.txtTotalCost.TabIndex = 0;
            this.txtTotalCost.Text = "0";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(826, 32);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(69, 19);
            this.lblTotalCost.TabIndex = 0;
            this.lblTotalCost.Text = "Tổng tiền";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(490, 68);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(90, 19);
            this.lblDuration.TabIndex = 0;
            this.lblDuration.Text = "Độ dài video";
            // 
            // cboDuration
            // 
            this.cboDuration.FormattingEnabled = true;
            this.cboDuration.Location = new System.Drawing.Point(590, 62);
            this.cboDuration.Name = "cboDuration";
            this.cboDuration.Size = new System.Drawing.Size(72, 27);
            this.cboDuration.TabIndex = 4;
            this.cboDuration.SelectedIndexChanged += new System.EventHandler(this.cboDuration_SelectedIndexChanged);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(15, 32);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(99, 19);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Tên sản phẩm";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(130, 29);
            this.txtProductName.MaxLength = 80;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(307, 27);
            this.txtProductName.TabIndex = 1;
            // 
            // gbControl
            // 
            this.gbControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new System.Drawing.Point(11, 621);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(1132, 64);
            this.gbControl.TabIndex = 0;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(18, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbRegisterSchedule
            // 
            this.gbRegisterSchedule.Controls.Add(this.btnViewDetail);
            this.gbRegisterSchedule.Controls.Add(this.button1);
            this.gbRegisterSchedule.Controls.Add(this.btnDeleteSchedule);
            this.gbRegisterSchedule.Controls.Add(this.btnAddSchedule);
            this.gbRegisterSchedule.Controls.Add(this.adgv);
            this.gbRegisterSchedule.Location = new System.Drawing.Point(12, 128);
            this.gbRegisterSchedule.Name = "gbRegisterSchedule";
            this.gbRegisterSchedule.Size = new System.Drawing.Size(1131, 487);
            this.gbRegisterSchedule.TabIndex = 0;
            this.gbRegisterSchedule.TabStop = false;
            this.gbRegisterSchedule.Text = "Lịch đăng ký";
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(888, 24);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(98, 28);
            this.btnViewDetail.TabIndex = 5;
            this.btnViewDetail.Text = "Xem";
            this.btnViewDetail.UseVisualStyleBackColor = true;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(753, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Xóa lịch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btnDeleteSchedule_Click);
            // 
            // btnDeleteSchedule
            // 
            this.btnDeleteSchedule.Location = new System.Drawing.Point(645, 24);
            this.btnDeleteSchedule.Name = "btnDeleteSchedule";
            this.btnDeleteSchedule.Size = new System.Drawing.Size(98, 28);
            this.btnDeleteSchedule.TabIndex = 0;
            this.btnDeleteSchedule.Text = "Xóa lịch";
            this.btnDeleteSchedule.UseVisualStyleBackColor = true;
            this.btnDeleteSchedule.Visible = false;
            this.btnDeleteSchedule.Click += new System.EventHandler(this.btnDeleteSchedule_Click);
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Location = new System.Drawing.Point(1017, 24);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(98, 28);
            this.btnAddSchedule.TabIndex = 6;
            this.btnAddSchedule.Text = "Thêm lịch";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // adgv
            // 
            this.adgv.AutoGenerateContextFilters = true;
            this.adgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgv.DateWithTime = false;
            this.adgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.adgv.Location = new System.Drawing.Point(18, 58);
            this.adgv.MultiSelect = false;
            this.adgv.Name = "adgv";
            this.adgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgv.Size = new System.Drawing.Size(1097, 424);
            this.adgv.TabIndex = 0;
            this.adgv.TimeFilter = false;
            this.adgv.SortStringChanged += new System.EventHandler(this.adgv_SortStringChanged);
            this.adgv.FilterStringChanged += new System.EventHandler(this.adgv_FilterStringChanged);
            this.adgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgv_CellClick);
            this.adgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.adgv_DataBindingComplete);
            this.adgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.adgv_RowPostPaint);
            // 
            // ContractItemDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 696);
            this.Controls.Add(this.gbRegisterSchedule);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbContractDetail);
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "ContractItemDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết sản phẩm";
            this.gbContractDetail.ResumeLayout(false);
            this.gbContractDetail.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.gbRegisterSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbContractDetail;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.ComboBox cboDuration;
        private System.Windows.Forms.GroupBox gbRegisterSchedule;
        private ADGV.AdvancedDataGridView adgv;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnDeleteSchedule;
        private System.Windows.Forms.Button btnSave;
        private TControls.MoneyTextBox txtTotalCost;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtNumberOfShow;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.ComboBox cboShowType;
        private System.Windows.Forms.Label lblShowType;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button button1;
    }
}