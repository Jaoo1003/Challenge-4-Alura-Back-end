using Challenge_4_Alura_Beck_End.Data.Dtos.Despesas;
using Challenge_4_Alura_Beck_End.Models;
using Challenge_4_Alura_Beck_End.Service;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Challenge_4_Alura_Beck_End.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class DespesaController : ControllerBase {

        private DespesaService _despesaService;

        public DespesaController(DespesaService despesaService) {
            _despesaService = despesaService;
        }

        [HttpPost]
        [Authorize(Roles = "authorized")]
        public IActionResult CadastraDespesa([FromBody] CreateDespesaDto createDto) {
            ReadDespesaDto readDto = _despesaService.CadastraDespesa(createDto);            
            if (readDto == null) {
                return Ok("Falha ao cadastrar nova despesa");
            }
            return CreatedAtAction(nameof(BuscaDespesaPorId), new { id = readDto.Id }, readDto);
        }

        [HttpGet]
        [Authorize(Roles = "authorized")]
        public IActionResult BuscaDespesa([FromQuery] string? descricao = null) {
            List<ReadDespesaDto> readDto = _despesaService.BuscaDespesa(descricao);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "authorized")]
        public IActionResult BuscaDespesaPorId(int id) {
            ReadDespesaDto readDto = _despesaService.BuscaDespesaPorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "authorized")]
        public IActionResult AtualizaDespesa(int id, [FromBody] UpdateDespesaDto updateDto) {
            Result resultado = _despesaService.AtualizaDespesa(id, updateDto);
            if (resultado.IsSuccess) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "authorized")]
        public IActionResult DeletaDespesa(int id) {
            Result resultado = _despesaService.DeletaDespesa(id);
            if (resultado.IsSuccess) return Ok();
            return NotFound();
        }
    }
}