using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DAL;

namespace Business.BLL
{
    public class SanPhamBLL
    {
        private SanPhamDAL hsxDAL = new SanPhamDAL();

        public List<SanPham> LayDanhSach()
        {
            return hsxDAL.LayDanhSach();
        }

        public SanPham Lay(int MaSP)
        {
            return hsxDAL.Lay(MaSP);
        }

        public void Them(SanPham item)
        {
            hsxDAL.Them(item);
        }

        public void Sua(SanPham item)
        {
            hsxDAL.Sua(item);
        }

        public void Xoa(int MaSP)
        {
            hsxDAL.Xoa(MaSP);
        }
    }
}
