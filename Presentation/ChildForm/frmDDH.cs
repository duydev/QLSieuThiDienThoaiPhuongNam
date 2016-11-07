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
using Business.DAL;
using Business.BLL;

namespace Presentation
{
    public partial class frmDDH : DevExpress.XtraEditors.XtraForm
    {
        private DonDatHangBLL ddhBLL = new DonDatHangBLL();
        private NhaCungCapBLL nccBLL = new NhaCungCapBLL();
        private SanPhamBLL spBLL = new SanPhamBLL();
        private LoaiSanPhamBLL lspBLL = new LoaiSanPhamBLL();

        private DonDatHang item = null;

        public frmDDH()
        {
            InitializeComponent();

            //
            layoutControlGroup2.Expanded = false;
            layoutControlGroup4.Expanded = false;

            // 
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

        }

        private void frmDDH_Load(object sender, EventArgs e)
        {
            CapNhatDDH();

        }

        public void CapNhatDDH()
        {
            gridControl1.DataSource = ddhBLL.LayDanhSach();
        }

        private void btnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CapNhatDDH();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThemMoi();
        }

        public void ThemMoi()
        {
            item = new DonDatHang();

            Reset();

            layoutControlGroup2.Expanded = true;
            layoutControlGroup4.Expanded = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnHuySP.Enabled = false;
        }

        public void Reset()
        {
            
            txtMaDDH.ResetText();

            txtNCC.Properties.DataSource = nccBLL.LayDanhSach();
            txtNCC.Properties.DisplayMember = "Ten";
            txtNCC.Properties.ValueMember = "MaNCC";

            txtNhanVien.Text = TaiKhoanBLL.TaiKhoanDaDangNhap().NhanVien.Ten;
            dtpNgayThem.ResetText();

            gridControl2.DataSource = null;

        }

        public void ResetSP()
        {
            txtMaSP.ResetText();

            txtTenSP.Properties.DataSource = spBLL.LayDanhSach();
            txtTenSP.Properties.DisplayMember = "Ten";
            txtTenSP.Properties.ValueMember = "MaSP";

            txtLSP.Properties.DataSource = lspBLL.LayDanhSach();
            txtLSP.Properties.DisplayMember = "Ten";
            txtLSP.Properties.ValueMember = "MaLSP";

            txtSoLuong.ResetText();
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            layoutControlGroup2.Expanded = false;
            layoutControlGroup4.Expanded = false;

            Reset();

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if(btnThemSP.Text != "Lưu")
            {
                ResetSP();

                layoutControlGroup4.Expanded = true;

                btnHuySP.Enabled = true;

                btnThemSP.Text = "Lưu";

                btnSuaSP.Enabled = false;
                btnXoaSP.Enabled = false;

                return;
            }

           if( string.IsNullOrEmpty(txtMaSP.Text) )
           {
                MessageBox.Show("Vui lòng chọn một sản phẩm", "Thông báo");
                return;
           }

           int MaSP = int.Parse(txtMaSP.Text);
           var sp = spBLL.Lay(MaSP);
           if(sp == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại.", "Thông báo");
                return;
            }

            item.CT_DonDatHang.Add(new CT_DonDatHang {
                SanPham = sp,
                SoLuong = (int) txtSoLuong.Value
            });

            gridControl2.DataSource = item.CT_DonDatHang;

        }

        private void txtTenSP_EditValueChanged(object sender, EventArgs e)
        {
            txtMaSP.Text = (sender as LookUpEdit).EditValue.ToString();
        }
    }
}