using lamlai.data;
using lamlai.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace lamlai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly myDBcontext _context;
        private readonly AppSetting _appSettings;

        public userController(myDBcontext context, IOptionsMonitor<AppSetting> options) {
            _context= context;
            _appSettings = options.CurrentValue;
        }
        [HttpPost("login")]
        public IActionResult ValiDate(loginmodel loginmodel)
        {
            var user= _context.nguoidungs.SingleOrDefault(us => us.UseName== loginmodel.UseName && us.passWord==loginmodel.passWord);
            if (user == null)
            {
                return Ok(new APIvaliDate
                {
                    Succer = false,
                    Message = "bạn nhập sai"
                });
            }
            else
            {
                return Ok(new APIvaliDate
                {
                    Succer = true,
                    Message = "ok bn",
                    data = GenerateToken(user)
                });
            }
        }
        private string GenerateToken(Nguoidung nguoidung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, nguoidung.hoTen),
                    new Claim(ClaimTypes.Email, nguoidung.email),
                    new Claim("UserName", nguoidung.UseName),
                    new Claim("Id", nguoidung.Id.ToString()),

                    //role 
                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),    //làm mới lại token trong khoảng thời gian 
                                                            // còn hiểu là cái token nó hết hạn sau bao lâu sẽ không được truy cập
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
