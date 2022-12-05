using System.ComponentModel.DataAnnotations;

namespace Challenge_4_Alura_Beck_End.Data.Dtos.Despesa {
    public class CreateDespesaDto {

        [Required]
        public string Descricao { get; set; }
        [Required]
        public double? Valor { get; set; }
        [DataType(DataType.Date)]        
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
    }
}