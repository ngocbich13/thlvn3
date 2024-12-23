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
    public partial class Dangki : Form
    {
        private string connectionString = "Data Source=DESKTOP-CV18KAT;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        public Dangki()
        {
            InitializeComponent();
            LoadLoaiNguoiDung();
        }

        private void LoadLoaiNguoiDung()
        {
            // Dữ liệu nạp vào ComboBox (LoaiNguoiDung)
            string query = "SELECT DISTINCT LoaiNguoiDung FROM TaiKhoan";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Thêm từng giá trị loại người dùng vào ComboBox
                        cbPhanLoaiNguoiDung.Items.Add(reader["LoaiNguoiDung"].ToString());
                    }

                    // Chọn giá trị mặc định nếu có dữ liệu
                    if (cbPhanLoaiNguoiDung.Items.Count > 0)
                    {
                        cbPhanLoaiNguoiDung.SelectedIndex = 0; // Đặt mặc định giá trị đầu tiên
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nạp loại người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txbMatKhau.Text != txbNhapLaiMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.");
                return;
            }

            // Kiểm tra tên đăng nhập và mật khẩu
            if (string.IsNullOrEmpty(txbTenDangNhap.Text) || string.IsNullOrEmpty(txbMatKhau.Text))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được bỏ trống.", "Thông báo");
                return;
            }

            // Kiểm tra người dùng đã chọn loại người dùng từ ComboBox
            if (cbPhanLoaiNguoiDung.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phân loại người dùng.", "Thông báo");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, Email, SoDienThoai, LoaiNguoiDung) VALUES (@TenDangNhap, @MatKhau, @HoTen, @Email, @SoDienThoai, @LoaiNguoiDung)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@TenDangNhap", txbTenDangNhap.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txbMatKhau.Text);
                cmd.Parameters.AddWithValue("@HoTen", txbHoTen.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txbSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@LoaiNguoiDung", cbPhanLoaiNguoiDung.SelectedItem.ToString()); // Lấy giá trị được chọn từ ComboBox

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đăng ký tài khoản khách hàng thành công!", "Thông báo");
                    this.Close(); // Đóng form sau khi đăng ký thành công
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đăng ký tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelDangnhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
