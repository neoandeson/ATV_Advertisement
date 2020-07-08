using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Advertisment.Forms.AdminForms
{
    public partial class ResetPasswordForm : CommonForm
    {
        private UserService _userService;

        public ResetPasswordForm()
        {
            InitializeComponent();
            LoadUserCombobox();
        }

        private void LoadUserCombobox()
        {
            try
            {
                _userService = new UserService();
                Utilities.LoadComboBoxOptions(cboUsername, _userService.Getoptions());
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _userService = null;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                _userService = new UserService();
                _userService.ChangePassword(Common.Session.GetId(), cboUsername.Text, "1234");
                Utilities.ShowMessage("Đã đặt lại mật khẩu mặt định cho người dùng có username " + cboUsername.Text);
                Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Update, "mật khẩu thành mặc định cho username " + cboUsername.Text),
                            Common.Constants.BusinessLogType.Update);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _userService = null;
            }
        }
    }
}
