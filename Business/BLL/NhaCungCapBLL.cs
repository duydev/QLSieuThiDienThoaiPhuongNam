using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DAL;

namespace Business.BLL
{
    public class NhaCungCapBLL
    {
        private NhaCungCapDAL nccDAL = new NhaCungCapDAL();

        public List<NhaCungCap> LayDanhSach()
        {
            return nccDAL.LayDanhSach();
        }

        public NhaCungCap Lay(int MaNCC)
        {
            return nccDAL.Lay(MaNCC);
        }

        public void Them(NhaCungCap item)
        {
            nccDAL.Them(item);
        }

        public void Sua(NhaCungCap item)
        {
            nccDAL.Sua(item);
        }

        public void Xoa(int MaNCC)
        {
            nccDAL.Xoa(MaNCC);
        }
    }
}
