namespace GiaoDien_DangNhap
{
    partial class TiemKiemHD
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_tk_mahd = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dt_hd = new System.Windows.Forms.DateTimePicker();
            this.txt_makh = new System.Windows.Forms.TextBox();
            this.txt_manv = new System.Windows.Forms.TextBox();
            this.txt_mahd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_hien_all = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.data_tk_HD = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_tk_HD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(342, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiềm kiếm hóa đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(55, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tiềm kiếm theo mã hóa đơn: ";
            // 
            // txt_tk_mahd
            // 
            this.txt_tk_mahd.Location = new System.Drawing.Point(296, 90);
            this.txt_tk_mahd.Name = "txt_tk_mahd";
            this.txt_tk_mahd.Size = new System.Drawing.Size(168, 22);
            this.txt_tk_mahd.TabIndex = 2;
            this.txt_tk_mahd.TextChanged += new System.EventHandler(this.txt_tk_mahd_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dt_hd);
            this.groupBox1.Controls.Add(this.txt_makh);
            this.groupBox1.Controls.Add(this.txt_manv);
            this.groupBox1.Controls.Add(this.txt_mahd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(59, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(893, 169);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn";
            // 
            // dt_hd
            // 
            this.dt_hd.Location = new System.Drawing.Point(602, 117);
            this.dt_hd.Name = "dt_hd";
            this.dt_hd.Size = new System.Drawing.Size(238, 22);
            this.dt_hd.TabIndex = 9;
            // 
            // txt_makh
            // 
            this.txt_makh.Location = new System.Drawing.Point(602, 31);
            this.txt_makh.Name = "txt_makh";
            this.txt_makh.Size = new System.Drawing.Size(168, 22);
            this.txt_makh.TabIndex = 8;
            // 
            // txt_manv
            // 
            this.txt_manv.Location = new System.Drawing.Point(237, 119);
            this.txt_manv.Name = "txt_manv";
            this.txt_manv.Size = new System.Drawing.Size(168, 22);
            this.txt_manv.TabIndex = 7;
            // 
            // txt_mahd
            // 
            this.txt_mahd.Location = new System.Drawing.Point(138, 30);
            this.txt_mahd.Name = "txt_mahd";
            this.txt_mahd.Size = new System.Drawing.Size(168, 22);
            this.txt_mahd.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(456, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày lập hóa đơn:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(471, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã khách hàng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(119, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã nhân viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã hóa đơn:";
            // 
            // btn_hien_all
            // 
            this.btn_hien_all.Location = new System.Drawing.Point(59, 336);
            this.btn_hien_all.Name = "btn_hien_all";
            this.btn_hien_all.Size = new System.Drawing.Size(145, 23);
            this.btn_hien_all.TabIndex = 4;
            this.btn_hien_all.Text = "Hiện tất cả hóa đơn";
            this.btn_hien_all.UseVisualStyleBackColor = true;
            this.btn_hien_all.Click += new System.EventHandler(this.btn_hien_all_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.data_tk_HD);
            this.groupBox2.Location = new System.Drawing.Point(59, 384);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(893, 201);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách hóa đơn";
            // 
            // data_tk_HD
            // 
            this.data_tk_HD.AllowUserToAddRows = false;
            this.data_tk_HD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_tk_HD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_tk_HD.Location = new System.Drawing.Point(27, 35);
            this.data_tk_HD.Name = "data_tk_HD";
            this.data_tk_HD.ReadOnly = true;
            this.data_tk_HD.RowHeadersWidth = 51;
            this.data_tk_HD.RowTemplate.Height = 24;
            this.data_tk_HD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_tk_HD.Size = new System.Drawing.Size(841, 148);
            this.data_tk_HD.TabIndex = 0;
            this.data_tk_HD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_tk_HD_CellClick);
            // 
            // TiemKiemHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1011, 597);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_hien_all);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_tk_mahd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TiemKiemHD";
            this.Text = "TiemKiemHD";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_tk_HD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_tk_mahd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_makh;
        private System.Windows.Forms.TextBox txt_manv;
        private System.Windows.Forms.TextBox txt_mahd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_hien_all;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView data_tk_HD;
        private System.Windows.Forms.DateTimePicker dt_hd;
    }
}