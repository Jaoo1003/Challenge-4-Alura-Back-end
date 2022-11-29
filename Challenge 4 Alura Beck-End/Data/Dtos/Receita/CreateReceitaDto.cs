using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Challenge_4_Alura_Beck_End.Data.Dtos.Receita {
    public class CreateReceitaDto {
        [Required(ErrorMessage = "A Descricão é um campo obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O Valor é um campo obrigatório")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "A Data é um campo obrigatório")]
        public DateTime Date { get; set; }
    }
}
