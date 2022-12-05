using Challenge_4_Alura_Beck_End.Data.Dtos.Despesa;
using Challenge_4_Alura_Beck_End.Models;
using Challenge_4_Alura_Beck_End.Service;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_4_Alura_Beck_End.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class DespesaController : ControllerBase {

        private DespesaService _despesaService;

        public DespesaController(DespesaService despesaService) {
            _despesaService = despesaService;
        }

        [HttpPost]
        public IActionResult CadastraDespesa([FromBody] CreateDespesaDto createDto) {
            ReadDespesaDto readDto = _despesaService.CadastraDespesa(createDto);            
            if (readDto == null) {
                return Ok("Falha ao cadastrar nova despesa");
            }
            return CreatedAtAction(nameof(BuscaDespesaPorId), new { id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult BuscaDespesa() {
            List<ReadDespesaDto> readDto = _despesaService.BuscaDespesa();
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult BuscaDespesaPorId(int id) {
            ReadDespesaDto readDto = _despesaService.BuscaDespesaPorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaDespesa(int id, [FromBody] UpdateDespesaDto updateDto) {
            Result resultado = _despesaService.AtualizaDespesa(id, updateDto);
            if (resultado.IsSuccess) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaDespesa(int id) {
            Result resultado = _despesaService.DeletaDespesa(id);
            if (resultado.IsSuccess) return Ok();
            return NotFound();
        }
    }
}