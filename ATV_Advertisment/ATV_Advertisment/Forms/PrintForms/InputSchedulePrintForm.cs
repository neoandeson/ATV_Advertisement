using ATV_Advertisment.Common;
using ATV_Advertisment.Services;
using DataService.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Advertisment.Forms.PrintForms
{
    public partial class InputSchedulePrintForm : Form
    {
        public InputSchedulePrintForm()
        {
            InitializeComponent();
            LoadCboCustomerCode();

            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpMonth.CustomFormat = "MM/yyyy";
            dtpMonth.ShowUpDown = true;
        }

        private void InputSchedulePrintForm_Load(object sender, EventArgs e)
        {

            this.rptViewer.RefreshReport();
        }

        private void LoadCboCustomerCode()
        {
            try
            {
                Utilities.LoadComboBoxOptions(cboCustomer, new CustomerService().GetOptions());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadCboContractCode()
        {
            try
            {
                string customerCode = cboCustomer.SelectedValue + "";
                var options = new ContractService().GetOptionsByCustomerCodeAndMonth(customerCode, dtpMonth.Value, dtpMonth.Value);
                Utilities.LoadComboBoxOptions(cboContractCode, options);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void LoadCboProductCode()
        {
            try
            {
                string contracCode = cboContractCode.SelectedValue + "";
                var options = new ContractItemService().GetOptionsByContractCode(contracCode.Trim());
                Utilities.LoadComboBoxOptions(cboProduct, options);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtSendTo.Text))
                {
                    Utilities.ShowMessage("Nhập đầy đủ các trường để tiếp tục");
                    return;
                }

                string contractCode = cboContractCode.SelectedValue.ToString();
                string productName = cboProduct.SelectedValue.ToString();
                if (!string.IsNullOrWhiteSpace(contractCode) && !string.IsNullOrWhiteSpace(productName))
                {
                    Contract contract = new ContractService().GetByCode(contractCode);
                    ContractItem contractItem = new ContractItemService().GetByContractCodeAndProductName(contractCode, productName);
                    if (contractItem != null)
                    {
                        Customer customer = new CustomerService().GetByCode(contract.CustomerCode);
                        int contractDetailId = contractItem.Id;
                        string cdProductName = contractItem.FileName;

                        string exeFolder = Application.StartupPath;
                        string reportPath = Path.Combine(exeFolder, @"Reports\InputScheduleReport.rdlc");

                        //
                        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
                        {
                            SqlDataAdapter da = null;

                            try
                            {
                                string query = "SELECT ProductName, TimeSlot, ShowTime, TimeSlotCode, Cost, TotalCost, [1] as D1,[2] as D2,[3] as D3,[4] as D4,[5] as D5," +
                                    "[6] as D6,[7] as D7,[8] as D8,[9] as D9,[10] as D10, [11] as D11,[12] as D12,[13] as D13,[14] as D14,[15] as D15," +
                                    "[16] as D16,[17] as D17,[18] as D18,[19] as D19,[20] as D20,[21] as D21,[22] as D22,[23] as D23,[24] as D24, [25] as D25, " +
                                    "[26] as D26, [27] as D27, [28] as D28, [29] as D29, [30] as D30, [31] as D31, Qty " +
                                    "FROM" +
                                    "(" +
                                        "SELECT ProductName, TimeSlot, ShowTime, TimeSlotCode, Cost, TotalCost," +
                                                "CAST(DAY(ShowDate) AS VARCHAR(4)) AS ShowDay, Quantity " +
                                        "FROM dbo.ProductScheduleShow p1 " +
                                        "WHERE   p1.ProductName = @productName " +
                                                "AND YEAR(p1.ShowDate) = @rptYear " +
                                                "AND MONTH(p1.ShowDate) = @rptMonth " +
                                                "AND ContractDetailId = @contractDetailId" +
                                    ") AS ts LEFT JOIN( " +
                                        "SELECT ProductName as ProductName1, TimeSlotCode as TimeSlotCode1, SUM(Quantity) as Qty " +
                                        "FROM  dbo.ProductScheduleShow p1 " +
                                        "WHERE p1.ProductName = @productName " +
                                                "AND YEAR(p1.ShowDate) = @rptYear " +
                                                "AND MONTH(p1.ShowDate) = @rptMonth " +
                                                "AND ContractDetailId = @contractDetailId " +
                                        "GROUP BY ProductName, Quantity, ShowTime, TimeSlotCode) as nu on ts.ProductName = nu.ProductName1 AND ts.TimeSlotCode = nu.TimeSlotCode1 " +
                                    "PIVOT " +
                                    "( " +
                                    "count(Quantity) " +
                                    "FOR ShowDay IN ( [1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20],[21],[22],[23],[24], [25], [26], [27], [28], [29], [30], [31]) " +
                                    ") AS pvt";
                                var cmd = new SqlCommand(query, con);
                                cmd.Parameters.Add(new SqlParameter("@rptYear", this.dtpMonth.Value.Year));
                                cmd.Parameters.Add(new SqlParameter("@rptMonth", this.dtpMonth.Value.Month));
                                cmd.Parameters.Add(new SqlParameter("@contractDetailId", contractDetailId));
                                cmd.Parameters.Add(new SqlParameter("@productName", cdProductName));

                                da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                var firstDayOfMonth = new DateTime(this.dtpMonth.Value.Year, this.dtpMonth.Value.Month, 1);
                                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                                List<ViewModel.InputScheduleRM> inputSchedules = Utilities.ConvertDataTable<ViewModel.InputScheduleRM>(dt);
                                List<ViewModel.InputScheduleMRM> reportData = new List<ViewModel.InputScheduleMRM>();
                                foreach (var ins in inputSchedules)
                                {
                                    ViewModel.InputScheduleMRM sc = new ViewModel.InputScheduleMRM()
                                    {
                                        ShowTime = ins.ShowTime,
                                        Cost = ins.Cost,
                                        TotalCost = ins.TotalCost,
                                        TimeSlot = ins.TimeSlot,
                                        TimeSlotCode = ins.TimeSlotCode,
                                        Qty = ins.Qty,
                                        D1 = ins.D1 == 0 ? "" : ins.D1 + "",
                                        D2 = ins.D2 == 0 ? "" : ins.D2 + "",
                                        D3 = ins.D3 == 0 ? "" : ins.D3 + "",
                                        D4 = ins.D4 == 0 ? "" : ins.D4 + "",
                                        D5 = ins.D5 == 0 ? "" : ins.D5 + "",
                                        D6 = ins.D6 == 0 ? "" : ins.D6 + "",
                                        D7 = ins.D7 == 0 ? "" : ins.D7 + "",
                                        D8 = ins.D8 == 0 ? "" : ins.D8 + "",
                                        D9 = ins.D9 == 0 ? "" : ins.D9 + "",
                                        D10 = ins.D10 == 0 ? "" : ins.D10 + "",
                                        D11 = ins.D11 == 0 ? "" : ins.D11 + "",
                                        D12 = ins.D12 == 0 ? "" : ins.D12 + "",
                                        D13 = ins.D13 == 0 ? "" : ins.D13 + "",
                                        D14 = ins.D14 == 0 ? "" : ins.D14 + "",
                                        D15 = ins.D15 == 0 ? "" : ins.D15 + "",
                                        D16 = ins.D16 == 0 ? "" : ins.D16 + "",
                                        D17 = ins.D17 == 0 ? "" : ins.D17 + "",
                                        D18 = ins.D18 == 0 ? "" : ins.D18 + "",
                                        D19 = ins.D19 == 0 ? "" : ins.D19 + "",
                                        D20 = ins.D20 == 0 ? "" : ins.D20 + "",
                                        D21 = ins.D21 == 0 ? "" : ins.D21 + "",
                                        D22 = ins.D22 == 0 ? "" : ins.D22 + "",
                                        D23 = ins.D23 == 0 ? "" : ins.D23 + "",
                                        D24 = ins.D24 == 0 ? "" : ins.D24 + "",
                                        D25 = ins.D25 == 0 ? "" : ins.D25 + "",
                                        D26 = ins.D26 == 0 ? "" : ins.D26 + "",
                                        D27 = ins.D27 == 0 ? "" : ins.D27 + "",
                                        D28 = ins.D28 == 0 ? "" : ins.D28 + "",
                                        D29 = ins.D29 == 0 ? "" : ins.D29 + "",
                                        D30 = ins.D30 == 0 ? "" : ins.D30 + "",
                                        D31 = ins.D31 == 0 ? "" : ins.D31 + "",

                                    };
                                    reportData.Add(sc);
                                }

                                DateTime today = Utilities.GetServerDateTimeNow();
                                string strToday = Utilities.DateToFormatVNDate(today);

                                ReportParameterCollection reportParameters = new ReportParameterCollection();
                                reportParameters.Add(new ReportParameter("str1Day", new DateTime(this.dtpMonth.Value.Year, this.dtpMonth.Value.Month, 1).DayOfWeek.ToString().Substring(0, 3)));
                                reportParameters.Add(new ReportParameter("str2Day", new DateTime(this.dtpMonth.Value.Year, this.dtpMonth.Value.Month, 2).DayOfWeek.ToString().Substring(0, 3)));
                                reportParameters.Add(new ReportParameter("str3day", new DateTime(this.dtpMonth.Value.Year, this.dtpMonth.Value.Month, 3).DayOfWeek.ToString().Substring(0, 3)));
                                reportParameters.Add(new ReportParameter("str4day", new DateTime(this.dtpMonth.Value.Year, this.dtpMonth.Value.Month, 4).DayOfWeek.ToString().Substring(0, 3)));
                                reportParameters.Add(new ReportParameter("str5day", new DateTime(this.dtpMonth.Value.Year, this.dtpMonth.Value.Month, 5).DayOfWeek.ToString().Substring(0, 3)));
                                reportParameters.Add(new ReportParameter("str6day", new DateTime(this.dtpMonth.Value.Year, this.dtpMonth.Value.Month, 6).DayOfWeek.ToString().Substring(0, 3)));
                                reportParameters.Add(new ReportParameter("str7day", new DateTime(this.dtpMonth.Value.Year, this.dtpMonth.Value.Month, 7).DayOfWeek.ToString().Substring(0, 3)));
                                reportParameters.Add(new ReportParameter("strMonth", string.Format("{0}/{1}", this.dtpMonth.Value.Month, this.dtpMonth.Value.Year)));
                                reportParameters.Add(new ReportParameter("strCustAddress", customer.Address));
                                reportParameters.Add(new ReportParameter("strCustPhone", customer.Phone1 + customer.Phone2));
                                reportParameters.Add(new ReportParameter("strCustFax", customer.Fax + " " ));
                                reportParameters.Add(new ReportParameter("strCustEmail", customer.Email == null ? "" : customer.Email));
                                reportParameters.Add(new ReportParameter("strSendTo", txtSendTo.Text));
                                reportParameters.Add(new ReportParameter("strProductName", contractItem.ProductName));
                                reportParameters.Add(new ReportParameter("strFileName", contractItem.FileName));
                                reportParameters.Add(new ReportParameter("strLength", contractItem.DurationSecond + " s"));
                                reportParameters.Add(new ReportParameter("strCreateDate", contractItem.CreateDate.Value.ToShortDateString()));
                                reportParameters.Add(new ReportParameter("strReportDate", strToday));
                                reportParameters.Add(new ReportParameter("strReportBy", Common.Session.GetFullName()));
                                reportParameters.Add(new ReportParameter("strReportByPhone", txtPhone.Text));
                                reportParameters.Add(new ReportParameter("intMaxDate", lastDayOfMonth.Day + ""));

                                rptViewer.LocalReport.ReportPath = reportPath;
                                rptViewer.LocalReport.DataSources.Clear();
                                rptViewer.LocalReport.SetParameters(reportParameters);
                                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsInputSchedule", reportData.AsEnumerable()));
                                rptViewer.RefreshReport();

                                Logging.LogBusiness(string.Format("{0} {1} {2}",
                                    Common.Session.GetUserName(),
                                    Common.Constants.LogAction.ExportData, "lịch đăng ký quảng cáo của khách hàng " + cboCustomer.SelectedValue.ToString() 
                                    + " mã hợp đồng " + cboContractCode.SelectedValue.ToString() 
                                    + " sản phẩm " + cboProduct.SelectedValue.ToString()),
                                    Common.Constants.BusinessLogType.ExportData);
                            }
                            catch (Exception ex)
                            {
                                throw;
                            }
                            finally
                            {
                                if (da != null)
                                {
                                    da.Dispose();
                                }
                            }

                        };
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCboContractCode();
        }

        private void dtpMonth_Validated(object sender, EventArgs e)
        {
            LoadCboContractCode();
        }

        private void cboContractCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboContractCode.Items.Count > 0)
            {
                LoadCboProductCode();
            }
            else
            {
                cboProduct.Items.Clear();
            }
        }
    }
}
