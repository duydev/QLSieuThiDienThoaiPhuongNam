using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAL
{
    class LoaiSanPhamDAL
    {
        private DBPhuongNamEntities db = new DBPhuongNamEntities();

        public List<LoaiSanPham> LayDanhSach()
        {
            return db.LoaiSanPham.ToList();
        }

        public LoaiSanPham Lay(int MaLSP)
        {
            return db.LoaiSanPham.SingleOrDefault(a => a.MaLSP == MaLSP);
        }

    }
}
