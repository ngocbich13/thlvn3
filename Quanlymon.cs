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
    public partial class Quanlymon : Form
    {
        private string connectionString = "Data Source=DESKTOP-CV18KAT;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        public Quanlymon()
        {
            InitializeComponent();
            LoadDanhMuc();
            LoadMonAn();
            // Điều chỉnh tự động kích thước cột dựa trên nội dung
            dgvMonAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Điều chỉnh tự động chiều cao hàng dựa trên nội dung
            //dgvMonAn.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

                        cbDanhMucThemSua.DataSource = dt;
                        cbDanhMucThemSua.DisplayMember = "TenDanhMuc";
                        cbDanhMucThemSua.ValueMember = "MaDanhMuc";
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
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT Menu.MaMon, Menu.TenMon, Menu.Gia, DanhMuc.TenDanhMuc 
                                     FROM Menu 
                                     JOIN DanhMuc ON Menu.MaDanhMuc = DanhMuc.MaDanhMuc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dgvMonAn.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải món ăn: {ex.Message}", "Thông báo");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenMon = txtTimKiem.Text.Trim();
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
                    MessageBox.Show($"Lỗi khi tìm kiếm món ăn: {ex.Message}", "Thông báo");
                }
            }
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            LoadMonAn();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int maDanhMuc = (int)cbDanhMucThemSua.SelectedValue; // Lấy mã danh mục từ combo box

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy mã món cao nhất của danh mục này và cộng thêm 1
                    string getMaxMaMonQuery = "SELECT ISNULL(MAX(MaMon), 0) + 1 FROM Menu WHERE MaDanhMuc = @MaDanhMuc";
                    SqlCommand getMaxMaMonCmd = new SqlCommand(getMaxMaMonQuery, conn);
                    getMaxMaMonCmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);
                    int maMon = (int)getMaxMaMonCmd.ExecuteScalar();

                    // Thêm món mới vào Menu
                    string insertQuery = "INSERT INTO Menu (MaMon, TenMon, Gia, MaDanhMuc) VALUES (@MaMon, @TenMon, @Gia, @MaDanhMuc)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@MaMon", maMon);
                    insertCmd.Parameters.AddWithValue("@TenMon", txtTenMon.Text);
                    insertCmd.Parameters.AddWithValue("@Gia", float.Parse(txtGia.Text));
                    insertCmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);

                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm món thành công!", "Thông báo");
                LoadMonAn();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm món: {ex.Message}", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMonAn.SelectedRows.Count > 0)
                {
                    int idMon = (int)dgvMonAn.SelectedRows[0].Cells["MaMon"].Value;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = @"UPDATE Menu 
                                         SET TenMon = @TenMon, Gia = @Gia, MaDanhMuc = @MaDanhMuc 
                                         WHERE MaMon = @MaMon";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@TenMon", txtTenMon.Text);
                        cmd.Parameters.AddWithValue("@Gia", Convert.ToDouble(txtGia.Text));
                        cmd.Parameters.AddWithValue("@MaDanhMuc", cbDanhMucThemSua.SelectedValue);
                        cmd.Parameters.AddWithValue("@MaMon", idMon);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sửa món thành công!", "Thông báo");
                        LoadMonAn();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn món cần sửa.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa món: {ex.Message}", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMonAn.SelectedRows.Count > 0)
                {
                    int idMon = (int)dgvMonAn.SelectedRows[0].Cells["MaMon"].Value;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Menu WHERE MaMon = @MaMon";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaMon", idMon);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa món thành công!", "Thông báo");
                        LoadMonAn();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn món cần xóa.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa món: {ex.Message}", "Thông báo");
            }
        }

        private void cbDanhMucLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbDanhMucLoc.SelectedValue != null && int.TryParse(cbDanhMucLoc.SelectedValue.ToString(), out int idDanhMuc))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = @"SELECT Menu.MaMon, Menu.TenMon, Menu.Gia, DanhMuc.TenDanhMuc 
                                         FROM Menu 
                                         JOIN DanhMuc ON Menu.MaDanhMuc = DanhMuc.MaDanhMuc 
                                         WHERE Menu.MaDanhMuc = @MaDanhMuc";
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
