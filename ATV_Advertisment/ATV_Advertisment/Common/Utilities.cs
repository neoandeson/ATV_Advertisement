using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Forms.ListForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using ATV_Advertisment.Forms.InputForms;
using ATV_Advertisment.Forms.PrintForms;
using System.Data;
using System.Reflection;
using ATV_Advertisment.Forms.SettingForms;
using ATV_Advertisment.Forms.AdminForms;

namespace ATV_Advertisment.Common
{
    public static class Utilities
    {
        public static Hashtable OpenedForms = new Hashtable();
        public static Hashtable MenuItemNames = new Hashtable();

        public static void ShowMessage(string message)
        {
            var cursor = Cursor.Current;
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string message)
        {
            var cursor = Cursor.Current;
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowReturnMessage(int type, string message)
        {
            string noti = "";
            //CRUDStatusCode
            switch (type)
            {
                case 0: noti = string.Format("{0} không thành công", message); break; //ERROR
                case 1: noti = string.Format("{0} thành công", message); break; //SUCCESS
                case 2: noti = string.Format("Dữ liệu ({0}) đã tồn tại.", message); break; //EXISTED
            }
            var cursor = Cursor.Current;
            MessageBox.Show(noti, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ShowConfirmMessage(string message)
        {
            bool result = false;
            var cursor = Cursor.Current;

            if (MessageBox.Show(message, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                result = true;
            }

            return result;
        }

        public static bool IsNumberic(string strNum, out int number)
        {
            bool isNumeric = int.TryParse(strNum, out number);
            return isNumeric;
        }

        public static DateTime GetServerDateTimeNow()
        {
            DateTime dt;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
            {
                var cmd = new SqlCommand("SELECT GETDATE()", conn);
                conn.Open();

                dt = (DateTime)cmd.ExecuteScalar();
            };
            return dt;
        }

        public static void LoadComboBoxOptions(ComboBox comboBox, Dictionary<int, string> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public static void LoadComboBoxOptions(ComboBox comboBox, Dictionary<int, int> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public static void LoadComboBoxOptions(ComboBox comboBox, Dictionary<string, string> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public static void LoadComboBoxOptions(ComboBox comboBox, List<KeyValuePair<double, string>> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public static void LoadComboBoxOptions(ComboBox comboBox, List<KeyValuePair<int, int>> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }
        public static void LoadComboBoxOptions(ComboBox comboBox, List<KeyValuePair<double, int>> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public static int GetHourFromHourInt(int hourInt)
        {
            return hourInt / 100;
        }

        public static int GetMinuteFromHourInt(int hourInt)
        {
            return hourInt % 100;
        }

        public static string GetHourFormInt(int hourInt)
        {
            int hour = GetHourFromHourInt(hourInt);
            int minute = GetMinuteFromHourInt(hourInt);

            string result = hour.ToString("00") + ":" + minute.ToString("00");
            return result;
        }

        public static int GetHourFromHourString(string hour, string minute)
        {
            return int.Parse(hour) * 100 + int.Parse(minute);
        }

        public static int GetIntFromTextBox(TextBox textBox)
        {
            int result = 0;
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                int.TryParse(textBox.Text, out result);
            }

            return result;
        }

        public static double GetDoubleFromTextBox(TextBox textBox)
        {
            double result = 0;
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                double.TryParse(textBox.Text, out result);
            }

            return result;
        }

        public static string DoubleMoneyToText(double money)
        {
            string result = "0";

            if (money != 0)
            {
                result = String.Format("{0:0,0}", money);
            }

            return result;
        }

        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public static string DateToFormatVNDate(DateTime dateTime)
        {
            return "Ngày " + dateTime.Day + " tháng " + dateTime.Month + " năm " + dateTime.Year;
        }

        public static Form ShowFormByName(string formName, out bool isLogout)
        {
            Form form = null;
            bool isFunctionLogout = false;
            if (!string.IsNullOrWhiteSpace(formName))
            {
                formName = formName.Trim();

                //Check if form is opened
                if (OpenedForms.Contains(formName))
                {
                    form = (Form)OpenedForms[formName];
                    form.Dispose();
                    if (form.IsDisposed)
                    {
                        OpenedForms.Remove(formName);
                        form = null;
                    }
                }

                switch (formName)
                {
                    case "Danh mục khách hàng":
                        ListCustomerForm listCustomerForm = new ListCustomerForm();
                        form = (Form)listCustomerForm;
                        break;
                    case "Danh mục loại quảng cáo":
                        ListShowTypeForm listShowTypeForm = new ListShowTypeForm();
                        form = (Form)listShowTypeForm;
                        break;
                    case "Danh mục buổi phát":
                        ListSessionForm listSessionForm = new ListSessionForm();
                        form = (Form)listSessionForm;
                        break;
                    case "Danh mục thời điểm":
                        ListTimeSlotForm listTimeSlotForm = new ListTimeSlotForm();
                        form = (Form)listTimeSlotForm;
                        break;

                    case "Danh mục thời lượng":
                        ListDurationForm listDurationForm = new ListDurationForm();
                        form = (Form)listDurationForm;
                        break;
                    //Nhập liệu
                    case "Hợp đồng quảng cáo":
                        ListContractForm listContractForm = new ListContractForm();
                        form = (Form)listContractForm;
                        break;
                    case "Xếp lịch theo ngày":
                        SortScheduleByDayForm sortScheduleByDayForm = new SortScheduleByDayForm();
                        form = (Form)sortScheduleByDayForm;
                        break;
                    //In ấn
                    case "In lịch phát sóng":
                        SchedulePrintForm schedulePrintForm = new SchedulePrintForm();
                        form = (Form)schedulePrintForm;
                        break;
                    case "Báo cáo doanh thu":
                        RevenuePrintForm revenuePrintForm = new RevenuePrintForm();
                        form = (Form)revenuePrintForm;
                        break;
                    case "Đối chiếu công nợ":
                        LiabilitesPrintForm liabilitesPrintForm = new LiabilitesPrintForm();
                        form = (Form)liabilitesPrintForm;
                        break;
                    case "Chứng nhận phát sóng":
                        ShowCommitmentPrintForm showCommitmentPrintForm = new ShowCommitmentPrintForm();
                        form = (Form)showCommitmentPrintForm;
                        break;
                    case "Dự trù thời lượng":
                        ExpectedPrintForm expectedPrintForm = new ExpectedPrintForm();
                        form = (Form)expectedPrintForm;
                        break;
                    case "Đăng ký quảng cáo":
                        InputSchedulePrintForm inputSchedulePrintForm = new InputSchedulePrintForm();
                        form = (Form)inputSchedulePrintForm;
                        break;
                    case "Bảng giá quảng cáo":
                        PricingPrintForm pricingPrintForm = new PricingPrintForm();
                        form = (Form)pricingPrintForm;
                        break;
                    //Trợ giúp
                    case "Đổi mật khẩu":
                        ChangePasswordForm changePasswordForm = new ChangePasswordForm();
                        form = (Form)changePasswordForm;
                        break;
                    case "Thông tin ứng dụng":
                        HelpForm helpForm = new HelpForm();
                        form = (Form)helpForm;
                        break;
                    //Quyền Admin
                    case "Đặt lại mật khẩu":
                        ResetPasswordForm resetPasswordForm = new ResetPasswordForm();
                        form = (Form)resetPasswordForm;
                        break;
                    case "Xem lịch sử":
                        LoggingForm loggingForm = new LoggingForm();
                        form = (Form)loggingForm;
                        break;
                    case "Tạo tài khoản":
                        CreateAccountForm createAccountForm = new CreateAccountForm();
                        form = (Form)createAccountForm;
                        break;

                    case "Logout":
                        Session.Logout();
                        isFunctionLogout = true;
                        break;
                    case "Exit":
                        Application.Exit();
                        break;
                }

                if (form != null)
                {
                    form.Owner = GlobalForm.ActiveForm;
                    form.MdiParent = GlobalForm.ActiveForm;
                    form.ShowInTaskbar = true;
                    form.BringToFront();
                    form.TopMost = true;
                    form.MinimizeBox = true;
                    form.WindowState = FormWindowState.Normal;
                    form.StartPosition = FormStartPosition.CenterScreen;

                    form.Show();

                    if (!OpenedForms.Contains(formName))
                    {
                        OpenedForms.Add(formName, form);
                    }
                }
            }

            isLogout = isFunctionLogout;
            return form;
        }
    }
}
