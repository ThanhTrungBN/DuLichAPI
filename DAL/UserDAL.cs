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
    public class UserDAL:IUserDAL
    {
        private IDatabase _dbHelper;
        public UserDAL(IDatabase dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public User Login(string taikhoan, string matkhau)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_login",
                     "@taikhoan", taikhoan,
                     "@matkhau", matkhau
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<User>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(Tour model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_tour_create",
                "@Matour", model.Matour,
                "@DanhmucID", model.DanhmucID,
                "@Madanhmuctour", model.Madanhmuctour,
                "@Tieudetour", model.Tieudetour,
                "@Noikhoihanh", model.Noikhoihanh,
                "@Gia", model.Gia,
                "@Sochoconnhan", model.Sochoconnhan,
                "@Songaydi", model.Songaydi,
                "@Ngaythangnam", model.Ngaythangnam,
                "@Anhdaidien", model.Anhdaidien);
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
        public bool Update(int Mataikhoan,string per)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "UpdatePer",
                "@Mataikhoan", Mataikhoan,
                "@NewPer", per);
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
        public bool Delete(int Manguoidung)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "DeleteUserAndAccount",
                    "@Manguoidung", Manguoidung);
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
        public List<User> GetNguoidung()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetNguoidung");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<User>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
