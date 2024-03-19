using crudApi1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace crudApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        //private readonly StudentContext _context;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        //public LoginController(IConfiguration config, StudentContext context)
        //{
        //    config = config;
        //    _context = context;
        //}


        private string genrateToken(LoginDetails obj)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
          


        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginDetails user)
        {
           
            IActionResult res = Unauthorized();
            var user_ = authenticateUser(user);
            if (user_ != null)
            {
                var token = genrateToken(user);
                res = Ok(new { token = token });
              
            }



            return res;
        }

        private LoginDetails authenticateUser(LoginDetails user)
        {
            LoginDetails _user = null;

            if(user.Email=="admin" && user.Password=="123")
            {
                _user = new LoginDetails { Email = "amit pandey" };
            }
            return _user;
            //var user1 = _context.LoginDetails.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            //if (user1 != null)
            //{
            //    return true;
            //}
          ///  return false;

        }

    }
}
