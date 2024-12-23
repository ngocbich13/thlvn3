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
    public partial class Quanlytaikhoan : Form
    {
        private string connectionString = "Data Source=DESKTOP-CV18KAT;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        public Quanlytaikhoan()
        {
            InitializeComponent();
            LoadTaiKhoan();
            LoadLoaiNguoiDung();
            // Điều chỉnh tự động chiều cao hàng dựa trên nội dung
            dgvTaiKhoan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void LoadTaiKhoan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, HoTen, SoDienThoai, TenDangNhap, LoaiNguoiDung FROM TaiKhoan";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dgvTaiKhoan.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách tài khoản: {ex.Message}", "Thông báo");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO TaiKhoan (HoTen, SoDienThoai, TenDangNhap, MatKhau, LoaiNguoiDung) " +
                                   "VALUES (@HoTen, @SoDienThoai, @TenDangNhap, @MatKhau, @LoaiNguoiDung)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                    cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                    cmd.Parameters.AddWithValue("@LoaiNguoiDung", cmbLoaiNguoiDung.SelectedItem.ToString());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo");
                    LoadTaiKhoan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm tài khoản: {ex.Message}", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgvTaiKhoan.SelectedRows[0].Cells["ID"].Value.ToString());
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE TaiKhoan SET HoTen = @HoTen, SoDienThoai = @SoDienThoai, " +
                                       "TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, LoaiNguoiDung = @LoaiNguoiDung WHERE ID = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                        cmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                        cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text);
                        cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                        cmd.Parameters.AddWithValue("@LoaiNguoiDung", cmbLoaiNguoiDung.SelectedItem.ToString());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sửa tài khoản thành công!", "Thông báo");
                        LoadTaiKhoan();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi sửa tài khoản: {ex.Message}", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản để sửa!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgvTaiKhoan.SelectedRows[0].Cells["ID"].Value.ToString());
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM TaiKhoan WHERE ID = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa tài khoản thành công!", "Thông báo");
                        LoadTaiKhoan();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa tài khoản: {ex.Message}", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa!", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadLoaiNguoiDung()
        {
            

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
                            cmbLoaiNguoiDung.Items.Add(reader["LoaiNguoiDung"].ToString());
                        }
                    }

                    // Đặt giá trị mặc định nếu có dữ liệu
                    if (cmbLoaiNguoiDung.Items.Count > 0)
                    {
                        cmbLoaiNguoiDung.SelectedIndex = 0; // Đặt mặc định là loại đầu tiên
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nạp loại người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
