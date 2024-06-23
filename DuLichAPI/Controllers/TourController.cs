using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DuLichAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private ITourBLL _tourBLL;

        public TourController(ITourBLL tourBLL)
        {
            _tourBLL = tourBLL;
        }
        [Route("get-by-tour-uudai")]
        [HttpGet]
        public List<Tour> GetDataTouruudai()
        {
            return _tourBLL.GetTouruudai();
        }
        [Route("get-by-tour-desc")]
        [HttpGet]
        public List<Tour> Gettourdesc()
        {
            return _tourBLL.GetTourdesc();
        }
        [Route("get-by-tour-asc")]
        [HttpGet]
        public List<Tour> GetTourasc()
        { 
            return _tourBLL.GetTourasc();
        }
        [Route("get-by-tour")]
        [HttpGet]
        public  List<Tour> GetDataTour()
        {
            return _tourBLL.GetTour();
        }
        [Route("get-by-tourdangdienra")]
        [HttpGet]
        public List<Tour> GetTourdangdienra()
        {
            return _tourBLL.GetTourdangdienra();
        }
        [Route("get-by-id/{Matour}")]
        [HttpGet]
        public Tour GetDatabyID(string Matour)
        {
            return _tourBLL.GetTourid(Matour);
        }
        [Route("get-by-danhmucid/{madanhmuctour}")]
        [HttpGet]
        public IActionResult GetTourdanhmuc(string madanhmuctour)
        {
            var tour = _tourBLL.GetTourdanhmuc(madanhmuctour);
            if (tour == null)
            {
                return NotFound(); 
            }
            return Ok(tour); 
        }
        [Route("create-tour")]
        [HttpPost]
        public Tour CreateItem([FromBody] Tour model)
        {
            _tourBLL.Create(model);
            return model;
        }
        [Route("update-tour")]
        [HttpPost]
        public Tour UpdateItem([FromBody] Tour model)
        {
            _tourBLL.Update(model);
            return model;
        }
        [Route("delete-tour/{Matour}")]
        [HttpDelete]
        public IActionResult DeleteItem(string Matour)
        {
            try
            {
                bool deleteResult = _tourBLL.Delete(Matour);
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
        [Route("search")]
        [HttpPost]
        public List<Tour> Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_tour = "";
                if (!string.IsNullOrEmpty(Convert.ToString(formData["tieudetour"]))) { ten_tour = Convert.ToString(formData["tieudetour"]); }
                string noi_khoi_hanh = "";
                if (!string.IsNullOrEmpty(Convert.ToString(formData["noikhoihanh"]))) { noi_khoi_hanh = Convert.ToString(formData["noikhoihanh"]); }
                long total = 0;
                var data = _tourBLL.Search(page, pageSize, out total, ten_tour, noi_khoi_hanh);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("Search-price")]
        [HttpPost]
        public List<Tour> Searchbyprice([FromBody] Dictionary<string, object> formData)
        {
            try
            {

                var MinPrice = float.Parse(formData["MinPrice"].ToString());
                var MaxPrice = float.Parse(formData["MaxPrice"].ToString());
                var data = _tourBLL.SearchByprice(MinPrice,MaxPrice);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
