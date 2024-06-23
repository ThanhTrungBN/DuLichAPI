using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Order
    {
        public int OrderID { get; set; }   
        public string Matour {  get; set; }
        public int Hanhkhach {  get; set; }
        public float Thanhtien { get; set; }
        public int Mataikhoan {  get; set; }
        public string? Anhdaidien { get; set; }
        public string? Tieudetour { get; set; }
        public string? Songaydi { get; set; }
        public string? Noikhoihanh { get; set; }
        public DateTime? Ngaythangnam { get; set; }
        public DateTime Ngaydangki { get; set; }
        public string Tinhtrang {  get; set; }
        public string? Hovaten {  get; set; }
        public string? Diachi {  get; set; }
        public string? Email {  get; set; }
        public int? Sdt {  get; set; }

        public int? Machitiettour { get; set; }
        public string? Madiadiem { get; set; }
        public string? Diemnhan { get; set; }
        public DateTime? Ngaykhoihanh { get; set; }
        public DateTime? Ngayketthuc { get; set; }
        public string? Thongtindichuyen { get; set; }
        public string? Thongtinhuongdanvien { get; set; }
        public string? Thongtintaptrung { get; set; }
    }
}
