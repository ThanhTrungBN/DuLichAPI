using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DuLichAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichtrinhController : Controller
    {
        private ILichtrinhBLL _lichtrinhBLL;

        public LichtrinhController(ILichtrinhBLL lichtrinhBLL)
        {
            _lichtrinhBLL = lichtrinhBLL;
        }
        [Route("create-lichtrinh")]
        [HttpPost]
        public Lichtrinh CreateItem([FromBody] Lichtrinh model)
        {
            _lichtrinhBLL.Create(model);
            return model;
        }
        [Route("update-lichtrinh")]
        [HttpPost]
        public Lichtrinh UpdateItem([FromBody] Lichtrinh model)
        {
            _lichtrinhBLL.Update(model);
            return model;
        }
        [Route("delete-lichtrinh/{Lichtrinhid}")]
        [HttpDelete]
        public IActionResult DeleteItem(int Lichtrinhid)
        {
            try
            {
                bool deleteResult = _lichtrinhBLL.Delete(Lichtrinhid);
                if (deleteResult)
                {
                    return Ok(new { message = "Tour deleted successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Failed to delete tour" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [Route("get-by-id-lichtrinh/{Machitiettour}")]
        [HttpGet]
        public List<Lichtrinh> GetDatabyID(int Machitiettour)
        {
            return _lichtrinhBLL.GetLichtrinh(Machitiettour);
        }
        [Route("get-by-all-lichtrinh")]
        [HttpGet]
        public List<Lichtrinh> GetLichtrinhAll()
        {
            return _lichtrinhBLL.GetLichtrinhAll();
        }
        [Route("get-by-lichtrinhid/{Lichtrinhid}")]
        [HttpGet]
        public Lichtrinh GetChitietLichtrinhid(int Lichtrinhid)
        {
            return _lichtrinhBLL.GetChitietLichtrinhid(Lichtrinhid);
        }
    }
}
