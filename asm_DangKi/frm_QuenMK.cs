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
    public partial class frm_QuenMK : Form
    {
        public frm_QuenMK()
        {
            InitializeComponent();
        }
        string str = "Data Source=.;Initial Catalog=WINFORM;Integrated Security=True"; // khai báo chuỗi liên kết 
        SqlConnection conn = null; // khai báo biến liên kết 
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            // mở form đăng nhập khi click vào button 
            frm_DangNhap frm_DangNhap = new frm_DangNhap();
            frm_DangNhap.Show(); 
            this.Hide();
        }

        private void btn_DangNhapLai_Click(object sender, EventArgs e)
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
            try
            {
                // kiểm tra giá trị đầu vào 
                if (txt_MatKhauMoi.Text.Length < 5)
                {
                    MessageBox.Show(" Mật khẩu phải >5 kí tự ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txt_XacNhanMK.Text != txt_MatKhauMoi.Text)
                {
                    MessageBox.Show(" Xác nhận lại mật khẩu !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //====================================================
                else
                {
                    /* string commet = @"select * from TAIKHOAN";

                     SqlCommand cmd = new SqlCommand(commet, conn);
                     SqlDataReader reader = cmd.ExecuteReader();
                     if (reader.Read())
                     {
                         if (txt_SDT.Text != reader["SoDienThoai"].ToString())
                         {
                             MessageBox.Show(" Số điện thoại không tồn tại !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         }
                         else if (txt_TenDangNhap.Text != reader["TenDangNhap"].ToString())
                         {
                             MessageBox.Show(" Tên đăng nhập không tồn tại !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         }
                     }*/

                    string query = $"update TAIKHOAN set MatKhau = '{txt_MatKhauMoi.Text}' where TenDangNhap = '{txt_TenDangNhap.Text}'"; // khai báo chuỗi câu lệnh SQL

                    SqlCommand command = new SqlCommand(query, conn); // khởi tạo biến với chuỗi câu lệnh và biến liên kết 
                    
                    // thực hiện câu lệnh SQL 
                    command.ExecuteNonQuery();
                    conn.Close(); // đóng liên kết 

                    MessageBox.Show("Thay đổi mật khẩu thành công !!(đăng nhập lại tại form đăng nhập)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    // mở form đăng nhập khi thay đổi mật khẩu thành công 
                    frm_DangNhap frm_DangNhap = new frm_DangNhap();
                    frm_DangNhap.Show();
                    this.Hide();
                }

            }
            catch (FormatException)
            {
                MessageBox.Show(" Số điện thoại không hợp lệ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void chk_HienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_HienThiMK.Checked)
            {
                txt_MatKhauMoi.UseSystemPasswordChar = false; // hiện thị mật khẩu khi chk_HienThiMK.Checked = true 
                txt_XacNhanMK.UseSystemPasswordChar = false; 
            }
            else
            {
                txt_MatKhauMoi.UseSystemPasswordChar = true; // ẩn mật khẩu khi chk_HienThiMK.Checked = false 
                txt_XacNhanMK.UseSystemPasswordChar = true;
            }
        }

        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            // mở form đăng kí khi click vào button
            frm_DangKi frm_DangKi = new frm_DangKi();   
            frm_DangKi.Show();
            this.Hide();
        }

        private void lab_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); // đóng form quên mật khẩu 
        }
    }
}
