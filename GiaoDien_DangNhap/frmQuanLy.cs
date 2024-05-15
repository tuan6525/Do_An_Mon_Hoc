using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        //biến toàn cục
        DataTable table;
        private bool btn_DSHD_Click = true;
        private bool textChange_HD_Khuyen_Mai = false;

        public static string scon = "Data Source = THONGDZ; Initial Catalog = qlbanmaytinh; Integrated Security = true;";

        public void frmQuanLy_Load(object sender, EventArgs e)
        {
            //TAB NHÂN VIÊN
            string sSql_Xem_Nhan_Vien = "SELECT NV.*, TK.PassWord, TK.ChucVu FROM NhanVien NV JOIN TaiKhoan TK ON NV.Username = TK.Username";
            DataSet ds_Nhan_Vien = Xem_Thong_Tin(sSql_Xem_Nhan_Vien);
            data_NV.DataSource = ds_Nhan_Vien.Tables[0];
            data_NV.Columns["PassWord"].HeaderText = "PASSWORD";
            data_NV.Columns["ChucVu"].HeaderText = "CHUCVU";
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
            Lay_MAHD();
            btn_HD_Ghi.Enabled = false;
            btn_HD_Luu.Enabled = false;
            btn_HD_Xoa.Enabled = false;
            btn_HD_Sua.Enabled = false;
            lab_HD_Tim_Kiem.Visible = false;
            txt_HD_Tim_Kiem.Visible = false;
            Them_Ten_Cot_Vao_DataHD();
            Hien_Thi_Len_HD_CBO_San_Pham();
            Hien_Thi_Len_HD_TXT_Nhan_Vien();
            Hien_Thi_Len_HD_CBO_Khach_Hang();
            Hien_Don_Gia();
            Tinh_Tien();
                //Sử dụng ToolTip cho các button
                    //Tạo ToolTip
                    ToolTip tlt_HD = new ToolTip();
                    tlt_HD.ShowAlways = true;
                    //Gán ToolTip vào button
                    tlt_HD.SetToolTip(btn_HD_Luu, "Lưu");
                    tlt_KH.SetToolTip(btn_HD_Sua, "Sửa");
                    tlt_KH.SetToolTip(btn_HD_Xoa, "Xóa");
                    tlt_KH.SetToolTip(btn_HD_Thong_Ke, "Thống kê");
                    tlt_KH.SetToolTip(btn_HD_Ghi, "Ghi");
                    tlt_KH.SetToolTip(btn_HD_Xem_DS_Hoa_Don, "Xem ds hóa đơn");

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

        public void Cap_Nhat_Du_lieu()
        {
            string sSql_Xem_San_Pham = "SELECT * FROM SanPham";
            DataSet ds_San_Pham = Xem_Thong_Tin(sSql_Xem_San_Pham);
            data_SP.DataSource = ds_San_Pham.Tables[0];
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

        public void Lam_Moi_HD()
        {
            cbo_HD_San_Pham.SelectedIndex = 0;
            nmr_HD_So_Luong.Value = 1;
            cbo_HD_Khach_Hang.SelectedIndex = 0;
            dt_HD_Ngay_Lap_HD.Value = DateTime.Now;
            txt_HD_Khuyen_Mai.Text = "";
            txt_HD_Thanh_Tien.Text = "";
            Tinh_Tien();
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
                txt_HD_Ma_Hoa_Don.Text = result.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        public void Hien_Thi_Len_HD_TXT_Nhan_Vien()
        {
            string username = frmDangNhap.LoggedInUsername;
            SqlConnection myConnection = Ket_Noi();
            string sSql_Hien = "SELECT MANV FROM NhanVien WHERE USERNAME = @username";
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(sSql_Hien, myConnection);
                cmd.Parameters.AddWithValue("@username", username);
                txt_HD_Nhan_Vien.Text = Convert.ToString(cmd.ExecuteScalar());
                myConnection.Close();
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

        public bool KT_So_Luong()
        {
            string MaSP = cbo_HD_San_Pham.SelectedValue.ToString();
            int SL_CT_HOADON = (int)nmr_HD_So_Luong.Value;
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
            catch(Exception ex)
            {
                MessageBox.Show("Kiểm tra sô lượng thất bại: " + ex.Message);
                return false;
            }
            return kq;
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

                data_HD.DataSource = table;
            }
        }

        public void Them_San_Pham_Vao_DataHD(string maHD, string maSP, int soLuong, double donGia, double thanhTien, string maKH, string maNV, string ngayLap, double khuyenMai)
        {
            if (table != null)
            {
                try
                {
                    foreach(DataRow row in table.Rows)
                    {
                        if (maSP == row["MASP"].ToString())
                        {
                            row["SOLUONG"] = soLuong + (int)data_HD.CurrentRow.Cells[2].Value;
                            row["THANHTIEN"] = thanhTien + (double)data_HD.CurrentRow.Cells[4].Value;
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
        public void Luu_Vao_Database()
        {
            if (table != null && table.Rows.Count > 0)
            {
                using (SqlConnection myConnection = Ket_Noi())
                {
                    string MaHD = txt_HD_Ma_Hoa_Don.Text;
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
                            string[] maspArray = new string[data_HD.Rows.Count];
                            for (int i = 0; i < data_HD.Rows.Count; i++)
                            {
                                maspArray[i] = data_HD.Rows[i].Cells["MASP"].Value.ToString();
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



        public bool Them_Nha_Cung_Cap(string tenNCC, string diaChi, string SDT, string email, bool trangThai)
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
            sSql_NCC += "'" + email + "'";
            sSql_NCC += "'" + trangThai + "')";

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
                MessageBox.Show("Lỗi Thêm Nhà Cung Cấp. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        public bool Sua_Nha_Cung_Cap(string tenNCC, string diaChi, string SDT, string email, bool trangThai)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            string maNCC = data_NCC.CurrentRow.Cells[0].Value.ToString();
            //Câu truy vấn sửa bảng NHACUNGCAP
            string sSql_NCC;
            sSql_NCC = "UPDATE NhaCungCap SET TENNCC = '" + tenNCC + "', DIACHI = N'" + diaChi + "', SDT = '" + SDT + "', EMAIL = '" + email + "', TRANGTHAI = '" + trangThai + "' WHERE MANCC = @MANCC";

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

        public bool Them_San_Pham(string tenSP, double giaNhap, double giaBan, string xuatXu, bool trangThai, string maNCC)
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
            sSql_SP += "'" + maNCC + "',";
            sSql_SP += " 0)";

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
                MessageBox.Show("Lỗi Thêm Sản Phẩm. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        public bool Sua_San_Pham(string tenSP, double giaNhap, double giaBan, string xuatXu, bool trangThai, string maNCC)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            string maSP = data_SP.CurrentRow.Cells[0].Value.ToString();
            //Câu truy vấn sửa bảng SANPHAM
            string sSql_SP;
            sSql_SP = "UPDATE SANPHAM SET TENSP = '" + tenSP + "',GIANHAP = '" + giaNhap + "', GIABAN = '" + giaBan + "', XUATXU = N'" + xuatXu + "', TRANGTHAI = '" + trangThai + "',  MANCC = '" + maNCC +" WHERE MASP = @MASP";

            try
            {
                myConnection.Open();
                //thực thi câu truy vấn sửa bảng SANPHAM
                SqlCommand cmd = new SqlCommand(sSql_SP, myConnection);
                cmd.Parameters.AddWithValue("@MASP", maSP);
                cmd.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi Sửa Sản Phẩm. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        public void Tinh_Tien()
        {
            //Lấy giá trị của mã sản phẩm, số lượng
            string maSP = cbo_HD_San_Pham.SelectedValue.ToString();
            int soLuong = (int)nmr_HD_So_Luong.Value;
            double giaBan = 0;
            double khuyenMai;

            //Kiểm tra Khuyến mãi phải nhập trước khi click
            if (txt_HD_Khuyen_Mai.Text == "")
            {
                khuyenMai = 0;
            }
            else { khuyenMai = (double.Parse(txt_HD_Khuyen_Mai.Text)) / 100; }




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
            btn_HD_Ghi.Enabled = true;
        }

        public bool Them_Khach_Hang(string tenKH, string diaChi, string SDT,string ngayTao, string email, bool trangThai)
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
            sSql_KH += "'" + email + "'";
            sSql_KH += "'" + trangThai + "')";

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
                MessageBox.Show("Lỗi Thêm Khách Hàng. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        public bool Sua_Khach_Hang(string tenKH, string diaChi, string SDT, string ngayTao, string email, bool trangThai)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            string maKH = data_KH.CurrentRow.Cells[0].Value.ToString();
            //Câu truy vấn sửa bảng KHACHHANG
            string sSql_KH;
            sSql_KH = "UPDATE KHACHHANG SET TENKH = N'" + tenKH + "', DIACHI = N'" + diaChi + "', SDT = '" + SDT + "', NGAYTAO = '" + ngayTao + "', EMAIL = '" + email + "' TRANGTHAI = '" + trangThai + "' WHERE MAKH = @MAKH";

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

        public bool Kiem_Tra_Ma_Co_Ton_Tai(string sSql_KT,string Ma,string cot)
        {
            SqlConnection myConnection = Ket_Noi();

            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand (sSql_KT, myConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string ma = (string)reader[cot];
                    if (ma == Ma)
                    {
                        return false;
                    }
                }
                myConnection.Close();
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Lỗi kiểm tra mã: " + ex.Message);
            }
            return true;
        }

        public bool Them_Nhan_Vien(string tenNV, string gioiTinh, string ngaySinh, string SDT, int luong, string username, string password, string email, bool trangThai)
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
            sSql_NV += "'" + email + "',";
            sSql_NV += "'" + trangThai + "')";

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
                MessageBox.Show("Lỗi Thêm Nhân Viên. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        public bool Sua_Nhan_Vien(string tenNV, string gioiTinh, string ngaySinh, string SDT, int luong, string username, string password, string email, bool trangThai)
        {
            bool kq;
            kq = true;
            SqlConnection myConnection = Ket_Noi();
            string maNV = data_NV.CurrentRow.Cells[0].Value.ToString();

            //Câu truy vấn sửa bảng NHANVIEN
            string sSql_NV;
            sSql_NV = "UPDATE NhanVien SET TENNV = N'" + tenNV + "', GIOITINH = N'" + gioiTinh + "', NGAYSINH = '" + ngaySinh + "', SDT = '" + SDT + "', LUONG = '" + luong + "', USERNAME = '" + username + "', EMAIL = '" + email + "', TRANGTHAI = '" + trangThai + "' WHERE MANV = @MANV";

            //Câu truy vấn sửa bảng TAIKHOAN
            string sSql_TK;
            sSql_TK = "UPDATE TaiKhoan SET USERNAME = '"+username+"', PASSWORD = '"+password+"' WHERE USERNAME = @USERNAME";

            try
            {
                myConnection.Open();

                //thực thi câu truy vấn sửa bảng NhanVien
                SqlCommand cmd = new SqlCommand(sSql_NV, myConnection);
                cmd.Parameters.AddWithValue("@MANV", maNV);
                cmd.ExecuteNonQuery();
                //thực thi câu truy vấn sửa bảng TaiKhoan
                cmd = new SqlCommand(sSql_TK, myConnection);
                cmd.Parameters.AddWithValue("USERNAME", username);
                cmd.ExecuteNonQuery();
                
                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi Sửa Nhân Viên. Chi tiết: " + ex.Message);
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
            DataSet ds = null;
            string[] keywords = tenTK.Split(' ');

            string sqlCondition = "";
            foreach (string keyword in keywords)
            {
                sqlCondition += "AND "+tenCot+" LIKE N'%" + keyword + "%' ";
            }

            if (sqlCondition.Length > 0)
            {
                sqlCondition = sqlCondition.Substring(4);
            }

            string query = "SELECT * FROM "+tenBang+" WHERE " + sqlCondition;
            try
            {
                myConnection.Open();

                SqlDataAdapter sql_DS = new SqlDataAdapter(query, myConnection);
                ds = new DataSet();
                sql_DS.Fill(ds);

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet Tim_Kiem_HD(string tenTK)
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Tim_Kiem = "SELECT HOADON.MAHD, MANV, MAKH, MASP, SOLUONG, DONGIA, KHUYENMAI,NGAYLAPHD " +
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
                if (txt_NV_SDT.Text.Length != 10)
                {
                    MessageBox.Show("Vui lòng nhập SĐT đủ 10 số.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string tenNV, gioiTinh, ngaySinh, SDT, username, password, email;
                int luong;
                bool trangThai;

                tenNV = txt_NV_Ten_Nhan_Vien.Text;
                if (rad_NV_Nam.Checked)
                {
                    gioiTinh = "Nam";
                }
                else
                {
                    gioiTinh = "Nữ";
                }
                if (chk_NV_Trang_Thai.Checked)
                {
                    trangThai = true;
                }
                else
                {
                    trangThai = false;
                }
                ngaySinh = dt_NV_Ngay_Sinh.Value.ToString("yyyy-MM-dd HH:mm:ss"); ;
                SDT = txt_NV_SDT.Text;
                luong = int.Parse(txt_NV_Luong.Text);
                username = txt_NV_User_Name.Text;
                password = txt_NV_Password.Text;
                email = txt_NV_Email.Text;

                bool kq = Them_Nhan_Vien(tenNV, gioiTinh, ngaySinh, SDT, luong, username, password, email, trangThai);
                if (kq == false)
                {
                    MessageBox.Show("Thêm Nhân Viên KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã thêm Nhân Viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_Nhan_Vien = "SELECT NV.*, TK.PassWord, TK.ChucVu FROM NhanVien NV JOIN TaiKhoan TK ON NV.Username = TK.Username";
                    DataSet ds_Nhan_Vien = Xem_Thong_Tin(sSql_Xem_Nhan_Vien);
                    data_NV.DataSource = ds_Nhan_Vien.Tables[0];
                    btn_NV_Lam_Moi_Click(sender, e);
                }
            }
        }

        private void data_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string tenNV, gioiTinh, SDT, luong, userName, passWord, email;
                DateTime ngaySinh;
                bool trangThai;

                tenNV = data_NV.CurrentRow.Cells[1].Value.ToString();
                gioiTinh = data_NV.CurrentRow.Cells[2].Value.ToString();
                ngaySinh = (DateTime)data_NV.CurrentRow.Cells[3].Value;
                SDT = data_NV.CurrentRow.Cells[4].Value.ToString();
                luong = data_NV.CurrentRow.Cells[5].Value.ToString();
                userName = data_NV.CurrentRow.Cells[6].Value.ToString();
                passWord = data_NV.CurrentRow.Cells[9].Value.ToString();
                email = data_NV.CurrentRow.Cells[7].Value.ToString();
                trangThai = (bool)data_NV.CurrentRow.Cells[8].Value;

                txt_NV_Ten_Nhan_Vien.Text = tenNV;
                if(gioiTinh == "Nam")
                {
                    rad_NV_Nam.Checked = true;
                }
                else { rad_NV_Nu.Checked = true; }
                dt_NV_Ngay_Sinh.Value = ngaySinh;
                txt_NV_SDT.Text = SDT;
                txt_NV_Luong.Text = luong;
                txt_NV_User_Name.Text = userName;
                txt_NV_Password.Text = passWord;
                txt_NV_Email.Text = email;
                chk_NV_Trang_Thai.Checked = trangThai;
                btn_NV_Sua.Enabled = true;
                btn_NV_Xoa.Enabled = true;
                btn_NV_Them.Enabled = false;
                txt_NV_User_Name.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NV_Sua_Click(object sender, EventArgs e)
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
                if (txt_NV_SDT.Text.Length != 10)
                {
                    MessageBox.Show("Vui lòng nhập SĐT đủ 10 số.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string tenNV, gioiTinh, ngaySinh, SDT, username, password, email;
                int luong;
                bool trangThai;

                tenNV = txt_NV_Ten_Nhan_Vien.Text;
                if (rad_NV_Nam.Checked)
                {
                    gioiTinh = "Nam";
                }
                else
                {
                    gioiTinh = "Nữ";
                }
                if (chk_NV_Trang_Thai.Checked)
                {
                    trangThai = true;
                }
                else
                {
                    trangThai = false;
                }
                ngaySinh = dt_NV_Ngay_Sinh.Value.ToString("yyyy-MM-dd HH:mm:ss"); ;
                SDT = txt_NV_SDT.Text;
                luong = int.Parse(txt_NV_Luong.Text);
                username = txt_NV_User_Name.Text;
                password = txt_NV_Password.Text;
                email = txt_NV_Email.Text;

                bool kq = Sua_Nhan_Vien(tenNV, gioiTinh, ngaySinh, SDT, luong, username, password, email, trangThai);
                if (kq == false)
                {
                    MessageBox.Show("Sửa Nhân Viên KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Sửa Nhân Viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_Nhan_Vien = "SELECT NV.*, TK.PASSWORD, TK.CHUCVU FROM NhanVien NV JOIN TaiKhoan TK ON NV.Username = TK.Username";
                    DataSet ds_Nhan_Vien = Xem_Thong_Tin(sSql_Xem_Nhan_Vien);
                    data_NV.DataSource = ds_Nhan_Vien.Tables[0];
                    btn_NV_Lam_Moi_Click(sender, e);
                }
            }
        }

        private void btn_NV_Xoa_Click(object sender, EventArgs e)
        {
            string bien1 = "@MANV";
            string bien2 = "@USERNAME";
            string maNV = data_NV.CurrentRow.Cells[0].Value.ToString();
            string username = data_NV.CurrentRow.Cells[6].Value.ToString();
            //Câu truy vấn xóa dòng của NHANVIEN
            string sSql_NV, sSql_TK;
            sSql_NV = "DELETE NhanVien WHERE MANV = @MANV";
            sSql_TK = "DELETE TaiKhoan WHERE USERNAME = @USERNAME";

            //Câu truy vấn kiểm tra xem MANV có đang được tham chiếu hay không
            string sSql_KT = "SELECT MANV FROM NHANVIEN WHERE EXISTS (SELECT 1 FROM HOADON WHERE HOADON.MANV = NHANVIEN.MANV)";
            string cot = "MANV";

            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Bạn có chắc muốn xóa Nhân Viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                bool kq = Kiem_Tra_Ma_Co_Ton_Tai(sSql_KT, maNV, cot);
                if (kq)
                {
                    bool kq1 = Xoa_Dong(maNV, sSql_NV, bien1);
                    bool kq2 = Xoa_Dong(username, sSql_TK, bien2);
                    if (kq1 == false || kq2 == false)
                    {
                        MessageBox.Show("Xóa Nhân Viên KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Xóa Nhân Viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string sSql_Xem_Nhan_Vien = "SELECT NV.*, TK.PassWord, TK.ChucVu FROM NhanVien NV JOIN TaiKhoan TK ON NV.Username = TK.Username";
                        DataSet ds_Nhan_Vien = Xem_Thong_Tin(sSql_Xem_Nhan_Vien);
                        data_NV.DataSource = ds_Nhan_Vien.Tables[0];
                        btn_NV_Lam_Moi_Click(sender, e);
                        btn_NV_Xoa.Enabled = false;
                        btn_NV_Them.Enabled = true;
                    }
                }
                else { MessageBox.Show("Nhân viên này đang được tham chiếu từ hóa đơn", "Lưu ý",MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { return; }
        }

        private void btn_NV_Lam_Moi_Click(object sender, EventArgs e)
        {
            txt_NV_Ten_Nhan_Vien.Text = "";
            rad_NV_Nam.Checked = true;
            dt_NV_Ngay_Sinh.Value = DateTime.Now;
            txt_NV_SDT.Text = "";
            txt_NV_Luong.Text = "";
            txt_NV_User_Name.Text = "";
            txt_NV_Password.Text = "";
            txt_NV_Email.Text = "";
            chk_NV_Trang_Thai.Checked = true;
            txt_NV_User_Name.Enabled = true;
            btn_NV_Them.Enabled = true;
            btn_NV_Sua.Enabled = false;
            btn_NV_Xoa.Enabled = false;
        }

        private void btn_SP_Them_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = Ket_Noi();
            if (string.IsNullOrEmpty(txt_SP_Ten_San_Pham.Text.Trim()) ||
                string.IsNullOrEmpty(cbo_SP_Xuat_Xu.Text.Trim()) ||
                string.IsNullOrEmpty(txt_SP_Gia_Nhap.Text.Trim()) ||
                string.IsNullOrEmpty(txt_SP_Gia_Ban.Text.Trim()) ||
                string.IsNullOrEmpty(cbo_SP_Nha_Cung_Cap.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string tenSP, xuatXu, maNCC;
                double giaNhap, giaBan;
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
                maNCC = cbo_SP_Nha_Cung_Cap.SelectedValue.ToString();

                bool kq = Them_San_Pham(tenSP, giaNhap, giaBan, xuatXu, trangThai, maNCC);
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
                    btn_SP_Lam_Moi_Click(sender, e);
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
                if (txt_NCC_SDT.Text.Length != 10)
                {
                    MessageBox.Show("Vui lòng nhập SĐT đủ 10 số.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string  tenNCC, diaChi, SDT, email;
                bool trangThai;

                tenNCC = txt_NCC_Ten_Nha_Cung_Cap.Text;
                diaChi = txt_NCC_Dia_Chi.Text;
                SDT = txt_NCC_SDT.Text;
                email = txt_NCC_Email.Text;
                if (chk_NCC_Trang_Thai.Checked)
                {
                    trangThai = true;
                }
                else
                {
                    trangThai = false;
                }

                bool kq = Them_Nha_Cung_Cap( tenNCC, diaChi, SDT, email, trangThai);
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
                if (txt_NCC_SDT.Text.Length != 10)
                {
                    MessageBox.Show("Vui lòng nhập SĐT đủ 10 số.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string tenNCC, diaChi, SDT, email;
                bool trangThai;

                tenNCC = txt_NCC_Ten_Nha_Cung_Cap.Text;
                diaChi = txt_NCC_Dia_Chi.Text;
                SDT = txt_NCC_SDT.Text;
                email = txt_NCC_Email.Text;
                if (chk_NCC_Trang_Thai.Checked)
                {
                    trangThai = true;
                }
                else
                {
                    trangThai = false;
                }

                bool kq = Sua_Nha_Cung_Cap(tenNCC, diaChi, SDT, email, trangThai);
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
                bool trangThai;
                tenNCC = data_NCC.CurrentRow.Cells[1].Value.ToString();
                diaChi = data_NCC.CurrentRow.Cells[2].Value.ToString();
                SDT = data_NCC.CurrentRow.Cells[3].Value.ToString();
                email = data_NCC.CurrentRow.Cells[4].Value.ToString();
                trangThai = (bool)data_NCC.CurrentRow.Cells[5].Value;

                txt_NCC_Ten_Nha_Cung_Cap.Text = tenNCC;
                txt_NCC_Dia_Chi.Text = diaChi;
                txt_NCC_SDT.Text = SDT;
                txt_NCC_Email.Text = email;
                chk_KH_Trang_Thai.Checked = trangThai;

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

            //Câu truy vấn kiểm tra xem MANCC có đang được tham chiếu hay không
            string sSql_KT = "SELECT MANCC FROM NHACUNGCAP WHERE EXISTS ( SELECT 1 FROM SANPHAM WHERE SANPHAM.MANCC = NHACUNGCAP.MANCC)";
            string cot = "MANCC";

            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Bạn có chắc muốn xóa Nhà Cung Cấp này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                bool kt = Kiem_Tra_Ma_Co_Ton_Tai(sSql_KT, maNCC, cot);
                if (kt)
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
                else { MessageBox.Show("Nhà cung cấp này đang được tham chiếu từ sản phẩm", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { return; }
        }

        private void btn_NCC_Lam_Moi_Click(object sender, EventArgs e)
        {
            txt_NCC_Ten_Nha_Cung_Cap.Text = "";
            txt_NCC_Dia_Chi.Text = "";
            txt_NCC_SDT.Text = "";
            txt_NCC_Email.Text = "";
            chk_KH_Trang_Thai.Checked = true;
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
                if(txt_KH_SDT.Text.Length != 10)
                {
                    MessageBox.Show("Vui lòng nhập SĐT đủ 10 số.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string tenKH, diaChi, SDT, email, ngayTao;
                bool trangThai;

                tenKH = txt_KH_Ten_Khach_Hang.Text;
                diaChi = txt_KH_Dia_Chi.Text;
                SDT = txt_KH_SDT.Text;
                email = txt_KH_Email.Text;
                ngayTao = dt_KH_Ngay_Tao.Value.ToString("yyyy-MM-dd HH:mm:ss");
                if (chk_KH_Trang_Thai.Checked)
                {
                    trangThai = true;
                }
                else
                {
                    trangThai = false;
                }

                bool kq = Them_Khach_Hang(tenKH, diaChi, SDT, ngayTao, email, trangThai);
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
                    btn_KH_Lam_Moi_Click(sender, e);
                }
            }
        }

        private void data_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string tenKH, diaChi, SDT, email;
                DateTime ngayTao;
                bool trangThai;
                tenKH = data_KH.CurrentRow.Cells[1].Value.ToString();
                diaChi = data_KH.CurrentRow.Cells[2].Value.ToString();
                SDT = data_KH.CurrentRow.Cells[3].Value.ToString();
                ngayTao = (DateTime)data_KH.CurrentRow.Cells[4].Value;
                email = data_KH.CurrentRow.Cells[5].Value.ToString();
                trangThai = (bool)data_KH.CurrentRow.Cells[6].Value;

                txt_KH_Ten_Khach_Hang.Text = tenKH;
                txt_KH_Dia_Chi.Text = diaChi;
                txt_KH_SDT.Text = SDT;
                dt_KH_Ngay_Tao.Value = ngayTao;
                txt_KH_Email.Text = email;
                chk_KH_Trang_Thai.Checked = trangThai;

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
                if (txt_KH_SDT.Text.Length != 10)
                {
                    MessageBox.Show("Vui lòng nhập SĐT đủ 10 số.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string tenKH, diaChi, SDT, email, ngayTao;
                bool trangThai;

                tenKH = txt_KH_Ten_Khach_Hang.Text;
                diaChi = txt_KH_Dia_Chi.Text;
                SDT = txt_KH_SDT.Text;
                email = txt_KH_Email.Text;
                ngayTao = dt_KH_Ngay_Tao.Value.ToString("yyyy-MM-dd HH:mm:ss");
                if (chk_KH_Trang_Thai.Checked)
                {
                    trangThai = true;
                }
                else
                {
                    trangThai = false;
                }

                bool kq = Sua_Khach_Hang(tenKH, diaChi, SDT, ngayTao, email, trangThai);
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

            //Câu truy vấn kiểm tra xem MAKH có đang được tham chiếu hay không
            string sSql_KT = "SELECT MAKH FROM KHACHHANG WHERE EXISTS (SELECT 1 FROM HOADON WHERE HOADON.MAKH = KHACHHANG.MAKH)";
            string cot = "MAKH";

            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Bạn có chắc muốn xóa Khách Hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                bool kt = Kiem_Tra_Ma_Co_Ton_Tai(sSql_KT, maKH, cot);
                if (kt)
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
                else { MessageBox.Show("Khách hàng này đang được tham chiếu từ hóa đơn", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error); }

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
            chk_KH_Trang_Thai.Checked = true;
        }

        private void txt_NV_Tim_Kiem_TextChanged(object sender, EventArgs e)
        {
            string tenBang, tenCot, tenTK;
            tenBang = "NhanVien";
            tenCot = "TenNV";
            tenTK = txt_NV_Tim_Kiem.Text.Trim();
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

        private void data_SP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SqlConnection myConnection = Ket_Noi();
                string tenSP, xuatXu, giaNhap, giaBan, nhaCungCap, soLuong;
                bool trangThai;
                tenSP = data_SP.CurrentRow.Cells[1].Value.ToString();
                xuatXu = data_SP.CurrentRow.Cells[4].Value.ToString();
                giaNhap = data_SP.CurrentRow.Cells[2].Value.ToString();
                giaBan = data_SP.CurrentRow.Cells[3].Value.ToString();
                nhaCungCap = data_SP.CurrentRow.Cells[6].Value.ToString();
                if ((bool)data_SP.CurrentRow.Cells[5].Value == true)
                {
                    trangThai = true;
                }
                else { trangThai = false; }
                soLuong = data_SP.CurrentRow.Cells[7].Value.ToString();

                try
                {
                    myConnection.Open();
                    string query = "SELECT TenNCC FROM NhaCungCap WHERE MaNCC = @MaNCC";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@MaNCC", nhaCungCap);
                    object result = cmd.ExecuteScalar();
                    myConnection.Close();
                    txt_SP_Ten_San_Pham.Text = tenSP;
                    cbo_SP_Xuat_Xu.Text = xuatXu;
                    txt_SP_Gia_Nhap.Text = giaNhap;
                    txt_SP_Gia_Ban.Text = giaBan;
                    chk_SP_Trang_Thai.Checked = trangThai;
                    cbo_SP_Nha_Cung_Cap.Text = result.ToString();
                }
                catch (Exception ex)
                {

                }
                btn_SP_Sua.Enabled = true;
                btn_SP_Xoa.Enabled = true;
                btn_SP_Them.Enabled = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_SP_Sua_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = Ket_Noi();
            if (string.IsNullOrEmpty(txt_SP_Ten_San_Pham.Text.Trim()) ||
                string.IsNullOrEmpty(cbo_SP_Xuat_Xu.Text.Trim()) ||
                string.IsNullOrEmpty(txt_SP_Gia_Nhap.Text.Trim()) ||
                string.IsNullOrEmpty(txt_SP_Gia_Ban.Text.Trim()) ||
                string.IsNullOrEmpty(cbo_SP_Nha_Cung_Cap.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                
                string tenSP, xuatXu, maNCC;
                double giaNhap, giaBan;
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
                maNCC = cbo_SP_Nha_Cung_Cap.SelectedValue.ToString();

                bool kq = Sua_San_Pham(tenSP, giaNhap, giaBan, xuatXu, trangThai, maNCC);
                if (kq == false)
                {
                    MessageBox.Show("Sửa Sản Phẩm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Sửa Sản Phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sSql_Xem_San_Pham = "SELECT * FROM SanPham";
                    DataSet ds_San_Pham = Xem_Thong_Tin(sSql_Xem_San_Pham);
                    data_SP.DataSource = ds_San_Pham.Tables[0];
                    Hien_Thi_Len_HD_CBO_San_Pham();
                    btn_SP_Lam_Moi_Click(sender, e);
                }
            }
        }

        private void btn_SP_Xoa_Click(object sender, EventArgs e)
        {
            string bien = "@MASP";
            string maSP = data_SP.CurrentRow.Cells[0].Value.ToString();
            //Câu truy vấn xóa dòng của SANPHAM
            string sSql_SP;
            sSql_SP = "DELETE SanPham WHERE MASP = @MASP";

            //Câu truy vấn kiểm tra xem MASP có đang được tham chiếu hay không
            string sSql_KT = "SELECT MASP FROM SANPHAM WHERE EXISTS (SELECT 1 FROM CT_HOADON WHERE CT_HOADON.MASP = SANPHAM.MASP)";
            string cot = "MASP";

            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Bạn có chắc muốn xóa Sản Phẩm này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                bool kt = Kiem_Tra_Ma_Co_Ton_Tai(sSql_KT, maSP, cot);
                if (kt)
                {
                    bool kq = Xoa_Dong(maSP, sSql_SP, bien);
                    if (kq == false)
                    {
                        MessageBox.Show("Xóa Sản Phẩm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Xóa Sản Phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string sSql_Xem_San_Pham = "SELECT * FROM SanPham";
                        DataSet ds_San_Pham = Xem_Thong_Tin(sSql_Xem_San_Pham);
                        data_KH.DataSource = ds_San_Pham.Tables[0];
                        Hien_Thi_Len_HD_CBO_San_Pham();
                        btn_SP_Lam_Moi_Click(sender, e);
                        btn_KH_Xoa.Enabled = false;
                        btn_KH_Them.Enabled = true;
                    }
                }
                else { MessageBox.Show("Sản phẩm này đang được tham chiếu từ hóa đơn", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { return; }
        }

        private void btn_SP_Lam_Moi_Click(object sender, EventArgs e)
        {
            txt_SP_Ten_San_Pham.Text = "";
            txt_SP_Gia_Nhap.Text = "";
            txt_SP_Gia_Ban.Text = "";
            cbo_SP_Xuat_Xu.SelectedIndex = 0;
            cbo_SP_Nha_Cung_Cap.SelectedIndex = 0;
            txt_SP_Ten_San_Pham.Text = "";
            chk_SP_Trang_Thai.Checked = true;
            btn_SP_Them.Enabled = true;
            btn_SP_Sua.Enabled = false;
            btn_SP_Xoa.Enabled = false;
        }

        private void btn_HD_Xem_DS_Hoa_Don_Click(object sender, EventArgs e)
        {
            if (btn_DSHD_Click)
            {
                string sSql_Xem_Hoa_Don = "SELECT HOADON.MAHD, MANV, MAKH, MASP, SOLUONG, DONGIA, CT_HOADON.TONGTIEN,KHUYENMAI,NGAYLAPHD " +
                          "FROM HOADON JOIN CT_HOADON ON HOADON.MAHD = CT_HOADON.MAHD";
                DataSet ds_Hoa_Don = Xem_Thong_Tin(sSql_Xem_Hoa_Don);
                data_HD.DataSource = ds_Hoa_Don.Tables[0];
                lab_HD_Tim_Kiem.Visible = true;
                txt_HD_Tim_Kiem.Visible = true;
                btn_HD_In_Hoa_Don.Visible = false;
                btn_DSHD_Click = false;
            }
            else
            {
                data_HD.DataSource = table;
                lab_HD_Tim_Kiem.Visible = false;
                txt_HD_Tim_Kiem.Visible = false;
                btn_HD_In_Hoa_Don.Visible = true;
                btn_DSHD_Click = true;
            }
            
        }

        private void btn_HD_Luu_Click(object sender, EventArgs e)
        {
            textChange_HD_Khuyen_Mai = true;
            Luu_Vao_Database();
            //Cập nhật lại ds hiển thị sản phẩm
            string sSql_Xem_San_Pham = "SELECT * FROM SanPham";
            DataSet ds_San_Pham = Xem_Thong_Tin(sSql_Xem_San_Pham);
            data_SP.DataSource = ds_San_Pham.Tables[0];
            table = null;
            Them_Ten_Cot_Vao_DataHD();
            Lam_Moi_HD();
            btn_HD_Luu.Enabled = false;
            textChange_HD_Khuyen_Mai = false;
            
        }

        private void btn_HD_Ghi_Click(object sender, EventArgs e)
        {
            bool kq = KT_So_Luong();
            if (kq)
            {
                textChange_HD_Khuyen_Mai = true;
                if (string.IsNullOrEmpty(txt_HD_Ma_Hoa_Don.Text.Trim()) ||
                   string.IsNullOrEmpty(txt_HD_Don_Gia.Text.Trim()) ||
                   string.IsNullOrEmpty(txt_HD_Thanh_Tien.Text.Trim()))
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
                    donGia = double.Parse(txt_HD_Don_Gia.Text);
                    thanhTien = double.Parse(txt_HD_Thanh_Tien.Text);
                    maKH = cbo_HD_Khach_Hang.SelectedValue.ToString();
                    maNV = txt_HD_Nhan_Vien.Text.ToString();
                    if (txt_HD_Khuyen_Mai.Text.Trim() == "")
                    {
                        khuyenMai = 0;
                    }
                    else { khuyenMai = double.Parse(txt_HD_Khuyen_Mai.Text); }
                    khuyenMai =  khuyenMai/ 100;
                    ngayLap = dt_HD_Ngay_Lap_HD.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    Them_San_Pham_Vao_DataHD(maHD, maSP, soLuong, donGia, thanhTien, maKH, maNV, ngayLap, khuyenMai);
                    btn_HD_Luu.Enabled = true;
                    btn_HD_Ghi.Enabled = false;
                    Lam_Moi_HD();
                }
                textChange_HD_Khuyen_Mai = false;
            }
            else
            {
                MessageBox.Show("Số lượng sản phẩm không đủ để lập hóa đơn!","Lưu ý",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void data_HD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (data_HD.DataSource != null)
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

                        maHD = data_HD.CurrentRow.Cells[0].Value.ToString();
                        sanPham = data_HD.CurrentRow.Cells[1].Value.ToString();
                        soLuong = (int)data_HD.CurrentRow.Cells[2].Value;
                        donGia = data_HD.CurrentRow.Cells[3].Value.ToString();
                        thanhTien = data_HD.CurrentRow.Cells[4].Value.ToString();
                        khachHang = data_HD.CurrentRow.Cells[5].Value.ToString();
                        nhanVien = data_HD.CurrentRow.Cells[6].Value.ToString();

                        string dateTimeString = data_HD.CurrentRow.Cells[7].Value.ToString();
                        string format = "yyyy-MM-dd HH:mm:ss";
                        if (DateTime.TryParseExact(dateTimeString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayLap))
                        {
                            dt_HD_Ngay_Lap_HD.Value = ngayLap;
                        }
                        else
                        {
                            MessageBox.Show("Không thể ép kiểu chuỗi thành DateTime.");
                        }

                        khuyenMai = ((double)data_HD.CurrentRow.Cells[8].Value * 100).ToString();

                        try
                        {
                            myConnection.Open();

                            string query = "SELECT TenSP FROM SanPham WHERE MaSP = @MaSP";
                            SqlCommand cmd = new SqlCommand(query, myConnection);
                            cmd.Parameters.AddWithValue("@MaSP", sanPham);
                            object result = cmd.ExecuteScalar();

                            txt_HD_Ma_Hoa_Don.Text = maHD;
                            cbo_HD_San_Pham.Text = result.ToString();
                            nmr_HD_So_Luong.Value = soLuong;
                            txt_HD_Don_Gia.Text = donGia;
                            txt_HD_Thanh_Tien.Text = thanhTien;

                            query = "SELECT TenKH FROM KhachHang WHERE MaKH = @MaKH";
                            cmd = new SqlCommand(query, myConnection);
                            cmd.Parameters.AddWithValue("@MaKH", khachHang);
                            result = cmd.ExecuteScalar();
                            cbo_HD_Khach_Hang.Text = result.ToString();

                            txt_HD_Nhan_Vien.Text = nhanVien;
                            txt_HD_Khuyen_Mai.Text = khuyenMai;

                            myConnection.Close();

                            btn_HD_Ghi.Enabled = false;
                            btn_HD_Luu.Enabled = false;
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
                    btn_HD_Sua.Enabled = true;
                    btn_HD_Xoa.Enabled = true;
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

        private void btn_HD_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = data_HD.CurrentRow.Index;

                string maHD = txt_HD_Ma_Hoa_Don.Text;
                string maSP = cbo_HD_San_Pham.SelectedValue.ToString();
                int soLuong = (int)nmr_HD_So_Luong.Value;
                double donGia = double.Parse(txt_HD_Don_Gia.Text);
                double thanhTien = double.Parse(txt_HD_Thanh_Tien.Text);
                string maKH = cbo_HD_Khach_Hang.SelectedValue.ToString();
                string maNV = txt_HD_Nhan_Vien.Text;
                string ngayLap = dt_HD_Ngay_Lap_HD.Value.ToString("yyyy-MM-dd HH:mm:ss");
                double khuyenMai;
                if (txt_HD_Khuyen_Mai.Text == "")
                {
                    khuyenMai = 0;
                }
                else { khuyenMai = (double.Parse(txt_HD_Khuyen_Mai.Text)) / 100; }

                data_HD.Rows[rowIndex].Cells["MAHD"].Value = maHD;
                data_HD.Rows[rowIndex].Cells["MASP"].Value = maSP;
                data_HD.Rows[rowIndex].Cells["SOLUONG"].Value = soLuong;
                data_HD.Rows[rowIndex].Cells["DONGIA"].Value = donGia;
                data_HD.Rows[rowIndex].Cells["THANHTIEN"].Value = thanhTien;
                data_HD.Rows[rowIndex].Cells["MAKH"].Value = maKH;
                data_HD.Rows[rowIndex].Cells["MANV"].Value = maNV;
                data_HD.Rows[rowIndex].Cells["NGAYLAPHD"].Value = ngayLap;
                data_HD.Rows[rowIndex].Cells["KHUYENMAI"].Value = khuyenMai;
                btn_HD_Luu.Enabled = true;
                btn_HD_Sua.Enabled = false;
                btn_HD_Ghi.Enabled = false;
                Lam_Moi_HD();
                MessageBox.Show("Sửa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tinh_Tien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không thành công: " + ex.Message);
            }
            
        }

        private void txt_HD_Khuyen_Mai_TextChanged(object sender, EventArgs e)
        {
            if (!textChange_HD_Khuyen_Mai)
            {
                Tinh_Tien();
            }
        }

        private void nmr_HD_So_Luong_ValueChanged(object sender, EventArgs e)
        {

            Tinh_Tien();
            
        }

        private void txt_HD_Khuyen_Mai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if(txt_HD_Khuyen_Mai.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btn_HD_Thong_Ke_Click(object sender, EventArgs e)
        {
            frmThongKe thongKe = new frmThongKe();
            thongKe.ShowDialog();
        }

        private void btn_Nhap_Hang_Click(object sender, EventArgs e)
        {
            frmNhapHang frm = new frmNhapHang();
            frm.ShowDialog();
        }

        private void btn_HD_Xoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow hang = data_HD.SelectedRows[0];
            data_HD.Rows.Remove(hang);
            btn_HD_Sua.Enabled = false;
            btn_HD_Xoa.Enabled = false;
            Lam_Moi_HD();
        }

        private void btn_HD_In_Hoa_Don_Click(object sender, EventArgs e)
        {
            frmInHoaDon frm = new frmInHoaDon();
            frm.ShowDialog();
        }
    }
}
