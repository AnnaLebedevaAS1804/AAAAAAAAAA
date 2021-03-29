using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adutova_TKR2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Adutova_TKR2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public struct LoginData
        {
            public string login { get; set; }
            public string password { get; set; }
        }
        [HttpPost]
        public object GetToken([FromBody] LoginData ld)
        {
            var user = DataBase.Users.FirstOrDefault(u => u.Login == ld.login && u.Password == ld.password);
            if (user == null)
            {
                Response.StatusCode = 401;
                return new { message = "wrong login/password" };
            }
            return AuthOptions.GenerateToken(user.IsAdmin);
        }

        [HttpGet("token")]
        public string GetToken()
        {
            return AuthOptions.GenerateToken();
        }
        [HttpGet("token/secret")]
        public string GetAdminToken()
        {
            return AuthOptions.GenerateToken(true);
        }
    }
}

