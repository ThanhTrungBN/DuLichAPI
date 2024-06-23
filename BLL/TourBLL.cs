using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;

namespace BLL
{
    public class TourBLL : ITourBLL
    {
        private ITourDAL _tour;

        public List<Tour> GetTouruudai()
        {
            return _tour.GetTouruudai();
        }
        public TourBLL(ITourDAL tour)
        {
            _tour = tour;
        }
        public List<Tour> GetTourdesc() 
        {
            return _tour.GetTourdesc();
        }
        public List <Tour> GetTourasc()
        {
            return _tour.GetTourasc();
        }
        public List<Tour> GetTour()
        {
            return _tour.GetTour();
        }
        public List<Tour> GetTourdangdienra()
        {
            return _tour.GetTourdangdienra();
        }
        public List<Tour> GetTourdanhmuc(string madanhmuctour)
        {
            return _tour.GetTourdanhmuc( madanhmuctour);
        }
        public Tour GetTourid(string Matour)
        {
            return _tour.GetTourid(Matour);
        }
        public bool Create(Tour model)
        {
            return _tour.Create(model);
        }
        public bool Update(Tour model) {
            return _tour.Update(model);
        }
        public bool Delete(string Matour)
        {
            return _tour.Delete(Matour);
        }
        public List<Tour> Search(int pageIndex, int pageSize, out long total, string ten_tour, string noi_khoi_hanh)
        {
            return _tour.Search(pageIndex, pageSize, out total, ten_tour, noi_khoi_hanh);
        }
        public List<Tour> SearchByprice(float Giamin,float Giamax)
        {
            return _tour.SearchByprice(Giamin,Giamax);
        }
    }
}