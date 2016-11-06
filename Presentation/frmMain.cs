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

            txtTenNhanVien.Caption = "Nhân viên: " + _nv.Ten;
            txtQuyen.Caption = "Vai trò: " + _tk.PhanQuyen.Ten;
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaiKhoanBLL.DangXuat();
            this.Close();
            new Thread( () => new frmLogin().ShowDialog() ).Start();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnTaiKhoanCuaToi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTaiKhoanCuaToi frm = new frmTaiKhoanCuaToi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnDanhSachLSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachLSP frm = new frmDanhSachLSP();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
