using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
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

namespace ATV_Advertisment.Forms.AdminForms
{
    public partial class LoggingForm : CommonForm
    {
        private BusinessLogService _businessLogService;

        public LoggingForm()
        {
            InitializeComponent();
            rbDate.Checked = true;
            rbMonth.Checked = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                _businessLogService = new BusinessLogService();
                List<BusinessLog> input;
                if (rbDate.Checked)
                {
                    var selectedDate = dtpDate.Value;
                    input = _businessLogService.GetLoggingByDate(selectedDate.Day, selectedDate.Month, selectedDate.Year);
                    LoadDGV(input);
                } else if (rbMonth.Checked)
                {
                    var selectedDate = dtpDate.Value;
                    input = _businessLogService.GetLoggingByMonth(selectedDate.Month, selectedDate.Year);
                    LoadDGV(input);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _businessLogService = null;
            }
            
        }

        #region AdvanceDataGridView
        private BindingSource bs = null;

        private void LoadDGV(List<BusinessLog> data)
        {
            try
            {
                SortableBindingList<BusinessLog> sbl = new SortableBindingList<BusinessLog>(data);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgv.DataSource = bs;

                adgv.Columns["Id"].Visible = false;

                adgv.Columns["Content"].HeaderText = ADGVText.Content;
                adgv.Columns["Content"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["ActorId"].HeaderText = ADGVText.ActUser;
                adgv.Columns["ActorId"].Width = ControlsAttribute.GV_WIDTH_SMALL;
                adgv.Columns["TypeId"].HeaderText = ADGVText.ActType;
                adgv.Columns["TypeId"].Width = ControlsAttribute.GV_WIDTH_SMALL;
                adgv.Columns["DateAct"].HeaderText = ADGVText.ActDate;
                adgv.Columns["DateAct"].Width = ControlsAttribute.GV_WIDTH_MEDIUM;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void adgv_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = adgv.SortString;
        }

        private void adgv_FilterStringChanged(object sender, EventArgs e)
        {
            string tmp = adgv.FilterString;
            string pattern = @"([a-zA-Z]+)";
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
        #endregion
    }
}
