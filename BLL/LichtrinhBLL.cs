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
    public class LichtrinhBLL :ILichtrinhBLL
    {
        private ILichtrinhDAL _lichtrinh;


        public LichtrinhBLL(ILichtrinhDAL lichtrinh)
        {
            _lichtrinh = lichtrinh;
        }
        public bool Create(Lichtrinh model)
        {
            return _lichtrinh.Create(model);
        }

        public bool Delete(int Lichtrinhid)
        {
            return _lichtrinh.Delete(Lichtrinhid);
        }

        public List<Lichtrinh> GetLichtrinh(int Machitiettour)
        {
            return _lichtrinh.GetLichtrinh(Machitiettour);
        }
        public List<Lichtrinh> GetLichtrinhAll()
        {
            return _lichtrinh.GetLichtrinhAll();
        }
        public Lichtrinh GetChitietLichtrinhid(int Lichtrinhid)
        {
            return _lichtrinh.GetChitietLichtrinhid(Lichtrinhid);
        }
        public bool Update(Lichtrinh model)
        {
           return _lichtrinh.Update(model);
        }
    }
}
