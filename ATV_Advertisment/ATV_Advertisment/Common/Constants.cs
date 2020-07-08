using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Advertisment.Common
{
    public static class Constants
    {
        public static class CommonStatus
        {
            public static int ACTIVE = 1;
            public static int DISABLE = 0;
            public static int DELETE = -1;
            //Contract
            public static int CANCEL = -2;
        }

        public static class CommonMessage
        {
            public static string INVALID_LOGIN = "Thông tin đăng nhâp không đúng";
            public static string UNAUTHORIZED = "Không có quyền truy cập";
            public static string ALREADY_LOGIN = "Tài khoản hiện đang được đăng nhập";

            public static string APPLICATION_IS_RUNNING = "Ứng dụng đang chạy";
            public static string CUSTOMER_NOTFOUND = "Không tìm thấy thông tin khách hàng";
            public static string ADD_SUCESSFULLY = "Thêm mới thành công";
            public static string EXPORT_SUCESSFULLY = "Xuất file thành công";
            public static string EXPORT_FAIL = "Xuất file không thành công, không tìm thấy dữ liệu";
            public static string EDIT_SUCESSFULLY = "Cập nhật thành công";
            public static string DELETE_SUCESSFULLY = "Xóa thành công";
            public static string UPDATE_SUCESSFULLY = "Cập nhật thành công";
            public static string CANCEL_SUCESSFULLY = "Cập nhật thành công";

            public static string CONFIRM_DELETE = "Có phải bạn muốn xóa thông tin này ?";
            public static string CONFIRM_CANCLE = "Có phải bạn muốn hủy thông tin này ?";

            public static string USED_CODE = "Mã đã được sử dụng";
            public static string USED_CODE_LENGTH = "Thời điểm có (Mã, Thời lượng) này đã được tạo";

            public static string EXISTED_PRODUCT_IN_CONTRACT = "Sản phẩm đã được tạo trong hợp đồng";
            public static string EXISTED_PRODUCT_SCHEDULE = "Sản phẩm đã được tạo lịch vào (Thời điểm phát, Ngày chiếu) này";
        }

        public static class ADGVText
        {
            //Customers, Sessions(Name, Code)
            public static string Name = "Tên";
            public static string Code = "Mã";
            public static string Address = "Địa chỉ";
            public static string TaxCode = "Mã số thuế";
            //ShowTypes, CostRules(ShowType), Contract(ShowType)
            public static string Description = "Mô tả";
            public static string ShowType = "Loại hình";
            //Discounts
            public static string PriceRate = "Mức giá";
            public static string Discount = "Giảm giá (%)";
            //Durations, TimSlots(Duration), CostRule(Duration)
            public static string Duration = "Thời lượng (s)";
            //TimSlots
            public static string Session = "Buổi";
            //Contracts
            public static string CustomerCode = "Mã KH";
            public static string ContractCode = "Mã HĐ";
            public static string StartDate = "Bắt đầu";
            public static string EndDate = "Kết thúc";
            public static string ContractType = "Loại HĐ";
            public static string Cost = "Giá tiền (VNĐ)";
            //ContractDetail, ProductScheduleShow(NumberOfShow)
            public static string BelongToContractCode = "Mã hợp đồng";
            public static string ShowDate = "Ngày chiếu";
            public static string TimeSlot = "Khung giờ";
            public static string ShowTime = "Giờ chiếu";
            public static string NumberOfShow = "Số lượng";
            public static string TotalCost = "Thành tiền (VNĐ)";
            public static string ProductName = "Tên sản phẩm";
            public static string OrderNumber = "Thứ tự";
            //Logging
            public static string Content = "Nội dung";
            public static string ActUser = "Tác giả";
            public static string ActType = "Loại";
            public static string ActDate = "Ngày";
        }

        public static class BusinessLogType
        {
            public static int Login = 1;
            public static int Logout = 2;
            public static int Create = 3;
            public static int Delete = 4;
            public static int Update = 5;
            public static int ExportData = 6;
        }

        public static class SystemLogType
        {
            public static int Exception = 1;
            public static int Backup = 2;
        }

        public static class LogAction
        {
            public static string Create = "Tạo";
            public static string Delete = "Xóa";
            public static string Update = "Sửa";
            public static string Cancle = "Hủy";
            public static string ExportData = "Xuất file";
        }

        public static class CRUDStatusCode
        {
            public static int ERROR = 0;
            public static int SUCCESS = 1;
            public static int EXISTED = 2;
        }

        #region Controls
        public static class ControlsAttribute
        {
            public static int TEXTBOX_WIDTH_SMALL = 100;
            public static int TEXTBOX_WIDTH_NORMAL = 140;
            public static int TEXTBOX_HEIGHT = 26;

            public static int GV_WIDTH_SMALL = 50;
            public static int GV_WIDTH_SEEM = 100;
            public static int GV_WIDTH_NORMAL = 150;
            public static int GV_WIDTH_MEDIUM = 170;
            public static int GV_WIDTH_LARGE = 230;
        }
        #endregion

        #region
        public static class ReportText
        {
            public static string ADSVERTISE_SCHEDULE = "LỊCH QUẢNG CÁO";
            public static string REVENUE_REPORT = "BÁO CÁO DOANH THU THÁNG";
        }
        #endregion
    }
}
