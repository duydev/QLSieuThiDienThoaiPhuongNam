using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DAL;

namespace Business.BLL
{
    public class TaiKhoanBLL
    {
        // Tai khoan dang nhap
        private static TaiKhoan _tk = null;

        public static bool DangNhap(string TenDangNhap, string MatKhau)
        {
            TaiKhoanDAL tkDAL = new TaiKhoanDAL();

            var tk = tkDAL.Lay(TenDangNhap, MatKhau);
            // Neu khong tim thay
            if (tk == null)
            {
                return false;
            }

            _tk = tk;
            return true;
        }

        public static bool DaDangNhap()
        {
            return _tk != null;
        }

        public static TaiKhoan TaiKhoanDaDangNhap()
        {
            return _tk;
        }

        public static void DangXuat()
        {
            _tk = null;
        }

    }
}
