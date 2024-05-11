using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDien_DangNhap
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        DataTable table;
        public static string Connect = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=true";
        public static SqlConnection Ket_Noi()
        {
            SqlConnection myConnection = new SqlConnection(Connect);
            return myConnection;
        }
        private void frmThongKe_Load(object sender, EventArgs e)
        {
            //Hien_Thi_Len_HD_CBO_San_Pham();

        }
        //public void Hien_Thi_Len_HD_CBO_San_Pham()
        //{
        //    SqlConnection myConnection = Ket_Noi();
        //    string sSql_Hien = "SELECT MaSP, TenSP FROM SanPham";
        //    try
        //    {
        //        myConnection.Open();
        //        SqlDataAdapter dsHien = new SqlDataAdapter(sSql_Hien, myConnection);
        //        DataSet ds = new DataSet();
        //        dsHien.Fill(ds);
        //        myConnection.Close();

        //        cbo_sanPham.DataSource = ds.Tables[0];
        //        cbo_sanPham.DisplayMember = "Tensp";
        //        cbo_sanPham.ValueMember = "masp";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Loi: 3 " + ex.Message);
        //    }
        //}
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
        bool  kiem_tra_ngay(DateTime ngaybd,DateTime ngaykt)
        {
            bool kq = true;
             ngaybd = dt_ngay_bat_dau.Value;
             ngaykt = dt_ngay_ket_thuc.Value;
            if (ngaybd>ngaykt)
            {

                kq = false;
            }
            else
            {
                kq = true;
            }
            return kq;

        }
        private void btn_tim_kiem_Click(object sender, EventArgs e)
        {
            bool ktra;
            ktra = kiem_tra_ngay(dt_ngay_bat_dau.Value, dt_ngay_ket_thuc.Value);
            if (ktra)
            {
                string ngayBatDau = dt_ngay_bat_dau.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string ngayKetThuc = dt_ngay_ket_thuc.Value.ToString("yyyy-MM-dd HH:mm:ss");
                {
                    string sSql_Xem_Thong_Ke = "select sp.TENSP ,SUM(ct.SOLUONG) as SOLUONG,SUM(TONGTIEN) as DOANHTHU\r\n" +
                        "from HOADON hd, CT_HOADON ct,SANPHAM sp\r\n" +
                        "where hd.MAHD=ct.MAHD and ct.MASP=sp.MASP and NGAYLAPHD>'" + ngayBatDau + "'and NGAYLAPHD<'" + ngayKetThuc + "'\r\ngroup by ct.MASP,sp.TENSP";
                    DataSet ds_Hoa_Don = Xem_Thong_Tin(sSql_Xem_Thong_Ke);
                    data_Thong_Ke.DataSource = ds_Hoa_Don.Tables[0];


                }
                hien_doanh_thu(ngayBatDau, ngayKetThuc);
                hien_so_luong(ngayBatDau, ngayKetThuc);
                hien_so_luong_hd(ngayBatDau, ngayKetThuc);
            }
            else
            {
                MessageBox.Show("Thông tin ngày/tháng/năm không hợp lệ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void hien_doanh_thu(string ngay_bd,string ngaykt)       
        {
            bool ktra;
            ktra = kiem_tra_ngay(dt_ngay_bat_dau.Value, dt_ngay_ket_thuc.Value);
            if (ktra)
            {
                ngay_bd = dt_ngay_bat_dau.Value.ToString("yyyy-MM-dd HH:mm:ss");
                ngaykt = dt_ngay_ket_thuc.Value.ToString("yyyy-MM-dd HH:mm:ss");
                SqlConnection myConnection = Ket_Noi();
                string sSql_Lay_Doanh_Thu = "select SUM(TONGTIEN) " +
                      "from CT_HOADON join HOADON on CT_HOADON.MAHD=HOADON.MAHD\r\n" +
                      "where NGAYLAPHD>'" + ngay_bd + "' and NGAYLAPHD<'" + ngaykt + "'";
                try
                {
                    myConnection.Open();

                    SqlCommand cmd = new SqlCommand(sSql_Lay_Doanh_Thu, myConnection);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        myConnection.Close();
                        string dt = result.ToString();
                        dt = $"{Convert.ToDecimal(result):N0}";
                        lb_lay_dt.Text = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thống kê doanh thu" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Thông tin ngày/tháng/năm không hợp lệ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        void hien_so_luong( string ngay_bd, string ngaykt)
        {
            bool ktra;
            ktra = kiem_tra_ngay(dt_ngay_bat_dau.Value, dt_ngay_ket_thuc.Value);
            if (ktra)
            {

                ngay_bd = dt_ngay_bat_dau.Value.ToString("yyyy-MM-dd HH:mm:ss");
            ngaykt = dt_ngay_ket_thuc.Value.ToString("yyyy-MM-dd HH:mm:ss");
            SqlConnection myConnection = Ket_Noi();
            string sSql_Lay_So_Luong = "select SUM(SOLUONG) " +
                      "from CT_HOADON join HOADON on CT_HOADON.MAHD=HOADON.MAHD\r\n" +
                      "where NGAYLAPHD>'" + ngay_bd + "' and NGAYLAPHD<'" + ngaykt + "'";
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql_Lay_So_Luong, myConnection);
                    
                        object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value) { 
                        myConnection.Close();
                        lb_lay_sl.Text = result.ToString();
                    }
                    else
                    {
                        myConnection.Close();
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
            else
            {
                MessageBox.Show("Thông tin ngày/tháng/năm không hợp lệ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void hien_so_luong_hd (string ngay_bd, string ngaykt)
        {
            bool ktra;
            ktra = kiem_tra_ngay(dt_ngay_bat_dau.Value, dt_ngay_ket_thuc.Value);
            if (ktra)
            {
                ngay_bd = dt_ngay_bat_dau.Value.ToString("yyyy-MM-dd HH:mm:ss");
            ngaykt = dt_ngay_ket_thuc.Value.ToString("yyyy-MM-dd HH:mm:ss");
            SqlConnection myConnection = Ket_Noi();
            string sSql_Lay_So_Luong = "select count(ct.mahd) from HOADON hd ,CT_HOADON ct\r\nwhere hd.MAHD=ct.MAHD and NGAYLAPHD>'"+ngay_bd+"'and NGAYLAPHD<'"+ngaykt+"'";
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql_Lay_So_Luong, myConnection);
                   
                        object result = cmd.ExecuteScalar();
                    if (result!=DBNull.Value)
                    {

                    
                        myConnection.Close();
                        lb_tong_tl_hd.Text = result.ToString();
                    }
                    else
                    {
                        myConnection.Close();
                        
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
            else
            {
                MessageBox.Show("Thông tin ngày/tháng/năm không hợp lệ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
