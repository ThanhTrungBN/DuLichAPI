using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IOrderDAL
    {
        List<Order> GetOder();
        bool Create(Order model,ThongtinLienlac thongtin);
        List<Order> GetOderid( int Mataikhoan );
        List<Order> GetBooking(int OrderID);
        bool Delete(int OrderID);
        public bool Update(int OrderID);
   

    }
}
