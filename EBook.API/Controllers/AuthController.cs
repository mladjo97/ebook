namespace EBook.API.Controllers
{
    using EBook.API.Models.Dto;
    using EBook.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginInfoDto loginInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest("Login information is not valid.");

            var auth = await _authService.Authenticate(loginInfo.Username, loginInfo.Password);
            if (!auth)
                return Unauthorized();

            var token = _tokenService.GenerateToken();

            return Ok(token);
        }

    }
}