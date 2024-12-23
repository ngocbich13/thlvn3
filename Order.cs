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
    public partial class Order : Form
    {
        private string connectionString = "Data Source=DESKTOP-CV18KAT;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        private int maBan;
        public Order(int maBan, string tenBan, string trangThai)
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadDanhMuc();
            LoadMonAn();
            //LoadBan();
            lblTenBan.Text = tenBan;
            lblTrangThai.Text = trangThai;
            this.maBan = maBan;
            LoadThongTinBan();
            LoadChiTietGoiMon();
            // Điều chỉnh tự động kích thước cột dựa trên nội dung
            dgvMonAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Điều chỉnh tự động chiều cao hàng dựa trên nội dung
            dgvMonAn.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

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
                    string query = "SELECT TenBan, TrangThai FROM Ban WHERE MaBan = @MaBan";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaBan", maBan);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTenBan.Text = reader["TenBan"].ToString();
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

        private void InitializeDataGridView()
        {
            if (dgvChiTiet.Columns.Count == 0)
            {
                dgvChiTiet.Columns.Add("MaMon", "Mã Món");
                dgvChiTiet.Columns.Add("TenMon", "Tên Món");
                dgvChiTiet.Columns.Add("Gia", "Giá");
                dgvChiTiet.Columns.Add("SoLuong", "Số Lượng");
                dgvChiTiet.Columns.Add("ThanhTien", "Thành Tiền");
            }
        }

        
        private void LoadDanhMuc()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        cbDanhMucLoc.DataSource = dt.Copy();
                        cbDanhMucLoc.DisplayMember = "TenDanhMuc";
                        cbDanhMucLoc.ValueMember = "MaDanhMuc";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh mục: {ex.Message}", "Thông báo");
            }
        }
        private void LoadMonAn()
        {
            string query = @"SELECT MaMon, TenMon, Gia FROM Menu";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvMonAn.DataSource = dt;
            }
        }
        private void LoadChiTietGoiMon()
        {
            dgvChiTiet.Rows.Clear();
        }

        private void dgvOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng đã chọn số lượng
            int soLuong = (int)numSoLuong.Value;

            if (soLuong <= 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng hợp lệ.", "Thông báo");
                return;
            }

            // Kiểm tra nếu có món được chọn trong dgvMonAn
            if (dgvMonAn.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvMonAn.SelectedRows)
                {
                    if (row.Cells["MaMon"].Value != null && row.Cells["TenMon"].Value != null && row.Cells["Gia"].Value != null)
                    {
                        // Thêm món vào DataGridView Chi Tiết với số lượng đã chọn từ NumericUpDown
                        dgvChiTiet.Rows.Add(
                            row.Cells["MaMon"].Value,   // Mã Món
                            row.Cells["TenMon"].Value,   // Tên Món
                            row.Cells["Gia"].Value,      // Giá
                            soLuong,                     // Số Lượng từ NumericUpDown
                            Convert.ToDouble(row.Cells["Gia"].Value) * soLuong  // Thành Tiền
                        );
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvChiTiet.SelectedRows)
                {
                    dgvChiTiet.Rows.Remove(row);
                }
            }
        }

        private void btnGuiDon_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có món ăn trong dgvChiTiet không
                if (dgvChiTiet.Rows.Count == 0)
                {
                    MessageBox.Show("Chưa có món ăn nào được chọn!", "Lỗi");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra xem bàn đã có hóa đơn chưa
                    int maHoaDon = GetCurrentHoaDon();

                    if (maHoaDon == -1)
                    {
                        // Nếu chưa có hóa đơn, tạo hóa đơn mới
                        string queryHoaDon = @"INSERT INTO HoaDon (MaBan, NgayTao, TongTien, DaThanhToan) 
                                       OUTPUT INSERTED.MaHoaDon
                                       VALUES (@MaBan, @NgayTao, 0, 0)";
                        SqlCommand cmdHoaDon = new SqlCommand(queryHoaDon, conn);
                        cmdHoaDon.Parameters.AddWithValue("@MaBan", maBan);
                        cmdHoaDon.Parameters.AddWithValue("@NgayTao", DateTime.Now);

                        maHoaDon = (int)cmdHoaDon.ExecuteScalar();  // Lấy Mã Hóa Đơn vừa tạo
                    }

                    // Cập nhật các chi tiết món ăn vào bảng ChiTietHoaDon
                    double tongTien = 0;
                    foreach (DataGridViewRow row in dgvChiTiet.Rows)
                    {
                        if (row.Cells["MaMon"].Value != null)
                        {
                            double thanhTien = Convert.ToDouble(row.Cells["ThanhTien"].Value);
                            tongTien += thanhTien;

                            string queryChiTiet = @"INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, ThanhTien) 
                                            VALUES (@MaHoaDon, @MaMon, @SoLuong, @ThanhTien)";
                            SqlCommand cmdChiTiet = new SqlCommand(queryChiTiet, conn);
                            cmdChiTiet.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                            cmdChiTiet.Parameters.AddWithValue("@MaMon", row.Cells["MaMon"].Value);
                            cmdChiTiet.Parameters.AddWithValue("@SoLuong", row.Cells["SoLuong"].Value);
                            cmdChiTiet.Parameters.AddWithValue("@ThanhTien", thanhTien);
                            cmdChiTiet.ExecuteNonQuery();
                        }
                    }

                    // Cập nhật tổng tiền cho hóa đơn
                    string queryUpdateHoaDon = "UPDATE HoaDon SET TongTien = @TongTien WHERE MaHoaDon = @MaHoaDon";
                    SqlCommand cmdUpdateHoaDon = new SqlCommand(queryUpdateHoaDon, conn);
                    cmdUpdateHoaDon.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdUpdateHoaDon.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmdUpdateHoaDon.ExecuteNonQuery();

                    // Cập nhật trạng thái bàn thành 'Đang sử dụng'
                    string queryUpdateBan = "UPDATE Ban SET TrangThai = N'Đang sử dụng' WHERE MaBan = @MaBan";
                    SqlCommand cmdUpdateBan = new SqlCommand(queryUpdateBan, conn);
                    cmdUpdateBan.Parameters.AddWithValue("@MaBan", maBan);
                    cmdUpdateBan.ExecuteNonQuery();

                    MessageBox.Show("Đặt đơn thành công!", "Thông báo");

                    // Kích hoạt nút xem hóa đơn
                    btnXemHoaDon.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi gửi đơn: {ex.Message}", "Lỗi");
            }
        }

        private void UpdateBanTrangThai(string trangThai)
        {
            string query = "UPDATE Ban SET TrangThai = @TrangThai WHERE MaBan = @MaBan";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@MaBan", maBan);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenMon = txtTim.Text.Trim();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"SELECT Menu.MaMon, Menu.TenMon, Menu.Gia, DanhMuc.TenDanhMuc 
                             FROM Menu 
                             JOIN DanhMuc ON Menu.MaDanhMuc = DanhMuc.MaDanhMuc 
                             WHERE Menu.TenMon LIKE @TenMon";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenMon", $"%{tenMon}%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dgvMonAn.DataSource = data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm món ăn: {ex.Message}");
                }
            }
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            LoadMonAn();
        }

        private void cbDanhMucLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbDanhMucLoc.SelectedValue != null && int.TryParse(cbDanhMucLoc.SelectedValue.ToString(), out int idDanhMuc))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Menu WHERE MaDanhMuc = @MaDanhMuc";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaDanhMuc", idDanhMuc);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        dgvMonAn.DataSource = data;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lọc món ăn: {ex.Message}", "Thông báo");
            }
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            int maHoaDon = GetCurrentHoaDon();
            if (maHoaDon > 0)
            {
                HoaDon formHoaDon = new HoaDon(maBan, lblTenBan.Text, lblTrangThai.Text, maHoaDon);
                formHoaDon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn.", "Thông báo");
            }
        }
        private int GetCurrentHoaDon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaHoaDon FROM HoaDon WHERE MaBan = @MaBan AND DaThanhToan = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaBan", maBan);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private void dgvChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvChiTiet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

    }
}
