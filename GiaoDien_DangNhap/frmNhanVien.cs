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

namespace GiaoDien_DangNhap
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        public static string Connect = "Data Source=TranTuan\\MSSQL_SERVER;Initial Catalog=qlbanmaytinh;Integrated Security=true";
        public static SqlConnection Ket_Noi()
        {
            SqlConnection myConnection = new SqlConnection(Connect);
            return myConnection;
        }

        public static DataSet Xem_Thong_Tin(string sSql_Xem)
        {

            SqlConnection myConnection = Ket_Noi();
            DataSet ds = null;
            try
            {
                myConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Xem, myConnection);
                ds = new DataSet();
                dsHien.Fill(ds);
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi:dataset " + ex.Message);
            }
            return ds;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            //TAB Bán hàng
            //string sSql_Xem_Hoa_Don = "select*from hoadon";
            //DataSet ds_Hoa_Don = Xem_Thong_Tin(sSql_Xem_Hoa_Don);
            //data_banHang_HD.DataSource = ds_Hoa_Don.Tables[0];
            Hien_Thi_Len_HD_CBO_San_Pham();
            Hien_Thi_Len_HD_CBO_Nhan_Vien();
            Hien_Thi_Len_HD_CBO_Khach_Hang();
            Hien_Don_Gia();
            //TAB KHÁCH HÀNG
            string sSql_Xem_Khach_Hang = "SELECT * FROM KhachHang";
            DataSet ds_Khach_Hang = Xem_Thong_Tin(sSql_Xem_Khach_Hang);
            data_khachHang.DataSource = ds_Khach_Hang.Tables[0];
        }

        public bool themHoaDon(string maHD, string maNV, string maKH, string ngayLapHD,int tienNhan,int tienTra,int thanhTien)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            string sSql = "";
            sSql = "insert into hoadon ";
            sSql += "values('" + maHD + "',";
            sSql += "'" + maNV + "',";
            sSql += "'" + maKH + "',";
            sSql += "'" + ngayLapHD + "',";
            sSql += tienNhan + ",";
            sSql += tienTra + ",";
            sSql+= thanhTien + ")";
            MessageBox.Show(sSql);

            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql, myConnection);
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception err)
            {
                kq = false;
                MessageBox.Show("loi" + err.Message);
            }

            return kq;
        }

        public void Hien_Thi_Len_HD_CBO_San_Pham()
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Hien = "SELECT MaSP, TenSP FROM SanPham";
            try
            {
                myConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Hien, myConnection);
                DataSet ds = new DataSet();
                dsHien.Fill(ds);
                myConnection.Close();

                cbo_BH_sanPham.DataSource = ds.Tables[0];
                cbo_BH_sanPham.DisplayMember = "TenSP";
                cbo_BH_sanPham.ValueMember = "MaSP";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: 1 " + ex.Message);
            }
        }
 
        public void Hien_Thi_Len_HD_CBO_Khach_Hang()
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Hien = "SELECT makh, Tenkh FROM khachhang";
            try
            {
                myConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Hien, myConnection);
                DataSet ds = new DataSet();
                dsHien.Fill(ds);
                myConnection.Close();

                cbo_BH_KH.DataSource = ds.Tables[0];
                cbo_BH_KH.DisplayMember = "TenKH";
                cbo_BH_KH.ValueMember = "MaKH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: 2 " + ex.Message);
            }
        }
        public void Hien_Thi_Len_HD_CBO_Nhan_Vien()
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Hien = "SELECT manv, Tennv FROM nhanvien";
            try
            {
                myConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Hien, myConnection);
                DataSet ds = new DataSet();
                dsHien.Fill(ds);
                myConnection.Close();

                cbo_BH_NV.DataSource = ds.Tables[0];
                cbo_BH_NV.DisplayMember = "TenNV";
                cbo_BH_NV.ValueMember = "MaNV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: 3 " + ex.Message);
            }
        }
        public void Hien_Don_Gia()
        {
            string maSP = cbo_BH_sanPham.SelectedValue.ToString();
            double giaBan = 0;

            SqlConnection myConnection = Ket_Noi();

            string sSql_Gia_Ban = "SELECT GiaBan FROM SanPham WHERE MASP = @MaSP";
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql_Gia_Ban, myConnection);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                giaBan = Convert.ToDouble(cmd.ExecuteScalar());
                txt_BH_donGia.Text = giaBan.ToString();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: dongia" + ex.Message);
            }
        }
        public bool Them_Hoa_Don(string maHD, string maSP, int soLuong, double donGia, double thanhTien, string maKH, string maNV, string ngayLap, double khuyenMai)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            //Câu truy vấn thêm vào bảng HOADON
            string sSql_HD;
            sSql_HD = "INSERT INTO HoaDon VALUES (";
            sSql_HD += "'" + maHD + "',";
            sSql_HD += "'" + maNV + "',";
            sSql_HD += "'" + maKH + "',";
            sSql_HD += "'" + ngayLap + "')";
      
        

            //Câu truy vấn thêm vào bảng CTHOADON
            string sSql_CTHD;
            sSql_CTHD = "INSERT INTO CT_HOADON VALUES (";
            sSql_CTHD += "'" + maHD + "',";
            sSql_CTHD += "'" + maSP + "',";
            sSql_CTHD += "" + soLuong + ",";
            sSql_CTHD += "" + donGia + ",";
            sSql_CTHD += "" + khuyenMai + ",";
            sSql_CTHD += thanhTien + ")";

            try
            {
                myConnection.Open();
                //thực thi câu truy vấn thêm vào bảng HOADON
                SqlCommand cmd = new SqlCommand(sSql_HD, myConnection);
                cmd.ExecuteNonQuery();

                //thực thi câu truy vấn thêm vào bảng HOADON
                cmd = new SqlCommand(sSql_CTHD, myConnection);
                cmd.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi. Chi tiết: them hd " + ex.Message);
            }
            return kq;
        }
        private void btn_BH_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_BH_maHD.Text) ||
                string.IsNullOrEmpty(cbo_BH_sanPham.Text) ||
                string.IsNullOrEmpty(txt_BH_donGia.Text) ||
                string.IsNullOrEmpty(txt_BH_thanhTien.Text) ||
                string.IsNullOrEmpty(cbo_BH_KH.Text) ||
                string.IsNullOrEmpty(cbo_BH_NV.Text) ||
                string.IsNullOrEmpty(txt_BH_khuyenMai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string maHD, maSP, maKH, maNV;
                double donGia, thanhTien, khuyenMai;
                int soLuong;
                string ngayLap;

                maHD = txt_BH_maHD.Text;
                maSP = cbo_BH_sanPham.SelectedValue.ToString();
                soLuong = int.Parse(nbr_BH_soLuong.Text);
                donGia = int.Parse(txt_BH_donGia.Text);
                thanhTien = int.Parse(txt_BH_thanhTien.Text);
                maKH = cbo_BH_KH.SelectedValue.ToString();
                maNV = cbo_BH_NV.SelectedValue.ToString();
                khuyenMai = double.Parse(txt_BH_khuyenMai.Text);
                ngayLap = dt_BH_ngayLapHD.Value.ToString("yyyy-MM-dd HH:mm:ss");

                bool kq = Them_Hoa_Don(maHD, maSP, soLuong, donGia, thanhTien, maKH, maNV, ngayLap, khuyenMai);
                if (kq == false)
                {
                    MessageBox.Show("Thêm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                   
                }
                else
                {
                    MessageBox.Show("Đã thêm Hóa Đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   string mahd = txt_BH_maHD.Text;
                   string masp = cbo_BH_sanPham.SelectedValue.ToString();
                    int soluong = int.Parse(nbr_BH_soLuong.Value.ToString());
                    double dongia = double.Parse(txt_BH_donGia.Text);
                    double khuyenmai = double.Parse(txt_BH_khuyenMai.Text);
                    double tongtien = double.Parse(txt_BH_thanhTien.Text);
                    them_du_lieu_dataridview_CTHD(mahd, masp, soluong, dongia, khuyenmai, tongtien);
                }

              

            }

        }
        private void btn_BH_tinhTien_Click(object sender, EventArgs e)
        {
            //Lấy giá trị của mã sản phẩm, số lượng
            string maSP = cbo_BH_sanPham.SelectedValue.ToString();
            int soLuong = (int)nbr_BH_soLuong.Value;
            double giaBan = 0;

            //Kiểm tra Khuyến mãi phải nhập trước khi click
            if (string.IsNullOrEmpty(txt_BH_khuyenMai.Text))
            {
                MessageBox.Show("Nhập khuyến mãi!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double khuyenMai = double.Parse(txt_BH_khuyenMai.Text);
            // Kết nối đến cơ sở dữ liệu
            SqlConnection myConnection = Ket_Noi();

            string sSql_Gia_Ban = "SELECT GiaBan FROM SanPham WHERE MASP = @MaSP";
            {
                try
                {
                    myConnection.Open();

                    SqlCommand cmd = new SqlCommand(sSql_Gia_Ban, myConnection);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);

                    giaBan = Convert.ToDouble(cmd.ExecuteScalar());

                    // Tính thành tiền
                    double thanhTien = (soLuong * giaBan) - (soLuong * giaBan) * khuyenMai;
                    txt_BH_thanhTien.Text = thanhTien.ToString();
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: thanh tien" + ex.Message);
                }
            }
            btn_BH_add.Enabled = true;
        }

        private void data_banHang_HD_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //try
            //{
            //    txt_BH_maHD.Enabled = false;
            //    string soLuong, ngayLapHD,khuyenMai,mahd,dongia,thanhTien;
            //    string masp;
            //    //Lay du lieu dataridview
            //    mahd = data_banHang_CTHD.CurrentRow.Cells[0].Value.ToString();
            //    soLuong = data_banHang_CTHD.CurrentRow.Cells[2].Value.ToString();
            //    khuyenMai = data_banHang_CTHD.CurrentRow.Cells[4].Value.ToString();
            //    dongia = data_banHang_CTHD.CurrentRow.Cells[3].Value.ToString();
            //    ngayLapHD = data_banHang_HD.CurrentRow.Cells[3].Value.ToString();
            //    thanhTien = data_banHang_CTHD.CurrentRow.Cells[5].Value.ToString();

            //    //điền dữ liềuj datagridview vào textbox
            //    txt_BH_maHD.Text = mahd;
            //    nbr_BH_soLuong.Text = soLuong;
            //    txt_BH_khuyenMai.Text = khuyenMai;
            //    txt_BH_donGia.Text = dongia;
            //    dt_BH_ngayLapHD.Text = ngayLapHD;
            //    txt_BH_thanhTien.Text = thanhTien;
            //}
            //catch (Exception err)
            //{


            //}
        }
        public bool CapNhatBanHang( string soLuong, string thanhtien, string khuyenMai,string mahd)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            string sSql = "";
            sSql = "UPDATE CT_HOADON";
            sSql += " SET ";
            sSql += "soluong='" + soLuong + "',";
            sSql += "khuyenMai='" + khuyenMai + "', ";
            sSql += "ThanhTien='" + thanhtien + "'";
            sSql += "where mahd='" + mahd + "'";
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql, myConnection);
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception err)
            {

                kq = false;
                MessageBox.Show("Chi Tiet" + err.Message);
            }

            return kq;

        }

        private void btn_BH_update_Click_1(object sender, EventArgs e)
        {
            string soLuong, thanhtien, ngayLapHD, khuyenMai,mahd;
            mahd=txt_BH_maHD.Text;
            soLuong = nbr_BH_soLuong.Text;
            thanhtien = txt_BH_thanhTien.Text;
            khuyenMai = txt_BH_khuyenMai.Text;
            bool kq = CapNhatBanHang(soLuong, thanhtien, khuyenMai,mahd);
            if (kq == true)
            {

                MessageBox.Show("Cập nhật  thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hien_Don_Gia();
                string sSql_Xem_CT_Hoa_Don = "select*from CT_hoadon";
                DataSet ds_CT_Hoa_Don = Xem_Thong_Tin(sSql_Xem_CT_Hoa_Don);
                data_banHang_CTHD.DataSource = ds_CT_Hoa_Don.Tables[0];

            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool Them_Khach_Hang(string tenKH, string diaChi, string SDT, string ngayTao, string email)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            //Câu truy vấn thêm vào bảng KHACHHANG
            string sSql_KH;
            sSql_KH = "INSERT INTO KhachHang VALUES (";
            sSql_KH += "'0',";
            sSql_KH += "N'" + tenKH + "',";
            sSql_KH += "N'" + diaChi + "',";
            sSql_KH += "'" + SDT + "',";
            sSql_KH += "'" + ngayTao + "',";
            sSql_KH += "'" + email + "')";

            try
            {
                myConnection.Open();
                //thực thi câu truy vấn thêm vào bảng KHACHHANG
                SqlCommand cmd = new SqlCommand(sSql_KH, myConnection);
                cmd.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi Khách Hàng. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        private void btn_KH_themKH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_KH_tenKH.Text.Trim()) ||
               string.IsNullOrEmpty(txt_KH_diaChi.Text.Trim()) ||
               string.IsNullOrEmpty(txt_KH_sdt.Text.Trim()) ||
               string.IsNullOrEmpty(txt_KH_email.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string tenKH, diaChi, SDT, email, ngayTao;

                tenKH = txt_KH_tenKH.Text;
                diaChi = txt_KH_diaChi.Text;
                SDT = txt_KH_sdt.Text;
                email = txt_KH_email.Text;
                ngayTao = dt_BH_ngayLapHD.Value.ToString("yyyy-MM-dd HH:mm:ss");

                bool kq = Them_Khach_Hang(tenKH, diaChi, SDT, ngayTao, email);
                if (kq == false)
                {
                    MessageBox.Show("Thêm Khách Hàng KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã thêm Khách Hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_Khach_Hang = "SELECT * FROM KhachHang";
                    DataSet ds_Khach_Hang = Xem_Thong_Tin(sSql_Xem_Khach_Hang);
                    data_khachHang.DataSource = ds_Khach_Hang.Tables[0];
                    Hien_Thi_Len_HD_CBO_Khach_Hang();
                }
            }
        }

        private void lab_BH_NV_Click(object sender, EventArgs e)
        {

        }

        private void btn_BH_xem_tat_ca_hd_Click(object sender, EventArgs e)
        {
           TiemKiemHD tk=new TiemKiemHD();
            tk.Show();
        }

        private void btn_them_moi_Click(object sender, EventArgs e)
        {
            txt_BH_maHD.Enabled = false;

        }
        public void Dang_Xuat()
        {
            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Bạn muốn đăng xuất tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                this.Hide();
                frmDangNhap dangNhap = new frmDangNhap();
                dangNhap.Show();
            }
            else { return; }
        }

        private void btn_BH_dang_xuat_Click(object sender, EventArgs e)
        {
            Dang_Xuat();
        }

        private void btn_them_moi_Click_1(object sender, EventArgs e)
        {
            // Lấy thông tin từ các control
            string mahd = txt_BH_maHD.Text;
            string manv = cbo_BH_NV.Text;
            string makh = cbo_BH_KH.Text;
            string ngaylaphd = dt_BH_ngayLapHD.Value.ToString();
            string tongtien = txt_BH_thanhTien.Text;

            // Gọi phương thức them_du_lieu_dataridview và truyền các thông tin lấy được từ các control vào
            them_du_lieu_dataridview(mahd, manv, makh, ngaylaphd);
        }

        private void them_du_lieu_dataridview(string mahd, string manv, string makh, string ngaylaphd)
        {
            // Tạo một DataGridViewRow mới và gán giá trị cho các cell của row đó
            bool tonTai = false;
            foreach (DataGridViewRow MAHD in data_banHang_HD.Rows)
            {
                if (MAHD.Cells[0].Value != null && MAHD.Cells[0].Value.ToString() == mahd)
                {
                    tonTai = true;
                    break;
                }
            }

            if (tonTai)
            {
                // Mã hóa đơn đã tồn tại, thông báo cho người dùng và không thêm mới
                MessageBox.Show("Mã hóa đơn đã tồn tại. Vui lòng chọn mã hóa đơn khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(data_banHang_HD);
                mahd = txt_BH_maHD.Text;
                manv = cbo_BH_NV.SelectedValue.ToString();
                makh = cbo_BH_KH.SelectedValue.ToString();
                ngaylaphd = dt_BH_ngayLapHD.Value.ToString();
                row.Cells[0].Value = mahd;
                row.Cells[1].Value = manv;
                row.Cells[2].Value = makh;
                row.Cells[3].Value = ngaylaphd;

                // Thêm row vào DataGridView
                data_banHang_HD.Rows.Add(row);
            }
        }
        private void them_du_lieu_dataridview_CTHD(string mahd, string masp, int soluong, double dongia, double khuyenmai, double tongtien)
        {


            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(data_banHang_CTHD);
            mahd = txt_BH_maHD.Text;
            masp = cbo_BH_sanPham.SelectedValue.ToString();
            soluong = int.Parse(nbr_BH_soLuong.Value.ToString());
            dongia = double.Parse(txt_BH_donGia.Text);
            khuyenmai = double.Parse(txt_BH_khuyenMai.Text);
            tongtien = double.Parse(txt_BH_thanhTien.Text);
            row.Cells[0].Value = mahd;
            row.Cells[1].Value = masp;
            row.Cells[2].Value = soluong;
            row.Cells[3].Value = dongia;
            row.Cells[4].Value = khuyenmai;
            row.Cells[5].Value = tongtien;

            // Thêm row vào DataGridView
            data_banHang_CTHD.Rows.Add(row);

        }

    }
}
