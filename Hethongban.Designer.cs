namespace QuanLyQuanCafe_THLVN
{
    partial class Hethongban
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hethongban));
            this.flowLayoutPanelBan = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetBan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanelBan
            // 
            this.flowLayoutPanelBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanelBan.AutoScroll = true;
            this.flowLayoutPanelBan.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelBan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanelBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanelBan.Location = new System.Drawing.Point(0, 113);
            this.flowLayoutPanelBan.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelBan.Name = "flowLayoutPanelBan";
            this.flowLayoutPanelBan.Size = new System.Drawing.Size(1244, 508);
            this.flowLayoutPanelBan.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 64);
            this.label1.TabIndex = 1;
            this.label1.Text = "HỆ THỐNG BÀN";
            // 
            // btnResetBan
            // 
            this.btnResetBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnResetBan.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnResetBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetBan.Location = new System.Drawing.Point(1079, 18);
            this.btnResetBan.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetBan.Name = "btnResetBan";
            this.btnResetBan.Size = new System.Drawing.Size(165, 64);
            this.btnResetBan.TabIndex = 2;
            this.btnResetBan.Text = "Reset";
            this.btnResetBan.UseVisualStyleBackColor = false;
            this.btnResetBan.Click += new System.EventHandler(this.btnResetBan_Click);
            // 
            // Hethongban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1245, 651);
            this.Controls.Add(this.btnResetBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanelBan);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Hethongban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hethongban";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnResetBan;
    }
}