using CodeMegaVNPay.Models;
using DAL.Helper.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CodeMegaVNPay.Services
{
    public class VnPayService : IVnPayService
    {
        private readonly IConfiguration _configuration;

        private IDatabase _database;
        public VnPayService(IDatabase database,IConfiguration configuration)
        {
            _database = database;
            _configuration = configuration;
        }
        public string CreatePaymentUrl(PaymentInformationModel model,Order od ,ThongtinLienlac tt,HttpContext context)
        {
            int newOrderId = -1;
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_configuration["TimeZoneId"]);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var tick = DateTime.Now.Ticks.ToString();
            var pay = new VnPayLibrary();
            var urlCallBack = _configuration["PaymentCallBack:ReturnUrl"];
            var connectionResult = _database.OpenConnectionAndBeginTransaction();
            if (!string.IsNullOrEmpty(connectionResult))
            {
                throw new Exception(connectionResult);
            }
            try
            {

                // Gọi phương thức để thêm các tham số vào cơ sở dữ liệu
                var result = _database.ExecuteSProcedure(
                    "InsertPaymentData",
                    "@Hovaten",tt.Hovaten,
                    "@Email",tt.Email,
                    "@Diachi",tt.Diachi,
                    "@Sdt",tt.Sdt, 
                    "@Mataikhoan", od.Mataikhoan, 
                    "@Matour", od.Matour,
                    "@Hanhkhach", od.Hanhkhach, 
                    "@Thanhtien", od.Thanhtien, 
                    "@Ngaydangki", od.Ngaydangki, 
                    "@Tinhtrang", od.Tinhtrang, 
                    "@Version", _configuration["Vnpay:Version"],
                    "@Command", _configuration["Vnpay:Command"],
                    "@TmnCode", _configuration["Vnpay:TmnCode"],
                    "@Amount", (int)model.Amount * 100,
                    "@CreateDate", timeNow.ToString("yyyyMMddHHmmss"),
                    "@CurrCode", _configuration["Vnpay:CurrCode"],
                    "@IpAddr", pay.GetIpAddress(context),
                    "@Locale", _configuration["Vnpay:Locale"],
                    "@OrderInfo", $"{model.Name} {model.OrderDescription} {model.Amount}",
                    "@OrderType", model.OrderType,
                    "@ReturnUrl", urlCallBack,
                    "@TxnRef", tick
                );

                if (!string.IsNullOrEmpty(result))
                {
                    throw new Exception(result);
                }
                // Truy vấn để lấy OrderID vừa được thêm vào
                string msgError;
                var orderIdQuery = "SELECT TOP 1 OrderId FROM OrderTour ORDER BY OrderId DESC";
                var orderIdTable = _database.ExecuteQueryToDataTable(orderIdQuery, out msgError);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                if (orderIdTable.Rows.Count > 0)
                {
                    newOrderId = Convert.ToInt32(orderIdTable.Rows[0]["OrderId"]);
                }

                if (newOrderId == -1)
                {
                    throw new Exception("Không thể lấy OrderID mới.");
                }

                // Commit giao dịch nếu thành công
                _database.CloseConnectionAndEndTransaction(false);
            }
            catch (Exception)
            {
                // Rollback giao dịch nếu có lỗi
                _database.CloseConnectionAndEndTransaction(true);
                throw;
            }
            pay.AddRequestData("vnp_Version", _configuration["Vnpay:Version"]);
            pay.AddRequestData("vnp_Command", _configuration["Vnpay:Command"]);
            pay.AddRequestData("vnp_TmnCode", _configuration["Vnpay:TmnCode"]);
            pay.AddRequestData("vnp_Amount", ((int)model.Amount).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(context));
            pay.AddRequestData("vnp_Locale", _configuration["Vnpay:Locale"]);
            pay.AddRequestData("vnp_OrderInfo", $"{newOrderId}-{model.Name}-{model.OrderDescription}-{model.Amount}");
            pay.AddRequestData("vnp_OrderType", model.OrderType);
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl =
                pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            return paymentUrl;
        }

        public PaymentResponseModel PaymentExecute(IQueryCollection collections)
        {
            var pay = new VnPayLibrary();
            var response = pay.GetFullResponseData(collections, _configuration["Vnpay:HashSecret"]);

            return response;
        }
    }
}
