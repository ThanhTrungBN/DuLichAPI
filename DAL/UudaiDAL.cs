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
    public class UudaiDAL : IUudaiDAL
    {
        private IDatabase _database;
        public UudaiDAL(IDatabase database)
        {
            _database = database;
        }
        public List<UuDai> GetUudai()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_select_uudai");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UuDai>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UuDai Giasale(string Matour)
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "Giasale",
                     "@Matour", Matour);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UuDai>().FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
