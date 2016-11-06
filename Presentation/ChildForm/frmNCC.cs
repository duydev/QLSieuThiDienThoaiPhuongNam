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
    public partial class frmNCC : DevExpress.XtraEditors.XtraForm
    {
        private NhaCungCap item = null;
        private Form from = null;

        private NhaCungCapBLL nccBLL = new NhaCungCapBLL();

        public frmNCC()
        {
            InitializeComponent();
        }

        public frmNCC(NhaCungCap item, Form from)
        {
            this.item = item;
            this.from = from;
            InitializeComponent();
        }

        private void frmNCC_Load(object sender, EventArgs e)
        {
            if (item == null)
            {
                txtMaNCC.Enabled = false;
                this.Text = "Thêm nhà cung cấp";
                return;
            }
            this.Text = "Sửa nhà cung cấp";
            txtMaNCC.Text = item.MaNCC.ToString();
            txtTen.Text = item.Ten;
            txtDiaChi.Text = item.DiaChi;
            txtDienThoai.Text = item.DienThoai;
            txtFax.Text = item.Fax;
     
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
                item = new NhaCungCap
                {
                    Ten = txtTen.Text,
                    DiaChi = txtDiaChi.Text,
                    DienThoai = txtDienThoai.Text,
                    Fax = txtFax.Text
                };

                nccBLL.Them(item);
                this.Close();

                if(from != null)
                {
                    (from as frmDanhSachNCC).CapNhat();
                    from.Focus();
                }

                MessageBox.Show("Thêm thành công.", "Thông báo");
                return;
            }

            item.Ten = txtTen.Text;
            nccBLL.Sua(item);

            (from as frmDanhSachNCC).CapNhat();
            from.Focus();

            MessageBox.Show("Sửa thành công.", "Thông báo");
        }
    }
}