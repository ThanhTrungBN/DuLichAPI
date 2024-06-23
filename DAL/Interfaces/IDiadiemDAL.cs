using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IDiadiemDAL
    {
        List<Diadiem> Getdiadiem();

        List<Diadiem> GetdiadiemMT();
        List<Diadiem> GetdiadiemMDNB();
        List<Diadiem> GetdiadiemMTNB();

        List<Diadiem> GetDD();
    }
}
