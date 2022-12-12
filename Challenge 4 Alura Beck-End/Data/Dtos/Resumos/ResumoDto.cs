using Challenge_4_Alura_Beck_End.Models;

namespace Challenge_4_Alura_Beck_End.Data.Dtos.Resumos {
    public class ResumoDto {
        public List<Despesa> Despesas { get; set; }
        public List<Receita> Receitas { get; set; }
        public double ValorTotalDespesa { get; set; } 
        public double ValorTotalReceita { get; set; }
        public double SaldoFinal { get; set; }
        public List<Despesa> GastosPorCategoria { get; set; }
    }
}
