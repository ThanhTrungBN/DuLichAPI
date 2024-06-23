using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DuLichAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoidungController : Controller
    {
        private INguoidungBLL _nguoidungBLL;
        public NguoidungController(INguoidungBLL nguoidungBLL)
        {
            _nguoidungBLL = nguoidungBLL;
        }
        [Route("get-user-id/{Manguoidung}")]
        [HttpGet]
        public Nguoidung GetDatabyID(int Manguoidung)
        {
            return _nguoidungBLL.GetNguoidung(Manguoidung);
        }
    }

}
