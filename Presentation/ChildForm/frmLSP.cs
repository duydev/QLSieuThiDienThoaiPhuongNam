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

namespace Presentation
{
    public partial class frmLSP : DevExpress.XtraEditors.XtraForm
    {
        private LoaiSanPham item = null;
        private Form from = null;

        private LoaiSanPhamBLL lspBLL = new LoaiSanPhamBLL();

        public frmLSP()
        {
            InitializeComponent();
        }

        public frmLSP(LoaiSanPham item, Form from)
        {
            this.item = item;
            this.from = from;
            InitializeComponent();
        }

        private void frmLSP_Load(object sender, EventArgs e)
        {
            if (item == null)
            {
                txtMaLSP.Enabled = false;
                this.Text = "Thêm loại sản phẩm";
                return;
            }
            this.Text = "Sửa loại sản phẩm";
            txtMaLSP.Text = item.MaLSP.ToString();
            txtTen.Text = item.Ten;
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
                item = new LoaiSanPham
                {
                    Ten = txtTen.Text
                };

                lspBLL.Them(item);
                this.Close();

                if(from != null)
                {
                    (from as frmDanhSachLSP).CapNhat();
                    from.Focus();
                }

                MessageBox.Show("Thêm thành công.", "Thông báo");
                return;
            }

            item.Ten = txtTen.Text;
            lspBLL.Sua(item);

            (from as frmDanhSachLSP).CapNhat();
            from.Focus();

            MessageBox.Show("Sửa thành công.", "Thông báo");
        }
    }
}