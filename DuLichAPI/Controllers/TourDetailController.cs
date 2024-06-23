using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DuLichAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourDetailController : Controller
    {

        private ITourDetailBLL _tourdetailBLL;

        public TourDetailController(ITourDetailBLL tourdetailBLL)
        {
            _tourdetailBLL = tourdetailBLL;
        }
        [Route("create-tourdetail")]
        [HttpPost]
        public TourDetail CreateItem([FromBody] TourDetail model)
        {
            _tourdetailBLL.Create(model);
            return model;
        }
        [Route("update-tourdetail")]
        [HttpPost]
        public TourDetail UpdateItem([FromBody] TourDetail model)
        {
            _tourdetailBLL.Update(model);
            return model;
        }
        [Route("delete-tourdetail/{Matour}")]
        [HttpDelete]
        public IActionResult DeleteItem(int Machitiettour)
        {
            try
            {
                bool deleteResult = _tourdetailBLL.Delete(Machitiettour);
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
        [Route("get-by-iddetail/{Matour}")]
        [HttpGet]
        public TourDetail GetDatabyID(string Matour)
        {
            return _tourdetailBLL.GetChitietTour(Matour);
        }
        [Route("get-by-detail/{Machitiettour}")]
        [HttpGet]
        public TourDetail GetChitietTourdetail(int Machitiettour)
        {
            return _tourdetailBLL.GetChitietTourdetail(Machitiettour);
        }
        [Route("get-by-IDnull")]
        [HttpGet]
        public List<TourDetail> GetDataTour()
        {
            return _tourdetailBLL.GetIDnull();
        }
        [Route("get-by-chitietall")]
        [HttpGet]
        public List<TourDetail> GetChitietAll()
        {
            return _tourdetailBLL.GetChitietAll();
        }
    }
}
