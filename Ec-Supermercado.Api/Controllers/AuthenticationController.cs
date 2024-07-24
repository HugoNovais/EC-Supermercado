using Ec_Supermercado.Api.DTOs;
using Ec_Supermercado.Api.Services.TokenService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ec_Supermercado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
          var token = await  _tokenService.GenerateToken(loginDto);

            if (token == "")
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
