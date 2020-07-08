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
    public partial class ShowCommitmentPrintForm : Form
    {
        public ShowCommitmentPrintForm()
        {
            InitializeComponent();
            LoadCboCustomerCode();

            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpMonth.CustomFormat = "MM/yyyy";
            dtpMonth.ShowUpDown = true;
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
                string contracCode = cboContractCode.SelectedValue.ToString();
                string productName = cboProduct.SelectedValue.ToString();
                if (!string.IsNullOrWhiteSpace(contracCode) && !string.IsNullOrWhiteSpace(productName))
                {
                    ContractItem contractItem = new ContractItemService().GetByContractCodeAndProductName(contracCode, productName);
                    if (contractItem != null)
                    {
                        int contractDetailId = contractItem.Id;
                        string cdProductName = contractItem.FileName;

                        string exeFolder = Application.StartupPath;
                        string reportPath = Path.Combine(exeFolder, @"Reports\ShowCommitmentReport.rdlc");

                        //
                        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
                        {
                            SqlDataAdapter da = null;

                            try
                            {
                                string query = "SELECT ProductName, TimeSlot, ShowTime, TimeSlotCode, [1] as D1,[2] as D2,[3] as D3,[4] as D4,[5] as D5," +
                                    "[6] as D6,[7] as D7,[8] as D8,[9] as D9,[10] as D10, [11] as D11,[12] as D12,[13] as D13,[14] as D14,[15] as D15," +
                                    "[16] as D16,[17] as D17,[18] as D18,[19] as D19,[20] as D20,[21] as D21,[22] as D22,[23] as D23,[24] as D24, [25] as D25, " +
                                    "[26] as D26, [27] as D27, [28] as D28, [29] as D29, [30] as D30, [31] as D31, Qty " +
                                    "FROM" +
                                    "(" +
                                        "SELECT ProductName, TimeSlot, ShowTime, TimeSlotCode, " +
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
                                List<ViewModel.ShowCommitmentRM> commitments = Utilities.ConvertDataTable<ViewModel.ShowCommitmentRM>(dt);
                                List<ViewModel.SCommitmentMRM> reportData = new List<ViewModel.SCommitmentMRM>();
                                foreach (var cm in commitments)
                                {
                                    ViewModel.SCommitmentMRM sc = new ViewModel.SCommitmentMRM()
                                    {
                                        ShowTime = cm.ShowTime,
                                        TimeSlot = cm.TimeSlot,
                                        TimeSlotCode = cm.TimeSlotCode,
                                        Qty = cm.Qty,
                                        D1 = cm.D1 == 0 ? "" : cm.D1 + "",
                                        D2 = cm.D2 == 0 ? "" : cm.D2 + "",
                                        D3 = cm.D3 == 0 ? "" : cm.D3 + "",
                                        D4 = cm.D4 == 0 ? "" : cm.D4 + "",
                                        D5 = cm.D5 == 0 ? "" : cm.D5 + "",
                                        D6 = cm.D6 == 0 ? "" : cm.D6 + "",
                                        D7 = cm.D7 == 0 ? "" : cm.D7 + "",
                                        D8 = cm.D8 == 0 ? "" : cm.D8 + "",
                                        D9 = cm.D9 == 0 ? "" : cm.D9 + "",
                                        D10 = cm.D10 == 0 ? "" : cm.D10 + "",
                                        D11 = cm.D11 == 0 ? "" : cm.D11 + "",
                                        D12 = cm.D12 == 0 ? "" : cm.D12 + "",
                                        D13 = cm.D13 == 0 ? "" : cm.D13 + "",
                                        D14 = cm.D14 == 0 ? "" : cm.D14 + "",
                                        D15 = cm.D15 == 0 ? "" : cm.D15 + "",
                                        D16 = cm.D16 == 0 ? "" : cm.D16 + "",
                                        D17 = cm.D17 == 0 ? "" : cm.D17 + "",
                                        D18 = cm.D18 == 0 ? "" : cm.D18 + "",
                                        D19 = cm.D19 == 0 ? "" : cm.D19 + "",
                                        D20 = cm.D20 == 0 ? "" : cm.D20 + "",
                                        D21 = cm.D21 == 0 ? "" : cm.D21 + "",
                                        D22 = cm.D22 == 0 ? "" : cm.D22 + "",
                                        D23 = cm.D23 == 0 ? "" : cm.D23 + "",
                                        D24 = cm.D24 == 0 ? "" : cm.D24 + "",
                                        D25 = cm.D25 == 0 ? "" : cm.D25 + "",
                                        D26 = cm.D26 == 0 ? "" : cm.D26 + "",
                                        D27 = cm.D27 == 0 ? "" : cm.D27 + "",
                                        D28 = cm.D28 == 0 ? "" : cm.D28 + "",
                                        D29 = cm.D29 == 0 ? "" : cm.D29 + "",
                                        D30 = cm.D30 == 0 ? "" : cm.D30 + "",
                                        D31 = cm.D31 == 0 ? "" : cm.D31 + "",

                                    };
                                    reportData.Add(sc);
                                }

                                ReportParameterCollection reportParameters = new ReportParameterCollection();
                                reportParameters.Add(new ReportParameter("strDate", this.dtpMonth.Value.Month + "/" + this.dtpMonth.Value.Year));
                                reportParameters.Add(new ReportParameter("strProductName", contractItem.ProductName));
                                reportParameters.Add(new ReportParameter("strFileName", contractItem.FileName));
                                reportParameters.Add(new ReportParameter("strLength", contractItem.DurationSecond + " giây"));
                                reportParameters.Add(new ReportParameter("strFromToDate", string.Format("{0} đến {1}", firstDayOfMonth.ToShortDateString(), lastDayOfMonth.ToShortDateString())));
                                reportParameters.Add(new ReportParameter("intMaxDate", lastDayOfMonth.Day+""));

                                rptViewer.LocalReport.ReportPath = reportPath;
                                rptViewer.LocalReport.DataSources.Clear();
                                rptViewer.LocalReport.SetParameters(reportParameters);
                                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsShowCommitment", reportData.AsEnumerable()));
                                rptViewer.RefreshReport();
                                Logging.LogBusiness(string.Format("{0} {1} {2}",
                                    Common.Session.GetUserName(),
                                    Common.Constants.LogAction.ExportData, "chứng nhận phát sóng của khách hàng " + cboCustomer.SelectedValue.ToString() 
                                    + " mã hợp đồng " + cboContractCode.SelectedValue.ToString() 
                                    + " sản phẩm " + cboProduct.SelectedValue.ToString() 
                                    + " trong " + this.dtpMonth.Value.Month + "/" + this.dtpMonth.Value.Year),
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

        private void ShowCommitmentPrintForm_Load(object sender, EventArgs e)
        {

            this.rptViewer.RefreshReport();
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
