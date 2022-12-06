using Challenge_4_Alura_Beck_End.Data.Dtos.Despesas;
using Challenge_4_Alura_Beck_End.Data.Dtos.Receitas;
using Challenge_4_Alura_Beck_End.Models;

namespace Challenge_4_Alura_Beck_End.Data.Dtos.Resumos {
    public class ResumoDto {
        public List<Despesa> Despesas { get; set; }
        public List<Receita> Receitas { get; set; }
    }
}
