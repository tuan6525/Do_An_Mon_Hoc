﻿namespace GiaoDien_DangNhap
{
    partial class frmThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_tim_kiem = new System.Windows.Forms.Button();
            this.dt_ngay_ket_thuc = new System.Windows.Forms.DateTimePicker();
            this.dt_ngay_bat_dau = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.data_Thong_Ke = new System.Windows.Forms.DataGridView();
            this.pn_doanh_thu = new System.Windows.Forms.Panel();
            this.lb_lay_dt = new System.Windows.Forms.Label();
            this.lb_dt = new System.Windows.Forms.Label();
            this.pn_so_da_ban = new System.Windows.Forms.Panel();
            this.lb_lay_sl = new System.Windows.Forms.Label();
            this.lb_sl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_tong_tl_hd = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_Thong_Ke)).BeginInit();
            this.pn_doanh_thu.SuspendLayout();
            this.pn_so_da_ban.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_tim_kiem
            // 
            this.btn_tim_kiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_tim_kiem.BackgroundImage")));
            this.btn_tim_kiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_tim_kiem.Location = new System.Drawing.Point(301, 298);
            this.btn_tim_kiem.Name = "btn_tim_kiem";
            this.btn_tim_kiem.Size = new System.Drawing.Size(51, 50);
            this.btn_tim_kiem.TabIndex = 23;
            this.btn_tim_kiem.UseVisualStyleBackColor = true;
            this.btn_tim_kiem.Click += new System.EventHandler(this.btn_tim_kiem_Click);
            // 
            // dt_ngay_ket_thuc
            // 
            this.dt_ngay_ket_thuc.CalendarFont = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_ngay_ket_thuc.CalendarMonthBackground = System.Drawing.Color.White;
            this.dt_ngay_ket_thuc.CustomFormat = "dd/MM/yyyy";
            this.dt_ngay_ket_thuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_ngay_ket_thuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_ngay_ket_thuc.Location = new System.Drawing.Point(95, 197);
            this.dt_ngay_ket_thuc.Name = "dt_ngay_ket_thuc";
            this.dt_ngay_ket_thuc.Size = new System.Drawing.Size(255, 30);
            this.dt_ngay_ket_thuc.TabIndex = 22;
            // 
            // dt_ngay_bat_dau
            // 
            this.dt_ngay_bat_dau.CalendarFont = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_ngay_bat_dau.CustomFormat = "dd/MM/yyyy";
            this.dt_ngay_bat_dau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_ngay_bat_dau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_ngay_bat_dau.Location = new System.Drawing.Point(95, 144);
            this.dt_ngay_bat_dau.Name = "dt_ngay_bat_dau";
            this.dt_ngay_bat_dau.Size = new System.Drawing.Size(255, 30);
            this.dt_ngay_bat_dau.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Đến ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Từ ngày :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(292, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 49);
            this.label1.TabIndex = 17;
            this.label1.Text = "Thống kê doanh thu";
            // 
            // data_Thong_Ke
            // 
            this.data_Thong_Ke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_Thong_Ke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_Thong_Ke.DefaultCellStyle = dataGridViewCellStyle1;
            this.data_Thong_Ke.Location = new System.Drawing.Point(1, 380);
            this.data_Thong_Ke.Name = "data_Thong_Ke";
            this.data_Thong_Ke.RowHeadersWidth = 51;
            this.data_Thong_Ke.RowTemplate.Height = 24;
            this.data_Thong_Ke.Size = new System.Drawing.Size(999, 214);
            this.data_Thong_Ke.TabIndex = 24;
            // 
            // pn_doanh_thu
            // 
            this.pn_doanh_thu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pn_doanh_thu.Controls.Add(this.lb_lay_dt);
            this.pn_doanh_thu.Controls.Add(this.lb_dt);
            this.pn_doanh_thu.Location = new System.Drawing.Point(779, 307);
            this.pn_doanh_thu.Name = "pn_doanh_thu";
            this.pn_doanh_thu.Size = new System.Drawing.Size(200, 67);
            this.pn_doanh_thu.TabIndex = 27;
            // 
            // lb_lay_dt
            // 
            this.lb_lay_dt.AutoSize = true;
            this.lb_lay_dt.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_lay_dt.Location = new System.Drawing.Point(45, 21);
            this.lb_lay_dt.Name = "lb_lay_dt";
            this.lb_lay_dt.Size = new System.Drawing.Size(0, 20);
            this.lb_lay_dt.TabIndex = 2;
            // 
            // lb_dt
            // 
            this.lb_dt.AutoSize = true;
            this.lb_dt.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dt.Location = new System.Drawing.Point(3, 0);
            this.lb_dt.Name = "lb_dt";
            this.lb_dt.Size = new System.Drawing.Size(83, 19);
            this.lb_dt.TabIndex = 0;
            this.lb_dt.Text = "Doanh thu:";
            // 
            // pn_so_da_ban
            // 
            this.pn_so_da_ban.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pn_so_da_ban.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_so_da_ban.Controls.Add(this.lb_lay_sl);
            this.pn_so_da_ban.Controls.Add(this.lb_sl);
            this.pn_so_da_ban.Location = new System.Drawing.Point(779, 234);
            this.pn_so_da_ban.Name = "pn_so_da_ban";
            this.pn_so_da_ban.Size = new System.Drawing.Size(200, 67);
            this.pn_so_da_ban.TabIndex = 28;
            // 
            // lb_lay_sl
            // 
            this.lb_lay_sl.AutoSize = true;
            this.lb_lay_sl.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_lay_sl.Location = new System.Drawing.Point(55, 31);
            this.lb_lay_sl.Name = "lb_lay_sl";
            this.lb_lay_sl.Size = new System.Drawing.Size(0, 19);
            this.lb_lay_sl.TabIndex = 1;
            // 
            // lb_sl
            // 
            this.lb_sl.AutoSize = true;
            this.lb_sl.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sl.Location = new System.Drawing.Point(3, 0);
            this.lb_sl.Name = "lb_sl";
            this.lb_sl.Size = new System.Drawing.Size(177, 19);
            this.lb_sl.TabIndex = 0;
            this.lb_sl.Text = "Tổng số lượng sản phẩm:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.lb_tong_tl_hd);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(779, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 67);
            this.panel1.TabIndex = 29;
            // 
            // lb_tong_tl_hd
            // 
            this.lb_tong_tl_hd.AutoSize = true;
            this.lb_tong_tl_hd.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tong_tl_hd.Location = new System.Drawing.Point(55, 31);
            this.lb_tong_tl_hd.Name = "lb_tong_tl_hd";
            this.lb_tong_tl_hd.Size = new System.Drawing.Size(0, 19);
            this.lb_tong_tl_hd.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tổng số lượng hóa đơn:";
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1001, 594);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pn_so_da_ban);
            this.Controls.Add(this.pn_doanh_thu);
            this.Controls.Add(this.data_Thong_Ke);
            this.Controls.Add(this.btn_tim_kiem);
            this.Controls.Add(this.dt_ngay_ket_thuc);
            this.Controls.Add(this.dt_ngay_bat_dau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_Thong_Ke)).EndInit();
            this.pn_doanh_thu.ResumeLayout(false);
            this.pn_doanh_thu.PerformLayout();
            this.pn_so_da_ban.ResumeLayout(false);
            this.pn_so_da_ban.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_tim_kiem;
        private System.Windows.Forms.DateTimePicker dt_ngay_ket_thuc;
        private System.Windows.Forms.DateTimePicker dt_ngay_bat_dau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView data_Thong_Ke;
        private System.Windows.Forms.Panel pn_doanh_thu;
        private System.Windows.Forms.Label lb_dt;
        private System.Windows.Forms.Panel pn_so_da_ban;
        private System.Windows.Forms.Label lb_lay_sl;
        private System.Windows.Forms.Label lb_sl;
        private System.Windows.Forms.Label lb_lay_dt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_tong_tl_hd;
        private System.Windows.Forms.Label label5;
    }
}