using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class ContractItemDetailForm : CommonForm
    {
        public ContractItem model { get; set; }
        public ProductScheduleShow productScheduleShow = null;
        public int productScheduleShowId = 0;
        private ContractItemService _contractDetailService = null;
        private ProductScheduleShowService _productScheduleShowService = null;
        private DurationService _durationService = null;
        private ShowTypeService _showTypeService = null;
        private bool IsExisted = false;
        private bool IsLoadCompleted = false;

        public ContractItemDetailForm(ContractItem inputModel)
        {
            InitializeComponent();
            this.model = inputModel;
            gbRegisterSchedule.Visible = false;
            if (model != null)
            {
                if (model.Id != 0)
                {
                    gbRegisterSchedule.Visible = true;
                }
            }

            LoadDurationComboBox();
            LoadCboShowType();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (model != null)
                {
                    if (model.Id != 0)
                    {
                        //Existed
                        _contractDetailService = new ContractItemService();
                        model = _contractDetailService.GetById(model.Id);
                        if (model != null)
                        {
                            IsExisted = true;

                            txtProductName.Text = model.ProductName;
                            txtTotalCost.Text = Utilities.DoubleMoneyToText(model.TotalCost);
                            txtNumberOfShow.Text = model.NumberOfShow.ToString();
                            txtFileName.Text = model.FileName.ToString();
                            cboDuration.SelectedValue = model.DurationSecond;
                            cboShowType.SelectedValue = model.ShowTypeId;

                            LoadDGV();
                        }
                    }
                }
                else
                {
                    gbRegisterSchedule.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contractDetailService = null;
                IsLoadCompleted = true;
            }
        }

        public void LoadDurationComboBox()
        {
            try
            {
                _durationService = new DurationService();
                Utilities.LoadComboBoxOptions(cboDuration, _durationService.Getoptions());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _durationService = null;
            }
        }

        public void LoadCboShowType()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _showTypeService = new ShowTypeService();

                Utilities.LoadComboBoxOptions(cboShowType, _showTypeService.Getoptions());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _showTypeService = null;
                Cursor.Current = Cursors.Default;
            }
        }

        #region AdvanceDataGridView
        private BindingSource bs = null;

        private void LoadDGV()
        {
            try
            {
                if (model.Id != 0)
                {
                    var productScheduleShows = new ProductScheduleShowService().GetAllVMForList(model.Id);

                    SortableBindingList<ProductScheduleShowViewModel> sbl = new SortableBindingList<ProductScheduleShowViewModel>(productScheduleShows);
                    bs = new BindingSource();
                    bs.DataSource = sbl;
                    adgv.DataSource = bs;
                    adgv.Columns["Id"].Visible = false;
                    adgv.Columns["ContractDetailId"].Visible = false;
                    adgv.Columns["ProductName"].Visible = false;
                    adgv.Columns["ShowTime"].Visible = false;
                    adgv.Columns["Discount"].Visible = false;
                    adgv.Columns["TotalCost"].Visible = false;

                    adgv.Columns["ShowDate"].HeaderText = ADGVText.ShowDate;
                    adgv.Columns["ShowDate"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                    adgv.Columns["TimeSlot"].HeaderText = ADGVText.TimeSlot;
                    adgv.Columns["TimeSlot"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    adgv.Columns["Quantity"].HeaderText = ADGVText.NumberOfShow;
                    adgv.Columns["Quantity"].Width = ControlsAttribute.GV_WIDTH_SEEM;
                    adgv.Columns["TimeSlotLength"].HeaderText = ADGVText.Duration;
                    adgv.Columns["TimeSlotLength"].Width = ControlsAttribute.GV_WIDTH_SEEM;
                    adgv.Columns["Cost"].HeaderText = ADGVText.Cost;
                    adgv.Columns["Cost"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                    adgv.Columns["Discount"].HeaderText = ADGVText.Discount;
                    adgv.Columns["Discount"].Width = ControlsAttribute.GV_WIDTH_SEEM;
                    adgv.Columns["TotalCost"].HeaderText = ADGVText.TotalCost;
                    adgv.Columns["TotalCost"].Width = ControlsAttribute.GV_WIDTH_MEDIUM;

                    productScheduleShow = new ProductScheduleShow()
                    {
                        ContractDetailId = model.Id,
                        TimeSlotLength = model.DurationSecond,
                        ProductName = txtFileName.Text//model.ProductName
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        private void adgv_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = adgv.SortString;
        }

        private void adgv_FilterStringChanged(object sender, EventArgs e)
        {
            string tmp = adgv.FilterString;
            string pattern = @"([a-zA-Z0-9 ]+)";
            MatchCollection matches = Regex.Matches(tmp, pattern);
            try
            {
                bs.Filter = adgv.FilterString;
            }
            catch (Exception ex)
            {
                Utilities.ShowError(ex.Message);
            }
        }

        private void adgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (adgv.SelectedRows.Count > 0)
            {
                var selectedRow = adgv.SelectedRows[0];

                //Prepare model
                if (selectedRow.Cells[0].Value.ToString() != "0" && !String.IsNullOrWhiteSpace(selectedRow.Cells[0].Value.ToString()))
                {
                    productScheduleShowId = int.Parse(selectedRow.Cells[0].Value.ToString());
                    productScheduleShow = new ProductScheduleShow()
                    {
                        Id = (int)selectedRow.Cells[0].Value,
                        ContractDetailId = model.Id,
                        TimeSlotLength = (int)cboDuration.SelectedValue,
                        ProductName = txtFileName.Text,
                        ShowTypeId = (int)cboShowType.SelectedValue
                    };
                }
                else
                {
                    productScheduleShowId = 0;
                }
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ContractItem result = null;
                int editResult = CRUDStatusCode.ERROR;

                _contractDetailService = new ContractItemService();

                if (model != null)
                {
                    if (model.Id == 0)
                    {
                        //Add
                        model.ProductName = txtProductName.Text;
                        model.TotalCost = Utilities.GetDoubleFromTextBox(txtTotalCost);
                        model.DurationSecond = (int)cboDuration.SelectedValue;
                        model.FileName = txtFileName.Text;
                        model.NumberOfShow = Utilities.GetIntFromTextBox(txtNumberOfShow);
                        model.ShowTypeId = (int)cboShowType.SelectedValue;

                        result = _contractDetailService.CreateContractDetail(model);
                        if (result != null)
                        {
                            if (result.Id == 0)
                            {
                                Utilities.ShowMessage(CommonMessage.EXISTED_PRODUCT_IN_CONTRACT);
                            } else
                            {
                                model = result;
                                gbRegisterSchedule.Visible = true;
                                productScheduleShow = new ProductScheduleShow()
                                {
                                    ContractDetailId = model.Id,
                                    TimeSlotLength = (int)cboDuration.SelectedValue,
                                    ProductName = txtFileName.Text
                                };
                                Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                                Logging.LogBusiness(string.Format("{0} {1} {2}",
                                Common.Session.GetUserName(),
                                Common.Constants.LogAction.Create, "sản phẩm thuộc hợp đồng mã " + model.ContractCode),
                                Common.Constants.BusinessLogType.Create);
                            }
                        }
                    }
                    else
                    {
                        //Edit
                        model.ProductName = txtProductName.Text;

                        model.TotalCost = Utilities.GetDoubleFromTextBox(txtTotalCost);
                        model.NumberOfShow = Utilities.GetIntFromTextBox(txtNumberOfShow);
                        model.FileName = txtFileName.Text;
                        model.ShowTypeId = (int)cboShowType.SelectedValue;
                        model.DurationSecond = (int)cboDuration.SelectedValue;

                        editResult = _contractDetailService.EditContractDetail(model);
                        if (editResult == CRUDStatusCode.SUCCESS)
                        {
                            gbRegisterSchedule.Visible = true;
                            Utilities.ShowMessage(CommonMessage.EDIT_SUCESSFULLY);
                            Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Update, "sản phẩm thuộc hợp đồng mã " + model.ContractCode),
                            Common.Constants.BusinessLogType.Update);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _contractDetailService = null;
            }
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            if (productScheduleShow != null)
            {
                productScheduleShow.Id = 0;
                productScheduleShow.TimeSlotLength = (int)cboDuration.SelectedValue;
                productScheduleShow.ShowTypeId = (int)cboShowType.SelectedValue;
            }
            if (model.Id != 0)
            {
                productScheduleShow.ContractDetailId = model.Id;
            }

            var options = new TimeSlotService().GetOptionsByLengthShowType((int)cboDuration.SelectedValue, (int)cboShowType.SelectedValue);
            if (options.FirstOrDefault().Key == -1)
            {
                Utilities.ShowMessage("Không tìm thấy thời điểm có thời lượng " + (int)cboDuration.SelectedValue + " (s) !\nVui lòng thêm thiết lập trong phần [Danh mục thời điểm].");
            }
            else
            {
                ProductScheduleDetailForm contractDetailDetailForm = new ProductScheduleDetailForm(productScheduleShow, model.ContractCode);
                contractDetailDetailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
                contractDetailDetailForm.ShowDialog();
            }
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                if (productScheduleShowId != 0)
                {
                    if (Utilities.ShowConfirmMessage(CommonMessage.CONFIRM_DELETE))
                    {
                        _productScheduleShowService = new ProductScheduleShowService();

                        //Completely delete from DB
                        _productScheduleShowService.DeleteProductScheduleShow(productScheduleShowId);
                        UpdateContractDetailTotalCost();
                        LoadDGV();
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Delete, "sản phẩm thuộc hợp đồng mã " + model.ContractCode),
                            Common.Constants.BusinessLogType.Delete);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _productScheduleShowService = null;
            }
        }

        private void DetailForm_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDGV();
            UpdateContractDetailTotalCost();
        }

        private void UpdateContractDetailTotalCost()
        {
            try
            {
                _contractDetailService = new ContractItemService();
                ContractDetailUpdateVM result = _contractDetailService.UpdateContractDetailCost(model.Id);
                txtTotalCost.Text = Utilities.DoubleMoneyToText(result.Cost);
                txtNumberOfShow.Text = result.NumberOfShow.ToString();
                Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Update, "giá tiền sản phẩm thuộc hợp đồng mã " + model.ContractCode),
                            Common.Constants.BusinessLogType.Update);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contractDetailService = null;
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (productScheduleShow.Id != 0)
            {
                var options = new TimeSlotService().GetOptionsByLengthShowType((int)cboDuration.SelectedValue, (int)cboShowType.SelectedValue);
                if (options.FirstOrDefault().Key == -1)
                {
                    Utilities.ShowMessage("Không tìm thấy thời điểm có thời lượng " + (int)cboDuration.SelectedValue + " (s) !\nVui lòng thêm thiết lập trong phần [Danh mục thời điểm].");
                }
                else
                {
                    ProductScheduleDetailForm contractDetailDetailForm = new ProductScheduleDetailForm(productScheduleShow, model.ContractCode);
                    contractDetailDetailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
                    contractDetailDetailForm.ShowDialog();
                }
            }
        }

        private void adgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            adgv.ClearSelection();
        }

        private void cboShowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(IsExisted && IsLoadCompleted)
            {
                btnSave_Click(sender, e);
            }
        }

        private void adgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void cboDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsExisted && IsLoadCompleted)
            {
                btnSave_Click(sender, e);
            }
        }
    }
}
