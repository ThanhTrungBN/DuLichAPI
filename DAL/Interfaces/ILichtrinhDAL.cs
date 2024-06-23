using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ILichtrinhDAL
    {
        List<Lichtrinh> GetLichtrinh(int Machitiettour);
        List<Lichtrinh> GetLichtrinhAll();
        bool Create(Lichtrinh model);
        Lichtrinh GetChitietLichtrinhid(int Lichtrinhid);
        bool Update(Lichtrinh model);

        bool Delete(int Lichtrinhid);
    }
}
