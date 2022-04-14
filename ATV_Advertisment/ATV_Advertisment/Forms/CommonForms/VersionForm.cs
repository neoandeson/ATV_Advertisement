using ATV_Advertisment.Common;
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

namespace ATV_Advertisment.Forms.CommonForms
{
    public partial class VersionForm : CommonForm
    {
        private SessionService _sessionService;

        public VersionForm()
        {
            InitializeComponent();
            LoadCboVersion();
        }

        private void LoadCboVersion()
        {
            var options = this.ReadVersionConfigFile();
            Utilities.LoadComboBoxOptions(cboVersion, options);

            string version = Utilities.GetConnectionStringVersion();
            cboVersion.SelectedText = version;
        }

        private Dictionary<string, string> ReadVersionConfigFile()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Assets\config.txt");

            var options = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                var version = line.Split(':');
                options.Add(version[1], version[0]);
            }

            return options;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _sessionService = new SessionService();

                Utilities.ChangeConnectionString("ATVEntities", cboVersion.SelectedValue.ToString());
                _sessionService.ChangeConnectionString("ATVEntities", cboVersion.SelectedValue.ToString());

                Utilities.ShowMessage(string.Format("Thành công chuyển sang phiên bản {0}. \n Vui lòng khởi động lại để áp dụng.", cboVersion.SelectedValue.ToString()));
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sessionService = null;
            }
        }
    }
}
