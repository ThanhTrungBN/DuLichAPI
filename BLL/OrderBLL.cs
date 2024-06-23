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
    public class OrderBLL : IOrderBLL
    {
        public OrderBLL(IOrderDAL order)
        {
            _order = order;
        }
        private IOrderDAL _order;
        public bool Create(Order model,ThongtinLienlac thongtin)
        {
            return _order.Create(model,thongtin);
        }

        public List<Order> GetOrder()
        {
            return _order.GetOder();
        }
        public bool Delete(int OrderID)
        {
            return _order.Delete(OrderID);
        }
        public bool Update(int OrderID)
        {
            return _order.Update(OrderID);
        }
        public List<Order> GetOderid(int Mataikhoan)
        {
            return _order.GetOderid(Mataikhoan);
        }
        public List<Order> GetBooking(int OrderID)
        {
            return _order.GetBooking(OrderID);
        }
       
    }
}
