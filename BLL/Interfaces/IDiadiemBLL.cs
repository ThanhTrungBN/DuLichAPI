using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface IDiadiemBLL
    {
        List<Diadiem> Getdiadiem();
        List<Diadiem> GetdiadiemMT();
        List<Diadiem> GetdiadiemMDNB();
        List<Diadiem> GetdiadiemMTNB();
        List<Diadiem> GetDD();
    }
}
