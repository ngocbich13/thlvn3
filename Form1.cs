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
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-CV18KAT;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        
        public Form1()
        {
            InitializeComponent();
            LoadLoaiNguoiDung();
            txbTendangnhap.Clear();  // Xóa tên đăng nhập
            txbMatkhau.Clear();  // Xóa mật khẩu
        }

        private void LoadLoaiNguoiDung()
        {
            // Chuỗi kết nối tới cơ sở dữ liệu
            string connectionString = "Data Source=DESKTOP-CV18KAT;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Truy vấn để lấy danh sách loại người dùng (loại bỏ trùng lặp)
                    string query = "SELECT DISTINCT LoaiNguoiDung FROM TaiKhoan";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Thêm từng loại người dùng vào ComboBox
                            cbPhanLoaiNguoiDung.Items.Add(reader["LoaiNguoiDung"].ToString());
                        }
                    }

                    // Đặt giá trị mặc định nếu có dữ liệu
                    if (cbPhanLoaiNguoiDung.Items.Count > 0)
                    {
                        cbPhanLoaiNguoiDung.SelectedIndex = 0; // Đặt mặc định là loại đầu tiên
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nạp loại người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbTendangnhap.Text) || string.IsNullOrEmpty(txbMatkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thông báo");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT LoaiNguoiDung FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau AND LoaiNguoiDung = @LoaiNguoiDung";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@TenDangNhap", txbTendangnhap.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", txbMatkhau.Text);
                    cmd.Parameters.AddWithValue("@LoaiNguoiDung", cbPhanLoaiNguoiDung.SelectedItem.ToString());

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string LoaiNguoiDung = reader["LoaiNguoiDung"].ToString();
                        Trangchu mainForm = new Trangchu(LoaiNguoiDung);
                        this.Hide();
                        mainForm.ShowDialog();
                        this.Show();

                        // Clear textboxes after successful login
                        txbTendangnhap.Clear();
                        txbMatkhau.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelQuenmatkhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Quenmatkhau f = new Quenmatkhau();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void linkLabelDangki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangki f = new Dangki();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txbMatkhau.PasswordChar = '\0'; // Hiển thị mật khẩu
            }
            else
            {
                txbMatkhau.PasswordChar = '*'; // Ẩn mật khẩu
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
