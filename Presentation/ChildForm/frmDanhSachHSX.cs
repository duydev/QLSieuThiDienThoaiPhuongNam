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
    public partial class frmDanhSachHSX : DevExpress.XtraEditors.XtraForm
    {
        private HangSanXuatBLL hsxBLL = new HangSanXuatBLL();

        public frmDanhSachHSX()
        {
            InitializeComponent();
        }

        private void btnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CapNhat();
        }

        public void CapNhat()
        {
            gridControl1.DataSource = hsxBLL.LayDanhSach();
        }

        private void frmDanhSachHSX_Load(object sender, EventArgs e)
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

            int MaHSX = (int) gridView1.GetRowCellValue(selected[0], "MaHSX");
            var item = hsxBLL.Lay(MaHSX);

            frmHSX frm = new frmHSX(item, this);
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
                int MaHSX = (int)gridView1.GetRowCellValue(selected[0], "MaHSX");
                hsxBLL.Xoa(MaHSX);
                CapNhat();
                MessageBox.Show("Xóa thành công.", "Thông báo");
            }
        }
    }
}