using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface  ITourDetailBLL
    {
        TourDetail GetChitietTour(string Matour);

        bool Create(TourDetail model);

        bool Update(TourDetail model);

        bool Delete(int Machitiettour);
        List<TourDetail> GetIDnull();
        List<TourDetail> GetChitietAll();

        TourDetail GetChitietTourdetail(int Machitiettour);
    }
}
