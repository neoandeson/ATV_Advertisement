using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Reports;
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
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.PrintForms
{
    public partial class RevenuePrintForm : Form
    {
        private ContractService _contractService;
        private bool byMonth = true;

        public RevenuePrintForm()
        {
            InitializeComponent();

            rbMonth.Checked = true;
            lblPeriod.Visible = false;
            cboPeriod.Visible = false;
            Dictionary<int, int> periodOptions = new Dictionary<int, int>();
            periodOptions.Add(1, 1);
            periodOptions.Add(2, 2);
            periodOptions.Add(3, 3);
            periodOptions.Add(4, 4);
            Utilities.LoadComboBoxOptions(cboPeriod, periodOptions);

            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
            ps.Landscape = true;
            ps.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
            ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
            rptViewer.SetPageSettings(ps);

            dtpFromMonth.Format = DateTimePickerFormat.Custom;
            dtpFromMonth.CustomFormat = "MM/yyyy";
            dtpFromMonth.ShowUpDown = true;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string exeFolder = Application.StartupPath;
                string reportPath = Path.Combine(exeFolder, @"Reports\RevenueRpt.rdlc");

                //
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
                {
                    SqlDataAdapter da = null;

                    try
                    {
                        string query = "";
                        if (byMonth)
                        {
                            query = "select ct.Code, ct.CustomerName, sum(pd.Cost)AS Cost, sum(pd.Cost) - (sum(pd.Cost) * ct.Discount / 100) AS TotalCost " +
                                    "from ProductScheduleShow pd inner join ContractItem cti on pd.ContractDetailId = cti.Id " +
                                    "inner join [Contract] ct on ct.Code = cti.ContractCode " +
                                    "where YEAR(ShowDate) = @rptYear and MONTH(ShowDate) = @rptMonth group by ct.Code, ct.CustomerName, ct.Discount";
                        }

                        if (!byMonth)
                        {
                            query = "select ct.Code, ct.CustomerName, sum(pd.Cost)AS Cost, sum(pd.Cost) - (sum(pd.Cost) * ct.Discount / 100) AS TotalCost " +
                                    "from ProductScheduleShow pd inner join ContractItem cti on pd.ContractDetailId = cti.Id " +
                                    "inner join [Contract] ct on ct.Code = cti.ContractCode " +
                                    "where YEAR(ShowDate) = @rptYear and (MONTH(ShowDate) in ( ";

                            switch (cboPeriod.SelectedValue)
                            {
                                case 1: query += "1, 2, 3"; break;
                                case 2: query += "4, 5, 6"; break;
                                case 3: query += "7, 8, 9"; break;
                                case 4: query += "10, 11, 12"; break;
                            }

                            query += " )) group by ct.Code, ct.CustomerName, ct.Discount";
                        }

                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@rptYear", this.dtpFromMonth.Value.Year));
                        if (byMonth)
                        {
                            cmd.Parameters.Add(new SqlParameter("@rptMonth", this.dtpFromMonth.Value.Month));
                        }

                        da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        List<ViewModel.RevenueRM> reportData = Utilities.ConvertDataTable<ViewModel.RevenueRM>(dt);

                        DateTime today = Utilities.GetServerDateTimeNow();
                        string strToday = Utilities.DateToFormatVNDate(today);
                        var totalCost = (decimal)reportData.Sum(r => r.Cost);
                        string strTotal = MoneyToText.NumberToTextVN(totalCost);

                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("strMonthYear", this.dtpFromMonth.Value.Month + "/" + this.dtpFromMonth.Value.Year));
                        reportParameters.Add(new ReportParameter("strReportDate", strToday));
                        reportParameters.Add(new ReportParameter("strTotal", strTotal));

                        rptViewer.LocalReport.ReportPath = reportPath;
                        rptViewer.LocalReport.DataSources.Clear();
                        rptViewer.LocalReport.SetParameters(reportParameters);
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsRevenues", dt));
                        rptViewer.RefreshReport();
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.ExportData, "báo cáo doanh thu"),
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

        private List<ViewModel.RevenueRM> GetRevenues()
        {
            try
            {
                _contractService = new ContractService();
                var reportData = _contractService.GetRevenueRptByMonth(new DateTime(dtpFromMonth.Value.Year, dtpFromMonth.Value.Month, 1));
                return reportData;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _contractService = null;
            }
        }

        private void RevenuePrintForm_Load(object sender, EventArgs e)
        {

            this.rptViewer.RefreshReport();
            this.rptViewer.RefreshReport();
        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            lblStart.Visible = true;
            dtpFromMonth.Visible = true;
            lblPeriod.Visible = false;
            cboPeriod.Visible = false;
            byMonth = true;
        }

        private void rbPeriod_CheckedChanged(object sender, EventArgs e)
        {
            lblStart.Visible = false;
            dtpFromMonth.Visible = false;
            lblPeriod.Visible = true;
            cboPeriod.Visible = true;
            byMonth = false;
        }
    }
}
