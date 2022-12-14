using Challenge_4_Alura_Beck_End.Data.Dtos.Categorias;
using Challenge_4_Alura_Beck_End.Models;
using Challenge_4_Alura_Beck_End.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_4_Alura_Beck_End.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase{

        private CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService) {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        [Authorize(Roles = "authorized")]
        public IActionResult AdicionaCategoria(CreateCategoriaDto createDto) {
            Categoria categoria = _categoriaService.AdicionaCategoria(createDto);
            return Ok(categoria);
        }
    }
}
