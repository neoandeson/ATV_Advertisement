using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
using DataService.Model;
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
    public partial class TimeSlotDetailForm : CommonForm
    {
        public TimeSlot model { get; set; }
        private CostRule costRule { get; set; }
        private int CompleteLoadData = 0;
        private TimeSlotService _timeSlotService = null;
        private CostRuleService _costRuleService = null;
        private SessionService _sessionService = null;
        private DurationService _durationService = null;
        private ShowTypeService _showTypeService = null;
        private bool LoadingData = true;

        public TimeSlotDetailForm(TimeSlot inputModel)
        {
            this.model = inputModel;
            InitializeComponent();
            gbCostRule.Visible = false;
            LoadCboSession();
            LoadCboDuration();
            LoadCboShowType();
            LoadData();
        }

        public void LoadCboSession()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _sessionService = new SessionService();

                Utilities.LoadComboBoxOptions(cboSession, _sessionService.Getoptions());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sessionService = null;
                Cursor.Current = Cursors.Default;
            }
        }

        public void LoadCboDuration()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _durationService = new DurationService();

                Utilities.LoadComboBoxOptions(cboDuration, _durationService.Getoptions());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CompleteLoadData = 1;
                _durationService = null;
                Cursor.Current = Cursors.Default;
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
                CompleteLoadData = 2;
                _showTypeService = null;
                Cursor.Current = Cursors.Default;
            }
        }

        public void LoadData()
        {
            try
            {
                if (model != null)
                {
                    _timeSlotService = new TimeSlotService();
                    model = _timeSlotService.GetById(model.Id);
                    if (model != null)
                    {
                        cboSession.SelectedValue = model.SessionCode;
                        txtCode.Text = model.Code;
                        txtName.Text = model.Name;
                        txtFromHour.Text = Utilities.GetHourFromHourInt(model.FromHour).ToString();
                        txtFromMinute.Text = Utilities.GetMinuteFromHourInt(model.FromHour).ToString();
                        txtCode.ReadOnly = true;

                        LoadDGV();
                    }
                    gbCostRule.Visible = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _timeSlotService = null;
                LoadingData = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TimeSlot result = null;

            try
            {
                _timeSlotService = new TimeSlotService();

                if(ckbUpdate.Checked)
                {
                    //Edit
                    int editResult = CRUDStatusCode.ERROR;
                    model.Code = txtCode.Text;
                    model.Name = txtName.Text;
                    model.FromHour = Utilities.GetHourFromHourString(txtFromHour.Text, txtFromMinute.Text);
                    model.SessionCode = cboSession.SelectedValue.ToString();

                    editResult = _timeSlotService.EditTimeSlot(model);
                    if (editResult == CRUDStatusCode.SUCCESS)
                    {
                        Utilities.ShowMessage(CommonMessage.EDIT_SUCESSFULLY);
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Update, "thời điểm phát " + model.Code),
                            Common.Constants.BusinessLogType.Update);
                    }
                } else
                {
                    bool isExistCode = _timeSlotService.IsExistCode(txtCode.Text.Trim());
                    if (isExistCode)
                    {
                        Utilities.ShowError("Mã " + txtCode.Text.Trim() + " đã tồn tại");
                    }
                    else
                    {
                        if (model == null)
                        {
                            //Add
                            model = new TimeSlot()
                            {
                                Code = txtCode.Text,
                                Name = txtName.Text,
                                FromHour = Utilities.GetHourFromHourString(txtFromHour.Text, txtFromMinute.Text),
                                SessionCode = cboSession.SelectedValue.ToString(),
                            };
                            result = _timeSlotService.CreateTimeSlot(model);
                            if (result != null)
                            {
                                model = result;
                                Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                                gbCostRule.Visible = true;
                                Logging.LogBusiness(string.Format("{0} {1} {2}",
                                    Common.Session.GetUserName(),
                                    Common.Constants.LogAction.Create, "thời điểm phát " + model.Code),
                                    Common.Constants.BusinessLogType.Create);
                            }
                        }
                        else
                        {
                            //TODO Check remove
                            //Edit
                            int editResult = CRUDStatusCode.ERROR;
                            model.Code = txtCode.Text;
                            model.Name = txtName.Text;
                            model.FromHour = Utilities.GetHourFromHourString(txtFromHour.Text, txtFromMinute.Text);
                            model.SessionCode = cboSession.SelectedValue.ToString();

                            editResult = _timeSlotService.EditTimeSlot(model);
                            if (editResult == CRUDStatusCode.SUCCESS)
                            {
                                Utilities.ShowMessage(CommonMessage.EDIT_SUCESSFULLY);
                                Logging.LogBusiness(string.Format("{0} {1} {2}",
                                    Common.Session.GetUserName(),
                                    Common.Constants.LogAction.Update, "thời điểm phát " + model.Code),
                                    Common.Constants.BusinessLogType.Update);
                            }
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
                _timeSlotService = null;
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            CheckExistTimeSlotInfo();
        }

        private void cboDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CompleteLoadData == 2)
            {
                CheckExistTimeSlotInfo();
            }
        }

        private void CheckExistTimeSlotInfo()
        {
            try
            {
                _timeSlotService = new TimeSlotService();
                bool result = false;//TODO check _timeSlotService.IsExistCodeAndLength(txtCode.Text, (int)cboDuration.SelectedValue);
                if (result)
                {
                    Utilities.ShowMessage(CommonMessage.USED_CODE_LENGTH);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _timeSlotService = null;
            }
        }

        #region AdvanceDataGridView
        private BindingSource bs = null;

        private void LoadDGV()
        {
            try
            {
                _costRuleService = new CostRuleService();
                List<CostRuleViewModel> costRuleVMs = _costRuleService.GetAllForList(model.Id);
                SortableBindingList<CostRuleViewModel> sbl = new SortableBindingList<CostRuleViewModel>(costRuleVMs);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgv.DataSource = bs;
                adgv.ClearSelection();

                adgv.Columns["Id"].Visible = false;
                adgv.Columns["TimeSlotId"].Visible = false;

                adgv.Columns["Length"].HeaderText = ADGVText.Duration;
                adgv.Columns["Length"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgv.Columns["ShowType"].HeaderText = ADGVText.ShowType;
                adgv.Columns["ShowType"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgv.Columns["Price"].HeaderText = ADGVText.Cost;
                adgv.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _costRuleService = null;
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
            var selectedRow = adgv.SelectedRows[0];

            //Prepare model
            if (selectedRow.Cells[0].Value.ToString() != "0")
            {
                int id = int.Parse(selectedRow.Cells[0].Value.ToString());
                costRule = GetCostRuleById(id);

                //Binding data
                if(costRule != null)
                {
                    cboDuration.SelectedValue = costRule.Length;
                    cboShowType.SelectedValue = costRule.ShowTypeId;
                    txtPrice.Text = Utilities.DoubleMoneyToText(costRule.Price);
                }
            }
            else
            {
                costRule = null;
            }
        }
        #endregion

        private CostRule GetCostRuleById(int id)
        {
            try
            {
                _costRuleService = new CostRuleService();
                CostRule costRule = _costRuleService.GetById(id);

                return costRule;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _costRuleService = null;
            }
        }

        private void btnSaveCostRule_Click(object sender, EventArgs e)
        {
            try
            {
                if(costRule != null)
                {
                    //Edit
                    int result = CRUDStatusCode.ERROR;
                    costRule.ShowTypeId = (int)cboShowType.SelectedValue;
                    costRule.Price = (double)txtPrice.MoneyValue;
                    costRule.Length = (int)cboDuration.SelectedValue;
                    _costRuleService = new CostRuleService();

                    result = _costRuleService.EditCostRule(costRule);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        LoadDGV();
                        Utilities.ShowMessage(CommonMessage.EDIT_SUCESSFULLY);
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Update, "giá tiền " + costRule.Length + " loại hình " + costRule.ShowTypeId + " của thời điểm " + model.Code),
                            Common.Constants.BusinessLogType.Update);
                    }
                } else
                {
                    //Add
                    int result = CRUDStatusCode.ERROR;
                    _costRuleService = new CostRuleService();

                    CostRule newCodeRule = new CostRule()
                    {
                        Length = (int)cboDuration.SelectedValue,
                        Price = (double)txtPrice.MoneyValue,
                        TimeSlotId = model.Id,
                        ShowTypeId = (int)cboShowType.SelectedValue
                    };
                    result = _costRuleService.AddCostRule(newCodeRule);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                        LoadDGV();
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Create, "giá tiền " + newCodeRule.Length + " loại hình " + newCodeRule.ShowTypeId + " của thời điểm " + model.Code),
                            Common.Constants.BusinessLogType.Create);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _costRuleService = null;
            }
        }

        private void btnDeleteCostRule_Click(object sender, EventArgs e)
        {
            try
            {
                if (costRule != null)
                {
                    int result = CRUDStatusCode.ERROR;
                    _costRuleService = new CostRuleService();
                    result = _costRuleService.DeleteCostRule(costRule.Id);
                    if(result == CRUDStatusCode.SUCCESS)
                    {
                        Utilities.ShowMessage(CommonMessage.DELETE_SUCESSFULLY);
                        LoadDGV();
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Delete, "giá tiền " + costRule.Length + " loại hình " + costRule.ShowTypeId + " của thời điểm " + model.Code),
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
                _costRuleService = null;
            }
        }

        private void adgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            adgv.ClearSelection();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            _timeSlotService = new TimeSlotService();

            try
            {
                if (!LoadingData)
                {
                    bool isExist = _timeSlotService.IsExistCode(txtCode.Text.Trim());
                    if (isExist)
                    {
                        Utilities.ShowError("Mã " + txtCode.Text.Trim() + " đã tồn tại");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _timeSlotService = null;
            }
        }
    }
}
