using CodeMegaVNPay.Models;
using DataModel;
using Microsoft.AspNetCore.Http;

namespace CodeMegaVNPay.Services;
public interface IVnPayService
{
    string CreatePaymentUrl(PaymentInformationModel model, Order od,ThongtinLienlac tt, HttpContext context);
    PaymentResponseModel PaymentExecute(IQueryCollection collections);
}