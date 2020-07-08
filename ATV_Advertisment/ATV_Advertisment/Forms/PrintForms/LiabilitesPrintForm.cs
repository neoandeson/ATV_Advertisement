using ATV_Advertisment.Common;
using ATV_Advertisment.Services;
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
    public partial class LiabilitesPrintForm : Form
    {
        public LiabilitesPrintForm()
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

        private void LiabilitesPrintForm_Load(object sender, EventArgs e)
        {
            this.rptViewer.RefreshReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string exeFolder = Application.StartupPath;
                string reportPath = Path.Combine(exeFolder, @"Reports\LiabilitiesReport.rdlc");

                //
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
                {
                    SqlDataAdapter da = null;

                    try
                    {
                        string query = "SELECT	ci.ProductName, ps.TimeSlot, ps.TimeSlotCode, ps.ShowTime, ps.TimeSlotLength, ps.Quantity, ps.Cost, ps.Cost * ps.Quantity as TotalCost, ct.Discount, ps.Cost * ps.Quantity - (ps.Cost * ps.Quantity * ct.Discount / 100) as FinalCost " +
                            "FROM ContractItem ci INNER JOIN ( " +
                                "SELECT  ContractDetailId, TimeSlot, TimeSlotCode, ShowTime, TimeSlotLength, Cost, COUNt(Id) as Quantity " +
                                "FROM    ProductScheduleShow " +
                                "WHERE   YEAR(ShowDate) = @rptYear " +
                                    "AND MONTH(ShowDate) = @rptMonth " +
                                "GROUP BY ContractDetailId, TimeSlot, TimeSlotCode, ShowTime, TimeSlotLength, Cost) ps on ci.Id = ps.ContractDetailId " +
                            "INNER JOIN[Contract] ct on ci.ContractCode = ct.Code " +
                            "WHERE ct.CustomerCode = @rptCustomerCode AND ci.StatusId = " + Constants.CommonStatus.ACTIVE + " " +
                            "GROUP BY ci.ProductName, ps.TimeSlot, ps.TimeSlotCode, ps.ShowTime, ps.TimeSlotLength, ps.Cost, ci.TotalCost, ct.Discount, ct.Cost, ps.Quantity";
                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@rptYear", this.dtpMonth.Value.Year));
                        cmd.Parameters.Add(new SqlParameter("@rptMonth", this.dtpMonth.Value.Month));
                        cmd.Parameters.Add(new SqlParameter("@rptCustomerCode", cboCustomer.SelectedValue));

                        da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        List<ViewModel.LiabilitiesRM> reportData = Utilities.ConvertDataTable<ViewModel.LiabilitiesRM>(dt);

                        DateTime today = Utilities.GetServerDateTimeNow();
                        string strToday = Utilities.DateToFormatVNDate(today);
                        var firstDayOfMonth = new DateTime(this.dtpMonth.Value.Year, this.dtpMonth.Value.Month, 1);
                        var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                        string customerName = new CustomerService().GetNameByCode(cboCustomer.SelectedValue.ToString());
                        var finalCost = (decimal)reportData.Sum(r => r.FinalCost);
                        string strTotal = MoneyToText.NumberToTextVN(finalCost);

                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("strMonthYear", this.dtpMonth.Value.Month + "/" + this.dtpMonth.Value.Year));
                        reportParameters.Add(new ReportParameter("strReportFromDate", firstDayOfMonth.ToShortDateString()));
                        reportParameters.Add(new ReportParameter("strReportToDate", lastDayOfMonth.ToShortDateString()));
                        reportParameters.Add(new ReportParameter("strTotal", strTotal));
                        reportParameters.Add(new ReportParameter("strCustomerName", customerName));

                        rptViewer.LocalReport.ReportPath = reportPath;
                        rptViewer.LocalReport.DataSources.Clear();
                        rptViewer.LocalReport.SetParameters(reportParameters);
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsLiabilities", dt));
                        rptViewer.RefreshReport();

                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.ExportData, "báo cáo công nợ của khách hàng " + cboCustomer.SelectedValue.ToString() + " trong " + this.dtpMonth.Value.Month + "/" + this.dtpMonth.Value.Year),
                            Common.Constants.BusinessLogType.ExportData);
                    }
                    catch (Exception)
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
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
