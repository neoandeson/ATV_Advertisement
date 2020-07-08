using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Forms.DetailForms;
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
using Session = DataService.Model.Session;

namespace ATV_Advertisment.Forms.ListForms
{
    public partial class ListSessionForm : CommonForm
    {
        private Session session = null;
        private SessionService _sessionService = null;

        public ListSessionForm()
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
                _sessionService = new SessionService();
                List<Session> sessions = _sessionService.GetAll();
                SortableBindingList<Session> sbl = new SortableBindingList<Session>(sessions);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgv.DataSource = bs;

                adgv.Columns["Id"].Visible = false;
                adgv.Columns["StatusId"].Visible = false;
                adgv.Columns["CreateDate"].Visible = false;
                adgv.Columns["LastUpdateBy"].Visible = false;
                adgv.Columns["LastUpdateDate"].Visible = false;

                adgv.Columns["Code"].HeaderText = ADGVText.Code;
                adgv.Columns["Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["Name"].HeaderText = ADGVText.Name;
                adgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _sessionService = null;
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

        private void adgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (adgv.SelectedRows.Count > 0)
            {
                var selectedRow = adgv.SelectedRows[0];

                //Prepare model
                if (selectedRow.Cells[0].Value.ToString() != "0")
                {
                    session = new Session()
                    {
                        Id = int.Parse(selectedRow.Cells[0].Value.ToString())
                    };
                }
            }
        }
        #endregion

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (session != null)
            {
                SessionDetailForm detailForm = new SessionDetailForm(session);
                detailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
                detailForm.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            session = null;
            SessionDetailForm detailForm = new SessionDetailForm(session);
            detailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
            detailForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (session != null)
                {
                    _sessionService = new SessionService();
                    int result = _sessionService.DeleteSession(session.Id);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        LoadDGV();
                        Utilities.ShowMessage(CommonMessage.DELETE_SUCESSFULLY);
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Delete, "buổi phát " + session.Code),
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
                _sessionService = null;
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
