// @TODO:
// - Change return types on /login endpoint

namespace EBook.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using EBook.Services.Contracts;
    using System.Threading.Tasks;
    using EBook.API.Models.Dto;
    using System;

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
            => _authService = authService;

        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel loginInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest("Login information is not valid.");

            try
            {
                var auth = await _authService.Authenticate(loginInfo.Username, loginInfo.Password);
                if (!auth)
                    return BadRequest();

                // @TODO:
                // - Generate token
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

    }
}