using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAL
{
    class NhaCungCapDAL
    {
        private DBPhuongNamEntities db = new DBPhuongNamEntities();

        public List<NhaCungCap> LayDanhSach()
        {
            // AsNoTracking la de detach ra khoi dbcontext
            return db.NhaCungCap.AsNoTracking().ToList();
        }

        public NhaCungCap Lay(int MaNCC)
        {
            var item = db.NhaCungCap.AsNoTracking().SingleOrDefault(a => a.MaNCC == MaNCC);
            return item;
        }

        public void Them(NhaCungCap item)
        {
            db.NhaCungCap.Add(item);
            db.SaveChanges();
        }

        public void Sua(NhaCungCap item)
        {
            db.NhaCungCap.Attach(item);
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Xoa(int MaNCC)
        {
            var item = db.NhaCungCap.SingleOrDefault(a => a.MaNCC == MaNCC);
            if(item != null)
            {
                db.NhaCungCap.Remove(item);
                db.SaveChanges();
            }
        }

    }
}
