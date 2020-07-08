using ATV_Advertisment.Common;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
using System;
using System.IO;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;
using ATV_Advertisment.Reports;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;
using System.Linq;

namespace ATV_Advertisment.Forms.PrintForms
{
    public partial class SchedulePrintForm : Form
    {
        public SchedulePrintForm()
        {
            InitializeComponent();
            LoadEmails();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string exeFolder = Application.StartupPath;
                string reportPath = Path.Combine(exeFolder, @"Reports\ProductSchedule.rdlc");

                //
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
                {
                    SqlDataAdapter da = null;

                    try
                    {
                        DateTime nextDate = this.dtpDate.Value.AddDays(1);

                        string query = "SELECT	ShowDate, ShowTimeInt, TimeSlot, ShowTime, ProductName, TimeSlotLength " +
                            "FROM ProductScheduleShow " +
                            "WHERE ((MONTH(ShowDate) = @rptMonth AND DAY(ShowDate) = @rptDay AND YEAR(ShowDate) = @rptYear AND ShowTimeInt >= 1200) " +
                                    "OR (MONTH(ShowDate) = @rptNextDayMonth AND DAY(ShowDate) = @rptNextDay AND YEAR(ShowDate) = @rptNextDayYear AND ShowTimeInt < 1156)) " +
                            "ORDER BY ShowTimeInt, OrderNumber";
                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@rptYear", this.dtpDate.Value.Year));
                        cmd.Parameters.Add(new SqlParameter("@rptMonth", this.dtpDate.Value.Month));
                        cmd.Parameters.Add(new SqlParameter("@rptDay", this.dtpDate.Value.Day));
                        cmd.Parameters.Add(new SqlParameter("@rptNextDayYear", nextDate.Year));
                        cmd.Parameters.Add(new SqlParameter("@rptNextDayMonth", nextDate.Month));
                        cmd.Parameters.Add(new SqlParameter("@rptNextDay", nextDate.Day));

                        da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        List<ViewModel.ProductScheduleShowRM> reportData = Utilities.ConvertDataTable<ViewModel.ProductScheduleShowRM>(dt);
                        reportData = reportData.OrderBy(r => r.ShowTime).ToList();

                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("strDate", string.Format("NGÀY {0} THÁNG {1} NĂM {2}", this.dtpDate.Value.Day, this.dtpDate.Value.Month, this.dtpDate.Value.Year)));

                        rptViewer.LocalReport.ReportPath = reportPath;
                        rptViewer.LocalReport.DataSources.Clear();
                        rptViewer.LocalReport.SetParameters(reportParameters);
                        //rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsProductSchedule", dt));
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsProductSchedule", reportData.AsEnumerable()));
                        rptViewer.RefreshReport();

                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.ExportData, "lịch phát sóng ngày " + dtpDate.Value),
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

        private void LoadEmails()
        {
            SystemConfigService systemConfigService = null;
            try
            {
                systemConfigService = new SystemConfigService();
                var fromMail = systemConfigService.GetByName("FromEmail");
                var toMail = systemConfigService.GetByName("ToEmail");
                if (fromMail != null)
                {
                    txtFromEmail.Text = fromMail.ValueString;
                }
                if (toMail != null)
                {
                    txtToEmail.Text = toMail.ValueString;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                systemConfigService = null;
            }
        }

        private void SchedulePrintForm_Load(object sender, EventArgs e)
        {
            this.rptViewer.RefreshReport();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            // Variables
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            string exeFolder = Application.StartupPath;
            string reportPath = Path.Combine(exeFolder, @"Reports\ProductSchedule.rdlc");
            string outputReportPath = Path.Combine(exeFolder, @"OutputReports\LichQuangCao.xlsx");

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
            {
                SqlDataAdapter da = null;

                try
                {
                    DateTime nextDate = this.dtpDate.Value.AddDays(1);

                    string query = "SELECT	ShowDate, ShowTimeInt, TimeSlot, ShowTime, ProductName, TimeSlotLength " +
                        "FROM ProductScheduleShow " +
                        "WHERE ((MONTH(ShowDate) = @rptMonth AND DAY(ShowDate) = @rptDay AND YEAR(ShowDate) = @rptYear AND ShowTimeInt >= 1200) " +
                                "OR (MONTH(ShowDate) = @rptNextDayMonth AND DAY(ShowDate) = @rptNextDay AND YEAR(ShowDate) = @rptNextDayYear AND ShowTimeInt < 1156)) " +
                        "ORDER BY ShowTimeInt, OrderNumber";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@rptYear", this.dtpDate.Value.Year));
                    cmd.Parameters.Add(new SqlParameter("@rptMonth", this.dtpDate.Value.Month));
                    cmd.Parameters.Add(new SqlParameter("@rptDay", this.dtpDate.Value.Day));
                    cmd.Parameters.Add(new SqlParameter("@rptNextDayYear", nextDate.Year));
                    cmd.Parameters.Add(new SqlParameter("@rptNextDayMonth", nextDate.Month));
                    cmd.Parameters.Add(new SqlParameter("@rptNextDay", nextDate.Day));

                    da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ReportParameterCollection reportParameters = new ReportParameterCollection();
                    reportParameters.Add(new ReportParameter("strDate", string.Format("NGÀY {0} THÁNG {1} NĂM {2}", this.dtpDate.Value.Day, this.dtpDate.Value.Month, this.dtpDate.Value.Year)));

                    rptViewer.LocalReport.ReportPath = reportPath;
                    rptViewer.LocalReport.DataSources.Clear();
                    rptViewer.LocalReport.SetParameters(reportParameters);
                    rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsProductSchedule", dt));
                    rptViewer.RefreshReport();

                    //
                    byte[] bytes = rptViewer.LocalReport.Render("EXCELOPENXML", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                    if (bytes != null)
                    {
                        BinaryWriter writer = null;

                        try
                        {
                            writer = new BinaryWriter(File.OpenWrite(outputReportPath));
                            writer.Write(bytes);
                            writer.Flush();
                        }
                        catch
                        {
                            throw;
                        }
                        finally
                        {
                            if(writer != null)
                            {
                                writer.Close();
                            }
                        }


                        string fromMail = txtFromEmail.Text.Trim();
                        string fromPassword = txtFromPassword.Text.Trim();
                        string toMail = txtToEmail.Text.Trim();
                        EmailService emailService = new EmailService();
                        emailService.SendMailWithAttachment(fromMail, fromPassword, toMail,
                            "Lịch quảng cáo ngày " + this.dtpDate.Value.Day + "/" + this.dtpDate.Value.Month + "/" + this.dtpDate.Value.Year,
                            "Nội dung trong file đính kèm",
                            outputReportPath);
                        emailService = null;
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.ExportData, "lịch phát sóng ngày " + dtpDate.Value + " và gửi mail cho " + txtToEmail.Text),
                            Common.Constants.BusinessLogType.ExportData);
                    }
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

        private void btnSaveEmailInfo_Click(object sender, EventArgs e)
        {
            SystemConfigService systemConfigService = null;
            try
            {
                systemConfigService = new SystemConfigService();
                var fromEmail = systemConfigService.GetByName("FromEmail");
                var toEmail = systemConfigService.GetByName("ToEmail");

                if (fromEmail != null)
                {
                    fromEmail.ValueString = txtFromEmail.Text.Trim();
                    systemConfigService.EditSystemConfig(fromEmail);
                }
                if (toEmail != null)
                {
                    toEmail.ValueString = txtToEmail.Text.Trim();
                    systemConfigService.EditSystemConfig(toEmail);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                systemConfigService = null;
            }
        }
    }
}
