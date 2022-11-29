using Challenge_4_Alura_Beck_End.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_4_Alura_Beck_End.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class DespesaController : ControllerBase{

        private DespesaService _despesaService;

        public DespesaController(DespesaService despesaService) {
            _despesaService = despesaService;
        }

        [HttpPost]
        public ReadDespesaDto CadastraDespesa() {
            Despesa despesa = _despesaService.CadatraDespesa();
        }
    }
}
