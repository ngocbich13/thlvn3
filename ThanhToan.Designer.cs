namespace QuanLyQuanCafe_THLVN
{
    partial class ThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThanhToan));
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPhuongThucThanhToan = new System.Windows.Forms.ComboBox();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblTenBan = new System.Windows.Forms.Label();
            this.lblTrangThaiBan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbTongTienTruocGiam = new System.Windows.Forms.TextBox();
            this.txbTongTienSauGiam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(14, 184);
            this.dgvChiTietHoaDon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.RowHeadersWidth = 62;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(523, 433);
            this.dgvChiTietHoaDon.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(562, 305);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Giảm giá (%)";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(562, 389);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Phương thức thanh toán";
            // 
            // cbPhuongThucThanhToan
            // 
            this.cbPhuongThucThanhToan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbPhuongThucThanhToan.FormattingEnabled = true;
            this.cbPhuongThucThanhToan.Location = new System.Drawing.Point(939, 391);
            this.cbPhuongThucThanhToan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPhuongThucThanhToan.Name = "cbPhuongThucThanhToan";
            this.cbPhuongThucThanhToan.Size = new System.Drawing.Size(294, 30);
            this.cbPhuongThucThanhToan.TabIndex = 16;
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGiamGia.Location = new System.Drawing.Point(939, 309);
            this.txtGiamGia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(294, 28);
            this.txtGiamGia.TabIndex = 15;
            this.txtGiamGia.TextChanged += new System.EventHandler(this.txtGiamGia_TextChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThoat.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(969, 566);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(264, 51);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThanhToan.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Location = new System.Drawing.Point(567, 566);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(264, 51);
            this.btnThanhToan.TabIndex = 17;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lblTenBan
            // 
            this.lblTenBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTenBan.AutoSize = true;
            this.lblTenBan.BackColor = System.Drawing.Color.Transparent;
            this.lblTenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBan.Location = new System.Drawing.Point(12, 133);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(85, 29);
            this.lblTenBan.TabIndex = 22;
            this.lblTenBan.Text = "label5";
            this.lblTenBan.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblTrangThaiBan
            // 
            this.lblTrangThaiBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTrangThaiBan.AutoSize = true;
            this.lblTrangThaiBan.BackColor = System.Drawing.Color.Transparent;
            this.lblTrangThaiBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThaiBan.Location = new System.Drawing.Point(259, 133);
            this.lblTrangThaiBan.Name = "lblTrangThaiBan";
            this.lblTrangThaiBan.Size = new System.Drawing.Size(85, 29);
            this.lblTrangThaiBan.TabIndex = 25;
            this.lblTrangThaiBan.Text = "label3";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(562, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 29);
            this.label3.TabIndex = 26;
            this.label3.Text = "Thành tiền";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(562, 474);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 29);
            this.label5.TabIndex = 27;
            this.label5.Text = "Tổng tiền";
            // 
            // txbTongTienTruocGiam
            // 
            this.txbTongTienTruocGiam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbTongTienTruocGiam.BackColor = System.Drawing.SystemColors.Window;
            this.txbTongTienTruocGiam.Location = new System.Drawing.Point(939, 225);
            this.txbTongTienTruocGiam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbTongTienTruocGiam.Name = "txbTongTienTruocGiam";
            this.txbTongTienTruocGiam.ReadOnly = true;
            this.txbTongTienTruocGiam.Size = new System.Drawing.Size(294, 28);
            this.txbTongTienTruocGiam.TabIndex = 28;
            // 
            // txbTongTienSauGiam
            // 
            this.txbTongTienSauGiam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbTongTienSauGiam.BackColor = System.Drawing.SystemColors.Window;
            this.txbTongTienSauGiam.Location = new System.Drawing.Point(939, 478);
            this.txbTongTienSauGiam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbTongTienSauGiam.Name = "txbTongTienSauGiam";
            this.txbTongTienSauGiam.ReadOnly = true;
            this.txbTongTienSauGiam.Size = new System.Drawing.Size(294, 28);
            this.txbTongTienSauGiam.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(321, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(627, 110);
            this.label4.TabIndex = 6;
            this.label4.Text = "THANH TOÁN";
            // 
            // ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1248, 669);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbTongTienSauGiam);
            this.Controls.Add(this.txbTongTienTruocGiam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTrangThaiBan);
            this.Controls.Add(this.lblTenBan);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.cbPhuongThucThanhToan);
            this.Controls.Add(this.txtGiamGia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThanhToan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPhuongThucThanhToan;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lblTenBan;
        private System.Windows.Forms.Label lblTrangThaiBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbTongTienTruocGiam;
        private System.Windows.Forms.TextBox txbTongTienSauGiam;
        private System.Windows.Forms.Label label4;
    }
}