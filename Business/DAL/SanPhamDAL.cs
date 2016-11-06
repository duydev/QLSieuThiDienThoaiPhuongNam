using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAL
{
    class SanPhamDAL
    {
        private DBPhuongNamEntities db = new DBPhuongNamEntities();

        public List<SanPham> LayDanhSach()
        {
            // AsNoTracking la de detach ra khoi dbcontext
            return db.SanPham.AsNoTracking().ToList();
        }

        public SanPham Lay(int MaSP)
        {
            var item = db.SanPham.AsNoTracking().SingleOrDefault(a => a.MaSP == MaSP);
            return item;
        }

        public void Them(SanPham item)
        {
            db.SanPham.Add(item);
            db.SaveChanges();
        }

        public void Sua(SanPham item)
        {
            db.SanPham.Attach(item);
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Xoa(int MaSP)
        {
            var item = db.SanPham.SingleOrDefault(a => a.MaSP == MaSP);
            if(item != null)
            {
                db.SanPham.Remove(item);
                db.SaveChanges();
            }
        }

    }
}
