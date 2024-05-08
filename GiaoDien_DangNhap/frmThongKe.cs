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
            Hien_Thi_Len_HD_CBO_San_Pham();
            //char_bieu_do_tk.Series["chart_bd"].Points.AddXY("Tháng 1 ", 10000);
            //char_bieu_do_tk.Series["chart_bd"].Points.AddXY("Tháng 2 ", 11000);
            //char_bieu_do_tk.Series["chart_bd"].Points.AddXY("Tháng 3 ", 12000);
            //char_bieu_do_tk.Series["chart_bd"].Points.AddXY("Tháng 4 ", 13000);
            //char_bieu_do_tk.Series["chart_bd"].Points.AddXY("Tháng 5 ", 14000);
            //char_bieu_do_tk.Series["chart_bd"].Points.AddXY("Tháng 6 ", 15000);
            //char_bieu_do_tk.Series["chart_bd"].Points.AddXY("Tháng 7 ", 16000);
            //char_bieu_do_tk.Series["chart_bd"].Points.AddXY("Tháng 8 ", 1000);
            //char_bieu_do_tk.Series["chart_bd"].Points.AddXY("Tháng 9 ", 180000);
            //char_bieu_do_tk.Series["chart_bd"].Points.AddXY("Tháng 10 ", 109000);
            //char_bieu_do_tk.Series["chart_bd"].Points.AddXY("Tháng 11", 10000);
            //char_bieu_do_tk.Series["chart_bd"].Points.AddXY("Tháng 12", 10000);



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

                cbo_sanPham.DataSource = ds.Tables[0];
                cbo_sanPham.DisplayMember = "Tensp";
                cbo_sanPham.ValueMember = "masp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: 3 " + ex.Message);
            }
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
        private void btn_tim_kiem_Click(object sender, EventArgs e)
        {
            string masp=cbo_sanPham.SelectedValue.ToString();
            string ngayBatDau = dt_ngay_bat_dau.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string ngayKetThuc = dt_ngay_ket_thuc.Value.ToString("yyyy-MM-dd HH:mm:ss");
            {
                string sSql_Xem_Thong_Ke = "select  DISTINCT CT_HOADON.MAHD, TENSP, CT_HOADON.SOLUONG, DONGIA, KHUYENMAI, TONGTIEN, MANV, MAKH, NGAYLAPHD\r\n" +
                    "from CT_HOADON , HOADON ,SANPHAM \r\n" +
                    "where CT_HOADON.MAHD=HOADON.MAHD and ct_hoadon.MASP=SANPHAM.MASP and  CT_HOADON.MASP='"+masp+"' and NGAYLAPHD>'"+ngayBatDau+"' and NGAYLAPHD<'"+ngayKetThuc+"'";
                DataSet ds_Hoa_Don = Xem_Thong_Tin(sSql_Xem_Thong_Ke);
                data_Thong_Ke.DataSource = ds_Hoa_Don.Tables[0];
              

            }
            hien_doanh_thu(masp,ngayBatDau,ngayKetThuc);
            hien_so_luong(masp, ngayBatDau, ngayKetThuc);
        }
        void hien_doanh_thu(string masp,string ngay_bd,string ngaykt)       
        {
            masp = cbo_sanPham.SelectedValue.ToString();
             ngay_bd = dt_ngay_bat_dau.Value.ToString("yyyy-MM-dd HH:mm:ss");
             ngaykt = dt_ngay_ket_thuc.Value.ToString("yyyy-MM-dd HH:mm:ss");
            SqlConnection myConnection = Ket_Noi();
            string sSql_Lay_Doanh_Thu = "select SUM(TONGTIEN) " +
                      "from CT_HOADON join HOADON on CT_HOADON.MAHD=HOADON.MAHD\r\n" +
                      "where MASP='" + masp + "' and NGAYLAPHD>'" + ngay_bd + "' and NGAYLAPHD<'" + ngaykt + "'";
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql_Lay_Doanh_Thu, myConnection);
                object result = cmd.ExecuteScalar();

                myConnection.Close();
                lb_lay_dt.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void hien_so_luong(string masp, string ngay_bd, string ngaykt)
        {
            masp = cbo_sanPham.SelectedValue.ToString();
            ngay_bd = dt_ngay_bat_dau.Value.ToString("yyyy-MM-dd HH:mm:ss");
            ngaykt = dt_ngay_ket_thuc.Value.ToString("yyyy-MM-dd HH:mm:ss");
            SqlConnection myConnection = Ket_Noi();
            string sSql_Lay_So_Luong = "select SUM(SOLUONG) " +
                      "from CT_HOADON join HOADON on CT_HOADON.MAHD=HOADON.MAHD\r\n" +
                      "where MASP='" + masp + "' and NGAYLAPHD>'" + ngay_bd + "' and NGAYLAPHD<'" + ngaykt + "'";
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql_Lay_So_Luong, myConnection);
                object result = cmd.ExecuteScalar();

                myConnection.Close();
                lb_lay_sl.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
