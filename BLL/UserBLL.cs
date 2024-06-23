using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace BLL
{
    public class UserBLL:IUserBLL
    {
        private IUserDAL _res;
        private string secret;
        public UserBLL(IUserDAL res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }

        public User Login(string taikhoan, string matkhau)
        {
            var user = _res.Login(taikhoan, matkhau);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Taikhoan.ToString()),
                    new Claim(ClaimTypes.Role, user.per),
                    
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            return user;
        }
        public List<User> GetNguoidung()
        {
            return _res.GetNguoidung();
        }
        public bool Delete(int Manguoidung)
        {
            return _res.Delete(Manguoidung);
        }
        public bool Update(int Mataikhoan, string per)
        {
            return _res.Update(Mataikhoan,per);
        }
    }
}
