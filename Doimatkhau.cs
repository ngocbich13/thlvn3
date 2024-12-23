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
    public partial class Doimatkhau : Form
    {
        private string connectionString = "Data Source=DESKTOP-CV18KAT;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        public Doimatkhau()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txbTenDangNhap.Text;
            string matKhauCu = txbMatKhauCu.Text;
            string matKhauMoi = txbMatKhauMoi.Text;
            string nhapLaiMatKhauMoi = txbNhapLaiMatKhauMoi.Text;

            // Kiểm tra các điều kiện mật khẩu
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(nhapLaiMatKhauMoi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhauMoi != nhapLaiMatKhauMoi)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu nhập lại không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra mật khẩu cũ có đúng không
                    string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhauCu";
                    SqlCommand cmdCheck = new SqlCommand(query, conn);
                    cmdCheck.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmdCheck.Parameters.AddWithValue("@MatKhauCu", matKhauCu);

                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Cập nhật mật khẩu mới
                    string updateQuery = "UPDATE TaiKhoan SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";
                    SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn);
                    cmdUpdate.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);
                    cmdUpdate.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                    int rowsAffected = cmdUpdate.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();  // Đóng form sau khi thành công
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thay đổi mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
