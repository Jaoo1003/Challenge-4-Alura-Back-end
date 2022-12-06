using Challenge_4_Alura_Beck_End.Models;

namespace Challenge_4_Alura_Beck_End.Data.Dtos.Despesas {
    public class ReadDespesaDto {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Date { get; set; }
        public Categoria Categoria { get; set; }
    }
}
