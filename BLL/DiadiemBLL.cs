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
    public class DiadiemBLL : IDiadiemBLL
    {
        private IDiadiemDAL _diadiem;
        public DiadiemBLL(IDiadiemDAL diadiem)
        {
            _diadiem = diadiem;
        }
        public List<Diadiem> Getdiadiem()
        {
            return _diadiem.Getdiadiem();
        }
        public List<Diadiem> GetdiadiemMT()
        {
            return _diadiem.GetdiadiemMT();
        }
        public List<Diadiem> GetdiadiemMDNB()
        {
            return _diadiem.GetdiadiemMDNB();
        }
        public List<Diadiem> GetdiadiemMTNB()
        {
            return _diadiem.GetdiadiemMTNB();
        }
        public List<Diadiem> GetDD()
        {
            return _diadiem.GetDD();
        }
    }
}
