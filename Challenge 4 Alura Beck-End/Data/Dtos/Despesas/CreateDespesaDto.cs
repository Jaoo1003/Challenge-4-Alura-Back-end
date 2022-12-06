using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Challenge_4_Alura_Beck_End.Data.Dtos.Despesas {
    public class CreateDespesaDto {

        [Required]
        public string Descricao { get; set; }
        [Required]
        public double? Valor { get; set; }
        [DataType(DataType.Date)]
        [Required]        
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
    }
}