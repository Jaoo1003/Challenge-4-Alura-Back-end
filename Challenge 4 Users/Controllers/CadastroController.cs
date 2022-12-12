using Challenge_4_Users.Data.Dtos;
using Challenge_4_Users.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_4_Users.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase{

        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService) {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto) {
            Result resultado = _cadastroService.CadastraUsuario(createDto);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes.First());
        }
    }
}
