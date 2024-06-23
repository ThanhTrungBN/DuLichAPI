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
    public class NguoidungDAL : INguoidungDAL
    {
        private IDatabase _database;
        public NguoidungDAL(IDatabase dbHelper)
        {
            _database = dbHelper;
        }

        public Nguoidung GetNguoidung(int Manguoidung)
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "GetUserInfoByUserId",
                     "@Manguoidung", Manguoidung);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Nguoidung>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
