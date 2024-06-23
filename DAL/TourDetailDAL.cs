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
    public class TourDetailDAL : ITourDetailDAL
    {
        private IDatabase _database;
        public TourDetailDAL(IDatabase database)
        {
            _database = database;
        }
        public bool Create(TourDetail model)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_InsertChiTietTourDuLich",
                "@Matour", model.Matour,
                "@Madiadiem", model.Madiadiem,
                "@Diemnhan", model.Diemnhan,
                "@Ngaykhoihanh", model.Ngaykhoihanh,
                "@Ngayketthuc", model.Ngayketthuc,
                "@Thongtindichuyen", model.Thongtindichuyen,
                "@Thongtinhuongdanvien", model.Thongtinhuongdanvien,
                "@Thongtintaptrung", model.Thongtintaptrung
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

        public bool Delete(int Machitiettour)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "XoaChiTietTour",
                    "@Machitiettour", Machitiettour);
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

        public TourDetail GetChitietTour(string Matour)
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_GetChiTietTourDuLich",
                     "@Matour", Matour);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TourDetail>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TourDetail GetChitietTourdetail(int Machitiettour)
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "GetChiTietTourDuLich",
                     "@Machitiettour", Machitiettour);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TourDetail>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TourDetail> GetChitietAll()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "getChitietTour");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TourDetail>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TourDetail> GetIDnull() {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "GetIDnull");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TourDetail>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(TourDetail model)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateChiTietTourDuLich",
                "@Machitiettour",model.Machitiettour,
                "@Matour", model.Matour,
                "@Madiadiem", model.Madiadiem,
                "@Diemnhan", model.Diemnhan,
                "@Ngaykhoihanh", model.Ngaykhoihanh,
                "@Ngayketthuc", model.Ngayketthuc,
                "@Thongtindichuyen", model.Thongtindichuyen,
                "@Thongtinhuongdanvien", model.Thongtinhuongdanvien,
                "@Thongtintaptrung", model.Thongtintaptrung
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
    }
}
