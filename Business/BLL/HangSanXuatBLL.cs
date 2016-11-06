using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DAL;

namespace Business.BLL
{
    public class HangSanXuatBLL
    {
        private HangSanXuatDAL hsxDAL = new HangSanXuatDAL();

        public List<HangSanXuat> LayDanhSach()
        {
            return hsxDAL.LayDanhSach();
        }

        public HangSanXuat Lay(int MaHSX)
        {
            return hsxDAL.Lay(MaHSX);
        }

        public void Them(HangSanXuat item)
        {
            hsxDAL.Them(item);
        }

        public void Sua(HangSanXuat item)
        {
            hsxDAL.Sua(item);
        }

        public void Xoa(int MaHSX)
        {
            hsxDAL.Xoa(MaHSX);
        }
    }
}
