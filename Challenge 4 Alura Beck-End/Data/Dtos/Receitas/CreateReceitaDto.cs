using System.ComponentModel.DataAnnotations;

namespace Challenge_4_Alura_Beck_End.Data.Dtos.Receita {
    public class CreateReceitaDto {

        [Required(ErrorMessage = "A Descricão é um campo obrigatório")]
        public string Descricao { get; set; }

        [Range(1, 1000000000, ErrorMessage = "O Valor é um campo obrigatório")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "A Data é um campo obrigatório")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}
