using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAL
{
    class DonDatHangDAL
    {
        private DBPhuongNamEntities db = new DBPhuongNamEntities();

        public List<DonDatHang> LayDanhSach()
        {
            // AsNoTracking la de detach ra khoi dbcontext
            return db.DonDatHang.AsNoTracking().ToList();
        }

        public DonDatHang Lay(int MaDDH)
        {
            var item = db.DonDatHang.AsNoTracking().SingleOrDefault(a => a.MaDDH == MaDDH);
            return item;
        }

        public void Them(DonDatHang item)
        {
            db.DonDatHang.Add(item);
            db.SaveChanges();
        }

        public void Sua(DonDatHang item)
        {
            db.DonDatHang.Attach(item);
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Xoa(int MaDDH)
        {
            var item = db.DonDatHang.SingleOrDefault(a => a.MaDDH == MaDDH);
            if(item != null)
            {
                db.DonDatHang.Remove(item);
                db.SaveChanges();
            }
        }

    }
}
