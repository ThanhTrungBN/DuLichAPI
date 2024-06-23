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
    public class DiaDiemDAL : IDiadiemDAL
    {
        private IDatabase _database;
        public DiaDiemDAL(IDatabase database)
        {
            _database = database;
        }
        public List<Diadiem> GetDD()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_select_diadiem");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Diadiem>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Diadiem> Getdiadiem()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_diadiemmb");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Diadiem>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Diadiem> GetdiadiemMDNB()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_diadiemmdnb");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Diadiem>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Diadiem> GetdiadiemMT()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_diadiemmt");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Diadiem>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Diadiem> GetdiadiemMTNB()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_diadiemmtnb");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Diadiem>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
