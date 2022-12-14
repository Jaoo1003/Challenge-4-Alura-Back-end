using Challenge_4_Alura_Beck_End.Data.Dtos.Receitas;
using Challenge_4_Alura_Beck_End.Models;
using Challenge_4_Alura_Beck_End.Service;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Data;

namespace Challenge_4_Alura_Beck_End.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ReceitaController : ControllerBase {

        private ReceitaService _receitaService;

        public ReceitaController(ReceitaService receitaService) {
            _receitaService = receitaService;
        }

        [HttpPost]
        [Authorize(Roles = "authorized")]
        public IActionResult CadastroReceita([FromBody] CreateReceitaDto createDto) {
            ReadReceitaDto readDto = _receitaService.CadastroReceita(createDto);
            if (readDto == null) {
                return Ok("Falha ao cadastrar nova receita");
            }
            return CreatedAtAction(nameof(BuscaReceitaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        [Authorize(Roles = "authorized")]
        public IActionResult BuscaReceita([FromQuery] string? descricao = null) {
            List<ReadReceitaDto> readDto = _receitaService.BuscaReceita(descricao);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "authorized")]
        public IActionResult BuscaReceitaPorId(int id) {
            ReadReceitaDto readDto = _receitaService.BuscaReceitaPorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{ano}/{mes}")]
        [Authorize(Roles = "authorized")]
        public IActionResult BuscaReceitaPorMes(int ano, int mes) {
            List<ReadReceitaDto> readDto = _receitaService.BuscaReceitaPorMes(ano, mes);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "authorized")]
        public IActionResult AtualizaReceita(int id, [FromBody] UpdateReceitaDto updateDto) {
            Result resultado = _receitaService.AtualizaReceita(id, updateDto);
            if (resultado.IsSuccess) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "authorized")]
        public IActionResult DeletaReceita(int id) {
            Result resultado = _receitaService.DeletaReceita(id);
            if (resultado.IsSuccess) return Ok();
            return NotFound();
        }
    }
}
