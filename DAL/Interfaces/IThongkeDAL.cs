using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IThongkeDAL
    {

        public int CountTour();

        public int User();

        public int CountOrder();
        List<Thongke> GetDoanhThuTheoThang();
    }
}
