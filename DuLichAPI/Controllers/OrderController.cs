using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DuLichAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController: ControllerBase
    {
        private IOrderBLL _orderBLL;

        public OrderController(IOrderBLL orderBLL)
        {
            _orderBLL = orderBLL;
        }
        [Route("get-by-order")]
        [HttpGet]
        public List<Order> GetOrders()
        {
            return _orderBLL.GetOrder();
        }
        [Route("create-order")]
        [HttpPost]
        public IActionResult CreateItem([FromBody] OrderCreationResult dto)
        {
            try
            {
                bool result = _orderBLL.Create(dto.model, dto.thongtin);

                // Trả về kết quả phù hợp
                if (result)
                {
                    return Ok("Dữ liệu đã được thêm thành công.");
                }
                else
                {
                    return BadRequest("Đã xảy ra lỗi khi thêm dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                return StatusCode(500, "Đã xảy ra lỗi trong quá trình xử lý.");
            }
        }
        [Route("get-by-orderid/{Mataikhoan}")]
        [HttpGet]
        public List<Order> Getorderid(int Mataikhoan)
        {
            return _orderBLL.GetOderid(Mataikhoan);
        }
        [Route("get-by-booking/{OrderID}")]
        [HttpGet]
        public List<Order> GetBooking(int OrderID)
        {
            return _orderBLL.GetBooking(OrderID);
        }
        [Route("delete-order/{OrderID}")]
        [HttpDelete]
        public IActionResult DeleteItem(int OrderID)
        {
            try
            {
                bool deleteResult = _orderBLL.Delete(OrderID);
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
        [Route("update-order-trangthai/{OrderID}")]
        [HttpPost]
        public IActionResult Update(int OrderID)
        {
            try
            {
                bool update = _orderBLL.Update(OrderID);
                if (update)
                {
                    return Ok(new { message = "Order update successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Failed to update tour" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
