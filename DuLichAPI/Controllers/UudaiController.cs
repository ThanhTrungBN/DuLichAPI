using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DuLichAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UudaiController : ControllerBase
    {
        private IUudaiBLL _uudaiBLL;
        public UudaiController(IUudaiBLL uudaiBLL)
        {
            _uudaiBLL = uudaiBLL;
        }
        [Route("get-by-uudai")]
        [HttpGet]
        public List<UuDai> GetdataUudai()
        {
            return _uudaiBLL.Getthongtinuudai();
        }

        [Route("get-by-sale/{Matour}")]
        [HttpGet]
        public UuDai Giasale(string Matour)
        {
            return _uudaiBLL.Giasale(Matour);
        }
    }
    
}
