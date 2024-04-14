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
                dGR_BH.DataSource = tb;
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
        private void btn_BH_search_Click(object sender, EventArgs e)
        {
            query("SELECT*FROM SANPHAM WHERE " + "masp="+txt_BH_maHD.Text);
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            query("Select*from hoadon");
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

        private void btn_BH_add_Click(object sender, EventArgs e)
        {
            string maHD,maNV,maKH,ngayLapHD;
            int tienNhan, tienTra, thanhTien;
            maHD=txt_BH_maHD.Text;
            maNV=txt_BH_maHD.Text;
            maKH=txt_BH_tenNV.Text;
            ngayLapHD=dt_BH_ngayLapHD.Value.ToString();
            //tienNhan=int.Parse(txt_BH_tienNhan.Text);
            //tienTra=int.Parse(txt_BH_tienTra.Text);
            //thanhTien=int.Parse(txt_BH_thanhTien.Text);

            //bool kq=   themHoaDon(maHD,maNV,maKH, ngayLapHD, tienNhan, tienTra,thanhTien);
            //if (kq == true)
            //{

            //    MessageBox.Show("Thêm hóa đơn thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    query("Select*from hoadon");
            //}
            //else
            //{
            //    MessageBox.Show("Thêm thất bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
    }
}
