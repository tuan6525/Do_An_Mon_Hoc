namespace GiaoDien_DangNhap
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.lab_Tai_khoan = new System.Windows.Forms.Label();
            this.lab_Mat_Khau = new System.Windows.Forms.Label();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.btn_Dang_Nhap = new System.Windows.Forms.Button();
            this.chk_Hien_Mat_Khau = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_Loi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_Tai_khoan
            // 
            this.lab_Tai_khoan.AutoSize = true;
            this.lab_Tai_khoan.BackColor = System.Drawing.Color.Transparent;
            this.lab_Tai_khoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Tai_khoan.ForeColor = System.Drawing.Color.Navy;
            this.lab_Tai_khoan.Location = new System.Drawing.Point(109, 155);
            this.lab_Tai_khoan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_Tai_khoan.Name = "lab_Tai_khoan";
            this.lab_Tai_khoan.Size = new System.Drawing.Size(101, 23);
            this.lab_Tai_khoan.TabIndex = 1;
            this.lab_Tai_khoan.Text = "Tài khoản:";
            // 
            // lab_Mat_Khau
            // 
            this.lab_Mat_Khau.AutoSize = true;
            this.lab_Mat_Khau.BackColor = System.Drawing.Color.Transparent;
            this.lab_Mat_Khau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Mat_Khau.ForeColor = System.Drawing.Color.Navy;
            this.lab_Mat_Khau.Location = new System.Drawing.Point(116, 210);
            this.lab_Mat_Khau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_Mat_Khau.Name = "lab_Mat_Khau";
            this.lab_Mat_Khau.Size = new System.Drawing.Size(98, 23);
            this.lab_Mat_Khau.TabIndex = 2;
            this.lab_Mat_Khau.Text = "Mật khẩu:";
            // 
            // txt_Username
            // 
            this.txt_Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Username.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Username.Location = new System.Drawing.Point(233, 153);
            this.txt_Username.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(293, 30);
            this.txt_Username.TabIndex = 3;
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.Location = new System.Drawing.Point(233, 208);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(293, 30);
            this.txt_Password.TabIndex = 4;
            // 
            // btn_Dang_Nhap
            // 
            this.btn_Dang_Nhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_Dang_Nhap.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dang_Nhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_Dang_Nhap.Location = new System.Drawing.Point(233, 339);
            this.btn_Dang_Nhap.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Dang_Nhap.Name = "btn_Dang_Nhap";
            this.btn_Dang_Nhap.Size = new System.Drawing.Size(293, 55);
            this.btn_Dang_Nhap.TabIndex = 6;
            this.btn_Dang_Nhap.Text = "Đăng nhập";
            this.btn_Dang_Nhap.UseVisualStyleBackColor = false;
            this.btn_Dang_Nhap.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // chk_Hien_Mat_Khau
            // 
            this.chk_Hien_Mat_Khau.AutoSize = true;
            this.chk_Hien_Mat_Khau.BackColor = System.Drawing.Color.Transparent;
            this.chk_Hien_Mat_Khau.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Hien_Mat_Khau.ForeColor = System.Drawing.Color.Navy;
            this.chk_Hien_Mat_Khau.Location = new System.Drawing.Point(398, 246);
            this.chk_Hien_Mat_Khau.Margin = new System.Windows.Forms.Padding(4);
            this.chk_Hien_Mat_Khau.Name = "chk_Hien_Mat_Khau";
            this.chk_Hien_Mat_Khau.Size = new System.Drawing.Size(128, 23);
            this.chk_Hien_Mat_Khau.TabIndex = 5;
            this.chk_Hien_Mat_Khau.Text = "Hiện mật khẩu";
            this.chk_Hien_Mat_Khau.UseVisualStyleBackColor = false;
            this.chk_Hien_Mat_Khau.CheckedChanged += new System.EventHandler(this.chk_Hien_Mat_Khau_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(250, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 53);
            this.label3.TabIndex = 7;
            this.label3.Text = "Đăng nhập";
            // 
            // lab_Loi
            // 
            this.lab_Loi.AutoSize = true;
            this.lab_Loi.BackColor = System.Drawing.SystemColors.Window;
            this.lab_Loi.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lab_Loi.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Loi.ForeColor = System.Drawing.Color.Red;
            this.lab_Loi.Location = new System.Drawing.Point(229, 275);
            this.lab_Loi.Name = "lab_Loi";
            this.lab_Loi.Size = new System.Drawing.Size(0, 20);
            this.lab_Loi.TabIndex = 9;
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(700, 422);
            this.Controls.Add(this.lab_Loi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chk_Hien_Mat_Khau);
            this.Controls.Add(this.btn_Dang_Nhap);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.lab_Mat_Khau);
            this.Controls.Add(this.lab_Tai_khoan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(718, 469);
            this.MinimumSize = new System.Drawing.Size(718, 469);
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDangNhap_FormClosing);
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_Tai_khoan;
        private System.Windows.Forms.Label lab_Mat_Khau;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_Dang_Nhap;
        private System.Windows.Forms.CheckBox chk_Hien_Mat_Khau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lab_Loi;
    }
}

