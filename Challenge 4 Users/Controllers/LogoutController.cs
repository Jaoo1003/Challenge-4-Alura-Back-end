﻿using Challenge_4_Users.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_4_Users.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase{

        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService) {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogaUsuario() {
            Result resultado = _logoutService.DeslogaUsuario();
            if (resultado.IsFailed) return Unauthorized();
            return Ok();
        }
    }
}
