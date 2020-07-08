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
    public class ProductScheduleShowRpt
    {
        public void ExportToExcel(IEnumerable<ProductScheduleShowRM> reportModel, FileInfo targetFile)
        {
            //    string showDate = "";
            //    if (reportModel.FirstOrDefault() != null)
            //    {
            //        showDate = reportModel.FirstOrDefault().ShowDate;

            //        using (var excelFile = new ExcelPackage(targetFile))
            //        {
            //            ////Clear sheet
            //            //var worksheets = excelFile.Workbook.Worksheets.SingleOrDefault(x => x.Name == "Worksheet1");
            //            //excelFile.Workbook.Worksheets.Delete(worksheet);

            //            //Tạo ra sheet

            //            ExcelWorksheet worksheet = excelFile.Workbook.Worksheets.FirstOrDefault();
            //            //ExcelWorksheet worksheet = excelFile.Workbook.Worksheets[showDate]; // add a new worksheet to the empty workbook
            //            if (worksheet == null)
            //            {
            //                worksheet = excelFile.Workbook.Worksheets.Add(showDate); // add a new worksheet to the empty workbook    
            //            }
            //            worksheet.Name = showDate;

            //            //In tiêu đề
            //            worksheet.Cells["A1"].Value = ReportText.ADSVERTISE_SCHEDULE +  " " + showDate;
            //            worksheet.Cells["A1:F1"].Style.Font.Bold = true;
            //            worksheet.Cells["A1:F1"].Style.Font.Size = 20;
            //            worksheet.Cells["A1:F1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            worksheet.Cells["A1:F1"].Style.Fill.BackgroundColor.SetColor(Color.Transparent);
            //            worksheet.Cells["A1:F1"].Style.Font.Color.SetColor(Color.Black);
            //            worksheet.Cells["A1:F1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //            worksheet.Cells["A1:F1"].Merge = true;

            //            //Set width
            //            worksheet.Column(1).Width = 12;
            //            worksheet.Column(2).Width = 35;
            //            worksheet.Column(3).Width = 8;
            //            worksheet.Column(4).Width = 35;
            //            worksheet.Column(5).Width = 8;
            //            worksheet.Column(6).Width = 10;

            //            //In tên cột
            //            worksheet.Cells["A2:F2"].Style.Font.Bold = true;
            //            worksheet.Cells["A2:F2"].Style.Font.Size = 12;
            //            worksheet.Cells["A2:F2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //            worksheet.Cells["A2"].Value = "Ngày";
            //            worksheet.Cells["B2"].Value = "Khung giờ";
            //            worksheet.Cells["C2"].Value = "Giờ";
            //            worksheet.Cells["D2"].Value = "Mẩu quảng cáo";
            //            worksheet.Cells["E2"].Value = "TL";
            //            worksheet.Cells["F2"].Value = "Tổng TL";

            //            //In lịch
            //            worksheet.Cells["A3"].LoadFromCollection(reportModel, false);

            //            //Set border
            //            var modelCells = worksheet.Cells["A2"];
            //            var modelRows = reportModel.Count() + 2;
            //            string modelRange = "A2:F" + modelRows.ToString();
            //            var modelTable = worksheet.Cells[modelRange];

            //            // Assign borders
            //            modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            //            modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            //            modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            //            modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            //            excelFile.Save();
            //        }
            //    }
        }
    }
}
