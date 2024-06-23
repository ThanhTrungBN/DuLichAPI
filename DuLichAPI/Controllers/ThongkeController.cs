using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuLichAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongkeController : ControllerBase
    {

        private IThongkeBLL _thongkeBLL;

        public ThongkeController(IThongkeBLL thongkeBLL)
        {
            _thongkeBLL = thongkeBLL;
        }

        [Route("get-soluong-tour")]
        [HttpGet]
        public int GetCountTour()
        {
           return _thongkeBLL.CountTour();
        }
        [Route("get-soluong-account")]
        [HttpGet]
        public int GetUser()
        {
            return _thongkeBLL.User();
        }
        [Route("get-soluong-order")]
        [HttpGet]
        public int GetCountOrder()
        {
            return _thongkeBLL.CountOrder();
        }
        [Route("get-doanhthu-thang")]
        [HttpGet]
        public List<Thongke> Getdoanhthutheothang()
        {
            return _thongkeBLL.GetDoanhThuTheoThang();
        }
    }
}
