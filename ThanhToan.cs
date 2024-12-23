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
    public partial class ThanhToan : Form
    {

        private string connectionString = "Data Source=DESKTOP-CV18KAT;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        private int maBan;
        private int maHoaDon;
        public ThanhToan(int maBan, string tenBan, string trangThai, int maHoaDon)
        {
            InitializeComponent();
            this.maBan = maBan;
            this.maHoaDon = maHoaDon;
            lblTenBan.Text = tenBan;
            lblTrangThaiBan.Text = trangThai;
            LoadPhuongThucThanhToan();
            LoadThongTinBan();
            LoadHoaDon();
            txtGiamGia.Text = "0";
            // Điều chỉnh tự động kích thước cột dựa trên nội dung
            dgvChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Điều chỉnh tự động chiều cao hàng dựa trên nội dung
            dgvChiTietHoaDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void LoadHoaDon()
        {
            string query = @"SELECT m.TenMon, cthd.SoLuong, cthd.ThanhTien 
                     FROM ChiTietHoaDon cthd
                     JOIN Menu m ON cthd.MaMon = m.MaMon
                     WHERE cthd.MaHoaDon = @MaHoaDon";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvChiTietHoaDon.DataSource = dt;

                // Tính tổng tiền trước giảm giá
                double tongTienTruocGiam = 0;
                foreach (DataRow row in dt.Rows)
                {
                    tongTienTruocGiam += Convert.ToDouble(row["ThanhTien"]);
                }

                // Hiển thị tổng tiền trước giảm giá theo định dạng VNĐ
                txbTongTienTruocGiam.Text = tongTienTruocGiam.ToString("N0") + " VNĐ";

                UpdateTongTienSauGiam(); // Cập nhật tổng tiền sau giảm giá
            }
        }
        private void UpdateTongTienSauGiam()
        {
            // Lấy tổng tiền trước giảm giá
            double tongTienTruocGiam = string.IsNullOrEmpty(txbTongTienTruocGiam.Text) ? 0 : double.Parse(txbTongTienTruocGiam.Text.Replace(" VNĐ", ""));

            // Lấy tỷ lệ giảm giá (nhập dưới dạng phần trăm)
            double giamGiaPhanTram = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : double.Parse(txtGiamGia.Text);

            // Tính số tiền giảm (giảm giá phần trăm)
            double giamGia = tongTienTruocGiam * (giamGiaPhanTram / 100);

            // Tính tổng tiền sau giảm
            double tongTienSauGiam = tongTienTruocGiam - giamGia;

            // Đảm bảo tổng tiền không thể âm
            if (tongTienSauGiam < 0)
            {
                tongTienSauGiam = 0;
            }

            // Hiển thị tổng tiền sau giảm giá theo định dạng VNĐ
            txbTongTienSauGiam.Text = tongTienSauGiam.ToString("N0") + " VNĐ";
        }

        private void LoadThongTinBan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Sửa lại truy vấn để lấy thông tin bàn và trạng thái
                    string query = "SELECT TenBan, TrangThai FROM Ban WHERE MaBan = @MaBan";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaBan", maBan);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTenBan.Text = $"Bàn: {reader["TenBan"]}";
                            lblTrangThaiBan.Text = $"Trạng thái: {reader["TrangThai"]}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin bàn: {ex.Message}", "Lỗi");
            }
        }

        private void LoadPhuongThucThanhToan()
        {
            cbPhuongThucThanhToan.Items.Add("Tiền mặt");
            cbPhuongThucThanhToan.Items.Add("Thẻ tín dụng");
            cbPhuongThucThanhToan.Items.Add("Chuyển khoản");
            cbPhuongThucThanhToan.SelectedIndex = 0; // Chọn mặc định là Tiền mặt
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            double tongTienSauGiam = double.Parse(txbTongTienSauGiam.Text.Replace(" VNĐ", "")); // Loại bỏ " VNĐ" khi lấy giá trị

            string phuongThuc = cbPhuongThucThanhToan.SelectedItem?.ToString() ?? "Không xác định";

            string updateHoaDonQuery = @"UPDATE HoaDon 
                                 SET TongTien = @TongTienSauGiam, 
                                     DaThanhToan = 1, 
                                     PhuongThucThanhToan = @PhuongThucThanhToan,
                                     GiamGia = @GiamGia
                                 WHERE MaHoaDon = @MaHoaDon";

            string updateBanTrangThaiQuery = "UPDATE Ban SET TrangThai = N'Trống' WHERE MaBan = @MaBan";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Cập nhật hóa đơn
                    SqlCommand cmdHoaDon = new SqlCommand(updateHoaDonQuery, conn, transaction);
                    cmdHoaDon.Parameters.AddWithValue("@TongTienSauGiam", tongTienSauGiam);
                    cmdHoaDon.Parameters.AddWithValue("@GiamGia", string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : double.Parse(txtGiamGia.Text));
                    cmdHoaDon.Parameters.AddWithValue("@PhuongThucThanhToan", phuongThuc);
                    cmdHoaDon.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmdHoaDon.ExecuteNonQuery();

                    // Cập nhật bàn
                    SqlCommand cmdBan = new SqlCommand(updateBanTrangThaiQuery, conn, transaction);
                    cmdBan.Parameters.AddWithValue("@MaBan", maBan);
                    cmdBan.ExecuteNonQuery();

                    // Commit transaction
                    transaction.Commit();

                    MessageBox.Show("Thanh toán thành công!", "Thông báo");

                    // Gọi lại phương thức LoadDoanhThu ở form DoanhThu để làm mới dữ liệu
                    var doanhThuForm = Application.OpenForms.OfType<DoanhThu>().FirstOrDefault();
                    if (doanhThuForm != null)
                    {
                        doanhThuForm.LoadDoanhThu(doanhThuForm.FromDate, doanhThuForm.ToDate);
                    }

                    this.Close(); // Đóng form thanh toán
                }
                catch (Exception ex)
                {
                    // Rollback nếu có lỗi
                    transaction.Rollback();
                    MessageBox.Show($"Lỗi thanh toán: {ex.Message}", "Lỗi");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            UpdateTongTienSauGiam();
        }
    }
}
