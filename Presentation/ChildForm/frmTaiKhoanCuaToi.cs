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
    public partial class frmTaiKhoanCuaToi : DevExpress.XtraEditors.XtraForm
    {
        public frmTaiKhoanCuaToi()
        {
            InitializeComponent();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Cập nhật thành công.", "Thông báo");
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}