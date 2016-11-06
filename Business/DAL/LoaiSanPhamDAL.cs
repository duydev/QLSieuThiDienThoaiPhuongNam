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
            // AsNoTracking la de detach ra khoi dbcontext
            return db.LoaiSanPham.AsNoTracking().ToList();
        }

        public LoaiSanPham Lay(int MaLSP)
        {
            var item = db.LoaiSanPham.AsNoTracking().SingleOrDefault(a => a.MaLSP == MaLSP);
            return item;
        }

        public void Them(LoaiSanPham item)
        {
            db.LoaiSanPham.Add(item);
            db.SaveChanges();
        }

        public void Sua(LoaiSanPham item)
        {
            db.LoaiSanPham.Attach(item);
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Xoa(int MaLSP)
        {
            var item = db.LoaiSanPham.SingleOrDefault(a => a.MaLSP == MaLSP);
            if(item != null)
            {
                db.LoaiSanPham.Remove(item);
                db.SaveChanges();
            }
        }

    }
}
