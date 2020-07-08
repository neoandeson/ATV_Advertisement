using ATV_Advertisment.ViewModel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Reports
{
    public class RevenueReport
    {
        //public void ExportToExcel(IEnumerable<RevenueRM> reportModels, FileInfo targetFile, int year, int month)
        //{
        //    if (reportModels.FirstOrDefault() != null)
        //    {
        //        using (var excelFile = new ExcelPackage(targetFile))
        //        {
        //            //Clear sheet
        //            var clearWorksheet = excelFile.Workbook.Worksheets.FirstOrDefault();
        //            if(clearWorksheet != null)
        //            {
        //                excelFile.Workbook.Worksheets.Delete(clearWorksheet);
        //            }

        //            //Tạo ra sheet

        //            ExcelWorksheet worksheet = excelFile.Workbook.Worksheets.FirstOrDefault();
        //            //ExcelWorksheet worksheet = excelFile.Workbook.Worksheets[showDate]; // add a new worksheet to the empty workbook
        //            if (worksheet == null)
        //            {
        //                worksheet = excelFile.Workbook.Worksheets.Add("abc"); // add a new worksheet to the empty workbook    
        //            }
        //            worksheet.Name = "def";

        //            //In tiêu đề
        //            worksheet.Cells["A1"].Value = ReportText.REVENUE_REPORT + " " + month + "/" + year;
        //            worksheet.Cells["A1:E1"].Style.Font.Bold = true;
        //            worksheet.Cells["A1:E1"].Style.Font.Size = 20;
        //            worksheet.Cells["A1:E1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells["A1:E1"].Style.Fill.BackgroundColor.SetColor(Color.Transparent);
        //            worksheet.Cells["A1:E1"].Style.Font.Color.SetColor(Color.Black);
        //            worksheet.Cells["A1:E1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //            worksheet.Cells["A1:E1"].Merge = true;

        //            //Set width
        //            worksheet.Column(1).Width = 12;
        //            worksheet.Column(2).Width = 55;
        //            worksheet.Column(3).Width = 15;
        //            worksheet.Column(4).Width = 15;
        //            worksheet.Column(5).Width = 25;

        //            //In tên cột
        //            worksheet.Cells["A2:E2"].Style.Font.Bold = true;
        //            worksheet.Cells["A2:E2"].Style.Font.Size = 12;
        //            worksheet.Cells["A2:E2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //            worksheet.Cells["A2"].Value = "Mã";
        //            worksheet.Cells["B2"].Value = "Đơn vị";
        //            worksheet.Cells["C2"].Value = "Chưa giảm";
        //            worksheet.Cells["D2"].Value = "Đã giảm";
        //            worksheet.Cells["E2"].Value = "Ghi chú";

        //            //In tổng cộng
        //            worksheet.Cells["A4"].Value = "Bằng chữ:";
        //            worksheet.Cells["B4"].Value = "Tổng cộng:";
        //            worksheet.Cells["C4"].Value = reportModels.Sum(m => m.SumCost);
        //            worksheet.Cells["C4"].Style.Numberformat.Format = "#,##0";
        //            worksheet.Cells["D4"].Value = reportModels.Sum(m => m.TotalCost);
        //            worksheet.Cells["D4"].Style.Numberformat.Format = "#,##0";

        //            worksheet.Cells["A5"].Value = "hai hai";
        //            worksheet.Cells["D5"].Value = "Ngày tháng năm";
        //            worksheet.Cells["D6"].Value = "Người báo cáo";

        //            //In báo cáo chèn
        //            worksheet.InsertRow(3, reportModels.Count());
        //            worksheet.Cells["A3"].LoadFromCollection(reportModels, false);

        //            //Format currency
        //            worksheet.Cells["C3:C" + reportModels.Count() + 3].Style.Numberformat.Format = "#,##0";
        //            worksheet.Cells["D3:D" + reportModels.Count() + 3].Style.Numberformat.Format = "#,##0";

        //            //Set border
        //            var modelCells = worksheet.Cells["A2"];
        //            var modelRows = reportModels.Count() + 2;
        //            string modelRange = "A2:E" + modelRows.ToString();
        //            var modelTable = worksheet.Cells[modelRange];

        //            // Assign borders
        //            modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //            modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //            modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //            modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

        //            //In số tiền bằng chữ


        //            excelFile.Save();
        //        }
        //    }
        //}

        public void ExportToExcel(IEnumerable<RevenueRM> reportModels, FileInfo targetFile, int year, int month)
        {
            if (reportModels.FirstOrDefault() != null)
            {
                var sPath = System.AppDomain.CurrentDomain.BaseDirectory;
                string templatePath = sPath + "RevenueTemplate.xlsx"; // the path of the template
                var templateFile = new FileInfo(templatePath);

                using (var excelFile = new ExcelPackage(targetFile, templateFile)) // creating a package with the given template, and our result as the new stream
                {
                    //Clear sheet
                    //var clearWorksheet = excelFile.Workbook.Worksheets.FirstOrDefault();
                    //if (clearWorksheet != null)
                    //{
                    //    excelFile.Workbook.Worksheets.Delete(clearWorksheet);
                    //}

                    //Tạo ra sheet

                    ExcelWorksheet worksheet = excelFile.Workbook.Worksheets.FirstOrDefault();
                    //ExcelWorksheet worksheet = excelFile.Workbook.Worksheets[showDate]; // add a new worksheet to the empty workbook
                    if (worksheet == null)
                    {
                        worksheet = excelFile.Workbook.Worksheets.Add("Doanh thu" + " " + month + "/" + year); // add a new worksheet to the empty workbook    
                    }
                    worksheet.Name = month + " " + year;

                    //In tiêu đề
                    worksheet.Cells["A1"].Value = ReportText.REVENUE_REPORT + " " + month + "/" + year;

                    //In báo cáo chèn
                    worksheet.InsertRow(3, reportModels.Count() - 1, 3 + reportModels.Count() - 1);
                    worksheet.Cells["A3"].LoadFromCollection(reportModels, false);

                    excelFile.Save(); // savin our work
                }
            }
        }
    }
}
