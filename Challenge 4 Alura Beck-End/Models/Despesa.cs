using System.ComponentModel.DataAnnotations;

namespace Challenge_4_Alura_Beck_End.Models {
    public class Despesa {

        [Key]
        [Required]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Date { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
} 