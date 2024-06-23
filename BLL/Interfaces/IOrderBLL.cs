using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface IOrderBLL
    {
        List<Order> GetOrder();
        bool Create(Order model, ThongtinLienlac thongtin);
        List<Order> GetOderid(int Mataikhoan);
        List<Order> GetBooking(int OrderID);
        bool Delete(int OrderID);
        public bool Update(int OrderID);
  
    }
}
