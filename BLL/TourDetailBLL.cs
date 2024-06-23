using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TourDetailBLL : ITourDetailBLL
    {
        private ITourDetailDAL _tourdetail;

      
        public TourDetailBLL(ITourDetailDAL tourdetail)
        {
            _tourdetail = tourdetail;
        }
        public bool Create(TourDetail model)
        {
            return _tourdetail.Create(model);
           
        }
        public List<TourDetail> GetIDnull()
        {
            return _tourdetail.GetIDnull();
        }
        public List<TourDetail> GetChitietAll()
        {
            return _tourdetail.GetChitietAll();
        }
        public bool Delete(int Machitiettour)
        {
            return _tourdetail.Delete(Machitiettour);
        }

        public TourDetail GetChitietTour(string Matour)
        {
            return _tourdetail.GetChitietTour(Matour);
        }
        public TourDetail GetChitietTourdetail(int Machitiettour)
        {
            return _tourdetail.GetChitietTourdetail(Machitiettour);
        }
        public bool Update(TourDetail model)
        {
            return _tourdetail.Update(model);   
        }
    }
}
