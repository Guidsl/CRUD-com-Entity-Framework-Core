using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ef_crud_api.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Constrói a configuração lendo o arquivo appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Define o diretório base atual
                .AddJsonFile("appsettings.json") // Lê o arquivo de configuração appsettings.json
                .Build(); // Constrói a configuração

            // Cria o builder das opções de DbContext
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Obtém a string de conexão a partir da configuração
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configura o uso do SQL Server com a string de conexão
            optionsBuilder.UseSqlServer(connectionString);

            // Retorna uma nova instância de ApplicationDbContext com as opções configuradas
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
