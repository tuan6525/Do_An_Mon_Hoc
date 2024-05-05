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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            this.AcceptButton = btn_Dang_Nhap;
        }
        private static string scon = "Data Source = TranTuan\\MSSQL_SERVER; Initial Catalog = qlbanmaytinh; Integrated Security = true;";

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txt_Password.PasswordChar = '*';
        }

        private void chk_Hien_Mat_Khau_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Hien_Mat_Khau.Checked)
            {
                txt_Password.PasswordChar = '\0';
            }
            else
            {
                txt_Password.PasswordChar = '*';
            }
        }

        public static SqlConnection Ket_Noi()
        {
            SqlConnection myConnection = new SqlConnection(scon);
            return myConnection;
        }

        private bool Kiem_Tra(string username, string password, string chucVu)
        {
            SqlConnection myConnection = Ket_Noi();
            string sSql = "SELECT COUNT(*) FROM TaiKhoan WHERE Username = @Username AND Password = @Password AND ChucVu = @ChucVu";
            bool kq = false;

            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(sSql, myConnection);
                cmd.Parameters.AddWithValue("Username", username);
                cmd.Parameters.AddWithValue("Password", password);
                cmd.Parameters.AddWithValue("ChucVu", chucVu);

                int count = (int)cmd.ExecuteScalar();
                kq = count> 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_Username.Text.Trim()) ||
               string.IsNullOrEmpty(txt_Password.Text.Trim()))
            {
                MessageBox.Show("Nhập đầy đủ Tên đăng nhập và Mật khẩu","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string username = txt_Username.Text;
                string password = txt_Password.Text;

                if (Kiem_Tra(username, password, "QL"))
                {
                    MessageBox.Show("Đăng nhập Quản Lý thành công!");
                    this.Hide();
                    frmQuanLy quanLy = new frmQuanLy();
                    quanLy.Show();
                }
                else if(Kiem_Tra(username, password, "NV"))
                {
                    MessageBox.Show("Đăng nhập Nhân Viên thành công!");
                    this.Hide();
                    frmNhanVien nhanVien = new frmNhanVien();
                    nhanVien.Show();
                }
                else
                {
                    lab_Loi.Text = "Tài khoản hoặc mật khẩu không đúng!!";
                }
            }
        }
    }
}
