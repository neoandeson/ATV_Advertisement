using Microsoft.Reporting.WinForms;
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
    public partial class ReportViewerForm : CommonForm
    {
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer;

        public ReportViewerForm()
        {
            InitializeComponent();
            reportViewer = rptViewer;
        }

        private void ReportViewerForm_Load(object sender, EventArgs e)
        {

            this.rptViewer.RefreshReport();
        }

        //public void ShowReport()
        //{
        //    ReportParameterCollection reportParameters = new ReportParameterCollection();
        //    reportParameters.Add(new ReportParameter("strMonthYear", this.dtpFromMonth.Value.Month + "/" + this.dtpFromMonth.Value.Year));
        //    reportParameters.Add(new ReportParameter("fltSubTotal", this.dtpFromMonth.Value.Month + "/" + this.dtpFromMonth.Value.Year));
        //    reportParameters.Add(new ReportParameter("fltTotal", this.dtpFromMonth.Value.Month + "/" + this.dtpFromMonth.Value.Year));
        //}
    }
}
