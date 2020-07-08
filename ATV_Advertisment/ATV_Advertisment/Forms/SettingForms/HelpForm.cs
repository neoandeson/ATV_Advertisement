using ATV_Advertisment.Forms.CommonForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Advertisment.Forms.SettingForms
{
    public partial class HelpForm : CommonForm
    {
        public HelpForm()
        {
            InitializeComponent();

            rtb.Text = "A: Tổng quan \n" +
                "   A1.Menu Danh mục: cấu hình thông tin sử dụng(khách hàng, loại hình quảng cáo, buổi phát, thời điểm, thời lượng, giảm giá). \n" +
                "   A2.Menu Nhập liệu: nhập thông tin của hợp đồng quảng cáo. \n" +
                "   A3.Menu in ấn: xuất ra báo cáo(lịch phát sóng, doanh thu, đối chiếu công nợ, chứng nhận phát sóng, dự trù thời lượng, lịch đăng ký quảng cáo, bảng giá quảng cáo). \n" +
                "B: Mô tả \n" +
                "   B1.Một thời điểm phát bao gồm thông tin của buổi phát, thời lượng, loại quảng cáo, giá tiền. \n" +
                "   B2.Một hợp đồng có thể bao gồm nhiều sản phẩm quảng cáo, mỗi sản phẩm có Lịch Chiếu riêng \n" +
                "   B3.Lịch chiếu bao gồm thông tin: Sản phẩm, Ngày chiếu, Thời điểm, Số lượng, Thứ tự ưu tiên và Giá tiền. \n" +
                "   B4.In ấn: Xuất ra báo cáo tương ứng \n" +
                "C: Luồng chính: (Role Staff) \n" +
                "   C1.Nhập các thông tin cấu hình cần thiết trong phần Danh Mục \n" +
                "   C2.Nhập liệu Hợp đồng trong phần nhập liệu(thêm/ cập nhật) \n" +
                "   C3.Thêm mới Sản Phẩm trong Hợp đồng \n" +
                "   C4.Thêm mới Lịch Chiếu cho Sản Phẩm \n" +
                "   C5.Sửa lịch phát(nếu có) \n" +
                "D: Screen: Chức năng các màn hình \n" +
                "   D1.Danh mục khách hàng: quản lý thông tin khách hàng \n" +
                "   D2.Danh mục loại quảng cáo: quản lý thông tin loại hình quảng cáo \n" +
                "   D3.Danh mục buổi phát: quản lý thông tin buổi phát trong ngày \n" +
                "   D4.Danh mục thời điểm: quản lý thông tin thời điểm phát theo buổi \n" +
                "   D5.Danh mục thời lượng: quản lý thông tin thời lượng phát \n" +
                "   D6.Danh mục giảm giá: quản lý thông tin giảm giá dùng để in trong báo giá \n" +
                "   D7.Hợp đồng quảng cáo: quản lý thông tin hợp đồng quảng cáo, sản phẩm quảng cáo có trong hợp đồng và thời gian phát. \n" +
                "   D8.In lịch phát sóng: xuất ra lịch phát sóng theo ngày đến buổi sáng ngày hôm sau \n" +
                "   D9.Báo cáo doanh thu: xuất ra báo cáo doanh thu đến ngày hiện tại theo tháng \n" +
                "   D10.Đối chiếu công nợ: xuất ra báo cáo thành tiền của hợp đồng theo khách hàng \n" +
                "   D11.Chứng nhận phát sóng: xuất ra lịch phát sóng của một hợp đồng \n" +
                "   D12.Dự trù thời lượng: xuất ra thời gian theo giây dự trù sẽ phát quảng cáo theo khung giờ \n" +
                "   D13.Đăng ký quảng cáo: xuất ra lịch đăng ký quảng cáo của khách hàng theo tháng \n" +
                "   D14.Bảng giá quảng cáo: xuất ra bảng giá quảng cáo \n" +
                "   D15.Đổi Password: thay đổi mật khẩu của tài khoản hiện tại \n" +
                "   D16.Thông tin ứng dụng: hiển thị hướng dẫn\n" +
                "   D17. Thông tin ứng dụng: hiển thị hướng dẫn. \n" +
                "   D18.Tạo tài khoản: tạo tài khoản mới.";
        }
    }
}
