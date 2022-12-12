using AutoMapper;
using Challenge_4_Alura_Beck_End.Data;
using Challenge_4_Alura_Beck_End.Data.Dtos.Resumos;
using Challenge_4_Alura_Beck_End.Models;

namespace Challenge_4_Alura_Beck_End.Service {
    public class ResumoService {

        private AppDbContext _context;
        private IMapper _mapper;
        public ResumoService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public ResumoDto BuscaResumo(int ano, int mes) {
            List<Despesa> despesas = _context.Despesas.Where(despesa => despesa.Data.Year == ano && despesa.Data.Month == mes).ToList();
            List<Receita> receitas = _context.Receitas.Where(receita => receita.Data.Year == ano && receita.Data.Month == mes).ToList();
            ResumoDto resumos = new ResumoDto();
            if (despesas != null || receitas != null) {
                resumos.Receitas = receitas;
                resumos.Despesas = despesas;

                for (int i = 0; i < despesas.Count; i++) {
                    resumos.ValorTotalDespesa += despesas[i].Valor;
                }
                for (int j = 0; j < receitas.Count; j++) {
                    resumos.ValorTotalReceita = +receitas[j].Valor;
                }
                resumos.SaldoFinal = resumos.ValorTotalReceita - resumos.ValorTotalDespesa;

                return resumos;
            }
            return null;
        }
    }
}
