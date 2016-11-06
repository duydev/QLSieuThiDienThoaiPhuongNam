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
    public partial class frmDanhSachSP : DevExpress.XtraEditors.XtraForm
    {
        private SanPhamBLL spBLL = new SanPhamBLL();

        public frmDanhSachSP()
        {
            InitializeComponent();
        }

        private void btnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CapNhat();
        }

        public void CapNhat()
        {
            gridControl1.DataSource = spBLL.LayDanhSach();
        }

        private void frmDanhSachSP_Load(object sender, EventArgs e)
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

            int MaSP = (int) gridView1.GetRowCellValue(selected[0], "MaSP");
            var item = spBLL.Lay(MaSP);

            frmSP frm = new frmSP(item, this);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            frm.Focus();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selected = gridView1.GetSelectedRows();

            if (selected.Count() == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng để xóa.");
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn thực sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                int MaSP = (int)gridView1.GetRowCellValue(selected[0], "MaSP");
                spBLL.Xoa(MaSP);
                CapNhat();
                MessageBox.Show("Xóa thành công.", "Thông báo");
            }
        }
    }
}