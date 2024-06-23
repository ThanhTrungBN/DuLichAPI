using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface ILichtrinhBLL
    {

        List<Lichtrinh> GetLichtrinh(int Machitiettour);

        bool Create(Lichtrinh model);

        bool Update(Lichtrinh model);
        Lichtrinh GetChitietLichtrinhid(int Lichtrinhid);
        bool Delete(int Lichtrinhid);
        List<Lichtrinh> GetLichtrinhAll();
    }
}
