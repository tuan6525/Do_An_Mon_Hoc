namespace GiaoDien_DangNhap
{
    partial class frmNhapHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapHang));
            this.grb_Ten_San_Pham = new System.Windows.Forms.GroupBox();
            this.cbo_Ten_San_Pham = new System.Windows.Forms.ComboBox();
            this.grb_So_Luong = new System.Windows.Forms.GroupBox();
            this.nmr_So_Luong = new System.Windows.Forms.NumericUpDown();
            this.btn_Them = new System.Windows.Forms.Button();
            this.grb_Ten_San_Pham.SuspendLayout();
            this.grb_So_Luong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_So_Luong)).BeginInit();
            this.SuspendLayout();
            // 
            // grb_Ten_San_Pham
            // 
            this.grb_Ten_San_Pham.BackColor = System.Drawing.Color.Transparent;
            this.grb_Ten_San_Pham.Controls.Add(this.cbo_Ten_San_Pham);
            this.grb_Ten_San_Pham.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_Ten_San_Pham.ForeColor = System.Drawing.Color.White;
            this.grb_Ten_San_Pham.Location = new System.Drawing.Point(624, 77);
            this.grb_Ten_San_Pham.Name = "grb_Ten_San_Pham";
            this.grb_Ten_San_Pham.Size = new System.Drawing.Size(270, 72);
            this.grb_Ten_San_Pham.TabIndex = 0;
            this.grb_Ten_San_Pham.TabStop = false;
            this.grb_Ten_San_Pham.Text = "Tên Sản Phẩm";
            // 
            // cbo_Ten_San_Pham
            // 
            this.cbo_Ten_San_Pham.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cbo_Ten_San_Pham.FormattingEnabled = true;
            this.cbo_Ten_San_Pham.Location = new System.Drawing.Point(6, 28);
            this.cbo_Ten_San_Pham.Name = "cbo_Ten_San_Pham";
            this.cbo_Ten_San_Pham.Size = new System.Drawing.Size(258, 28);
            this.cbo_Ten_San_Pham.TabIndex = 0;
            // 
            // grb_So_Luong
            // 
            this.grb_So_Luong.BackColor = System.Drawing.Color.Transparent;
            this.grb_So_Luong.Controls.Add(this.nmr_So_Luong);
            this.grb_So_Luong.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_So_Luong.ForeColor = System.Drawing.Color.White;
            this.grb_So_Luong.Location = new System.Drawing.Point(624, 166);
            this.grb_So_Luong.Name = "grb_So_Luong";
            this.grb_So_Luong.Size = new System.Drawing.Size(139, 72);
            this.grb_So_Luong.TabIndex = 1;
            this.grb_So_Luong.TabStop = false;
            this.grb_So_Luong.Text = "Số Lượng";
            // 
            // nmr_So_Luong
            // 
            this.nmr_So_Luong.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.nmr_So_Luong.Location = new System.Drawing.Point(6, 28);
            this.nmr_So_Luong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmr_So_Luong.Name = "nmr_So_Luong";
            this.nmr_So_Luong.Size = new System.Drawing.Size(125, 28);
            this.nmr_So_Luong.TabIndex = 0;
            this.nmr_So_Luong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Them.Location = new System.Drawing.Point(672, 302);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(198, 64);
            this.btn_Them.TabIndex = 2;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // frmNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(935, 525);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.grb_So_Luong);
            this.Controls.Add(this.grb_Ten_San_Pham);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmNhapHang";
            this.Text = "Nhập Hàng";
            this.Load += new System.EventHandler(this.frmNhapHang_Load);
            this.grb_Ten_San_Pham.ResumeLayout(false);
            this.grb_So_Luong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmr_So_Luong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_Ten_San_Pham;
        private System.Windows.Forms.ComboBox cbo_Ten_San_Pham;
        private System.Windows.Forms.GroupBox grb_So_Luong;
        private System.Windows.Forms.NumericUpDown nmr_So_Luong;
        private System.Windows.Forms.Button btn_Them;
    }
}