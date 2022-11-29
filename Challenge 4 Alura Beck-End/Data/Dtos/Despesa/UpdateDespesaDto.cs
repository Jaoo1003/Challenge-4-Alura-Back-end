using System.ComponentModel.DataAnnotations;

namespace Challenge_4_Alura_Beck_End.Data.Dtos.Despesa {
    public class UpdateDespesaDto {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        public string Categoria { get; set; }
        [Required]
        public DateTime Data { get; set; }
    }
}
