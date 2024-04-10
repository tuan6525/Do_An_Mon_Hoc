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
    public partial class frmQuanLy : Form
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }

        private static string scon = "Data Source = THONGDZ; Initial Catalog = qlbanmaytinh; Integrated Security = true;";

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql_Xem = "SELECT * FROM SanPham";
            DataSet ds = Xem_Thong_Tin(sSql_Xem);
            data_SP.DataSource = ds.Tables[0];
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " +ex.Message);
            }
            return ds;
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

                    SqlCommand cmd = new SqlCommand(sSql_Them,myConnection);
                    cmd.ExecuteNonQuery();
                    DataSet ds = Xem_Thong_Tin(sSql_Xem);

                    myConnection.Close();
                    data_SP.DataSource = ds.Tables[0];
                }catch (Exception ex)
                {
                    MessageBox.Show("Loi: " + ex.Message);
                }
            }
        }

        private void btn_HD_Tinh_Tien_Click(object sender, EventArgs e)
        {
            //Lấy giá trị của mã sản phẩm
            int maSP = int.Parse(txt_HD_Ma_San_Pham.Text);
            int soLuong = (int)nmr_So_Luong.Value;
            double giaBan = 0;

            // Viết câu lệnh truy vấn lấy giá bán của sản phẩm
            string sSql_Gia_Ban = "SELECT GiaBan FROM SanPham WHERE MASP = @MaSP";

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection myConnection = Ket_Noi())
            {
                try
                {
                    myConnection.Open();
                    // Thực thi truy vấn
                    SqlCommand cmd = new SqlCommand(sSql_Gia_Ban, myConnection);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);

                    // Đọc giá trị giá bán từ kết quả truy vấn
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        giaBan = Convert.ToDouble(result);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm có mã " + maSP);
                        return;
                    }

                    // Tính thành tiền
                    double thanhTien = soLuong * giaBan;
                    txt_HD_Thanh_Tien.Text = thanhTien.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

        }

       
    }
}
