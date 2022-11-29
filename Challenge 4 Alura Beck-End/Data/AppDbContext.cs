using Challenge_4_Alura_Beck_End.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge_4_Alura_Beck_End.Data {
    public class AppDbContext : DbContext{

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){
        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
    }
}
