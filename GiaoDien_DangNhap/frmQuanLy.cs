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

            //TAB KHÁCH HÀNG
            string sSql_Xem_Khach_Hang = "SELECT * FROM KhachHang";
            DataSet ds_Khach_Hang = Xem_Thong_Tin(sSql_Xem_Khach_Hang);
            data_KH.DataSource = ds_Khach_Hang.Tables[0];

            //TAB HÓA ĐƠN
            string sSql_Xem_Hoa_Don = "SELECT HOADON.MAHD, MANV, MAKH, MASP, SOLUONG, DONGIA, HOADON.TONGTIEN,KHUYENMAI,NGAYLAPHD " +
                                      "FROM HOADON JOIN CT_HOADON ON HOADON.MAHD = CT_HOADON.MAHD";
            DataSet ds_Hoa_Don = Xem_Thong_Tin(sSql_Xem_Hoa_Don);
            data_HD.DataSource = ds_Hoa_Don.Tables[0];
            Hien_Thi_Len_HD_CBO_San_Pham();
            Hien_Thi_Len_HD_CBO_Nhan_Vien();
            Hien_Thi_Len_HD_CBO_Khach_Hang();
            Hien_Don_Gia();

            //TAB NHÀ CUNG CẤP
            string sSql_Xem_Nha_Cung_Cap = "SELECT * FROM NhaCungCap";
            DataSet ds_Nha_Cung_Cap = Xem_Thong_Tin(sSql_Xem_Nha_Cung_Cap);
            data_NCC.DataSource = ds_Nha_Cung_Cap.Tables[0];

            //TAB SẢN PHẨM
            string sSql_Xem_San_Pham = "SELECT * FROM SanPham";
            DataSet ds_San_Pham = Xem_Thong_Tin(sSql_Xem_San_Pham);
            data_SP.DataSource = ds_San_Pham.Tables[0];

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

        public static SqlCommand Them_Thong_Tin(string sSql_Them)
        {
            SqlConnection myConnection = Ket_Noi();
            SqlCommand cmd = null;
            try
            {
                myConnection.Open();
                cmd = new SqlCommand(sSql_Them, myConnection);
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
            return cmd;
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


        private void btn_SP_Them_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = Ket_Noi();
            if (string.IsNullOrEmpty(txt_SP_Ma_San_Pham.Text) ||
                string.IsNullOrEmpty(txt_SP_Ten_San_Pham.Text) ||
                string.IsNullOrEmpty(cbo_SP_Xuat_Xu.Text) ||
                string.IsNullOrEmpty(txt_SP_Gia_Nhap.Text) ||
                string.IsNullOrEmpty(txt_SP_Gia_Ban.Text) ||
                string.IsNullOrEmpty(txt_SP_NCC.Text) ||
                string.IsNullOrEmpty(txt_SP_Ma_San_Pham.Text) ||
                string.IsNullOrEmpty(txt_SP_Khuyen_Mai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //Lấy thông tin mã sản phẩm, tên sản phẩm, xuất xứ, giá nhập, giá bán, mã nhà cung cấp, khuyến mãi, trạng thái
                int maSP = int.Parse(txt_SP_Ma_San_Pham.Text);
                string tenSP = txt_SP_Ten_San_Pham.Text;
                string xuatXu = cbo_SP_Xuat_Xu.Text;
                double giaNhap = double.Parse(txt_SP_Gia_Nhap.Text);
                double giaBan = double.Parse(txt_SP_Gia_Ban.Text);
                int maNCC = int.Parse(txt_SP_NCC.Text);
                float khuyenMai = float.Parse(txt_SP_Khuyen_Mai.Text);
                bool trangThai = false;
                if (chk_SP_Trang_Thai.Checked)
                {
                    trangThai = true;
                }

                string sSql_Them = "INSERT INTO SanPham (MASP, TENSP, GIANHAP, GIABAN, XUATXU, TRANGTHAI, KHUYENMAI, MANCC)" +
                      "VALUES('" + maSP + "','" + tenSP + "'," + giaNhap + "," + giaBan + ",'" + xuatXu + "'," + (trangThai ? "1" : "0") + "," + khuyenMai + ",'" + maNCC + "')";

                string sSql_Xem = "SELECT * FROM SanPham";
                try
                {
                    myConnection.Open();

                    SqlCommand cmd = Them_Thong_Tin(sSql_Them);
                    DataSet ds = Xem_Thong_Tin(sSql_Xem);

                    myConnection.Close();
                    //Hiện danh sách sau khi thêm sản phẩm
                    data_SP.DataSource = ds.Tables[0];
                }catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chi tiết: " + ex.Message);
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

                //thực thi câu truy vấn thêm vào bảng HOADON
                cmd = new SqlCommand(sSql_CTHD, myConnection);
                cmd.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        private void btn_HD_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_HD_Ma_Hoa_Don.Text) ||
                string.IsNullOrEmpty(cbo_HD_San_Pham.Text) ||
                string.IsNullOrEmpty(txt_HD_Don_Gia.Text) ||
                string.IsNullOrEmpty(txt_HD_Thanh_Tien.Text) ||
                string.IsNullOrEmpty(cbo_HD_Khach_Hang.Text) ||
                string.IsNullOrEmpty(cbo_HD_Nhan_Vien.Text) ||
                string.IsNullOrEmpty(txt_HD_Khuyen_Mai.Text))
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
                ngayLap = dt_Ngay_Lap_HD.Value.ToString("yyyy-MM-dd HH:mm:ss");

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

        private void data_HD_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
