namespace QuanLyQuanCafe_THLVN
{
    partial class Order
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order));
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.btnGuiDon = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTrove = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.cbDanhMucLoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTenBan = new System.Windows.Forms.Label();
            this.btnXemHoaDon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Location = new System.Drawing.Point(563, 211);
            this.dgvChiTiet.Margin = new System.Windows.Forms.Padding(5);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersWidth = 62;
            this.dgvChiTiet.Size = new System.Drawing.Size(596, 257);
            this.dgvChiTiet.TabIndex = 3;
            this.dgvChiTiet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDetails_CellContentClick);
            this.dgvChiTiet.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvChiTiet_CellValidating);
            this.dgvChiTiet.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellValueChanged);
            // 
            // btnGuiDon
            // 
            this.btnGuiDon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuiDon.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGuiDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiDon.Location = new System.Drawing.Point(563, 584);
            this.btnGuiDon.Margin = new System.Windows.Forms.Padding(5);
            this.btnGuiDon.Name = "btnGuiDon";
            this.btnGuiDon.Size = new System.Drawing.Size(183, 42);
            this.btnGuiDon.TabIndex = 2;
            this.btnGuiDon.Text = "Gửi Đơn";
            this.btnGuiDon.UseVisualStyleBackColor = false;
            this.btnGuiDon.Click += new System.EventHandler(this.btnGuiDon_Click);
            // 
            // panel8
            // 
            this.panel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel8.Controls.Add(this.label4);
            this.panel8.Location = new System.Drawing.Point(563, 141);
            this.panel8.Margin = new System.Windows.Forms.Padding(5);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(596, 60);
            this.panel8.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(114, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(386, 40);
            this.label4.TabIndex = 7;
            this.label4.Text = "CHI TIẾT ĐƠN HÀNG";
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThoat.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(976, 585);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(183, 42);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTrove
            // 
            this.btnTrove.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTrove.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnTrove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrove.Location = new System.Drawing.Point(1034, 75);
            this.btnTrove.Margin = new System.Windows.Forms.Padding(5);
            this.btnTrove.Name = "btnTrove";
            this.btnTrove.Size = new System.Drawing.Size(125, 42);
            this.btnTrove.TabIndex = 8;
            this.btnTrove.Text = "Trở về";
            this.btnTrove.UseVisualStyleBackColor = false;
            this.btnTrove.Click += new System.EventHandler(this.btnTrove_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTimKiem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(885, 75);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(5);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(125, 42);
            this.btnTimKiem.TabIndex = 7;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel7.Controls.Add(this.label3);
            this.panel7.Location = new System.Drawing.Point(-2, 141);
            this.panel7.Margin = new System.Windows.Forms.Padding(5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(557, 60);
            this.panel7.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(225, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 40);
            this.label3.TabIndex = 6;
            this.label3.Text = "MENU";
            // 
            // txtTim
            // 
            this.txtTim.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTim.Location = new System.Drawing.Point(617, 91);
            this.txtTim.Margin = new System.Windows.Forms.Padding(5);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(247, 26);
            this.txtTim.TabIndex = 0;
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonAn.Location = new System.Drawing.Point(-2, 211);
            this.dgvMonAn.Margin = new System.Windows.Forms.Padding(5);
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.RowHeadersWidth = 62;
            this.dgvMonAn.Size = new System.Drawing.Size(557, 416);
            this.dgvMonAn.TabIndex = 3;
            // 
            // cbDanhMucLoc
            // 
            this.cbDanhMucLoc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbDanhMucLoc.FormattingEnabled = true;
            this.cbDanhMucLoc.Location = new System.Drawing.Point(153, 89);
            this.cbDanhMucLoc.Margin = new System.Windows.Forms.Padding(5);
            this.cbDanhMucLoc.Name = "cbDanhMucLoc";
            this.cbDanhMucLoc.Size = new System.Drawing.Size(199, 28);
            this.cbDanhMucLoc.TabIndex = 1;
            this.cbDanhMucLoc.SelectedIndexChanged += new System.EventHandler(this.cbDanhMucLoc_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Danh mục";
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(772, 510);
            this.btnThem.Margin = new System.Windows.Forms.Padding(5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(178, 42);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXoa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(976, 510);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(183, 42);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(277, 40);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(70, 25);
            this.lblTrangThai.TabIndex = 13;
            this.lblTrangThai.Text = "label5";
            // 
            // lblTenBan
            // 
            this.lblTenBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTenBan.AutoSize = true;
            this.lblTenBan.BackColor = System.Drawing.Color.Transparent;
            this.lblTenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBan.Location = new System.Drawing.Point(17, 40);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(70, 25);
            this.lblTenBan.TabIndex = 14;
            this.lblTenBan.Text = "label5";
            // 
            // btnXemHoaDon
            // 
            this.btnXemHoaDon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXemHoaDon.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXemHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemHoaDon.Location = new System.Drawing.Point(767, 584);
            this.btnXemHoaDon.Margin = new System.Windows.Forms.Padding(5);
            this.btnXemHoaDon.Name = "btnXemHoaDon";
            this.btnXemHoaDon.Size = new System.Drawing.Size(183, 42);
            this.btnXemHoaDon.TabIndex = 15;
            this.btnXemHoaDon.Text = "Xem hóa đơn";
            this.btnXemHoaDon.UseVisualStyleBackColor = false;
            this.btnXemHoaDon.Click += new System.EventHandler(this.btnXemHoaDon_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(563, 519);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Số Lượng:";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoLuong.Location = new System.Drawing.Point(681, 514);
            this.numSoLuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(71, 32);
            this.numSoLuong.TabIndex = 17;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1159, 640);
            this.Controls.Add(this.numSoLuong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXemHoaDon);
            this.Controls.Add(this.lblTenBan);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGuiDon);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dgvMonAn);
            this.Controls.Add(this.cbDanhMucLoc);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnTrove);
            this.Controls.Add(this.btnTimKiem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Button btnGuiDon;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTrove;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.ComboBox cbDanhMucLoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblTenBan;
        private System.Windows.Forms.Button btnXemHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}