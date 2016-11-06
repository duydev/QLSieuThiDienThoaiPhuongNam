using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAL
{
    class HangSanXuatDAL
    {
        private DBPhuongNamEntities db = new DBPhuongNamEntities();

        public List<HangSanXuat> LayDanhSach()
        {
            // AsNoTracking la de detach ra khoi dbcontext
            return db.HangSanXuat.AsNoTracking().ToList();
        }

        public HangSanXuat Lay(int MaHSX)
        {
            var item = db.HangSanXuat.AsNoTracking().SingleOrDefault(a => a.MaHSX == MaHSX);
            return item;
        }

        public void Them(HangSanXuat item)
        {
            db.HangSanXuat.Add(item);
            db.SaveChanges();
        }

        public void Sua(HangSanXuat item)
        {
            db.HangSanXuat.Attach(item);
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Xoa(int MaHSX)
        {
            var item = db.HangSanXuat.SingleOrDefault(a => a.MaHSX == MaHSX);
            if(item != null)
            {
                db.HangSanXuat.Remove(item);
                db.SaveChanges();
            }
        }

    }
}
