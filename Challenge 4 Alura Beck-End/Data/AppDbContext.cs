using Challenge_4_Alura_Beck_End.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge_4_Alura_Beck_End.Data {
    public class AppDbContext : DbContext{

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<Despesa>()
                .HasOne(despesa => despesa.Categoria)
                .WithMany(categoria => categoria.Despesas)
                .HasForeignKey(despesa => despesa.CategoriaId);
        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}