using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DAL;

namespace Business.BLL
{
    public class LoaiSanPhamBLL
    {
        private LoaiSanPhamDAL lspDAL = new LoaiSanPhamDAL();

        public List<LoaiSanPham> LayDanhSach()
        {
            return lspDAL.LayDanhSach();
        }

        public LoaiSanPham Lay(int MaLSP)
        {
            return lspDAL.Lay(MaLSP);
        }

        public void Them(LoaiSanPham item)
        {
            lspDAL.Them(item);
        }

        public void Sua(LoaiSanPham item)
        {
            lspDAL.Sua(item);
        }

        public void Xoa(int MaLSP)
        {
            lspDAL.Xoa(MaLSP);
        }
    }
}
