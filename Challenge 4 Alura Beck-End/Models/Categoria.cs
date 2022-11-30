using System.Text.Json.Serialization;

namespace Challenge_4_Alura_Beck_End.Models {
    public class Categoria {
        public int Id { get; set; }
        public string Tipo { get; set; }
        [JsonIgnore]
        public virtual List<Despesa> Despesas { get; set; }
    }
}
