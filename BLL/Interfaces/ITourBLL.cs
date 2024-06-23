using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface ITourBLL
    {
        List<Tour> GetTouruudai();
        List<Tour> GetTour();
        List<Tour> GetTourdesc();
        List<Tour> GetTourdanhmuc(string madanhmuctour);
        List<Tour> GetTourdangdienra();
        List<Tour> GetTourasc();
        Tour GetTourid(string Matour);

        bool Create(Tour model);

        bool Update(Tour model);

        bool Delete(string Matour);

        public List<Tour> Search(int pageIndex, int pageSize, out long total, string ten_tour, string noi_khoi_hanh);

        public List<Tour> SearchByprice(float Giamin, float Giamax);
    }
}
