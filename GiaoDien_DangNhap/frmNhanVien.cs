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
            query("SELECT*FROM SANPHAM WHERE " + "masp="+txt_maSP.Text);
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            query("Select*from hoadon");
            que("select*from khachhang");
        }

        private void txt_maSP_TextChanged(object sender, EventArgs e)
        {
            string masp=txt_maSP.Text;
            query("select*from sanpham where masp=" + masp);

        }
    }
}
