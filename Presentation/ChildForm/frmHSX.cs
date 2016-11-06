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
    public partial class frmHSX : DevExpress.XtraEditors.XtraForm
    {
        private HangSanXuat item = null;
        private Form from = null;

        private HangSanXuatBLL lspBLL = new HangSanXuatBLL();

        public frmHSX()
        {
            InitializeComponent();
        }

        public frmHSX(HangSanXuat item, Form from)
        {
            this.item = item;
            this.from = from;
            InitializeComponent();
        }

        private void frmHSX_Load(object sender, EventArgs e)
        {
            if (item == null)
            {
                txtMaHSX.Enabled = false;
                this.Text = "Thêm hãng sản xuất";
                return;
            }
            this.Text = "Sửa hãng sản xuất";
            txtMaHSX.Text = item.MaHSX.ToString();
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
                item = new HangSanXuat
                {
                    Ten = txtTen.Text
                };

                lspBLL.Them(item);
                this.Close();

                if(from != null)
                {
                    (from as frmDanhSachHSX).CapNhat();
                    from.Focus();
                }

                MessageBox.Show("Thêm thành công.", "Thông báo");
                return;
            }

            item.Ten = txtTen.Text;
            lspBLL.Sua(item);

            (from as frmDanhSachHSX).CapNhat();
            from.Focus();

            MessageBox.Show("Sửa thành công.", "Thông báo");
        }
    }
}