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
    }
}
