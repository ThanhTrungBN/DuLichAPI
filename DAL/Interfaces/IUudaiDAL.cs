using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IUudaiDAL
    {
        List<UuDai> GetUudai();
        public UuDai Giasale(string Matour);
    }
}
