using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;   
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GiaoDien_DangNhap
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        //global
        DataTable table;
        bool btn_DSHD_Click = true;
        bool textChange_HD_Khuyen_Mai = false;
        public static string Connect = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=true";
        
        public static SqlConnection Ket_Noi()
        {
            SqlConnection myConnection = new SqlConnection(Connect);
            return myConnection;
        }

        public static System.Data.DataSet Xem_Thong_Tin(string sSql_Xem)
        {

            SqlConnection myConnection = Ket_Noi();
            System.Data.DataSet ds = null;
            try
            {
                myConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Xem, myConnection);
                ds = new System.Data.DataSet();
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
            btn_KH_sua.Enabled = false;
            Lay_MAHD();
            Them_Ten_Cot_Vao_DataHD();
            Hien_Thi_Len_HD_CBO_San_Pham();
            Hien_Thi_Len_HD_CBO_Nhan_Vien();
            Hien_Thi_Len_HD_CBO_Khach_Hang();
            Hien_Don_Gia();
            Tinh_Thanh_Tien();
            //TAB KHÁCH HÀNG
            txt_KH_maKH.Enabled = false;
            Lay_MAKH();
            string sSql_Xem_Khach_Hang = "SELECT * FROM KhachHang";
            System.Data.DataSet ds_Khach_Hang = Xem_Thong_Tin(sSql_Xem_Khach_Hang);
            data_khachHang.DataSource = ds_Khach_Hang.Tables[0];
          
        }
        public void Lay_MAHD()
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Lay_MAHD = "SELECT CONCAT('HD', RIGHT('000' + CAST(MAX(CAST(SUBSTRING(MAHD, 3, LEN(MAHD) - 2) AS INT)) + 1 AS VARCHAR), 3)) AS MAHD FROM HOADON";
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql_Lay_MAHD, myConnection);
                object result = cmd.ExecuteScalar();

                myConnection.Close();
                txt_BH_maHD.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Lay_MAKH()
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Lay_MAKH = "SELECT CONCAT('KH', RIGHT('000' + CAST(MAX(CAST(SUBSTRING(MAKH, 3, LEN(MAKH) - 2) AS INT)) + 1 AS VARCHAR), 3)) AS MAKH FROM KHACHHANG";
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql_Lay_MAKH, myConnection);
                object result = cmd.ExecuteScalar();

                myConnection.Close();
                txt_KH_maKH.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        public void Them_Ten_Cot_Vao_DataHD()
        {
            //Chỉ tạo một lần duy nhất
            if (table == null)
            {
                table = new DataTable();
                table.Columns.Add("MAHD", typeof(string));
                table.Columns.Add("MASP", typeof(string));
                table.Columns.Add("SOLUONG", typeof(int));
                table.Columns.Add("DONGIA", typeof(double));
                table.Columns.Add("THANHTIEN", typeof(double));
                table.Columns.Add("MAKH", typeof(string));
                table.Columns.Add("MANV", typeof(string));
                table.Columns.Add("NGAYLAPHD", typeof(string));
                table.Columns.Add("KHUYENMAI", typeof(double));

                data_ban_hang.DataSource = table;
            }
        }
        public void Hien_Thi_Len_HD_CBO_San_Pham()
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Hien = "SELECT MaSP, TenSP FROM SanPham";
            try
            {
                myConnection.Open();
                SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Hien, myConnection);
                System.Data.DataSet ds = new System.Data.DataSet();
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
                System.Data.DataSet ds = new System.Data.DataSet();
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
                System.Data.DataSet ds = new System.Data.DataSet();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void Tinh_Thanh_Tien()
        {
            //Lấy giá trị của mã sản phẩm, số lượng
            string maSP = cbo_BH_sanPham.SelectedValue.ToString();
            int soLuong = (int)nbr_BH_soLuong.Value;
            double giaBan = 0;
            double khuyenMai;

            //Kiểm tra Khuyến mãi phải nhập trước khi click
            if (txt_BH_khuyenMai.Text == "")
            {
                khuyenMai = 0;
            }
            else { khuyenMai = (double.Parse(txt_BH_khuyenMai.Text)) / 100; }




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
                    txt_BH_thanhTien.Text = thanhTien.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
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
            textChange_HD_Khuyen_Mai = true;
            Luu_Vao_Database();
            //Cập nhật lại ds hiển thị sản phẩm
            string sSql_Xem_San_Pham = "SELECT * FROM SanPham";
            System.Data.DataSet ds_San_Pham = Xem_Thong_Tin(sSql_Xem_San_Pham);
            data_ban_hang.DataSource = ds_San_Pham.Tables[0];
            table = null;
            Them_Ten_Cot_Vao_DataHD();
            Lam_Moi_HD();
            textChange_HD_Khuyen_Mai = false;
            btn_BH_add.Enabled = false;
            btn_BH_update.Enabled = false;

        }
      

        public bool CapNhatBanHang( string soLuong, string khuyenMai,string mahd)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            string sSql = "";
            sSql = "UPDATE CT_HOADON";
            sSql += " SET ";
            sSql += "soluong='" + soLuong + "',";
            sSql += "khuyenMai='" + khuyenMai + "', ";

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
            try
                {
                    int rowIndex = data_ban_hang.CurrentRow.Index;

                    string maHD = txt_BH_maHD.Text;
                    string maSP = cbo_BH_sanPham.SelectedValue.ToString();
                    int soLuong = (int)nbr_BH_soLuong.Value;
                    double donGia = double.Parse(txt_BH_donGia.Text);
                    double thanhTien = double.Parse(txt_BH_thanhTien.Text);
                    string maKH = cbo_BH_KH.SelectedValue.ToString();
                    string maNV = cbo_BH_NV.SelectedValue.ToString();
                    string ngayLap = dt_BH_ngayLapHD.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    double khuyenMai;
                    if (txt_BH_khuyenMai.Text == "")
                    {
                        khuyenMai = 0;
                    }
                    else { khuyenMai = (double.Parse(txt_BH_khuyenMai.Text)) / 100; }

                    data_ban_hang.Rows[rowIndex].Cells["MAHD"].Value = maHD;
                    data_ban_hang.Rows[rowIndex].Cells["MASP"].Value = maSP;
                    data_ban_hang.Rows[rowIndex].Cells["SOLUONG"].Value = soLuong;
                    data_ban_hang.Rows[rowIndex].Cells["DONGIA"].Value = donGia;
                    data_ban_hang.Rows[rowIndex].Cells["THANHTIEN"].Value = thanhTien;
                    data_ban_hang.Rows[rowIndex].Cells["MAKH"].Value = maKH;
                    data_ban_hang.Rows[rowIndex].Cells["MANV"].Value = maNV;
                    data_ban_hang.Rows[rowIndex].Cells["NGAYLAPHD"].Value = ngayLap;
                    data_ban_hang.Rows[rowIndex].Cells["KHUYENMAI"].Value = khuyenMai;

                    Lam_Moi_HD();
                    MessageBox.Show("Sửa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sửa không thành công: " + ex.Message);
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
                    System.Data.DataSet ds_Khach_Hang = Xem_Thong_Tin(sSql_Xem_Khach_Hang);
                    data_khachHang.DataSource = ds_Khach_Hang.Tables[0];
                    Hien_Thi_Len_HD_CBO_Khach_Hang();
                }
            }
        }
        public void Tru_So_Luong(SqlConnection connection, SqlTransaction transaction, string maSP, string maHD)
        {
            string soLuong, maSP_Tam;
            string sSql_Tru1 = "UPDATE SANPHAM SET SANPHAM.SOLUONG = SANPHAM.SOLUONG - @SoLuong WHERE SANPHAM.MASP = @MaSP";
            string sSql_Tru2 = "SELECT SOLUONG FROM CT_HOADON WHERE MAHD = @MaHD AND MASP = @MaSP";
            string sSql_Tru3 = "SELECT MASP FROM CT_HOADON WHERE MAHD = @MaHD AND MASP = @MaSP";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sSql_Tru2, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    soLuong = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand(sSql_Tru3, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    maSP_Tam = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand(sSql_Tru1, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@MaSP", maSP_Tam);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Trừ số lượng thất bại: " + ex.Message);
            }
        }
        public void Luu_Vao_Database()
        {
            if (table != null && table.Rows.Count > 0)
            {
                using (SqlConnection myConnection = Ket_Noi())
                {
                    string MaHD = txt_BH_maHD.Text;
                    try
                    {
                        myConnection.Open();
                        SqlTransaction transaction = myConnection.BeginTransaction();

                        try
                        {
                            using (SqlCommand cmd = myConnection.CreateCommand())
                            {
                                cmd.Transaction = transaction;

                                // Thêm vào bảng HOADON một lần
                                cmd.CommandText = "INSERT INTO HOADON VALUES (@MAHD, @MANV, @MAKH, @NGAYLAPHD)";
                                cmd.Parameters.AddWithValue("@MAHD", table.Rows[0]["MAHD"]);
                                cmd.Parameters.AddWithValue("@MANV", table.Rows[0]["MANV"]);
                                cmd.Parameters.AddWithValue("@MAKH", table.Rows[0]["MAKH"]);
                                cmd.Parameters.AddWithValue("@NGAYLAPHD", table.Rows[0]["NGAYLAPHD"]);
                                cmd.ExecuteNonQuery();

                                // Vòng lặp qua từng hàng trong DataTable và chèn dữ liệu vào cơ sở dữ liệu
                                foreach (DataRow row in table.Rows)
                                {
                                    cmd.CommandText = "INSERT INTO CT_HOADON VALUES (@MAHD, @MASP, @SOLUONG, @DONGIA, @KHUYENMAI, @THANHTIEN)";
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.AddWithValue("@MAHD", row["MAHD"]);
                                    cmd.Parameters.AddWithValue("@MASP", row["MASP"]);
                                    cmd.Parameters.AddWithValue("@SOLUONG", row["SOLUONG"]);
                                    cmd.Parameters.AddWithValue("@DONGIA", row["DONGIA"]);
                                    cmd.Parameters.AddWithValue("@KHUYENMAI", row["KHUYENMAI"]);
                                    cmd.Parameters.AddWithValue("@THANHTIEN", row["THANHTIEN"]);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // Mảng lưu các mã sản phẩm
                            string[] maspArray = new string[data_ban_hang.Rows.Count];
                            for (int i = 0; i < data_ban_hang.Rows.Count; i++)
                            {
                                maspArray[i] = data_ban_hang.Rows[i].Cells["MASP"].Value.ToString();
                            }

                            // Trừ số lượng sản phẩm
                            foreach (string maSP in maspArray)
                            {
                                Tru_So_Luong(myConnection, transaction, maSP, MaHD);
                            }

                            // Commit giao dịch nếu mọi thứ thành công
                            transaction.Commit();

                            // Hiển thị thông báo thành công
                            MessageBox.Show("Hóa đơn đã được lưu vào cơ sở dữ liệu.");
                            Lay_MAHD();
                            table.Rows.Clear();
                        }
                        catch (Exception ex)
                        {
                            // Nếu có lỗi xảy ra, rollback giao dịch
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi lưu hóa đơn vào cơ sở dữ liệu: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message);
                    }
                }
            }
            else
            {
                // Hiển thị thông báo nếu DataTable không có dữ liệu
                MessageBox.Show("Không có dữ liệu để lưu vào cơ sở dữ liệu.");
            }
        
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
        public bool KT_So_Luong()
        {
            string MaSP = cbo_BH_sanPham.SelectedValue.ToString();
            int SL_CT_HOADON = (int)nbr_BH_soLuong.Value;
            bool kq;
            SqlConnection myConnection = Ket_Noi();

            string sSql_SL_SANPHAM = "SELECT SOLUONG FROM SANPHAM WHERE MASP = '" + MaSP + "'";

            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(sSql_SL_SANPHAM, myConnection);
                int SL_SANPHAM = Convert.ToInt32(cmd.ExecuteScalar());

                if (SL_CT_HOADON > SL_SANPHAM)
                {
                    kq = false;
                }
                else { kq = true; }

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiểm tra sô lượng thất bại: " + ex.Message);
                return false;
            }
            return kq;
        }


        public void Them_San_Pham_Vao_DataHD(string maHD, string maSP, int soLuong, double donGia, double thanhTien, string maKH, string maNV, string ngayLap, double khuyenMai)
        {
            if (table != null)
            {
                try
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if ( maSP == row["MASP"].ToString() && maKH == row["MAKH"].ToString() && maNV == row["MANV"].ToString())
                        {
                            row["SOLUONG"] = soLuong + (int)data_ban_hang.CurrentRow.Cells[2].Value;
                            row["THANHTIEN"] = thanhTien + (double)data_ban_hang.CurrentRow.Cells[4].Value;
                            row["NGAYLAPHD"] = ngayLap;
                            row["KHUYENMAI"] = khuyenMai;
                            return;
                        }
                    }
                    table.Rows.Add(maHD, maSP, soLuong, donGia, thanhTien, maKH, maNV, ngayLap, khuyenMai);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm sản phẩm vào hóa đơn: " + ex.Message);
                }
            }
        }
        public void Lam_Moi_HD()
        {
            cbo_BH_sanPham.SelectedIndex = 0;
            nbr_BH_soLuong.Value = 1;
            cbo_BH_KH.SelectedIndex = 0;
            cbo_BH_NV.SelectedIndex = 0;
            dt_BH_ngayLapHD.Value = DateTime.Now;
            txt_BH_khuyenMai.Text = "";
            txt_BH_thanhTien.Text = "";

        }
        private void btn_them_moi_Click_1(object sender, EventArgs e)
        {
            if (btn_DSHD_Click)
            {
                bool kq = KT_So_Luong();
                if (kq)
                {

                    if (string.IsNullOrEmpty(txt_BH_maHD.Text.Trim()) ||
                       string.IsNullOrEmpty(cbo_BH_sanPham.Text.Trim()) ||
                       string.IsNullOrEmpty(txt_BH_donGia.Text.Trim()) ||
                       string.IsNullOrEmpty(txt_BH_thanhTien.Text.Trim()) ||
                       string.IsNullOrEmpty(cbo_BH_KH.Text.Trim()) ||
                       string.IsNullOrEmpty(cbo_BH_NV.Text.Trim()) ||
                       string.IsNullOrEmpty(txt_BH_khuyenMai.Text.Trim()))
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
                        donGia = double.Parse(txt_BH_donGia.Text);
                        thanhTien = double.Parse(txt_BH_thanhTien.Text);
                        maKH = cbo_BH_KH.SelectedValue.ToString();
                        maNV = cbo_BH_NV.SelectedValue.ToString();
                        khuyenMai = double.Parse(txt_BH_khuyenMai.Text) / 100;
                        ngayLap = dt_BH_ngayLapHD.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        Them_San_Pham_Vao_DataHD(maHD, maSP, soLuong, donGia, thanhTien, maKH, maNV, ngayLap, khuyenMai);

                        Lam_Moi_HD();
                    }
                    btn_BH_add.Enabled = true;
                    btn_BH_update.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Số lượng sản phẩm không đủ để lập hóa đơn!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            
        }

        private void txt_BH_khuyenMai_TextChanged(object sender, EventArgs e)
        {
            
            Tinh_Thanh_Tien();

            

        }

        private void data_ban_hang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (data_ban_hang.DataSource != null)
            {
                if (btn_DSHD_Click)
                {
                    try
                    {
                        SqlConnection myConnection = Ket_Noi();
                        string maHD, sanPham, khachHang, nhanVien;
                        string donGia, thanhTien, khuyenMai;
                        int soLuong;
                        DateTime ngayLap;

                        maHD = data_ban_hang.CurrentRow.Cells[0].Value.ToString();
                        sanPham = data_ban_hang.CurrentRow.Cells[1].Value.ToString();
                        soLuong = (int)data_ban_hang.CurrentRow.Cells[2].Value;
                        donGia = data_ban_hang.CurrentRow.Cells[3].Value.ToString();
                        thanhTien = data_ban_hang.CurrentRow.Cells[4].Value.ToString();
                        khachHang = data_ban_hang.CurrentRow.Cells[5].Value.ToString();
                        nhanVien = data_ban_hang.CurrentRow.Cells[6].Value.ToString();

                        string dateTimeString = data_ban_hang.CurrentRow.Cells[7].Value.ToString();
                        string format = "yyyy-MM-dd HH:mm:ss";
                        if (DateTime.TryParseExact(dateTimeString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayLap))
                        {
                            dt_BH_ngayLapHD.Value = ngayLap;
                        }
                        else
                        {
                            MessageBox.Show("Không thể ép kiểu chuỗi thành DateTime.");
                        }

                        khuyenMai = ((double)data_ban_hang.CurrentRow.Cells[8].Value * 100).ToString();

                        try
                        {
                            myConnection.Open();

                            string query = "SELECT TenSP FROM SanPham WHERE MaSP = @MaSP";
                            SqlCommand cmd = new SqlCommand(query, myConnection);
                            cmd.Parameters.AddWithValue("@MaSP", sanPham);
                            object result = cmd.ExecuteScalar();

                            txt_BH_maHD.Text = maHD;
                            cbo_BH_sanPham.Text = result.ToString();
                            nbr_BH_soLuong.Value = soLuong;
                            txt_BH_donGia.Text = donGia;
                            txt_BH_thanhTien.Text = thanhTien;

                            query = "SELECT TenKH FROM KhachHang WHERE MaKH = @MaKH";
                            cmd = new SqlCommand(query, myConnection);
                            cmd.Parameters.AddWithValue("@MaKH", khachHang);
                            result = cmd.ExecuteScalar();
                            cbo_BH_KH.Text = result.ToString();

                            query = "SELECT manv FROM nhanvien WHERE manv = @Manv";
                            cmd = new SqlCommand(query, myConnection);
                            cmd.Parameters.AddWithValue("@manv", nhanVien);
                            result = cmd.ExecuteScalar();
                            cbo_BH_NV.Text = result.ToString();
                            txt_BH_khuyenMai.Text = khuyenMai;

                            myConnection.Close();

                            //btn_HD_Ghi.Enabled = false;
                            //btn_HD_Luu.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //btn_HD_Sua.Enabled = true;
                    //btn_HD_Xoa.Enabled = true;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

        }

        private void btn_xem_ds_hoa_don_Click(object sender, EventArgs e)
        {
            if (btn_DSHD_Click)
            {
                string sSql_Xem_Hoa_Don = "SELECT HOADON.MAHD, MANV, MAKH, MASP, SOLUONG, DONGIA, CT_HOADON.TONGTIEN,KHUYENMAI,NGAYLAPHD " +
                          "FROM HOADON JOIN CT_HOADON ON HOADON.MAHD = CT_HOADON.MAHD";
                System.Data.DataSet ds_Hoa_Don = Xem_Thong_Tin(sSql_Xem_Hoa_Don);
                data_ban_hang.DataSource = ds_Hoa_Don.Tables[0];
                lb_tk.Visible = true;
                txt_BH_tim_kiem.Visible = true;
                btn_DSHD_Click = false;
            }
            else
            {
                data_ban_hang.DataSource = table;
                lb_tk.Visible = false;
                txt_BH_tim_kiem.Visible = false;
                btn_DSHD_Click = true;
            }
        }

        public System.Data.DataSet Tim_Kiem_HD(string tenTK)
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Tim_Kiem = "SELECT HOADON.MAHD, MANV, MAKH, MASP, SOLUONG, DONGIA, KHUYENMAI,NGAYLAPHD " +
                                              "FROM HOADON JOIN CT_HOADON ON HOADON.MAHD = CT_HOADON.MAHD " +
                                              "WHERE HOADON.MAHD LIKE N'%" + tenTK + "%'";
            System.Data.DataSet ds = null;
            try
            {
                myConnection.Open();

                SqlDataAdapter ds_Hien = new SqlDataAdapter(sSql_Tim_Kiem, myConnection);
                ds = new System.Data.DataSet();
                ds_Hien.Fill(ds);

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
            return ds;
        }
        private void txt_BH_tim_kiem_TextChanged(object sender, EventArgs e)
        {
            string tenTK;
            tenTK = txt_BH_tim_kiem.Text;
            System.Data.DataSet ds = Tim_Kiem_HD(tenTK);
            data_ban_hang.DataSource = ds.Tables[0];
        }

        private void nbr_BH_soLuong_ValueChanged(object sender, EventArgs e)
        {
            Tinh_Thanh_Tien();
        }

        private void cbo_BH_sanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hien_Don_Gia();
            Tinh_Thanh_Tien() ;
        }

        private void btn_KH_lammoi_Click(object sender, EventArgs e)
        {
            txt_KH_tenKH.Text = "";
            txt_KH_sdt.Text = "";
            txt_KH_email.Text = "";
            txt_KH_diaChi.Text = "";
            txt_KH_tenKH.Select();
            dt_ngayTao.Value=DateTime.Now;
            btn_KH_sua.Enabled= false;
        }

        public bool Sua_Khach_Hang(string tenKH, string diaChi, string SDT, string ngayTao, string email)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            string maKH = data_khachHang.CurrentRow.Cells[0].Value.ToString();
            //Câu truy vấn sửa bảng KHACHHANG
            string sSql_KH;
            sSql_KH = "UPDATE KHACHHANG SET TENKH = N'" + tenKH + "', DIACHI = N'" + diaChi + "', SDT = '" + SDT + "', NGAYTAO = '" + ngayTao + "', EMAIL = '" + email + "' WHERE MAKH = @MAKH";

            try
            {
                myConnection.Open();
                //thực thi câu truy vấn sửa bảng KHACHHANG
                SqlCommand cmd = new SqlCommand(sSql_KH, myConnection);
                cmd.Parameters.AddWithValue("@MAKH", maKH);
                cmd.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi Sửa Khách Hàng. Chi tiết: " + ex.Message);
            }
            return kq;
        }
        private void btn_KH_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_KH_tenKH.Text.Trim()) ||
               string.IsNullOrEmpty(txt_KH_sdt.Text.Trim()) ||
               string.IsNullOrEmpty(txt_KH_email.Text.Trim()) ||
               string.IsNullOrEmpty(txt_KH_diaChi.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (txt_KH_sdt.Text.Length != 10)
                {
                    MessageBox.Show("Vui lòng nhập SĐT đủ 10 số.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string tenKH, diaChi, SDT, email, ngayTao;

                tenKH = txt_KH_tenKH.Text;
                diaChi = txt_KH_diaChi.Text;
                SDT = txt_KH_sdt.Text;
                email = txt_KH_email.Text;
                ngayTao = dt_ngayTao.Value.ToString("yyyy-MM-dd HH:mm:ss");

                bool kq = Sua_Khach_Hang(tenKH, diaChi, SDT, ngayTao, email);
                if (kq == false)
                {
                    MessageBox.Show("Sửa Khách Hàng KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Sửa Khách Hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_Khach_Hang = "SELECT * FROM KhachHang";
                    System.Data.DataSet ds_Khach_Hang = Xem_Thong_Tin(sSql_Xem_Khach_Hang);
                    data_khachHang.DataSource = ds_Khach_Hang.Tables[0];
                    Hien_Thi_Len_HD_CBO_Khach_Hang();
               
                }
            }
        }
        private void data_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string makh,tenKH, diaChi, SDT, email;
                DateTime ngayTao;
                makh = data_khachHang.CurrentRow.Cells[0].Value.ToString();
                tenKH = data_khachHang.CurrentRow.Cells[1].Value.ToString();
                diaChi = data_khachHang.CurrentRow.Cells[2].Value.ToString();
                SDT = data_khachHang.CurrentRow.Cells[3].Value.ToString();
                ngayTao = (DateTime)data_khachHang.CurrentRow.Cells[4].Value;
                email = data_khachHang.CurrentRow.Cells[5].Value.ToString();
                txt_KH_maKH.Text= makh;
                txt_KH_tenKH.Text = tenKH;
                txt_KH_diaChi.Text = diaChi;
                txt_KH_sdt.Text = SDT;
                dt_ngayTao.Value = ngayTao;
                txt_KH_email.Text = email;
            }
            catch (Exception ex)
            {

            }
            btn_KH_sua.Enabled = true;
        }

        private void txt_BH_khuyenMai_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (txt_BH_khuyenMai.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }


        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlg;
            dlg = MessageBox.Show("Bạn muốn thoát chương trình?", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_in_hoadon_Click(object sender, EventArgs e)
        {
            frmInHoaDon inhd= new frmInHoaDon();
            inhd.ShowDialog();
        }
    }
}
