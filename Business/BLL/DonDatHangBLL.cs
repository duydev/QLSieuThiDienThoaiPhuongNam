using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DAL;

namespace Business.BLL
{
    public class DonDatHangBLL
    {
        private DonDatHangDAL ddhDAL = new DonDatHangDAL();

        public List<DonDatHang> LayDanhSach()
        {
            return ddhDAL.LayDanhSach();
        }

        public DonDatHang Lay(int MaDDH)
        {
            return ddhDAL.Lay(MaDDH);
        }

        public void Them(DonDatHang item)
        {
            ddhDAL.Them(item);
        }

        public void Sua(DonDatHang item)
        {
            ddhDAL.Sua(item);
        }

        public void Xoa(int MaDDH)
        {
            ddhDAL.Xoa(MaDDH);
        }
    }
}
