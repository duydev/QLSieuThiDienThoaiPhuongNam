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
        private DateTime _dn = DateTime.MinValue;

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
            _dn = DateTime.Now;

            txtTenNhanVien.Caption = "Nhân viên: " + _nv.Ten;
            txtQuyen.Caption = "Vai trò: " + _tk.PhanQuyen.Ten;

            // Mo san form
            btnDanhSachDDH.PerformClick();

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

        private void btnThemLSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLSP frm = new frmLSP();
            frm.MdiParent = this;
            frm.Show();
            frm.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan diff = DateTime.Now - _dn;
            txtThoiGianSuDung.Caption = string.Format("Thời gian sử dụng: {0} giờ {1} phút {2} giây.", diff.Hours, diff.Minutes, diff.Seconds);
        }

        private void btnDanhSachNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachNCC frm = new frmDanhSachNCC();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnThemNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNCC frm = new frmNCC();
            frm.MdiParent = this;
            frm.Show();
            frm.Focus();
        }

        private void btnDanhSachHSX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachHSX frm = new frmDanhSachHSX();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnHSX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHSX frm = new frmHSX();
            frm.MdiParent = this;
            frm.Show();
            frm.Focus();
        }

        private void btnDanhSachSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachSP frm = new frmDanhSachSP();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnThemSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSP frm = new frmSP();
            frm.MdiParent = this;
            frm.Show();
            frm.Focus();
        }

        private void btnDanhSachDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDDH frm = new frmDDH();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
