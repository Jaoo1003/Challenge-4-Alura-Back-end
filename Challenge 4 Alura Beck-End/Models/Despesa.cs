namespace Challenge_4_Alura_Beck_End.Models {
    public class Despesa {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string Categoria { get; set; }
        public DateTime Data { get; set; }
    }
}
