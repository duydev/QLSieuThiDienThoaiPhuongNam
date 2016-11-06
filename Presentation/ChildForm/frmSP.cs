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
using Business.DAL;
using DevExpress.XtraEditors.Controls;

namespace Presentation
{
    public partial class frmSP : DevExpress.XtraEditors.XtraForm
    {
        private SanPham item = null;
        private Form from = null;

        private SanPhamBLL spBLL = new SanPhamBLL();

        public frmSP()
        {
            InitializeComponent();
            tabbedControlGroup1.SelectedTabPageIndex = 0;
            tabbedControlGroup1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
        }

        public frmSP(SanPham item, Form from)
        {
            this.item = item;
            this.from = from;
            InitializeComponent();
        }

        private void frmSP_Load(object sender, EventArgs e)
        {
            CapNhat();

            if (item == null)
            {
                txtMaSP.Enabled = false;
                this.Text = "Thêm sản phẩm";
                return;
            }

            this.Text = "Sửa sản phẩm";

            txtTen.Text = item.Ten;
            leLSP.EditValue = item.MaLSP;
            leNCC.EditValue = item.MaNCC;
            leHSX.EditValue = item.MaHSX;
            txtDonGia.Value = item.DonGia;
            txtThoiGianBaoHanh.Value = item.ThoiGianBaoHanh;
            txtXuatXu.Text = item.XuatXu;

            if (item.MaLSP == 1)
            {
                txtCao.Value = item.CT_SanPham.Cao;
                txtDai.Value = item.CT_SanPham.Dai;
                txtRong.Value = item.CT_SanPham.Rong;
                txtTrongLuong.Value = item.CT_SanPham.TrongLuong;
                txtHeDieuHanh.Text = item.CT_SanPham.HeDieuHanh;
                txtMoTa.Text = item.CT_SanPham.MoTa;
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Thêm mới
            if(item == null)
            {
                item = new SanPham
                {
                    Ten = txtTen.Text,
                    MaLSP = (int)leLSP.EditValue,
                    MaNCC = (int)leNCC.EditValue,
                    MaHSX = (int)leHSX.EditValue,
                    DonGia = txtDonGia.Value,
                    ThoiGianBaoHanh = (int) txtThoiGianBaoHanh.Value,
                    XuatXu = txtXuatXu.Text
                };

                if(item.MaLSP == 1)
                {
                    var _more = new CT_SanPham
                    {
                        Cao = (int)txtCao.Value,
                        Dai = (int)txtDai.Value,
                        Rong = (int)txtRong.Value,
                        TrongLuong = (int)txtTrongLuong.Value,
                        HeDieuHanh = txtHeDieuHanh.Text,
                        MoTa = txtMoTa.Text
                    };

                    item.CT_SanPham = _more;
                }

                spBLL.Them(item);
                this.Close();

                if(from != null)
                {
                    (from as frmDanhSachSP).CapNhat();
                    from.Focus();
                }

                MessageBox.Show("Thêm thành công.", "Thông báo");
                return;
            }

            item.Ten = txtTen.Text;
            item.MaLSP = (int)leLSP.EditValue;
            item.MaNCC = (int)leNCC.EditValue;
            item.MaHSX = (int)leHSX.EditValue;
            item.DonGia = txtDonGia.Value;
            item.ThoiGianBaoHanh = (int)txtThoiGianBaoHanh.Value;
            item.XuatXu = txtXuatXu.Text;

            spBLL.Sua(item);

            (from as frmDanhSachSP).CapNhat();
            from.Focus();

            MessageBox.Show("Sửa thành công.", "Thông báo");
        }


        private void CapNhat()
        {

            var lsp = (new LoaiSanPhamBLL() ).LayDanhSach();
            var ncc = (new NhaCungCapBLL() ).LayDanhSach();
            var hsx = (new HangSanXuatBLL() ).LayDanhSach();

            BindingSource _lsp = new BindingSource();
            _lsp.DataSource = lsp;

            BindingSource _ncc = new BindingSource();
            _ncc.DataSource = ncc;

            BindingSource _hsx = new BindingSource();
            _hsx.DataSource = hsx;

            leLSP.Properties.DataSource = lsp;
            leLSP.Properties.DisplayMember = "Ten";
            leLSP.Properties.ValueMember = "MaLSP";

            leNCC.Properties.DataSource = ncc;
            leNCC.Properties.DisplayMember = "Ten";
            leNCC.Properties.ValueMember = "MaNCC";

            leHSX.Properties.DataSource = hsx;
            leHSX.Properties.DisplayMember = "Ten";
            leHSX.Properties.ValueMember = "MaHSX";

        }

        private void leLSP_EditValueChanged(object sender, EventArgs e)
        {

            if ( (int)leLSP.EditValue == 1 )
            {
                tabbedControlGroup1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            }
            else
            {
                tabbedControlGroup1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            }
        }
    }
}