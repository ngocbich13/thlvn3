using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe_THLVN
{
    public partial class Quenmatkhau2 : Form
    {
        private string _maXacNhan;
        private string _emailOrPhone;
        public Quenmatkhau2(string maXacNhan, string emailOrPhone)
        {
            InitializeComponent();
            _maXacNhan = maXacNhan;
            _emailOrPhone = emailOrPhone;
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã xác nhận
            if (txtMaXacNhan.Text != _maXacNhan)
            {
                MessageBox.Show("Mã xác nhận không chính xác.", "Thông báo");
                return;
            }

            // Kiểm tra mật khẩu nhập lại
            if (txtMatKhauMoi.Text != txtNhapLaiMatKhauMoi.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.", "Thông báo");
                return;
            }

            // Cập nhật mật khẩu mới vào cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection("Data Source=HELLO\\SQLEXPRESS;Initial Catalog=QuanLyQuanCafe;Integrated Security=True"))
            {
                string query = "UPDATE TaiKhoan SET MatKhau = @MatKhau WHERE Email = @Email OR SoDienThoai = @SoDienThoai";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MatKhau", txtMatKhauMoi.Text); // Thêm mật khẩu mới
                cmd.Parameters.AddWithValue("@Email", _emailOrPhone);  // Truyền email hoặc số điện thoại
                cmd.Parameters.AddWithValue("@SoDienThoai", _emailOrPhone); // Truyền email hoặc số điện thoại

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công!", "Thông báo");
                    this.Hide();
                    var frmDangNhap = new Form1(); // Quay lại form đăng nhập
                    frmDangNhap.Show();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật mật khẩu.", "Thông báo");
                }
            }
        }
    }
}
