using Challenge_4_Alura_Beck_End.Data.Dtos.Receita;
using Challenge_4_Alura_Beck_End.Models;
using Challenge_4_Alura_Beck_End.Service;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Challenge_4_Alura_Beck_End.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ReceitaController : ControllerBase {

        private ReceitaService _receitaService;

        public ReceitaController(ReceitaService receitaService) {
            _receitaService = receitaService;
        }

        [HttpPost]
        public IActionResult CadastroReceita([FromBody] CreateReceitaDto createDto) {
            ReadReceitaDto readDto = _receitaService.CadastroReceita(createDto);
            if (readDto == null) {
                return Ok("Falha ao cadastrar nova receita");
            }
            readDto.Date = createDto.Date;
            return CreatedAtAction(nameof(BuscaReceitaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult BuscaReceita() {
            List<ReadReceitaDto> readDto = _receitaService.BuscaReceita();
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult BuscaReceitaPorId(int id) {
            ReadReceitaDto readDto = _receitaService.BuscaReceitaPorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaReceita(int id, [FromBody] UpdateReceitaDto updateDto) {
            Result resultado = _receitaService.AtualizaReceita(id, updateDto);
            if (resultado.IsSuccess) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaReceita(int id) {
            Result resultado = _receitaService.DeletaReceita(id);
            if (resultado.IsSuccess) return Ok();
            return NotFound();
        }
    }
}
