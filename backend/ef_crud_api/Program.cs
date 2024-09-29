using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ef_crud_api.Data; // Adicione a referência ao seu DbContext

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ef_crud_api", Version = "v1" });
});

// Registre o ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicione suporte aos controladores
builder.Services.AddControllers();

// Configura e ativa o CORS (substitui o que estava no Startup.cs)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()  // Permite qualquer origem
               .AllowAnyMethod()  // Permite qualquer método (GET, POST, etc.)
               .AllowAnyHeader()); // Permite qualquer cabeçalho
});

var app = builder.Build();

// Configure o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ef_crud_api V1");
        c.RoutePrefix = string.Empty; // Para que o Swagger UI esteja na raiz
    });
}

// Use o redirecionamento de HTTPS
app.UseHttpsRedirection();

// Coloque o middleware de CORS entre UseRouting e UseAuthorization
app.UseRouting();
app.UseCors("AllowAll"); // Ativa o CORS com a política "AllowAll"
app.UseAuthorization();

// Mapeia os controladores para os endpoints de API
app.MapControllers();

app.Run();
