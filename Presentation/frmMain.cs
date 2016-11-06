using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.BLL;
using Business.DAL;
using System.Threading;

namespace Presentation
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private TaiKhoan _tk = null;
        private NhanVien _nv = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Kiem tra dang nhap
            if( !TaiKhoanBLL.DaDangNhap() )
            {
                this.Close();
                new Thread(() => new frmLogin().ShowDialog()).Start();
                return;
            }

            _tk = TaiKhoanBLL.TaiKhoanDaDangNhap();
            _nv = _tk.NhanVien;

            txtTenNhanVien.Caption = _nv.Ten;
        }
    }
}
