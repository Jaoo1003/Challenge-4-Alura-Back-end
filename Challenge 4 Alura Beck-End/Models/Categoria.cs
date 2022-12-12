using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Challenge_4_Alura_Beck_End.Models {
    public class Categoria {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Despesa> Despesas { get; set; }
    }
}
