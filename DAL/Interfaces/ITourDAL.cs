using DataModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ITourDAL
    {
        List<Tour> GetTouruudai();
        List<Tour> GetTour();
        List<Tour> GetTourdesc();
        List<Tour> GetTourdanhmuc(string madanhmuctour);
        List<Tour> GetTourasc();
        List<Tour> GetTourdangdienra();
        Tour GetTourid(string Matour);

        bool Create(Tour model);

        bool Update(Tour model);

        bool Delete(string Matour);

        public List<Tour> Search(int pageIndex, int pageSize, out long total, string ten_tour, string noi_khoi_hanh);

        public List<Tour> SearchByprice(float Giamin, float Giamax);
    }
}
