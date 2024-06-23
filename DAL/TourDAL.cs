using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DAL
{
    public class TourDAL: ITourDAL
    {
        private IDatabase _database;
        public TourDAL(IDatabase database)
        {
            _database = database;
        }
        public List<Tour> GetTouruudai()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "GetToursInDiscount");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Tour>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tour> GetTourdesc()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_select_desc");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Tour>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List <Tour> GetTourasc() {

            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_select_asc");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Tour>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tour> GetTour()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_select_tour");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Tour>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tour> GetTourdangdienra()
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "Tourdangdienra");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Tour>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tour> GetTourdanhmuc(string madanhmuctour)
        {

            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_SearchToursByDanhMuc","@Madanhmuctour", madanhmuctour);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Tour>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Tour GetTourid(string Matour)
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_tour_get_by_id",
                     "@Matour", Matour);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Tour>().FirstOrDefault();
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
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_tour_create",
                "@Matour", model.Matour,
                "@DanhmucID", model.DanhmucID,
                "@Madanhmuctour", model.Madanhmuctour,
                "@Tieudetour", model.Tieudetour,
                "@Noikhoihanh", model.Noikhoihanh,
                "@Gia",model.Gia,
                "@Sochoconnhan",model.Sochoconnhan,
                "@Songaydi",model.Songaydi,
                "@Ngaythangnam",model.Ngaythangnam,
                "@Anhdaidien",model.Anhdaidien);
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
        public bool Update(Tour model)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_tour_update",
                "@Matour", model.Matour,
                "@DanhmucID", model.DanhmucID,
                "@Madanhmuctour", model.Madanhmuctour,
                "@Tieudetour", model.Tieudetour,
                "@Noikhoihanh", model.Noikhoihanh,
                "@Gia", model.Gia,
                "@Sochoconnhan", model.Sochoconnhan,
                "@Songaydi", model.Songaydi,
                "@Ngaythangnam", model.Ngaythangnam,
                "@Anhdaidien",model.Anhdaidien);
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
        public bool Delete(string Matour)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_tour_delete",
                    "@Matour", Matour);
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
        public List<Tour> Search(int pageIndex, int pageSize, out long total, string ten_tour, string noi_khoi_hanh)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_tour_search_pagination",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_tour", ten_tour,
                    "@noi_khoi_hanh", noi_khoi_hanh);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<Tour>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tour> SearchByprice(float  Giamin, float Giamax)
        {

            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "SearchTourByPrice", "@MinPrice", Giamin, "@MaxPrice",Giamax);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Tour>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}