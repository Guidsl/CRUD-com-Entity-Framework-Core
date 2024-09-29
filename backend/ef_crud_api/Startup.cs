using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ef_crud_api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Configuração do Entity Framework Core para usar SQL Server
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Adiciona serviços de controle à aplicação
        services.AddControllers();

        // Configura o Swagger para a documentação da API
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });

        // Ativando CORS para permitir chamadas de outros domínios
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
                builder.AllowAnyOrigin() // Permite qualquer origem
                       .AllowAnyMethod() // Permite qualquer método (GET, POST, etc.)
                       .AllowAnyHeader()); // Permite qualquer cabeçalho
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        // Mova o CORS para entre UseRouting e UseEndpoints
        app.UseCors("AllowAll");

        app.UseAuthorization();

        // Ativa o middleware do Swagger para gerar e servir a documentação da API
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Mapeia os controladores para os endpoints de API
        });
    }
}
