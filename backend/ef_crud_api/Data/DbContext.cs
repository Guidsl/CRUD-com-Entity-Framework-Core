// Importa os namespaces necessários
using Microsoft.EntityFrameworkCore; // Necessário para trabalhar com Entity Framework Core
using ef_crud_api.Models; // Importa o namespace onde está a classe Product

// Define o namespace para a classe DbContext
namespace ef_crud_api.Data
{
    // Define a classe ApplicationDbContext que herda de Microsoft.EntityFrameworkCore.DbContext
    public class ApplicationDbContext : DbContext
    {
        // Construtor da classe ApplicationDbContext, que recebe as opções de configuração
        public ApplicationDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");  // ou
                //.HasPrecision(18, 2); // Alternativa com .HasPrecision()
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define um conjunto de dados para a tabela de produtos
        public DbSet<Product> Products { get; set; }
    }
}
