using Challenge_4_Users.Data.Requests;
using Challenge_4_Users.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Challenge_4_Users.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase{

        private LoginService _loginService;

        public LoginController(LoginService loginService) {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request) {
            Result resultado = _loginService.LogaUsuario(request);
            if (resultado.IsFailed) return Unauthorized();
            return Ok(resultado.Successes.First());
        }
    }
}
