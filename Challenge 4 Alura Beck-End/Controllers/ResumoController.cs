using Challenge_4_Alura_Beck_End.Data.Dtos.Resumos;
using Challenge_4_Alura_Beck_End.Service;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_4_Alura_Beck_End.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ResumoController : ControllerBase{

        private ResumoService _resumoService;

        public ResumoController(ResumoService resumoService) {
            _resumoService = resumoService;
        }

        [HttpGet]
        public IActionResult BuscaResumo() {
            ResumoDto resumoDto = _resumoService.BuscaResumo();
            if (resumoDto != null) return Ok(resumoDto);
            return null;
        }
    }
}
