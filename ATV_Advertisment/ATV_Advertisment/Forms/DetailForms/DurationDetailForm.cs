using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using DataService.Model;
using System;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class DurationDetailForm : CommonForm
    {
        public Duration model { get; set; }
        private DurationService _durationService = null;

        public DurationDetailForm(Duration inputModel)
        {
            this.model = inputModel;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                if (model != null)
                {
                    _durationService = new DurationService();
                    model = _durationService.GetById(model.Id);
                    if (model != null)
                    {
                        txtLength.Text = model.Length.ToString();
                    }
                }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = CRUDStatusCode.ERROR;

            try
            {
                _durationService = new DurationService();

                if (model == null)
                {
                    //Add
                    model = new Duration()
                    {
                        Length = int.Parse(txtLength.Text)
                    };
                    result = _durationService.AddDuration(model);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Create, "thời lượng " + model.Length),
                            Common.Constants.BusinessLogType.Create);
                    }
                }
                else
                {
                    //Edit
                    model.Length = int.Parse(txtLength.Text);

                    result = _durationService.EditDuration(model);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        Utilities.ShowMessage(CommonMessage.EDIT_SUCESSFULLY);
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Update, "hợp đồng mã " + model.Length),
                            Common.Constants.BusinessLogType.Update);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _durationService = null;
            }
        }
    }
}
