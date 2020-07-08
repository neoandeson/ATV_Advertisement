using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
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

namespace ATV_Advertisment.Forms.InputForms
{
    public partial class SortScheduleByDayForm : CommonForm
    {
        private ProductScheduleShowService _productScheduleShowService;
        private SearchPSSModel searchModel = new SearchPSSModel();

        public SortScheduleByDayForm()
        {
            InitializeComponent();
        }

        private void BuildSearchModel()
        {
            searchModel = new SearchPSSModel();
            searchModel.SearchDate = dtpOneDate.Value;
        }

        #region AdvanceDataGridView
        private BindingSource bs = null;

        private void LoadDGV()
        {
            try
            {
                _productScheduleShowService = new ProductScheduleShowService();
                List<SortProductScheduleViewModel> sortPSSVMs = _productScheduleShowService.GetAllVMSearchingList(searchModel);
                SortableBindingList<SortProductScheduleViewModel> sbl = new SortableBindingList<SortProductScheduleViewModel>(sortPSSVMs);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgv.DataSource = bs;

                adgv.Columns["Id"].Visible = false;
                adgv.Columns["ContractDetailId"].Visible = false;
                adgv.Columns["Quantity"].Visible = false;
                adgv.Columns["ShowDate"].Visible = false;
                adgv.Columns["ShowTimeInt"].Visible = false;
                adgv.Columns["TimeSlotLength"].Visible = false;

                adgv.Columns["ProductName"].ReadOnly = true;
                adgv.Columns["TimeSlot"].ReadOnly = true;
                adgv.Columns["ShowTime"].ReadOnly = true;
                //adgv.Columns["ShowTime"].ToolTipText = "Thứ tự xuất hiện của quảng cáo: là một số có độ ưu tiên giảm dần từ 1 đến 7";
                adgv.Columns["ShowTime"].ValueType = typeof(int);

                adgv.Columns["TimeSlot"].HeaderText = ADGVText.TimeSlot;
                adgv.Columns["TimeSlot"].Width = ControlsAttribute.GV_WIDTH_LARGE;
                adgv.Columns["ShowTime"].HeaderText = ADGVText.ShowTime;
                adgv.Columns["ShowTime"].Width = ControlsAttribute.GV_WIDTH_SEEM;
                adgv.Columns["ProductName"].HeaderText = ADGVText.ProductName;
                adgv.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["OrderNumber"].HeaderText = ADGVText.OrderNumber;
                adgv.Columns["OrderNumber"].Width = ControlsAttribute.GV_WIDTH_SEEM;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _productScheduleShowService = null;
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

        //private void adgv_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (adgv.SelectedRows.Count > 0)
        //    {
        //        var selectedRow = adgv.SelectedRows[0];

        //        //Prepare model
        //        if (selectedRow.Cells[0].Value.ToString() != "0")
        //        {
        //            timeslot = new TimeSlot()
        //            {
        //                Id = int.Parse(selectedRow.Cells[0].Value.ToString())
        //            };
        //        }
        //        else
        //        {
        //            timeslot = null;
        //        }
        //    }
        //}
        #endregion

        private void btnFind_Click(object sender, EventArgs e)
        {
            BuildSearchModel();
            LoadDGV();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                List<SortProductScheduleViewModel> sortPSSVMs = new List<SortProductScheduleViewModel>();

                foreach (DataGridViewRow dr in adgv.Rows)
                {
                    if(dr.Cells[0].Value != null)
                    {
                        SortProductScheduleViewModel spps = new SortProductScheduleViewModel();
                        spps.Id = (int)dr.Cells[0].Value;
                        spps.ProductName = dr.Cells[2].Value.ToString();
                        spps.ShowTime = dr.Cells[3].Value.ToString();
                        spps.ShowDate = dr.Cells[4].Value.ToString();
                        spps.ContractDetailId = (int)dr.Cells[1].Value;
                        spps.TimeSlot = dr.Cells[6].Value.ToString();
                        spps.TimeSlotLength = (int)dr.Cells[7].Value;
                        spps.Quantity = (int)dr.Cells[5].Value;
                        spps.OrderNumber = (int)dr.Cells[8].Value;
                        spps.ShowTimeInt = (int)dr.Cells[9].Value;

                        sortPSSVMs.Add(spps);
                    }
                }

                if (sortPSSVMs.Count > 0)
                {
                    sortPSSVMs = sortPSSVMs.OrderBy(s => s.ShowTimeInt)
                    .ThenBy(s => s.OrderNumber).ToList();

                    SortableBindingList<SortProductScheduleViewModel> sbl = new SortableBindingList<SortProductScheduleViewModel>(sortPSSVMs);
                    bs = new BindingSource();
                    bs.DataSource = sbl;
                    adgv.DataSource = bs;
                }
                    
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<SortProductScheduleViewModel> sortPSSVMs = new List<SortProductScheduleViewModel>();

            foreach (DataGridViewRow dr in adgv.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    SortProductScheduleViewModel spps = new SortProductScheduleViewModel();
                    spps.Id = (int)dr.Cells[0].Value;
                    spps.ProductName = dr.Cells[2].Value.ToString();
                    spps.ShowTime = dr.Cells[3].Value.ToString();
                    spps.ShowDate = dr.Cells[4].Value.ToString();
                    spps.ContractDetailId = (int)dr.Cells[1].Value;
                    spps.TimeSlot = dr.Cells[6].Value.ToString();
                    spps.TimeSlotLength = (int)dr.Cells[7].Value;
                    spps.Quantity = (int)dr.Cells[5].Value;
                    spps.OrderNumber = (int)dr.Cells[8].Value;
                    spps.ShowTimeInt = (int)dr.Cells[9].Value;

                    sortPSSVMs.Add(spps);
                }
            }

            if(sortPSSVMs.Count > 0)
            {
                try
                {
                    _productScheduleShowService = new ProductScheduleShowService();
                    foreach (var pssVM in sortPSSVMs)
                    {
                        var dbPss = _productScheduleShowService.GetById(pssVM.Id);
                        if(dbPss != null)
                        {
                            dbPss.OrderNumber = pssVM.OrderNumber;
                            _productScheduleShowService.EditProductScheduleShow(dbPss);
                        }
                    }
                    Utilities.ShowMessage("Cập nhật thành công");
                    Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Update, "thứ tự phát sóng của lịch chiếu ngày " + dtpOneDate.Value),
                            Common.Constants.BusinessLogType.Update);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    _productScheduleShowService = null;
                }
            }
        }
    }
}
