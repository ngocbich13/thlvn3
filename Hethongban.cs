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
    public partial class Hethongban : Form
    {
        private string connectionString = "Data Source=DESKTOP-CV18KAT;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        public Hethongban()
        {
            InitializeComponent();
            LoadBan();
        }

        private void LoadBan()
        {
            flowLayoutPanelBan.Controls.Clear(); // Xóa danh sách cũ
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaBan, TenBan, TrangThai FROM Ban";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Button btnBan = new Button
                        {
                            Text = $"{row["TenBan"]}\n({row["TrangThai"]})",
                            Tag = row["MaBan"], // Lưu mã bàn vào Tag
                            Width = 150,
                            Height = 100,
                            BackColor = row["TrangThai"].ToString() == "Trống" ? Color.LightGreen : Color.LightSalmon
                        };

                        btnBan.Click += BtnBan_Click; // Thêm sự kiện click
                        flowLayoutPanelBan.Controls.Add(btnBan);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}", "Lỗi");
            }
        }
        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int maBan = (int)btn.Tag;
            string tenBan = "";
            string trangThai = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT TenBan, TrangThai FROM Ban WHERE MaBan = @MaBan";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaBan", maBan);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tenBan = reader["TenBan"].ToString();
                        trangThai = reader["TrangThai"].ToString();
                    }
                }

                // Instantiate Order form with necessary parameters
                Order goiMonForm = new Order(maBan, tenBan, trangThai);
                goiMonForm.ShowDialog();
                LoadBan(); // Cập nhật lại trạng thái bàn sau khi đóng form gọi món
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin bàn: {ex.Message}", "Lỗi");
            }
        }
        

        
        private void btnResetBan_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Ban SET TrangThai = N'Trống'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tất cả bàn đã được đặt về trạng thái trống.", "Thông báo");
                    LoadBan(); // Tải lại danh sách bàn
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đặt lại trạng thái bàn: {ex.Message}", "Lỗi");
            }
        }
        public void ReloadBan()
        {
            LoadBan(); // Gọi lại LoadBan để cập nhật lại giao diện
        }
    }
}
