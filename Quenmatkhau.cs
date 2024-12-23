using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe_THLVN
{
    public partial class Quenmatkhau : Form
    {
        public Quenmatkhau()
        {
            InitializeComponent();
        }

        private void btnGuiMaXacNhan_Click(object sender, EventArgs e)
        {
            string input = txbPhone.Text;

            // Kiểm tra xem người dùng nhập vào là email hay số điện thoại
            if (IsValidPhoneNumber(input))
            {
                // Nếu là số điện thoại
                string maXacNhan = GenerateRandomCode(6); // Tạo mã xác nhận ngẫu nhiên 6 ký tự
                MessageBox.Show($"Mã xác nhận đã được gửi đến số điện thoại: {input}.", "Thông báo");
                MessageBox.Show($"Mã xác nhận: {maXacNhan}", "Thông báo");

                // Đóng form hiện tại và mở form Quên Mật Khẩu 2
                this.Hide();
                var frmQuenMatKhau2 = new Quenmatkhau2(maXacNhan, input); // Truyền mã xác nhận và email/sdt
                frmQuenMatKhau2.ShowDialog();
                this.Close();  // Đảm bảo form Quên Mật Khẩu sẽ đóng lại khi mở form mới
            }
            
            else
            {
                // Nếu không phải email hay số điện thoại hợp lệ
                MessageBox.Show("Vui lòng nhập địa chỉ email hoặc số điện thoại hợp lệ.", "Thông báo");
            }
        }
        private string GenerateRandomCode(int length)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";  // Các ký tự hợp lệ
            StringBuilder code = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                code.Append(validChars[random.Next(validChars.Length)]);
            }

            return code.ToString();
        }
       
        // Kiểm tra số điện thoại hợp lệ (giả sử là 10-11 chữ số)
        private bool IsValidPhoneNumber(string phone)
        {
            string pattern = @"^\d{10,11}$"; // Kiểm tra số điện thoại có 10 hoặc 11 chữ số
            return Regex.IsMatch(phone, pattern);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
