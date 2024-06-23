using CodeMegaVNPay.Models;
using CodeMegaVNPay.Services;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuLichAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VnPayController : ControllerBase
    {
        private readonly IVnPayService _vnPayService;

        public VnPayController(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }

        [HttpPost("create-payment-url")]
        public IActionResult CreatePaymentUrl([FromBody] OrderCreationResult data)
        {
            if (data == null)
            {
                return BadRequest("Invalid payment information");
            }

            var url = _vnPayService.CreatePaymentUrl(data.payment, data.model, data.thongtin, HttpContext);

            return Ok(new { PaymentUrl = url });
        }

        [HttpGet("payment-callback")]
        public IActionResult PaymentCallback()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);

            return Ok(response);
        }
    }
}
