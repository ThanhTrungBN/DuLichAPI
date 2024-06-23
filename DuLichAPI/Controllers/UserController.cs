using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace DuLichAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBLL _userBusiness;
        public UserController(IUserBLL userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [AllowAnonymous]
        [HttpPost("login")]
       
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _userBusiness.Login(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.Taikhoan, token = user.token ,per =user.per,manguoidung = user.Manguoidung,mataikhoan=user.Mataikhoan});
        }
        [Route("get-by-user")]
        [HttpGet]
        public List<User> GetNguoidung()
        {
            return _userBusiness.GetNguoidung();
        }
        [Route("delete-user/{Manguoidung}")]
        [HttpDelete]
        public IActionResult DeleteItem(int Manguoidung)
        {
            try
            {
                bool deleteResult = _userBusiness.Delete(Manguoidung);
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
        [Route("update-per")]
        [HttpPost]
        public IActionResult UpdateItem([FromBody] Per model)
        {
            try
            {
                _userBusiness.Update(model.Mataikhoan, model.per);
                return Ok("PER updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update PER: {ex.Message}");
            }
        }
    }
}
