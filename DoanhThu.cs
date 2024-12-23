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
    public partial class DoanhThu : Form
    {
        private string connectionString = "Data Source=DESKTOP-CV18KAT;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        public DoanhThu()
        {
            InitializeComponent();
            // Điều chỉnh tự động kích thước cột dựa trên nội dung
            dgvDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Điều chỉnh tự động chiều cao hàng dựa trên nội dung
            //dgvDoanhThu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;



        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Gọi lại phương thức LoadDoanhThu với khoảng thời gian từ người dùng chọn
            LoadDoanhThu(dtpFromDate.Value, dtpToDate.Value);
        }
        public void LoadDoanhThu(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT HoaDon.NgayTao, SUM(ChiTietHoaDon.SoLuong * Menu.Gia) AS TongDoanhThu " +
                               "FROM HoaDon " +
                               "JOIN ChiTietHoaDon ON HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon " +
                               "JOIN Menu ON ChiTietHoaDon.MaMon = Menu.MaMon " +
                               "WHERE HoaDon.NgayTao BETWEEN @FromDate AND @ToDate " +
                               "GROUP BY HoaDon.NgayTao";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", startDate);
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", endDate);
                DataTable revenue = new DataTable();
                adapter.Fill(revenue);
                dgvDoanhThu.DataSource = revenue;

                decimal totalRevenue = 0;
                foreach (DataRow row in revenue.Rows)
                {
                    if (row["TongDoanhThu"] != DBNull.Value)
                    {
                        totalRevenue += Convert.ToDecimal(row["TongDoanhThu"]);
                    }
                }

                txtTongdoanhthu.Text = totalRevenue.ToString("C0", new System.Globalization.CultureInfo("vi-VN"));
            }
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            // Kiểm tra và chỉ thêm các cột nếu chúng chưa tồn tại
            if (dgvDoanhThu.Columns.Count == 0)
            {
                dgvDoanhThu.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "NgayTao",
                    HeaderText = "Ngày Tạo",
                    DataPropertyName = "NgayTao"
                });
                dgvDoanhThu.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TongDoanhThu",
                    HeaderText = "Tổng Doanh Thu",
                    DataPropertyName = "TongDoanhThu"
                });
            }
        }
        public DateTime FromDate
        {
            get { return dtpFromDate.Value; }
        }

        public DateTime ToDate
        {
            get { return dtpToDate.Value; }
        }

        
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
