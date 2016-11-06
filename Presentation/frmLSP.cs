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

        public frmLSP()
        {
            InitializeComponent();
        }

        public frmLSP(LoaiSanPham item)
        {
            this.item = item;
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
            
        }
    }
}