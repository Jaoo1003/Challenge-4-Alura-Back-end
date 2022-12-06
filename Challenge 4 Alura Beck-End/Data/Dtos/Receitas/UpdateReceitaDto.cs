using System.ComponentModel.DataAnnotations;

namespace Challenge_4_Alura_Beck_End.Data.Dtos.Receitas {
    public class UpdateReceitaDto {
        [Required(ErrorMessage = "A Descricão é um campo obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O Valor é um campo obrigatório")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "A Data é um campo obrigatório")]
        public DateTime Data { get; set; }
    }
}
