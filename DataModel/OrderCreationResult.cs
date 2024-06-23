using CodeMegaVNPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class OrderCreationResult
    {
        public Order model { get; set; }
        public ThongtinLienlac thongtin { get; set; }
        public PaymentInformationModel payment { get; set; }

    }
}
