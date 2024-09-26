using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ef_crud_api.Data;

namespace ef_crud_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context; // Altere para o nome do seu DbContext

        public TestController(ApplicationDbContext context) // Altere para o nome do seu DbContext
        {
            _context = context;
        }

        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                // Tenta executar uma consulta simples
                await _context.Database.ExecuteSqlRawAsync("SELECT 1");
                return Ok("Conexão com o banco de dados bem-sucedida!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }
}
