using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GiaoDien_DangNhap
{
    public partial class frmQuanLy : Form
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }
        
        private static string scon = "Data Source = TranTuan\\MSSQL_SERVER; Initial Catalog = qlbanmaytinh; Integrated Security = true;";

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            //TAB NHÂN VIÊN
            string sSql_Xem_Nhan_Vien = "SELECT * FROM NhanVien";
            DataSet ds_Nhan_Vien = Xem_Thong_Tin(sSql_Xem_Nhan_Vien);
            data_NV.DataSource = ds_Nhan_Vien.Tables[0];
                //Sử dụng ToolTip cho các button
                    //Tạo ToolTip
                    ToolTip tlt_NV = new ToolTip();
                    tlt_NV.ShowAlways = true;
                    //Gán ToolTip vào button
                    tlt_NV.SetToolTip(btn_NV_Them, "Thêm");
                    tlt_NV.SetToolTip(btn_NV_Sua, "Sửa");
                    tlt_NV.SetToolTip(btn_NV_Xoa, "Xóa");
                    tlt_NV.SetToolTip(btn_NV_Lam_Moi, "Làm mới");

            //TAB KHÁCH HÀNG
            string sSql_Xem_Khach_Hang = "SELECT * FROM KhachHang";
            DataSet ds_Khach_Hang = Xem_Thong_Tin(sSql_Xem_Khach_Hang);
            data_KH.DataSource = ds_Khach_Hang.Tables[0];
                //Sử dụng ToolTip cho các button
                    //Tạo ToolTip
                    ToolTip tlt_KH = new ToolTip();
                    tlt_KH.ShowAlways = true;
                    //Gán ToolTip vào button
                    tlt_KH.SetToolTip(btn_KH_Them, "Thêm");
                    tlt_KH.SetToolTip(btn_KH_Sua, "Sửa");
                    tlt_KH.SetToolTip(btn_KH_Xoa, "Xóa");
                    tlt_KH.SetToolTip(btn_KH_Lam_Moi, "Làm mới");

            //TAB HÓA ĐƠN
            string sSql_Xem_Hoa_Don = "SELECT HOADON.MAHD, MANV, MAKH, MASP, SOLUONG, DONGIA, HOADON.TONGTIEN,KHUYENMAI,NGAYLAPHD " +
                                      "FROM HOADON JOIN CT_HOADON ON HOADON.MAHD = CT_HOADON.MAHD";
            DataSet ds_Hoa_Don = Xem_Thong_Tin(sSql_Xem_Hoa_Don);
            data_HD.DataSource = ds_Hoa_Don.Tables[0];
            Hien_Thi_Len_HD_CBO_San_Pham();
            Hien_Thi_Len_HD_CBO_Nhan_Vien();
            Hien_Thi_Len_HD_CBO_Khach_Hang();
            Hien_Don_Gia();
                //Sử dụng ToolTip cho các button
                    //Tạo ToolTip
                    ToolTip tlt_HD = new ToolTip();
                    tlt_HD.ShowAlways = true;
                    //Gán ToolTip vào button
                    tlt_HD.SetToolTip(btn_HD_Them, "Thêm");
                    tlt_KH.SetToolTip(btn_HD_Sua, "Sửa");
                    tlt_KH.SetToolTip(btn_HD_Xoa, "Xóa");
                    tlt_KH.SetToolTip(btn_HD_Thong_Ke, "Thống kê");

            //TAB NHÀ CUNG CẤP
            string sSql_Xem_Nha_Cung_Cap = "SELECT * FROM NhaCungCap";
            DataSet ds_Nha_Cung_Cap = Xem_Thong_Tin(sSql_Xem_Nha_Cung_Cap);
            data_NCC.DataSource = ds_Nha_Cung_Cap.Tables[0];
                //Sử dụng ToolTip cho các button
                    //Tạo ToolTip
                    ToolTip tlt_NCC = new ToolTip();
                    tlt_NCC.ShowAlways = true;
                    //Gán ToolTip vào button
                    tlt_NCC.SetToolTip(btn_NCC_Them, "Thêm");
                    tlt_NCC.SetToolTip(btn_NCC_Sua, "Sửa");
                    tlt_NCC.SetToolTip(btn_NCC_Xoa, "Xóa");
                    tlt_NCC.SetToolTip(btn_NCC_Lam_Moi, "Làm mới");

            //TAB SẢN PHẨM
            string sSql_Xem_San_Pham = "SELECT * FROM SanPham";
            DataSet ds_San_Pham = Xem_Thong_Tin(sSql_Xem_San_Pham);
            data_SP.DataSource = ds_San_Pham.Tables[0];
            Hien_Thi_Len_SP_CBO_Nha_Cung_Cap();
            cbo_SP_Xuat_Xu.SelectedItem = cbo_SP_Xuat_Xu.Items[0];
                //Sử dụng ToolTip cho các button
                    //Tạo ToolTip
                    ToolTip tlt_SP = new ToolTip();
                    tlt_SP.ShowAlways = true;
                    //Gán ToolTip vào button
                    tlt_SP.SetToolTip(btn_SP_Them, "Thêm");
                    tlt_SP.SetToolTip(btn_SP_Sua, "Sửa");
                    tlt_SP.SetToolTip(btn_SP_Xoa, "Xóa");
                    tlt_SP.SetToolTip(btn_SP_Lam_Moi, "Làm mới");
        }

        public static SqlConnection Ket_Noi()
        {
            SqlConnection myConnection = new SqlConnection(scon);
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
                MessageBox.Show("Loi: " +ex.Message);
            }
            return ds;
        }

        public void Dang_Xuat()
        {
            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Bạn muốn đăng xuất tài khoản?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dlg == DialogResult.Yes)
            {
                this.Hide();
                frmDangNhap dangNhap = new frmDangNhap();
                dangNhap.Show();
            }
            else { return; }
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

                cbo_HD_San_Pham.DataSource = ds.Tables[0];
                cbo_HD_San_Pham.DisplayMember = "TenSP";
                cbo_HD_San_Pham.ValueMember = "MaSP";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
        }

        public void Hien_Thi_Len_HD_CBO_Nhan_Vien()
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Hien = "SELECT MaNV, TenNV FROM NhanVien";
            try
            {
                myConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Hien, myConnection);
                DataSet ds = new DataSet();
                dsHien.Fill(ds);
                myConnection.Close();

                cbo_HD_Nhan_Vien.DataSource = ds.Tables[0];
                cbo_HD_Nhan_Vien.DisplayMember = "TenNV";
                cbo_HD_Nhan_Vien.ValueMember = "MaNV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
        }

        public void Hien_Thi_Len_HD_CBO_Khach_Hang()
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Hien = "SELECT MaKH, TenKH FROM KhachHang";
            try
            {
                myConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Hien, myConnection);
                DataSet ds = new DataSet();
                dsHien.Fill(ds);
                myConnection.Close();

                cbo_HD_Khach_Hang.DataSource = ds.Tables[0];
                cbo_HD_Khach_Hang.DisplayMember = "TenKH";
                cbo_HD_Khach_Hang.ValueMember = "MaKH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
        }

        public void Hien_Thi_Len_SP_CBO_Nha_Cung_Cap()
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Hien = "SELECT MaNCC, TenNCC FROM NhaCungCap";
            try
            {
                myConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Hien, myConnection);
                DataSet ds = new DataSet();
                dsHien.Fill(ds);
                myConnection.Close();

                cbo_SP_Nha_Cung_Cap.DataSource = ds.Tables[0];
                cbo_SP_Nha_Cung_Cap.DisplayMember = "TenNCC";
                cbo_SP_Nha_Cung_Cap.ValueMember = "MaNCC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
        }

        public void Hien_Don_Gia()
        {
            string maSP = cbo_HD_San_Pham.SelectedValue.ToString();
            double giaBan = 0;

            SqlConnection myConnection = Ket_Noi();
            string sSql_Gia_Ban = "SELECT GiaBan FROM SanPham WHERE MASP = @MaSP";
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql_Gia_Ban, myConnection);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                giaBan = Convert.ToDouble(cmd.ExecuteScalar());
                txt_HD_Don_Gia.Text = giaBan.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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
            sSql_HD += "'" + ngayLap + "',";
            sSql_HD += thanhTien + ")";

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

                //thực thi câu truy vấn thêm vào bảng CT_HOADON
                cmd = new SqlCommand(sSql_CTHD, myConnection);
                cmd.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi Hóa Đơn. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        public bool Them_Nha_Cung_Cap(string tenNCC, string diaChi, string SDT, string email)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            //Câu truy vấn thêm vào bảng NHACUNGCAP
            string sSql_NCC;
            sSql_NCC = "INSERT INTO NhaCungCap VALUES (";
            sSql_NCC += "'0',";
            sSql_NCC += "'" + tenNCC + "',";
            sSql_NCC += "N'" + diaChi + "',";
            sSql_NCC += "'" + SDT + "',";
            sSql_NCC += "'" + email + "')";

            try
            {
                myConnection.Open();
                //thực thi câu truy vấn thêm vào bảng NHACUNGCAP
                SqlCommand cmd = new SqlCommand(sSql_NCC, myConnection);
                cmd.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi Nhà Cung Cấp. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        public bool Sua_Nha_Cung_Cap(string tenNCC, string diaChi, string SDT, string email)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            string maNCC = data_NCC.CurrentRow.Cells[0].Value.ToString();
            //Câu truy vấn sửa bảng NHACUNGCAP
            string sSql_NCC;
            sSql_NCC = "UPDATE NhaCungCap SET TENNCC = '" + tenNCC + "', DIACHI = N'" + diaChi + "', SDT = '" + SDT + "', EMAIL = '" + email + "' WHERE MANCC = @MANCC";

            try
            {
                myConnection.Open();
                //thực thi câu truy vấn sửa bảng NHACUNGCAP
                SqlCommand cmd = new SqlCommand(sSql_NCC, myConnection);
                cmd.Parameters.AddWithValue("@MANCC", maNCC);
                cmd.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi Sửa Nhà Cung Cấp. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        public bool Them_San_Pham(string tenSP, double giaNhap, double giaBan, string xuatXu, bool trangThai, double khuyenMai, string maNCC)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            //Câu truy vấn thêm vào bảng SANPHAM
            string sSql_SP;
            sSql_SP = "INSERT INTO SanPham VALUES (";
            sSql_SP += "'0',";
            sSql_SP += "'" + tenSP + "',";
            sSql_SP += giaNhap + ",";
            sSql_SP += giaBan + ",";
            sSql_SP += "N'" + xuatXu + "',";
            sSql_SP += "'"+ trangThai + "',";
            sSql_SP += khuyenMai + ",";
            sSql_SP += "'" + maNCC + "')";

            try
            {
                myConnection.Open();
                //thực thi câu truy vấn thêm vào bảng NHACUNGCAP
                SqlCommand cmd = new SqlCommand(sSql_SP, myConnection);
                cmd.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi Sản Phẩm. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        public bool Them_Khach_Hang(string tenKH, string diaChi, string SDT,string ngayTao, string email)
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

        public bool Them_Nhan_Vien(string tenNV, string gioiTinh, string ngaySinh, string SDT, int luong, string username, string password, string email)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            //Câu truy vấn thêm vào bảng TAIKHOAN
            string sSql_TK;
            sSql_TK = "INSERT INTO TaiKhoan VALUES (";
            sSql_TK += "'" + username + "',";
            sSql_TK += "'" + password + "',";
            sSql_TK += "'NV')";

            //Câu truy vấn thêm vào bảng NHANVIEN
            string sSql_NV;
            sSql_NV = "INSERT INTO NhanVien VALUES (";
            sSql_NV += "'0',";
            sSql_NV += "N'" + tenNV + "',";
            sSql_NV += "N'" + gioiTinh + "',";
            sSql_NV += "'" + ngaySinh + "',";
            sSql_NV += "'" + SDT + "',";
            sSql_NV += luong + ",";
            sSql_NV += "'" + username + "',";
            sSql_NV += "'" + password + "',";
            sSql_NV += "'" + email + "')";

            try
            {
                myConnection.Open();

                //thực thi câu truy vấn thêm vào bảng TaiKhoan
                SqlCommand cmd = new SqlCommand(sSql_TK, myConnection);
                cmd.ExecuteNonQuery();
                //thực thi câu truy vấn thêm vào bảng NhanVien
                cmd = new SqlCommand(sSql_NV, myConnection);
                cmd.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi Nhân Viên. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        public bool Xoa_Dong(string ma, string sSql_Xoa, string bien)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();

            try
            {
                myConnection.Open();
                //thực thi câu truy vấn xóa dòng của NHACUNGCAP
                SqlCommand cmd = new SqlCommand(sSql_Xoa, myConnection);
                cmd.Parameters.AddWithValue(bien, ma);
                cmd.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi Sửa. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        public DataSet Tim_Kiem(string tenBang, string tenCot, string tenTK)
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Tim_Kiem = "SELECT * FROM " + tenBang + " WHERE " + tenCot + " LIKE N'%" + tenTK + "%'";
            DataSet ds = null;
            try
            {
                myConnection.Open();

                SqlDataAdapter ds_Hien = new SqlDataAdapter(sSql_Tim_Kiem,myConnection);
                ds = new DataSet();
                ds_Hien.Fill(ds);

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
            return ds;
        }

        public DataSet Tim_Kiem_HD(string tenTK)
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Tim_Kiem = "SELECT HOADON.MAHD, MANV, MAKH, MASP, SOLUONG, DONGIA, HOADON.TONGTIEN,KHUYENMAI,NGAYLAPHD " +
                                              "FROM HOADON JOIN CT_HOADON ON HOADON.MAHD = CT_HOADON.MAHD " +
                                              "WHERE HOADON.MAHD LIKE N'%"+tenTK+"%'";
            DataSet ds = null;
            try
            {
                myConnection.Open();

                SqlDataAdapter ds_Hien = new SqlDataAdapter(sSql_Tim_Kiem, myConnection);
                ds = new DataSet();
                ds_Hien.Fill(ds);

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
            return ds;
        }

        private void btn_NV_Them_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = Ket_Noi();
            if (string.IsNullOrEmpty(txt_NV_Ten_Nhan_Vien.Text.Trim()) ||
                string.IsNullOrEmpty(txt_NV_SDT.Text.Trim()) ||
                string.IsNullOrEmpty(txt_NV_Luong.Text.Trim()) ||
                string.IsNullOrEmpty(txt_NV_User_Name.Text.Trim()) ||
                string.IsNullOrEmpty(txt_NV_Password.Text.Trim()) ||
                string.IsNullOrEmpty(txt_NV_Email.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string tenNV, gioiTinh, ngaySinh, SDT, username, password, email;
                int luong;

                tenNV = txt_NV_Ten_Nhan_Vien.Text;
                if (rad_NV_Nam.Checked)
                {
                    gioiTinh = "Nam";
                }
                else
                {
                    gioiTinh = "Nữ";
                }
                ngaySinh = dt_NV_Ngay_Sinh.Value.ToString("yyyy-MM-dd HH:mm:ss"); ;
                SDT = txt_NV_SDT.Text;
                luong = int.Parse(txt_NV_Luong.Text);
                username = txt_NV_User_Name.Text;
                password = txt_NV_Password.Text;
                email = txt_NV_Email.Text;

                bool kq = Them_Nhan_Vien(tenNV, gioiTinh, ngaySinh, SDT, luong, username, password, email);
                if (kq == false)
                {
                    MessageBox.Show("Thêm Nhân Viên KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã thêm Nhân Viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_Nhan_Vien = "SELECT * FROM NhanVien";
                    DataSet ds_Nhan_Vien = Xem_Thong_Tin(sSql_Xem_Nhan_Vien);
                    data_NV.DataSource = ds_Nhan_Vien.Tables[0];
                    Hien_Thi_Len_HD_CBO_Nhan_Vien();
                }
            }
        }


        private void btn_SP_Them_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = Ket_Noi();
            if (string.IsNullOrEmpty(txt_SP_Ten_San_Pham.Text.Trim()) ||
                string.IsNullOrEmpty(cbo_SP_Xuat_Xu.Text.Trim()) ||
                string.IsNullOrEmpty(txt_SP_Gia_Nhap.Text.Trim()) ||
                string.IsNullOrEmpty(txt_SP_Gia_Ban.Text.Trim()) ||
                string.IsNullOrEmpty(cbo_SP_Nha_Cung_Cap.Text.Trim()) ||
                string.IsNullOrEmpty(txt_SP_Khuyen_Mai.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string tenSP, xuatXu, maNCC;
                double giaNhap, giaBan, khuyenMai;
                bool trangThai;

                tenSP = txt_SP_Ten_San_Pham.Text;
                giaNhap = double.Parse(txt_SP_Gia_Nhap.Text);
                giaBan = double.Parse(txt_SP_Gia_Ban.Text);
                xuatXu = cbo_SP_Xuat_Xu.Text;
                trangThai = false;
                if (chk_SP_Trang_Thai.Checked)
                {
                    trangThai = true;
                }
                khuyenMai = double.Parse(txt_SP_Khuyen_Mai.Text);
                maNCC = cbo_SP_Nha_Cung_Cap.SelectedValue.ToString();

                bool kq = Them_San_Pham(tenSP, giaNhap, giaBan, xuatXu, trangThai, khuyenMai, maNCC);
                if (kq == false)
                {
                    MessageBox.Show("Thêm Sản Phẩm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã thêm Sản Phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_San_Pham = "SELECT * FROM SanPham";
                    DataSet ds_San_Pham = Xem_Thong_Tin(sSql_Xem_San_Pham);
                    data_SP.DataSource = ds_San_Pham.Tables[0];
                    Hien_Thi_Len_HD_CBO_San_Pham();
                }
            }
        }

        private void btn_HD_Tinh_Tien_Click(object sender, EventArgs e)
        {
            //Lấy giá trị của mã sản phẩm, số lượng
            string maSP = cbo_HD_San_Pham.SelectedValue.ToString();
            int soLuong = (int)nmr_HD_So_Luong.Value;
            double giaBan = 0;

            //Kiểm tra Khuyến mãi phải nhập trước khi click
            if (string.IsNullOrEmpty(txt_HD_Khuyen_Mai.Text))
            {
                MessageBox.Show("Nhập khuyến mãi!!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double khuyenMai = double.Parse(txt_HD_Khuyen_Mai.Text);


            // Câu lệnh truy vấn lấy giá bán của sản phẩm
            string sSql_Gia_Ban = "SELECT GiaBan FROM SanPham WHERE MASP = @MaSP";

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection myConnection = Ket_Noi())
            {
                try
                {
                    myConnection.Open();

                    SqlCommand cmd = new SqlCommand(sSql_Gia_Ban, myConnection);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);

                    giaBan = Convert.ToDouble(cmd.ExecuteScalar());

                    // Tính thành tiền
                    double thanhTien = (soLuong * giaBan) - (soLuong * giaBan) * khuyenMai;
                    txt_HD_Thanh_Tien.Text = thanhTien.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            btn_HD_Them.Enabled = true;
        }

        private void btn_HD_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_HD_Ma_Hoa_Don.Text.Trim()) ||
                string.IsNullOrEmpty(cbo_HD_San_Pham.Text.Trim()) ||
                string.IsNullOrEmpty(txt_HD_Don_Gia.Text.Trim()) ||
                string.IsNullOrEmpty(txt_HD_Thanh_Tien.Text.Trim()) ||
                string.IsNullOrEmpty(cbo_HD_Khach_Hang.Text.Trim()) ||
                string.IsNullOrEmpty(cbo_HD_Nhan_Vien.Text.Trim()) ||
                string.IsNullOrEmpty(txt_HD_Khuyen_Mai.Text.Trim()))
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

                maHD = txt_HD_Ma_Hoa_Don.Text;
                maSP = cbo_HD_San_Pham.SelectedValue.ToString();
                soLuong = int.Parse(nmr_HD_So_Luong.Text);
                donGia = int.Parse(txt_HD_Don_Gia.Text);
                thanhTien = int.Parse(txt_HD_Thanh_Tien.Text);
                maKH = cbo_HD_Khach_Hang.SelectedValue.ToString();
                maNV = cbo_HD_Nhan_Vien.SelectedValue.ToString();
                khuyenMai = double.Parse(txt_HD_Khuyen_Mai.Text);
                ngayLap = dt_HD_Ngay_Lap_HD.Value.ToString("yyyy-MM-dd HH:mm:ss");

                bool kq = Them_Hoa_Don(maHD, maSP, soLuong, donGia, thanhTien, maKH, maNV, ngayLap, khuyenMai);
                if (kq == false)
                {
                    MessageBox.Show("Thêm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã thêm Hóa Đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_Hoa_Don = "SELECT HOADON.MAHD, MANV, MAKH, MASP, SOLUONG, DONGIA, HOADON.TONGTIEN,KHUYENMAI,NGAYLAPHD " +
                                              "FROM HOADON JOIN CT_HOADON ON HOADON.MAHD = CT_HOADON.MAHD";
                    DataSet ds_Hoa_Don = Xem_Thong_Tin(sSql_Xem_Hoa_Don);
                    data_HD.DataSource = ds_Hoa_Don.Tables[0];
                }
            }
        }

        private void cbo_HD_San_Pham_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hien_Don_Gia();
        }

        private void btn_NCC_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_NCC_Ten_Nha_Cung_Cap.Text.Trim()) ||
                string.IsNullOrEmpty(txt_NCC_Dia_Chi.Text.Trim()) ||
                string.IsNullOrEmpty(txt_NCC_SDT.Text.Trim()) ||
                string.IsNullOrEmpty(txt_NCC_Email.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string  tenNCC, diaChi, SDT, email;

                tenNCC = txt_NCC_Ten_Nha_Cung_Cap.Text;
                diaChi = txt_NCC_Dia_Chi.Text;
                SDT = txt_NCC_SDT.Text;
                email = txt_NCC_Email.Text;

                bool kq = Them_Nha_Cung_Cap( tenNCC, diaChi, SDT, email);
                if (kq == false)
                {
                    MessageBox.Show("Thêm Nhà Cung Cấp KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã thêm Nhà Cung Cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_Nha_Cung_Cap = "SELECT * FROM NhaCungCap";
                    DataSet ds_Nha_Cung_Cap = Xem_Thong_Tin(sSql_Xem_Nha_Cung_Cap);
                    data_NCC.DataSource = ds_Nha_Cung_Cap.Tables[0];
                    Hien_Thi_Len_SP_CBO_Nha_Cung_Cap();
                }
            }
        }

        private void btn_KH_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_KH_Ten_Khach_Hang.Text.Trim()) ||
                string.IsNullOrEmpty(txt_KH_Dia_Chi.Text.Trim()) ||
                string.IsNullOrEmpty(txt_KH_SDT.Text.Trim()) ||
                string.IsNullOrEmpty(txt_KH_Email.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string tenKH, diaChi, SDT, email, ngayTao;

                tenKH = txt_KH_Ten_Khach_Hang.Text;
                diaChi = txt_KH_Dia_Chi.Text;
                SDT = txt_KH_SDT.Text;
                email = txt_KH_Email.Text;
                ngayTao = dt_KH_Ngay_Tao.Value.ToString("yyyy-MM-dd HH:mm:ss");

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
                    data_KH.DataSource = ds_Khach_Hang.Tables[0];
                    Hien_Thi_Len_HD_CBO_Khach_Hang();
                }
            }
        }

        private void txt_NV_Tim_Kiem_TextChanged(object sender, EventArgs e)
        {
            string tenBang, tenCot, tenTK;
            tenBang = "NhanVien";
            tenCot = "TenNV";
            tenTK = txt_NV_Tim_Kiem.Text;
            DataSet ds = Tim_Kiem(tenBang, tenCot, tenTK);
            data_NV.DataSource = ds.Tables[0];
        }

        private void txt_KH_Tim_Kiem_TextChanged(object sender, EventArgs e)
        {
            string tenBang, tenCot, tenTK;
            tenBang = "KhachHang";
            tenCot = "TenKH";
            tenTK = txt_KH_Tim_Kiem.Text;
            DataSet ds = Tim_Kiem(tenBang, tenCot, tenTK);
            data_KH.DataSource = ds.Tables[0];
        }

        private void txt_HD_Tim_Kiem_TextChanged(object sender, EventArgs e)
        {
            string tenTK;
            tenTK = txt_HD_Tim_Kiem.Text;
            DataSet ds = Tim_Kiem_HD(tenTK);
            data_HD.DataSource = ds.Tables[0];
        }

        private void txt_NCC_Tim_Kiem_TextChanged(object sender, EventArgs e)
        {
            string tenBang, tenCot, tenTK;
            tenBang = "NhaCungcap";
            tenCot = "TenNCC";
            tenTK = txt_NCC_Tim_Kiem.Text;
            DataSet ds = Tim_Kiem(tenBang, tenCot, tenTK);
            data_NCC.DataSource = ds.Tables[0];
        }

        private void txt_SP_Tim_Kiem_TextChanged(object sender, EventArgs e)
        {
            string tenBang, tenCot, tenTK;
            tenBang = "SanPham";
            tenCot = "TenSP";
            tenTK = txt_SP_Tim_Kiem.Text;
            DataSet ds = Tim_Kiem(tenBang, tenCot, tenTK);
            data_SP.DataSource = ds.Tables[0];
        }

        private void btn_NCC_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_NCC_Ten_Nha_Cung_Cap.Text.Trim()) ||
                string.IsNullOrEmpty(txt_NCC_Dia_Chi.Text.Trim()) ||
                string.IsNullOrEmpty(txt_NCC_SDT.Text.Trim()) ||
                string.IsNullOrEmpty(txt_NCC_Email.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string tenNCC, diaChi, SDT, email;

                tenNCC = txt_NCC_Ten_Nha_Cung_Cap.Text;
                diaChi = txt_NCC_Dia_Chi.Text;
                SDT = txt_NCC_SDT.Text;
                email = txt_NCC_Email.Text;

                bool kq = Sua_Nha_Cung_Cap(tenNCC, diaChi, SDT, email);
                if (kq == false)
                {
                    MessageBox.Show("Sửa Nhà Cung Cấp KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Sửa Nhà Cung Cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_Nha_Cung_Cap = "SELECT * FROM NhaCungCap";
                    DataSet ds_Nha_Cung_Cap = Xem_Thong_Tin(sSql_Xem_Nha_Cung_Cap);
                    data_NCC.DataSource = ds_Nha_Cung_Cap.Tables[0];
                    Hien_Thi_Len_SP_CBO_Nha_Cung_Cap();
                    btn_NCC_Lam_Moi_Click(sender, e);
                    btn_NCC_Sua.Enabled = false;
                    btn_NCC_Them.Enabled = true;
                }
            }
        }

        private void data_NCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string tenNCC, diaChi, SDT, email;
                tenNCC = data_NCC.CurrentRow.Cells[1].Value.ToString();
                diaChi = data_NCC.CurrentRow.Cells[2].Value.ToString();
                SDT = data_NCC.CurrentRow.Cells[3].Value.ToString();
                email = data_NCC.CurrentRow.Cells[4].Value.ToString();

                txt_NCC_Ten_Nha_Cung_Cap.Text = tenNCC;
                txt_NCC_Dia_Chi.Text = diaChi;
                txt_NCC_SDT.Text = SDT;
                txt_NCC_Email.Text = email;

                btn_NCC_Sua.Enabled = true;
                btn_NCC_Xoa.Enabled = true;
                btn_NCC_Them.Enabled = false;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btn_NCC_Xoa_Click(object sender, EventArgs e)
        {
            string bien = "@MANCC";
            string maNCC = data_NCC.CurrentRow.Cells[0].Value.ToString();
            //Câu truy vấn xóa dòng của NHACUNGCAP
            string sSql_NCC;
            sSql_NCC = "DELETE NhaCungCap WHERE MANCC = @MANCC";
            DialogResult dlg = new DialogResult(); 
            dlg = MessageBox.Show("Bạn có chắc muốn xóa Nhà Cung Cấp này?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dlg == DialogResult.Yes)
            {
                bool kq = Xoa_Dong(maNCC, sSql_NCC, bien);
                if (kq == false)
                {
                    MessageBox.Show("Xóa Nhà Cung Cấp KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Xóa Nhà Cung Cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_Nha_Cung_Cap = "SELECT * FROM NhaCungCap";
                    DataSet ds_Nha_Cung_Cap = Xem_Thong_Tin(sSql_Xem_Nha_Cung_Cap);
                    data_NCC.DataSource = ds_Nha_Cung_Cap.Tables[0];
                    Hien_Thi_Len_SP_CBO_Nha_Cung_Cap();
                    btn_NCC_Lam_Moi_Click(sender, e);
                    btn_NCC_Xoa.Enabled = false;
                    btn_NCC_Them.Enabled = true;
                }
            }
            else { return; }
        }

        private void btn_NCC_Lam_Moi_Click(object sender, EventArgs e)
        {
            txt_NCC_Ten_Nha_Cung_Cap.Text = "";
            txt_NCC_Dia_Chi.Text = "";
            txt_NCC_SDT.Text = "";
            txt_NCC_Email.Text = "";
        }

        
        private void data_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string tenKH, diaChi, SDT, email;
                DateTime ngayTao;
                tenKH = data_KH.CurrentRow.Cells[1].Value.ToString();
                diaChi = data_KH.CurrentRow.Cells[2].Value.ToString();
                SDT = data_KH.CurrentRow.Cells[3].Value.ToString();
                ngayTao = (DateTime)data_KH.CurrentRow.Cells[4].Value;
                email = data_KH.CurrentRow.Cells[5].Value.ToString();

                txt_KH_Ten_Khach_Hang.Text = tenKH;
                txt_KH_Dia_Chi.Text = diaChi;
                txt_KH_SDT.Text = SDT;
                dt_KH_Ngay_Tao.Value = ngayTao;
                txt_KH_Email.Text = email;

                btn_KH_Sua.Enabled = true;
                btn_KH_Xoa.Enabled = true;
                btn_KH_Them.Enabled = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_KH_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_KH_Ten_Khach_Hang.Text.Trim()) ||
                string.IsNullOrEmpty(txt_KH_Dia_Chi.Text.Trim()) ||
                string.IsNullOrEmpty(txt_KH_SDT.Text.Trim()) ||
                string.IsNullOrEmpty(txt_KH_Email.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string tenKH, diaChi, SDT, email, ngayTao;

                tenKH = txt_KH_Ten_Khach_Hang.Text;
                diaChi = txt_KH_Dia_Chi.Text;
                SDT = txt_KH_SDT.Text;
                email = txt_KH_Email.Text;
                ngayTao = dt_KH_Ngay_Tao.Value.ToString("yyyy-MM-dd HH:mm:ss");

                bool kq = Them_Khach_Hang(tenKH, diaChi, SDT, ngayTao, email);
                if (kq == false)
                {
                    MessageBox.Show("Sửa Khách Hàng KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Sửa Khách Hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_Khach_Hang = "SELECT * FROM KhachHang";
                    DataSet ds_Khach_Hang = Xem_Thong_Tin(sSql_Xem_Khach_Hang);
                    data_KH.DataSource = ds_Khach_Hang.Tables[0];
                    Hien_Thi_Len_HD_CBO_Khach_Hang();
                    btn_KH_Lam_Moi_Click(sender, e);
                    btn_KH_Sua.Enabled = false;
                    btn_KH_Them.Enabled = true;
                }
            }
        }

        private void btn_KH_Xoa_Click(object sender, EventArgs e)
        {
            string bien = "@MAKH";
            string maKH = data_KH.CurrentRow.Cells[0].Value.ToString();
            //Câu truy vấn xóa dòng của KHACHHANG
            string sSql_KH;
            sSql_KH = "DELETE KhachHang WHERE MAKH = @MAKH";
            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Bạn có chắc muốn xóa Khách Hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                bool kq = Xoa_Dong(maKH, sSql_KH, bien);
                if (kq == false)
                {
                    MessageBox.Show("Xóa Khách Hàng KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Xóa Khách Hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_Khach_Hang = "SELECT * FROM KhachHang";
                    DataSet ds_Khach_Hang = Xem_Thong_Tin(sSql_Xem_Khach_Hang);
                    data_KH.DataSource = ds_Khach_Hang.Tables[0];
                    Hien_Thi_Len_HD_CBO_Khach_Hang();
                    btn_KH_Lam_Moi_Click(sender, e);
                    btn_KH_Xoa.Enabled = false;
                    btn_KH_Them.Enabled = true;
                }
            }
            else { return; }
        }

        private void btn_KH_Lam_Moi_Click(object sender, EventArgs e)
        {
            txt_KH_Ten_Khach_Hang.Text = "";
            txt_KH_Dia_Chi.Text = "";
            txt_KH_SDT.Text = "";
            dt_KH_Ngay_Tao.Value = DateTime.Now;
            txt_KH_Email.Text = "";
        }

        private void btn_NV_Thoat_Click(object sender, EventArgs e)
        {
            Dang_Xuat();
        }

        private void btn_KH_Thoat_Click(object sender, EventArgs e)
        {
            Dang_Xuat();
        }

        private void btn_NCC_Thoat_Click(object sender, EventArgs e)
        {
            Dang_Xuat();
        }

        private void btn_SP_Thoat_Click(object sender, EventArgs e)
        {
            Dang_Xuat();
        }
    }
}
