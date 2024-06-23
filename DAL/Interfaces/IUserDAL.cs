using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IUserDAL
    {
        User Login(string taikhoan, string matkhau);
        List<User> GetNguoidung();
        bool Delete(int Manguoidung);
        bool Update(int Mataikhoan, string per);
    }
}
