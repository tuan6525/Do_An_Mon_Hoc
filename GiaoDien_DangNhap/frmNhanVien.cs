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

        String Connect = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=true";
        SqlConnection conn;
        SqlDataAdapter adt;
        DataTable tb;
      
        private SqlDataAdapter query(String Que)
        {
            conn = new SqlConnection(Connect);
            try
            {
                conn.Open();
                adt = new SqlDataAdapter(Que, conn);
                tb = new DataTable();
                adt.Fill(tb);
                data_banHang.DataSource = tb;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return adt;
        }
        private SqlDataAdapter que(String Que)
        {
            conn = new SqlConnection(Connect);
            try
            {
                conn.Open();
                adt = new SqlDataAdapter(Que, conn);
                tb = new DataTable();
                adt.Fill(tb);
                dataGridView2.DataSource = tb;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return adt;
        }
        public static DataSet Xem_Thong_Tin(string sSql_Xem)
        {
            string conn;
            conn = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=True";
            SqlConnection mySqlConnection = new SqlConnection(conn);
            DataSet ds = null;
            try
            {
                mySqlConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Xem, mySqlConnection);
                ds = new DataSet();
                dsHien.Fill(ds);
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi:dataset " + ex.Message);
            }
            return ds;
        }
        private void btn_BH_search_Click(object sender, EventArgs e)
        {
            query("SELECT*FROM SANPHAM WHERE " + "masp="+txt_BH_maHD.Text);
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            //TAB Bán hàng
            string sSql_Xem_Hoa_Don = "select ct.MASP,sp.TENSP,ct.SOLUONG,ct.DONGIA,ct.TONGTIEN,ct.KHUYENMAI\r\nfrom HOADON hd ,SANPHAM sp,CT_HOADON ct\r\nwhere hd.MAHD=ct.MAHD and sp.MASP=ct.MASP";
            DataSet ds_Hoa_Don = Xem_Thong_Tin(sSql_Xem_Hoa_Don);
            data_banHang.DataSource = ds_Hoa_Don.Tables[0];
            Hien_Thi_Len_HD_CBO_San_Pham();
            Hien_Thi_Len_HD_CBO_Nhan_Vien();
            Hien_Thi_Len_HD_CBO_Khach_Hang();
            Hien_Don_Gia();
            que("select*from khachhang");
        }

        private void txt_maSP_TextChanged(object sender, EventArgs e)
        {
            string masp=txt_BH_maHD.Text;
            query("select*from sanpham where masp=" + masp);

        }
        public bool themHoaDon(string maHD, string maNV, string maKH, string ngayLapHD,int tienNhan,int tienTra,int thanhTien)
        {
            bool kq;
            kq = true;
            string conn;
            conn = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=True";
            SqlConnection mySqlConnection = new SqlConnection(conn);
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
                mySqlConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql, mySqlConnection);
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
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
            string conn;
            conn = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=True";
            SqlConnection mySqlConnection = new SqlConnection(conn);
            string sSql_Hien = "SELECT MaSP, TenSP FROM SanPham";
            try
            {
                mySqlConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Hien, mySqlConnection);
                DataSet ds = new DataSet();
                dsHien.Fill(ds);
                mySqlConnection.Close();

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
            string conn;
            conn = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=True";
            SqlConnection mySqlConnection = new SqlConnection(conn);
            string sSql_Hien = "SELECT makh, Tenkh FROM khachhang";
            try
            {
                mySqlConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Hien, mySqlConnection);
                DataSet ds = new DataSet();
                dsHien.Fill(ds);
                mySqlConnection.Close();

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
            string conn;
            conn = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=True";
            SqlConnection mySqlConnection = new SqlConnection(conn);
            string sSql_Hien = "SELECT manv, Tennv FROM nhanvien";
            try
            {
                mySqlConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Hien, mySqlConnection);
                DataSet ds = new DataSet();
                dsHien.Fill(ds);
                mySqlConnection.Close();

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

            string conn;
            conn = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=True";
            SqlConnection mySqlConnection = new SqlConnection(conn);
            string sSql_Gia_Ban = "SELECT GiaBan FROM SanPham WHERE MASP = @MaSP";
            try
            {
                mySqlConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql_Gia_Ban, mySqlConnection);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                giaBan = Convert.ToDouble(cmd.ExecuteScalar());
                txt_BH_donGia.Text = giaBan.ToString();
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
            string conn;
            conn = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=True";
            SqlConnection mySqlConnection = new SqlConnection(conn);
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
                mySqlConnection.Open();
                //thực thi câu truy vấn thêm vào bảng HOADON
                SqlCommand cmd = new SqlCommand(sSql_HD, mySqlConnection);
                cmd.ExecuteNonQuery();

                //thực thi câu truy vấn thêm vào bảng HOADON
                cmd = new SqlCommand(sSql_CTHD, mySqlConnection);
                cmd.ExecuteNonQuery();

                mySqlConnection.Close();
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
                    string sSql_Xem_Hoa_Don = "select ct.MASP,sp.TENSP,ct.SOLUONG,ct.DONGIA,ct.TONGTIEN,ct.KHUYENMAI\r\nfrom HOADON hd ,SANPHAM sp,CT_HOADON ct\r\nwhere hd.MAHD=ct.MAHD and sp.MASP=ct.MASP";
                    DataSet ds_Hoa_Don = Xem_Thong_Tin(sSql_Xem_Hoa_Don);
                    data_banHang.DataSource = ds_Hoa_Don.Tables[0];
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
            string conn;
            conn = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=True";
            SqlConnection mySqlConnection = new SqlConnection(conn);
            string sSql_Gia_Ban = "SELECT GiaBan FROM SanPham WHERE MASP = @MaSP";
            {
                try
                {
                    mySqlConnection.Open();

                    SqlCommand cmd = new SqlCommand(sSql_Gia_Ban, mySqlConnection);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);

                    giaBan = Convert.ToDouble(cmd.ExecuteScalar());

                    // Tính thành tiền
                    double thanhTien = (soLuong * giaBan) - (soLuong * giaBan) * khuyenMai;
                    txt_BH_thanhTien.Text = thanhTien.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: thanh tien" + ex.Message);
                }
            }
            btn_BH_add.Enabled = true;
        }

        private void data_banHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string soLuong, donGia, ngayLapHD,khuyenMai;
                //Lay du lieu dataridview
                soLuong = data_banHang.CurrentRow.Cells[2].Value.ToString();
                donGia = data_banHang.CurrentRow.Cells[3].Value.ToString();
                khuyenMai = data_banHang.CurrentRow.Cells[5].Value.ToString();
                //điền dữ liềuj datagridview vào textbox


                nbr_BH_soLuong.Text = soLuong;
                txt_BH_donGia.Text = donGia;
                txt_BH_khuyenMai.Text = khuyenMai;

            }
            catch (Exception err)
            {


            }
        }
        public bool CapNhatBanHang( string soLuong, string donGia, string khuyenMai)
        {
            bool kq;
            kq = true;
            string sconn;
            sconn = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=True";
            SqlConnection myConnection = new SqlConnection(sconn);
            string sSql = "";
            sSql = "UPDATE NhaSanXuat";
            sSql += " SET ";
            sSql += "soluong='" + soLuong + "',";
            sSql += "dongia='" + donGia + "',";
            sSql += "khuyenMai='" + khuyenMai + "' ";
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

        private void btn_BH_update_Click(object sender, EventArgs e)
        {
            string soLuong, donGia, ngayLapHD, khuyenMai;
            soLuong = nbr_BH_soLuong.Text;
            donGia = txt_BH_donGia.Text;
            khuyenMai = txt_BH_khuyenMai.Text;
            bool kq = CapNhatBanHang(soLuong, donGia, khuyenMai);
            if (kq == true)
            {

                MessageBox.Show("Cập nhật  thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hien_Don_Gia();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
