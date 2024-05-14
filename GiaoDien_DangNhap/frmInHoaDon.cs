using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace GiaoDien_DangNhap
{
    public partial class frmInHoaDon : Form
    {
        public frmInHoaDon()
        {
            InitializeComponent();
        }
        private static string scon = "Data Source = TranTuan\\MSSQL_SERVER; Initial Catalog = qlbanmaytinh; Integrated Security = true;";
        SqlConnection con = null;

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            
            this.reportViewer1.RefreshReport();
        }

        private void btn_In_Hoa_Don_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_Ma_Hoa_Don.Text.Trim()))
                {
                    MessageBox.Show("Nhập mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (con == null)
                {
                    con = new SqlConnection(scon);
                }

                string maHD = txt_Ma_Hoa_Don.Text.Trim();
                string sSql = "SELECT TENSP, CT_HoaDon.SOLUONG, DONGIA, KHUYENMAI, TONGTIEN FROM CT_HoaDon JOIN SanPham ON CT_HoaDon.MaSP = SanPham.MaSP WHERE maHD = @maHD";

                SqlCommand cmd = new SqlCommand(sSql, con);
                cmd.Parameters.AddWithValue("@maHD", maHD);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "HoaDon");
                if (ds.Tables["HoaDon"].Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu cho mã hóa đơn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.reportViewer1.LocalReport.ReportPath = @"..\..\ReportHoaDon.rdlc";

                ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables["HoaDon"]);
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
