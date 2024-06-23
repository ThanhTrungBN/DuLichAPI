using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class User
    {
        public int Mataikhoan {  get; set; }
        public int Manguoidung {  get; set; }
        public string Taikhoan { get; set; }
        public string Matkhau { get; set; }
        public string per { get; set; }
        public string token { get; set; }
        public string? Hoten {  get; set; }
        public string? Email { get; set; }
        public string? Diachi { get; set; }
        public string? Gioitinh { get; set; }
        public int? Sodienthoai { get; set; }
        public DateTime? Ngaysinh {  get; set; }
        public string? Anhdaidien {  get; set; }
    }
}
