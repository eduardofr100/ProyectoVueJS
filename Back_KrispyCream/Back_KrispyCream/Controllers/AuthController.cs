using Back_KrispyCream.Helpers;
using Back_KrispyCream.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Back_KrispyCream.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredentials creds)
        {
            if (creds.Username == "admin" && creds.Password == "1234")
            {
                var token = JwtHelper.GenerateJwt(creds.Username, _config);
                return Ok(new { token });
            }

            return Unauthorized("Credenciales inválidas");
        }
    }
}
