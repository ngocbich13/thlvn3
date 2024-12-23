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
    public partial class HoaDon : Form
    {
        private string connectionString = "Data Source=DESKTOP-CV18KAT;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        private int maBan;
        private int maHoaDon;
        public HoaDon(int maBan, string tenBan, string trangThai, int maHoaDon)
        {
            InitializeComponent();
            lblTenBan.Text = tenBan;
            lblTrangThai.Text = trangThai;
            this.maBan = maBan;
            this.maHoaDon = maHoaDon;
            LoadThongTinBan();
            LoadHoaDon(maHoaDon);
            // Điều chỉnh tự động kích thước cột dựa trên nội dung
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Điều chỉnh tự động chiều cao hàng dựa trên nội dung
            dgvChiTiet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

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
                            lblTrangThai.Text = $"Trạng thái: {reader["TrangThai"]}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin bàn: {ex.Message}", "Lỗi");
            }
        }

        private void LoadHoaDon(int maHoaDon)
        {
            string query = @"SELECT m.TenMon, cthd.SoLuong, cthd.ThanhTien 
                     FROM ChiTietHoaDon cthd
                     JOIN Menu m ON cthd.MaMon = m.MaMon
                     WHERE cthd.MaHoaDon = @MaHoaDon";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvChiTiet.DataSource = dt;

                // Tính tổng tiền
                double tongTien = 0;
                foreach (DataRow row in dt.Rows)
                {
                    tongTien += Convert.ToDouble(row["ThanhTien"]);
                }

                // Hiển thị tổng tiền lên lblTongTien
                lblTongTien.Text = $"Tổng Tiền: {tongTien:N0} VNĐ";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            ThanhToan formThanhToan = new ThanhToan(maBan, lblTenBan.Text, lblTrangThai.Text, maHoaDon);
            formThanhToan.ShowDialog();
            this.Close();
        }

        private void lblTrangThai_Click(object sender, EventArgs e)
        {

        }
    }
}
