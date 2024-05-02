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
    public partial class TiemKiemHD : Form
    {
        public TiemKiemHD()
        {
            InitializeComponent();
        }
        public static string Connect = "Data Source=THONGDZ;Initial Catalog=qlbanmaytinh;Integrated Security=true";
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
        private void btn_hien_all_Click(object sender, EventArgs e)
        {
            string sSql_Xem_Hoa_Don = "select*from hoadon";
            DataSet ds_Hoa_Don = Xem_Thong_Tin(sSql_Xem_Hoa_Don);
            data_tk_HD.DataSource = ds_Hoa_Don.Tables[0];
        }

        private void data_tk_HD_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
            try
            {
                string mahd, manv, makh, ngaylaphd;
                //lay du lieu dataridview
                mahd = data_tk_HD.CurrentRow.Cells[0].Value.ToString();
                manv = data_tk_HD.CurrentRow.Cells[1].Value.ToString();
                makh = data_tk_HD.CurrentRow.Cells[2].Value.ToString();
                ngaylaphd = data_tk_HD.CurrentRow.Cells[3].Value.ToString();
                txt_mahd.Text = mahd;
                txt_manv.Text = manv;
                txt_makh.Text = makh;
                dt_hd.Text = ngaylaphd;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txt_tk_mahd_TextChanged(object sender, EventArgs e)
        {
            string tkHD;
            tkHD = txt_tk_mahd.Text;
            DataSet ds = Tim_Kiem_HD(tkHD);
            data_tk_HD.DataSource = ds.Tables[0];
        }
        public DataSet Tim_Kiem_HD(string tkHD)
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Tim_Kiem = "SELECT *FROM HOADON WHERE MAHD LIKE N'%" + tkHD + "%'";
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
    }
}
