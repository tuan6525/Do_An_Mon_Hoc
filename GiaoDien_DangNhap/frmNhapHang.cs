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
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }

        public SqlConnection Ket_Noi()
        {
            string scon = "Data Source = TranTuan\\MSSQL_SERVER; Initial Catalog = qlbanmaytinh; Integrated Security = true;";
            SqlConnection myConnection = new SqlConnection(scon);
            return myConnection;
        }

        public DataSet Hien_cbo_Ten_San_Pham()
        {
            SqlConnection myConnection = Ket_Noi();
            DataSet ds = null;
            string sSql = "SELECT MASP, TENSP FROM SANPHAM";
            try
            {
                myConnection.Open();

                SqlDataAdapter dssp = new SqlDataAdapter(sSql, myConnection);
                ds = new DataSet();
                dssp.Fill(ds);

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiện tên sản phẩm: " + ex.Message);
            }
            return ds;
        }

        public bool Them_So_Luong(string maSP, int soLuong)
        {
            SqlConnection myConnection = Ket_Noi();
            bool kq;
            string sSql_Lay = "SELECT SOLUONG FROM SANPHAM WHERE MASP = @maSP";
            string sSql_Sua = "UPDATE SANPHAM SET SOLUONG = @soLuong WHERE MASP = @maSP";

            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand(sSql_Lay, myConnection);
                cmd.Parameters.AddWithValue("@maSP", maSP);
                soLuong += Convert.ToInt32(cmd.ExecuteScalar());


                cmd = new SqlCommand(sSql_Sua, myConnection);
                cmd.Parameters.AddWithValue("@soLuong", soLuong);
                cmd.Parameters.AddWithValue("@maSP", maSP);
                cmd.ExecuteNonQuery();
                kq = true;

                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show("Lỗi thêm số lượng: " + ex.Message);
            }
            return kq;
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            DataSet ds = Hien_cbo_Ten_San_Pham();
            cbo_Ten_San_Pham.DataSource = ds.Tables[0];
            cbo_Ten_San_Pham.DisplayMember = "TENSP";
            cbo_Ten_San_Pham.ValueMember = "MASP";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string maSP = cbo_Ten_San_Pham.SelectedValue.ToString();
            int soLuong = (int)nmr_So_Luong.Value;
            bool kq = Them_So_Luong(maSP, soLuong);
            if (kq)
            {
                MessageBox.Show("Nhập hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Application.OpenForms["frmQuanLy"] != null)
                {
                    (Application.OpenForms["frmQuanLy"] as frmQuanLy).Cap_Nhat_Du_lieu();
                }
                nmr_So_Luong.Value = 1;
            }
            else
            {
                MessageBox.Show("Nhập hàng KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
