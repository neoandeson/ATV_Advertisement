using ATV_Advertisment.Common;
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
    public partial class ExpectedPrintForm : Form
    {
        public ExpectedPrintForm()
        {
            InitializeComponent();

            ckbHalfday.Checked = true;
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd/MM/yyyy";
            dtpDate.ShowUpDown = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(ckbHalfday.Checked)
            {
                PrintHalfday();
            } else
            {
                PrintAllDay();
            }
        }

        private void PrintAllDay()
        {
            try
            {
                string exeFolder = Application.StartupPath;
                string reportPath = Path.Combine(exeFolder, @"Reports\ExpectedReport.rdlc");

                //
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
                {
                    SqlDataAdapter da = null;

                    try
                    {
                        string query = "SELECT ROW_NUMBER() OVER (ORDER BY mt.FromHour) AS Num, mt.*, dd.ShowTime, dd.Duration " +
                            "FROM " +
                            "(SELECT ts.Code as TSCode, ts.Name as TSName, ts.FromHour, ss.Code as SSCode, ss.Name as SSName " +
                            "FROM    TimeSlot ts " +
                                    "INNER JOIN[Session] ss on ts.SessionCode = ss.Code " +
                                    "WHERE   ts.StatusId = 1) mt " +
                            "INNER JOIN " +
                            "( " +
                            "SELECT  TimeSlotCode, ShowTime, SUM(TimeSlotLength) as Duration " +
                            "FROM    ProductScheduleShow " +
                            "WHERE   YEAR(ShowDate) = @rptYear " +
                                    "AND MONTH(ShowDate) = @rptMonth " +
                                    "AND DAY(ShowDate) = @rptDay " +
                            "GROUP BY TimeSlotCode, ShowTime " +
                            ") dd on mt.TSCode = dd.TimeSlotCode";
                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@rptDay", this.dtpDate.Value.Day));
                        cmd.Parameters.Add(new SqlParameter("@rptYear", this.dtpDate.Value.Year));
                        cmd.Parameters.Add(new SqlParameter("@rptMonth", this.dtpDate.Value.Month));

                        da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        //List<ViewModel.RevenueRM> reportData = Utilities.ConvertDataTable<ViewModel.RevenueRM>(dt);

                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("strDate", string.Format("NGÀY {0} THÁNG {1} NĂM {2}", dtpDate.Value.Day, dtpDate.Value.Month, dtpDate.Value.Year)));

                        rptViewer.LocalReport.ReportPath = reportPath;
                        rptViewer.LocalReport.DataSources.Clear();
                        rptViewer.LocalReport.SetParameters(reportParameters);
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsExpectations", dt));
                        rptViewer.RefreshReport();

                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.ExportData, "bảng dự trù quảng cáo " + dtpDate.Value),
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
            catch (Exception ex)
            {
                throw;
            }
        }

        private void PrintHalfday()
        {
            try
            {
                string exeFolder = Application.StartupPath;
                string reportPath = Path.Combine(exeFolder, @"Reports\ExpectedHalfdayReport.rdlc");

                //
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
                {
                    SqlDataAdapter da = null;

                    try
                    {
                        DateTime nextDate = this.dtpDate.Value.AddDays(1);

                        string query = "SELECT ROW_NUMBER() OVER(ORDER BY mt.FromHour) AS Num, mt.*, dd.ShowTime, dd.Duration, dd.ShowDate " +
                            "FROM " +
                            "(SELECT ts.Code as TSCode, ts.Name as TSName, ts.FromHour, ss.Code as SSCode, ss.Name as SSName " +
                            "FROM    TimeSlot ts " +
                            "   INNER JOIN[Session] ss on ts.SessionCode = ss.Code " +
                            "WHERE   ts.StatusId = 1) mt " +
                            "INNER JOIN ( SELECT  TimeSlotCode, ShowTime, SUM(TimeSlotLength) as Duration, ShowDate " +
                            "FROM    ProductScheduleShow " +
                            "WHERE   ((MONTH(ShowDate) = @rptMonth AND DAY(ShowDate) = @rptDay AND YEAR(ShowDate) = @rptYear AND ShowTimeInt >= 1200) " +
                            "OR(MONTH(ShowDate) = @rptNextDayMonth AND DAY(ShowDate) = @rptNextDay AND YEAR(ShowDate) = @rptNextDayYear AND ShowTimeInt < 1156)) " +
                            "GROUP BY TimeSlotCode, ShowTime, ShowDate) dd on mt.TSCode = dd.TimeSlotCode";
                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@rptDay", this.dtpDate.Value.Day));
                        cmd.Parameters.Add(new SqlParameter("@rptMonth", this.dtpDate.Value.Month));
                        cmd.Parameters.Add(new SqlParameter("@rptYear", this.dtpDate.Value.Year));
                        cmd.Parameters.Add(new SqlParameter("@rptNextDay", nextDate.Day));
                        cmd.Parameters.Add(new SqlParameter("@rptNextDayMonth", nextDate.Month));
                        cmd.Parameters.Add(new SqlParameter("@rptNextDayYear", nextDate.Year));

                        da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        //List<ViewModel.RevenueRM> reportData = Utilities.ConvertDataTable<ViewModel.RevenueRM>(dt);

                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("strDate", string.Format("TỪ TRƯA {0}/{1}/{2} ĐẾN TRƯA {3}/{4}/{5} ",
                            dtpDate.Value.Day, dtpDate.Value.Month, dtpDate.Value.Year,
                            nextDate.Day, nextDate.Month, nextDate.Year)));

                        rptViewer.LocalReport.ReportPath = reportPath;
                        rptViewer.LocalReport.DataSources.Clear();
                        rptViewer.LocalReport.SetParameters(reportParameters);
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsExpectationHalfdays", dt));
                        rptViewer.RefreshReport();

                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.ExportData, "bảng dự trù quảng cáo " + dtpDate.Value),
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
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ExpectedPrintForm_Load(object sender, EventArgs e)
        {
            this.rptViewer.RefreshReport();
        }
    }
}
