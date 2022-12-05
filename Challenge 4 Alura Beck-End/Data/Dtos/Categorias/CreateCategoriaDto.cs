using System.ComponentModel.DataAnnotations;

namespace Challenge_4_Alura_Beck_End.Data.Dtos.Categorias {
    public class CreateCategoriaDto {
        [Required]
        public string Name { get; set; }
    }
}
