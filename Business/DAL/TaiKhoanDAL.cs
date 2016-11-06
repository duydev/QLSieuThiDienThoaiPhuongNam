using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace Business.DAL
{
    public class TaiKhoanDAL
    {
        private DBPhuongNamEntities db = new DBPhuongNamEntities();
        
        public TaiKhoan Lay(string TenDangNhap, string MatKhau)
        {
            return db.TaiKhoan.SingleOrDefault(a => a.TenDangNhap == TenDangNhap && a.MatKhau == MatKhau && a.TinhTrang == true);
        }


    }
}
