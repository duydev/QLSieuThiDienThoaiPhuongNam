using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Business.BLL;
using System.Threading;

namespace Presentation
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var TenDangNhap = txtTenDangNhap.Text;
            var MatKhau = txtMatKhau.Text;

            if( !TaiKhoanBLL.DangNhap(TenDangNhap, MatKhau) )
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng.\nVui lòng thử lại.", "Lỗi");
                return;
            }

            this.Close();
            new Thread(() => new frmMain().ShowDialog()).Start();
        }
    }
}