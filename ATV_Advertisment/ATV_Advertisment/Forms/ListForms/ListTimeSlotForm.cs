using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Forms.DetailForms;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.ListForms
{
    public partial class ListTimeSlotForm : CommonForm
    {
        private TimeSlot timeslot = null;
        private TimeSlotService _timeSlotService = null;

        public ListTimeSlotForm()
        {
            InitializeComponent();
            LoadDGV();
        }

        #region AdvanceDataGridView
        private BindingSource bs = null;

        private void LoadDGV()
        {
            try
            {
                _timeSlotService = new TimeSlotService();
                List<TimeSlotViewModel> timeSlotVMs = _timeSlotService.GetAllForDetailList();
                SortableBindingList<TimeSlotViewModel> sbl = new SortableBindingList<TimeSlotViewModel>(timeSlotVMs);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgv.DataSource = bs;

                adgv.Columns["Id"].Visible = false;
                adgv.Columns["StatusId"].Visible = false;
                adgv.Columns["CreateDate"].Visible = false;
                adgv.Columns["LastUpdateBy"].Visible = false;
                adgv.Columns["LastUpdateDate"].Visible = false;

                adgv.Columns["Code"].HeaderText = ADGVText.Code;
                adgv.Columns["Code"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgv.Columns["Name"].HeaderText = ADGVText.Name;
                adgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["FromHour"].HeaderText = ADGVText.TimeSlot;
                adgv.Columns["FromHour"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgv.Columns["SessionCode"].HeaderText = ADGVText.Session;
                adgv.Columns["SessionCode"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
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
                if (selectedRow.Cells[0].Value.ToString() != "0")
                {
                    timeslot = new TimeSlot()
                    {
                        Id = int.Parse(selectedRow.Cells[0].Value.ToString())
                    };
                }
                else
                {
                    timeslot = null;
                }
            }
        }
        #endregion

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (timeslot != null)
            {
                TimeSlotDetailForm detailForm = new TimeSlotDetailForm(timeslot);
                detailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
                detailForm.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            timeslot = null;
            TimeSlotDetailForm detailForm = new TimeSlotDetailForm(timeslot);
            detailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
            detailForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Utilities.ShowConfirmMessage(CommonMessage.CONFIRM_DELETE))
            {
                try
                {
                    if (timeslot != null)
                    {
                        _timeSlotService = new TimeSlotService();
                        int result = _timeSlotService.DeleteTimeSlot(timeslot.Id);
                        if (result == CRUDStatusCode.SUCCESS)
                        {
                            LoadDGV();
                            Utilities.ShowMessage(CommonMessage.DELETE_SUCESSFULLY);
                            Logging.LogBusiness(string.Format("{0} {1} {2}",
                                Common.Session.GetUserName(),
                                Common.Constants.LogAction.Delete, "thời điểm phát " + timeslot.Code + " " + timeslot.FromHour),
                                Common.Constants.BusinessLogType.Delete);
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
        }

        private void DetailForm_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDGV();
        }

        private void adgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            adgv.ClearSelection();
        }
    }
}
