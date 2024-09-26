// Importa os namespaces necessários
using Microsoft.EntityFrameworkCore; // Necessário para trabalhar com Entity Framework Core
using ef_crud_api.Models; // Importa o namespace onde está a classe Product

// Define o namespace para a classe DbContext
namespace ef_crud_api.Data
{
    // Define a classe DbContext que herda de Microsoft.EntityFrameworkCore.DbContext
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        // Construtor da classe DbContext, que recebe as opções de configuração
        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        // Define um conjunto de dados para a tabela de produtos
        public DbSet<Product> Products { get; set; }
    }
}
