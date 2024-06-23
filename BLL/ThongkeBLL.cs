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
    public class ThongkeBLL : IThongkeBLL
    {
        private IThongkeDAL _thongke;


        public ThongkeBLL(IThongkeDAL thongke)
        {
            _thongke = thongke;
        }

        public int CountOrder()
        {
            return _thongke.CountOrder();
        }

        public int CountTour()
        {
           return _thongke.CountTour();   
        }

        public int User()
        {
            return _thongke.User();
        }
         public List<Thongke> GetDoanhThuTheoThang()
        {
            return _thongke.GetDoanhThuTheoThang();
        }
    }
}
