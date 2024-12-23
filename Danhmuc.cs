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
    public partial class Danhmuc : Form
    {
        private string connectionString = "Data Source=DESKTOP-CV18KAT;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        public Danhmuc()
        {
            InitializeComponent();
            LoadDanhMuc();
            // Điều chỉnh tự động kích thước cột dựa trên nội dung
            dgvDanhMuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Điều chỉnh tự động chiều cao hàng dựa trên nội dung
            dgvDanhMuc.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void LoadDanhMuc()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dgvDanhMuc.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh mục: {ex.Message}");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Lấy mã danh mục cao nhất
                    string getMaxIdQuery = "SELECT ISNULL(MAX(MaDanhMuc), 0) + 1 FROM DanhMuc";
                    SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, conn);

                    conn.Open();
                    int newMaDanhMuc = (int)getMaxIdCmd.ExecuteScalar();

                    string insertQuery = "INSERT INTO DanhMuc (MaDanhMuc, TenDanhMuc) VALUES (@MaDanhMuc, @TenDanhMuc)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@MaDanhMuc", newMaDanhMuc);
                    insertCmd.Parameters.AddWithValue("@TenDanhMuc", txtTenDanhMuc.Text);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm danh mục thành công!","Thông báo");
                    LoadDanhMuc();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm danh mục: {ex.Message}", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDanhMuc.SelectedRows.Count > 0)
                {
                    int maDanhMuc = (int)dgvDanhMuc.SelectedRows[0].Cells["MaDanhMuc"].Value;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Xóa các món thuộc danh mục trước
                        string deleteMenuQuery = "DELETE FROM Menu WHERE MaDanhMuc = @MaDanhMuc";
                        SqlCommand deleteMenuCmd = new SqlCommand(deleteMenuQuery, conn);
                        deleteMenuCmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);
                        deleteMenuCmd.ExecuteNonQuery();

                        // Xóa danh mục
                        string deleteDanhMucQuery = "DELETE FROM DanhMuc WHERE MaDanhMuc = @MaDanhMuc";
                        SqlCommand deleteDanhMucCmd = new SqlCommand(deleteDanhMucQuery, conn);
                        deleteDanhMucCmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);
                        deleteDanhMucCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo");
                    LoadDanhMuc();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn danh mục cần xóa.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa danh mục: {ex.Message}", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDanhMuc.SelectedRows.Count > 0)
                {
                    int idDanhMuc = (int)dgvDanhMuc.SelectedRows[0].Cells["MaDanhMuc"].Value;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE DanhMuc SET TenDanhMuc = @TenDanhMuc WHERE MaDanhMuc = @MaDanhMuc";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@TenDanhMuc", txtTenDanhMuc.Text);
                        cmd.Parameters.AddWithValue("@MaDanhMuc", idDanhMuc);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Sửa danh mục thành công!", "Thông báo");
                        LoadDanhMuc();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn danh mục cần sửa.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa danh mục: {ex.Message}", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];
                txtTenDanhMuc.Text = row.Cells["TenDanhMuc"].Value.ToString();
            }
        }
    }
}
