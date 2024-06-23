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
    public class ThongkeDAL : IThongkeDAL
    {
        private IDatabase _database;
        public ThongkeDAL(IDatabase database)
        {
            _database = database;
        }

        public int CountOrder()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "countorder");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                int soluongorder = 0;
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    soluongorder = Convert.ToInt32(dt.Rows[0][0]);
                }
                return soluongorder;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CountTour()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "CountTours");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                int soluongtour = 0;
                if(dt != null && dt.Rows.Count >0 && dt.Rows[0][0]!= DBNull.Value)
                {
                    soluongtour = Convert.ToInt32(dt.Rows[0][0]);
                }
                return soluongtour;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int User()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "Countacc");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                int soluongacc = 0;
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    soluongacc = Convert.ToInt32(dt.Rows[0][0]);
                }
                return soluongacc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Thongke> GetDoanhThuTheoThang()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_GetDoanhThuTheoThang");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Thongke>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
