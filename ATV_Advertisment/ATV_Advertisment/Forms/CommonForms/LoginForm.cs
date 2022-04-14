using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisement.CommonForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.BackColor = Color.Beige;
            this.TransparencyKey = Color.Beige;
            this.GetConnectionStringVersion();
        }

        private void GetConnectionStringVersion()
        {
            txtVersion.Text = Utilities.GetConnectionStringVersion();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SessionService sessionService = new SessionService();

                if (!Session.Login(txtUsername.Text, txtPassword.Text))
                {
                    Utilities.ShowError(CommonMessage.INVALID_LOGIN);
                } else
                {
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                Utilities.ShowError(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void btnChangeVersion_Click(object sender, EventArgs e)
        {
            VersionForm versionForm = new VersionForm();
            versionForm.FormClosed += new FormClosedEventHandler(VersionForm_Closed);
            versionForm.ShowDialog();
        }

        private void VersionForm_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
