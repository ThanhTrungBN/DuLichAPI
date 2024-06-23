using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NguoidungBLL : INguoidungBLL
    {
        private INguoidungDAL _nguoidung;

       
        public NguoidungBLL(INguoidungDAL nguoidung)
        {
            _nguoidung = nguoidung;
        }

        public Nguoidung GetNguoidung(int Manguoidung)
        {
            return _nguoidung.GetNguoidung(Manguoidung);
        }
    }
}
