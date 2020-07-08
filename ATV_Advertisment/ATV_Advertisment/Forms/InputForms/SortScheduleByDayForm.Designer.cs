namespace ATV_Advertisment.Forms.InputForms
{
    partial class SortScheduleByDayForm
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
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.dtpOneDate = new System.Windows.Forms.DateTimePicker();
            this.lblShowDate = new System.Windows.Forms.Label();
            this.gbPSS = new System.Windows.Forms.GroupBox();
            this.adgv = new ADGV.AdvancedDataGridView();
            this.gbSearch.SuspendLayout();
            this.gbPSS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnSave);
            this.gbSearch.Controls.Add(this.btnSort);
            this.gbSearch.Controls.Add(this.btnFind);
            this.gbSearch.Controls.Add(this.dtpOneDate);
            this.gbSearch.Controls.Add(this.lblShowDate);
            this.gbSearch.Location = new System.Drawing.Point(11, 11);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(871, 60);
            this.gbSearch.TabIndex = 0;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Tiêu chí";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(771, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 24);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(676, 23);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(89, 24);
            this.btnSort.TabIndex = 3;
            this.btnSort.Text = "Sắp xếp";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(214, 24);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(89, 24);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // dtpOneDate
            // 
            this.dtpOneDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOneDate.Location = new System.Drawing.Point(100, 24);
            this.dtpOneDate.Name = "dtpOneDate";
            this.dtpOneDate.Size = new System.Drawing.Size(95, 27);
            this.dtpOneDate.TabIndex = 1;
            // 
            // lblShowDate
            // 
            this.lblShowDate.AutoSize = true;
            this.lblShowDate.Location = new System.Drawing.Point(5, 25);
            this.lblShowDate.Name = "lblShowDate";
            this.lblShowDate.Size = new System.Drawing.Size(81, 19);
            this.lblShowDate.TabIndex = 0;
            this.lblShowDate.Text = "Ngày chiếu";
            // 
            // gbPSS
            // 
            this.gbPSS.Controls.Add(this.adgv);
            this.gbPSS.Location = new System.Drawing.Point(11, 77);
            this.gbPSS.Name = "gbPSS";
            this.gbPSS.Size = new System.Drawing.Size(871, 384);
            this.gbPSS.TabIndex = 0;
            this.gbPSS.TabStop = false;
            this.gbPSS.Text = "Lich chiếu";
            // 
            // adgv
            // 
            this.adgv.AutoGenerateContextFilters = true;
            this.adgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgv.DateWithTime = false;
            this.adgv.Location = new System.Drawing.Point(9, 24);
            this.adgv.Name = "adgv";
            this.adgv.Size = new System.Drawing.Size(851, 352);
            this.adgv.TabIndex = 0;
            this.adgv.TimeFilter = false;
            this.adgv.SortStringChanged += new System.EventHandler(this.adgv_SortStringChanged);
            this.adgv.FilterStringChanged += new System.EventHandler(this.adgv_FilterStringChanged);
            // 
            // SortScheduleByDayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 465);
            this.Controls.Add(this.gbPSS);
            this.Controls.Add(this.gbSearch);
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "SortScheduleByDayForm";
            this.Text = "Xếp lịch theo ngày";
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbPSS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.GroupBox gbPSS;
        private ADGV.AdvancedDataGridView adgv;
        private System.Windows.Forms.Label lblShowDate;
        private System.Windows.Forms.DateTimePicker dtpOneDate;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnSave;
    }
}