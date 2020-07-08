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

namespace ATV_Advertisment.Forms.SettingForms
{
    public partial class ChangePasswordForm : CommonForm
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            bool validatedUser = Session.Login(Session.GetUserName(), txtOld.Text.Trim());
            if (!validatedUser)
            {
                Utilities.ShowError("Mật khẩu không đúng");
            }
            else if (String.IsNullOrWhiteSpace(txtNew.Text))
            {
                Utilities.ShowError("Vui lòng nhập mật khẩu (không bao gồm kí tự khoảng trắng)");
            }
            else if (txtNew.Text.Trim().Length < 4)
            {
                Utilities.ShowError("Độ dài mật khẩu phải ít nhất 4 ký tự");
            }
            else if (txtNew.Text.Trim() != txtConfirm.Text.Trim())
            {
                Utilities.ShowError("Mật khẩu và xác nhận mật khẩu không khớp");
            }
            else
            {
                UserService userService = new UserService();
                userService.ChangePassword(Session.GetId(), Session.GetUserName(), txtNew.Text.Trim());
                Utilities.ShowMessage("Đổi mật khẩu thành công");
                Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Update, "mật khẩu"),
                            Common.Constants.BusinessLogType.Update);
            }

        }
    }
}
