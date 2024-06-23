using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDAL : IOrderDAL
    {
        private IDatabase _database;
        public OrderDAL(IDatabase database)
        {
            _database = database;
        }
        public bool Create(Order model,ThongtinLienlac thongtin)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_order_create",
                "@Matour", model.Matour,
                "@Hanhkhach", model.Hanhkhach,
                "@Thanhtien", model.Thanhtien,
                 "@Mataikhoan", model.Mataikhoan,
                 "@Ngaydangki",model.Ngaydangki,
                 "@Tinhtrang",model.Tinhtrang,
                 "@Hovaten",thongtin.Hovaten,
                 "@Email",thongtin.Email,
                 "@Diachi",thongtin.Diachi,
                 "@Sdt",thongtin.Sdt);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(int OrderID)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "DeleteOrderDetails",
                    "@OrderID", OrderID);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Order> GetOder()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "GetOrderTour");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Order>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Order> GetOderid(int Mataikhoan)
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "GetOrderTourByMataikhoan",
                     "@Mataikhoan", Mataikhoan);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Order>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Order> GetBooking(int OrderID)
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "Booking",
                     "@OrderID", OrderID);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Order>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update (int OrderID)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteSProcedureReturnDataTable(out msgError, "UpdateTinhTrangOrderTour",
                     "@OrderID", OrderID);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  

    }
}
