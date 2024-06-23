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
    public class UudaiBLL : IUudaiBLL
    {
        private IUudaiDAL _uudai;
        public UudaiBLL(IUudaiDAL uudai)
        {
            _uudai = uudai;
        }
        public List<UuDai> Getthongtinuudai()
        {
            return _uudai.GetUudai();
        }
        public UuDai Giasale(string Matour)
        {
            return _uudai.Giasale(Matour);
        }
    }
}
