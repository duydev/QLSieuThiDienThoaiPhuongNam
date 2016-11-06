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
    public partial class frmDanhSachLSP : DevExpress.XtraEditors.XtraForm
    {
        private LoaiSanPhamBLL lspBLL = new LoaiSanPhamBLL();

        public frmDanhSachLSP()
        {
            InitializeComponent();
        }

        private void btnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CapNhat();
        }

        private void CapNhat()
        {
            gridControl1.DataSource = lspBLL.LayDanhSach();
        }

        private void frmDanhSachLSP_Load(object sender, EventArgs e)
        {
            CapNhat();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selected = gridView1.GetSelectedRows();

            if (selected.Count() == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng để sửa.");
                return;
            }

            int MaLSP = (int) gridView1.GetRowCellValue(selected[0], "MaLSP");
            var item = lspBLL.Lay(MaLSP);

            frmLSP frm = new frmLSP(item);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            frm.Focus();
        }
    }
}