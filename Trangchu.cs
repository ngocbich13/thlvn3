using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe_THLVN
{
    public partial class Trangchu : Form
    {
        private string LoaiNguoiDung;
        public Trangchu(string loaiNguoiDung)
        {
            InitializeComponent();
            LoaiNguoiDung = loaiNguoiDung;
            PhanQuyen();
        }

        // Phân quyền dựa trên loại người dùng
        private void PhanQuyen()
        {
            if (LoaiNguoiDung == "Admin")
            {
                // Nếu là Admin, cho phép truy cập tất cả các chức năng
                quảnLýMenuToolStripMenuItem.Enabled = true;
                danhMụcToolStripMenuItem.Enabled = true;
                hệThốngBànToolStripMenuItem.Enabled = true;
                tàiKhoảnToolStripMenuItem1.Enabled = true;
                doanhThuToolStripMenuItem.Enabled = true;
                đăngXuấtToolStripMenuItem.Enabled = true;
                đổiMậtKhẩuToolStripMenuItem.Enabled = true;
            }
            else if (LoaiNguoiDung == "Nhân viên")
            {
                // Nếu là Nhân viên, ẩn những chức năng không cần thiết
                quảnLýMenuToolStripMenuItem.Enabled = false;
                danhMụcToolStripMenuItem.Enabled = false;
                hệThốngBànToolStripMenuItem.Enabled = true;  // Nhân viên có thể truy cập vào hệ thống bàn
                tàiKhoảnToolStripMenuItem1.Enabled = false;
                doanhThuToolStripMenuItem.Enabled = false;
                đăngXuấtToolStripMenuItem.Enabled = true;
                đổiMậtKhẩuToolStripMenuItem.Enabled = true;
            }
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Danhmuc f = new Danhmuc();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlymon f = new Quanlymon();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doimatkhau f = new Doimatkhau();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?","Xác nhận đăng xuất",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form Trang chủ, form Đăng nhập sẽ hiện lại
            }
        }

        private void tàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Quanlytaikhoan f = new Quanlytaikhoan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoanhThu f = new DoanhThu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void hệThốngBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hethongban f = new Hethongban();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
