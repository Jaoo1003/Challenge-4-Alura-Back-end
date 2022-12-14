using System.ComponentModel.DataAnnotations;

namespace Challenge_4_Alura_Beck_End.Data.Dtos.Despesas {
    public class UpdateDespesaDto {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }
    }
}
