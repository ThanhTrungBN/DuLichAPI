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
    public class LichtrinhDAL : ILichtrinhDAL
    {
        private IDatabase _database;
        public LichtrinhDAL(IDatabase database)
        {
            _database = database;
        }
        public bool Create(Lichtrinh model)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "InsertLichTrinh",
                "@Machitiettour", model.Machitiettour,
                "@Ngay", model.Ngay,
                "@Tieude", model.Tieude,
                "@Mota", model.Mota,
                "@Nghingoi", model.Nghingoi
                );
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

        public bool Delete(int Lichtrinhid)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "DeleteLichTrinh",
                    "@Lichtrinhid", Lichtrinhid);
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

        public List<Lichtrinh> GetLichtrinh(int Machitiettour)
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "SelectLichTrinh",
                     "@Machitiettour", Machitiettour);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Lichtrinh>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Lichtrinh> GetLichtrinhAll()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "getLichtrinh");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Lichtrinh>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Lichtrinh model)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "UpdateLichTrinh",
                    "@Lichtrinhid",model.Lichtrinhid,
                   "@Machitiettour", model.Machitiettour,
                   "@Ngay", model.Ngay,
                   "@Tieude", model.Tieude,
                   "@Mota", model.Mota,
                   "@Nghingoi", model.Nghingoi
                   );
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
        public Lichtrinh GetChitietLichtrinhid(int Lichtrinhid)
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "GetChiTietLichtrinh",
                     "@Lichtrinhid", Lichtrinhid);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Lichtrinh>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
