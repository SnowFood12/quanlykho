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

namespace asm_DangKi
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }
        string str = "Data Source=.;Initial Catalog=WINFORM;Integrated Security=True"; // khai báo chuỗi liên kết 
        SqlConnection conn = null; // khai báo biến liên kết 
        private void frm_DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            // chuyển qua form đăng kí khi click vào button
            frm_DangKi frm_DangKi = new frm_DangKi(); 
            frm_DangKi.Show();
            this.Hide();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(str); // khởi tạo biến liên kết 
                conn.Open(); // mở liên kết 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex); // bẫy lỗi khi không liên kết được 
            }
            // kiểm tra giá trị đầu vào 
            if (txt_TenDangNhap.Text.Length < 5)
            {
                MessageBox.Show("Tên đăng nhập không hợp lệ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_MatKhau.Text.Length < 5)
            {
                MessageBox.Show("Mật khẩu không hợp lệ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //====================================================================
            else
            {
                // khai báo chuỗi câu lệnh SQL 
                string commet = $"select * from TAIKHOAN where TenDangNhap = '{txt_TenDangNhap.Text}'"; 

                SqlCommand cmd = new SqlCommand(commet, conn); // khởi tại biến với chuỗi câu lệnh

                SqlDataReader reader = cmd.ExecuteReader(); // khởi tạo biến đọc SQL

                if (reader.Read()) // khi biến đang được đọc
                {
                    if ( txt_TenDangNhap.Text == reader["TenDangNhap"].ToString() && txt_MatKhau.Text == reader["MatKhau"].ToString()) // nếu trùng nhau 
                    {
                        MessageBox.Show("Đăng nhập thành công !!!"); 
                    }
                    else // nếu khác nhau 
                    {
                        MessageBox.Show("Đăng nhập thất bại !!!");
                    }
                }
            }
        }

        private void lab_QuenMK_Click(object sender, EventArgs e)
        {
            // mở form đặt lại mật khẩu khi click vào button
            frm_QuenMK frm_QuenMK = new frm_QuenMK();
            frm_QuenMK.Show(); 
            this.Hide();
        }

        private void chk_HienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if( chk_HienThiMK.Checked )
            {
                txt_MatKhau.UseSystemPasswordChar = false; // hiển thị mật khẩu khi chk_HienThiMK.Checked = true 
            }
            else
            { 
                txt_MatKhau.UseSystemPasswordChar = true; // ẩn mật khẩu khi chk_HienThiMK.Checked = false 
            }
        }

        private void lab_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); // đóng form đăng nhập 
        }
    }
}
