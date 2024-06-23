using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DuLichAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiadiemController : ControllerBase
    {
        private IDiadiemBLL _diadiemBLL;
        public DiadiemController(IDiadiemBLL diadiem)
        {
            _diadiemBLL = diadiem;
        }
        [Route("get-by-diadiem-mb")]
        [HttpGet]
        public List<Diadiem> Getdatadiadiem()
        {
            return _diadiemBLL.Getdiadiem();
        }
        [Route("get-by-diadiem-mt")]
        [HttpGet]
        public List<Diadiem> GetdatadiadiemMT()
        {
            return _diadiemBLL.GetdiadiemMT();
        }
        [Route("get-by-diadiem-mdnb")]
        [HttpGet]
        public List<Diadiem> GetdatadiadiemMDNB()
        {
            return _diadiemBLL.GetdiadiemMDNB();
        }
        [Route("get-by-diadiem-mtnb")]
        [HttpGet]
        public List<Diadiem> GetdatadiadiemMTNB()
        {
            return _diadiemBLL.GetdiadiemMTNB();
        }
        [Route("get-by-DD")]
        [HttpGet]
        public List<Diadiem> GetDD()
        {
            return _diadiemBLL.GetDD();
        }
    }
}
