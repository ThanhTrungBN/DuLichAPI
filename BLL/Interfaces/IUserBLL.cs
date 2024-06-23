using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface IUserBLL
    {
        User Login(string taikhoan, string matkhau);
        List<User> GetNguoidung();
        bool Delete(int Manguoidung);
        bool Update(int Mataikhoan, string per);
    }
}
