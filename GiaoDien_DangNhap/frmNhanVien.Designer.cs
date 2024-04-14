namespace GiaoDien_DangNhap
{
    partial class frmNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVien));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SAD = new System.Windows.Forms.Label();
            this.dGR_BH = new System.Windows.Forms.DataGridView();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_BH_out = new System.Windows.Forms.Button();
            this.btn_BH_search = new System.Windows.Forms.Button();
            this.btn_BH_del = new System.Windows.Forms.Button();
            this.btn_BH_add = new System.Windows.Forms.Button();
            this.btn_BH_new = new System.Windows.Forms.Button();
            this.grbox = new System.Windows.Forms.GroupBox();
            this.ccb_BH_NV = new System.Windows.Forms.ComboBox();
            this.cbb_BH_maKH = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dt_BH_ngayLapHD = new System.Windows.Forms.DateTimePicker();
            this.txt_BH_tenNV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_BH_maHD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGR_BH)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.grbox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(971, 720);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gray;
            this.tabPage1.Controls.Add(this.SAD);
            this.tabPage1.Controls.Add(this.dGR_BH);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.grbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(963, 684);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bán hàng";
            // 
            // SAD
            // 
            this.SAD.AutoSize = true;
            this.SAD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.SAD.Location = new System.Drawing.Point(366, 14);
            this.SAD.Name = "SAD";
            this.SAD.Size = new System.Drawing.Size(213, 23);
            this.SAD.TabIndex = 42;
            this.SAD.Text = "HÓA ĐƠN BÁN HÀNG";
            // 
            // dGR_BH
            // 
            this.dGR_BH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGR_BH.Location = new System.Drawing.Point(6, 473);
            this.dGR_BH.Name = "dGR_BH";
            this.dGR_BH.ReadOnly = true;
            this.dGR_BH.RowHeadersWidth = 51;
            this.dGR_BH.RowTemplate.Height = 24;
            this.dGR_BH.Size = new System.Drawing.Size(946, 206);
            this.dGR_BH.TabIndex = 41;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label24.Location = new System.Drawing.Point(6, 447);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(167, 23);
            this.label24.TabIndex = 40;
            this.label24.Text = "Danh sách hóa đơn";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_BH_out);
            this.groupBox3.Controls.Add(this.btn_BH_search);
            this.groupBox3.Controls.Add(this.btn_BH_del);
            this.groupBox3.Controls.Add(this.btn_BH_add);
            this.groupBox3.Controls.Add(this.btn_BH_new);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox3.Location = new System.Drawing.Point(403, 331);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(537, 136);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // btn_BH_out
            // 
            this.btn_BH_out.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BH_out.BackgroundImage")));
            this.btn_BH_out.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_BH_out.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BH_out.Location = new System.Drawing.Point(313, 47);
            this.btn_BH_out.Name = "btn_BH_out";
            this.btn_BH_out.Size = new System.Drawing.Size(52, 56);
            this.btn_BH_out.TabIndex = 47;
            this.btn_BH_out.UseVisualStyleBackColor = true;
            // 
            // btn_BH_search
            // 
            this.btn_BH_search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BH_search.BackgroundImage")));
            this.btn_BH_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_BH_search.Location = new System.Drawing.Point(228, 182);
            this.btn_BH_search.Name = "btn_BH_search";
            this.btn_BH_search.Size = new System.Drawing.Size(60, 50);
            this.btn_BH_search.TabIndex = 32;
            this.btn_BH_search.UseVisualStyleBackColor = true;
            this.btn_BH_search.Click += new System.EventHandler(this.btn_BH_search_Click);
            // 
            // btn_BH_del
            // 
            this.btn_BH_del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BH_del.BackgroundImage")));
            this.btn_BH_del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_BH_del.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BH_del.Location = new System.Drawing.Point(425, 47);
            this.btn_BH_del.Name = "btn_BH_del";
            this.btn_BH_del.Size = new System.Drawing.Size(52, 56);
            this.btn_BH_del.TabIndex = 46;
            this.btn_BH_del.UseVisualStyleBackColor = true;
            // 
            // btn_BH_add
            // 
            this.btn_BH_add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BH_add.BackgroundImage")));
            this.btn_BH_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_BH_add.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BH_add.Location = new System.Drawing.Point(85, 47);
            this.btn_BH_add.Name = "btn_BH_add";
            this.btn_BH_add.Size = new System.Drawing.Size(52, 56);
            this.btn_BH_add.TabIndex = 45;
            this.btn_BH_add.UseVisualStyleBackColor = true;
            this.btn_BH_add.Click += new System.EventHandler(this.btn_BH_add_Click);
            // 
            // btn_BH_new
            // 
            this.btn_BH_new.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BH_new.BackgroundImage")));
            this.btn_BH_new.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_BH_new.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BH_new.Location = new System.Drawing.Point(191, 47);
            this.btn_BH_new.Name = "btn_BH_new";
            this.btn_BH_new.Size = new System.Drawing.Size(52, 56);
            this.btn_BH_new.TabIndex = 43;
            this.btn_BH_new.UseVisualStyleBackColor = true;
            // 
            // grbox
            // 
            this.grbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grbox.Controls.Add(this.ccb_BH_NV);
            this.grbox.Controls.Add(this.cbb_BH_maKH);
            this.grbox.Controls.Add(this.label3);
            this.grbox.Controls.Add(this.dt_BH_ngayLapHD);
            this.grbox.Controls.Add(this.txt_BH_tenNV);
            this.grbox.Controls.Add(this.label7);
            this.grbox.Controls.Add(this.label5);
            this.grbox.Controls.Add(this.txt_BH_maHD);
            this.grbox.Controls.Add(this.label2);
            this.grbox.Controls.Add(this.label1);
            this.grbox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grbox.Location = new System.Drawing.Point(7, 67);
            this.grbox.Name = "grbox";
            this.grbox.Size = new System.Drawing.Size(950, 258);
            this.grbox.TabIndex = 18;
            this.grbox.TabStop = false;
            this.grbox.Text = "Thông tin sản phẩm";
            // 
            // ccb_BH_NV
            // 
            this.ccb_BH_NV.FormattingEnabled = true;
            this.ccb_BH_NV.Location = new System.Drawing.Point(164, 130);
            this.ccb_BH_NV.Name = "ccb_BH_NV";
            this.ccb_BH_NV.Size = new System.Drawing.Size(261, 31);
            this.ccb_BH_NV.TabIndex = 49;
            // 
            // cbb_BH_maKH
            // 
            this.cbb_BH_maKH.FormattingEnabled = true;
            this.cbb_BH_maKH.Location = new System.Drawing.Point(164, 82);
            this.cbb_BH_maKH.Name = "cbb_BH_maKH";
            this.cbb_BH_maKH.Size = new System.Drawing.Size(261, 31);
            this.cbb_BH_maKH.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-3, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Mã Khách Hàng:";
            // 
            // dt_BH_ngayLapHD
            // 
            this.dt_BH_ngayLapHD.CustomFormat = "dd-MM-yyyy";
            this.dt_BH_ngayLapHD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_BH_ngayLapHD.Location = new System.Drawing.Point(165, 222);
            this.dt_BH_ngayLapHD.Name = "dt_BH_ngayLapHD";
            this.dt_BH_ngayLapHD.Size = new System.Drawing.Size(260, 30);
            this.dt_BH_ngayLapHD.TabIndex = 39;
            // 
            // txt_BH_tenNV
            // 
            this.txt_BH_tenNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BH_tenNV.Location = new System.Drawing.Point(164, 176);
            this.txt_BH_tenNV.Name = "txt_BH_tenNV";
            this.txt_BH_tenNV.Size = new System.Drawing.Size(261, 30);
            this.txt_BH_tenNV.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Tên Nhân Viên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "Mã Hóa Đơn:";
            // 
            // txt_BH_maHD
            // 
            this.txt_BH_maHD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BH_maHD.Location = new System.Drawing.Point(163, 35);
            this.txt_BH_maHD.Name = "txt_BH_maHD";
            this.txt_BH_maHD.Size = new System.Drawing.Size(261, 30);
            this.txt_BH_maHD.TabIndex = 3;
            this.txt_BH_maHD.TextChanged += new System.EventHandler(this.txt_maSP_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày Lập Hóa Đơn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Nhân Viên:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(963, 684);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Khách hàng";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(11, 420);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(936, 258);
            this.dataGridView2.TabIndex = 4;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label23.Location = new System.Drawing.Point(11, 394);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(196, 23);
            this.label23.TabIndex = 3;
            this.label23.Text = "Danh sách khách hàng";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.textBox12);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox4.Location = new System.Drawing.Point(529, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(418, 204);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chức năng";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(304, 104);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 23);
            this.label21.TabIndex = 24;
            this.label21.Text = "Sửa";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(169, 104);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(84, 23);
            this.label20.TabIndex = 23;
            this.label20.Text = "Làm mới";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(70, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 23);
            this.label19.TabIndex = 22;
            this.label19.Text = "Thêm";
            // 
            // button11
            // 
            this.button11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button11.BackgroundImage")));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button11.Location = new System.Drawing.Point(293, 48);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(62, 48);
            this.button11.TabIndex = 21;
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button10.BackgroundImage")));
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button10.Location = new System.Drawing.Point(178, 48);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(62, 48);
            this.button10.TabIndex = 20;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button9.BackgroundImage")));
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button9.Location = new System.Drawing.Point(61, 48);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(64, 48);
            this.button9.TabIndex = 19;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.Location = new System.Drawing.Point(366, 151);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(46, 41);
            this.button8.TabIndex = 18;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 160);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 23);
            this.label18.TabIndex = 17;
            this.label18.Text = "Tìm kiếm:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(112, 157);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(243, 30);
            this.textBox12.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Pink;
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(6, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 370);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin khách hàng";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(229, 232);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(255, 30);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(140, 292);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 20);
            this.label17.TabIndex = 5;
            this.label17.Text = "Địa chỉ:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(229, 329);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(111, 24);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Trạng thái";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(229, 289);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(255, 27);
            this.textBox11.TabIndex = 11;
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(229, 185);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(255, 27);
            this.textBox9.TabIndex = 9;
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(229, 133);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(255, 27);
            this.textBox8.TabIndex = 8;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(229, 81);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(255, 27);
            this.textBox7.TabIndex = 7;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(229, 29);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(255, 27);
            this.textBox6.TabIndex = 6;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(125, 240);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 20);
            this.label16.TabIndex = 4;
            this.label16.Text = "Ngày tạo:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(150, 188);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 20);
            this.label15.TabIndex = 3;
            this.label15.Text = "Email:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(92, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 20);
            this.label14.TabIndex = 2;
            this.label14.Text = "Số điện thoại:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(71, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 20);
            this.label13.TabIndex = 1;
            this.label13.Text = "Tên khách hàng:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(74, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Mã khách hàng:";
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 717);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmNhanVien";
            this.Text = "Nhân Viên";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGR_BH)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.grbox.ResumeLayout(false);
            this.grbox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dGR_BH;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_BH_search;
        private System.Windows.Forms.Button btn_BH_out;
        private System.Windows.Forms.Button btn_BH_del;
        private System.Windows.Forms.Button btn_BH_add;
        private System.Windows.Forms.Button btn_BH_new;
        private System.Windows.Forms.GroupBox grbox;
        private System.Windows.Forms.TextBox txt_BH_maHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dt_BH_ngayLapHD;
        private System.Windows.Forms.TextBox txt_BH_tenNV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label SAD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ccb_BH_NV;
        private System.Windows.Forms.ComboBox cbb_BH_maKH;
    }
}