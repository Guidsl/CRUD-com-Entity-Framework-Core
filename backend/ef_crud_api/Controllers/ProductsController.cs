using ef_crud_api.Data;
using ef_crud_api.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace ef_crud_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context; // Injeção do DbContext para acessar o banco de dados

        // Construtor que injeta o DbContext no controlador
        public ProductsController(ApplicationDbContext context)
        {
            _context = context; // Inicializa o campo _context com o contexto injetado
        }

        // GET: api/products
        // Método GET para retornar todos os produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            // Retorna uma lista de produtos do banco de dados de forma assíncrona
            return await _context.Products.ToListAsync();
        }

        // GET: api/products/5
        // Método GET para retornar um produto específico com base no ID fornecido
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // Procura o produto no banco de dados pelo ID
            var product = await _context.Products.FindAsync(id);

            // Se o produto não for encontrado, retorna 404 (NotFound)
            if (product == null)
            {
                return NotFound();
            }

            // Se o produto for encontrado, retorna o produto
            return product;
        }

        // POST: api/products
        // Método POST para criar um novo produto
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            // Adiciona o novo produto ao contexto do banco de dados
            _context.Products.Add(product);

            // Salva as mudanças de forma assíncrona no banco de dados
            await _context.SaveChangesAsync();

            // Retorna 201 (Created) com o novo produto e a URL onde ele pode ser acessado
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/products/5
        // Método PUT para atualizar um produto existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            // Verifica se o ID fornecido corresponde ao ID do produto a ser atualizado
            if (id != product.Id)
            {
                return BadRequest(); // Se não corresponder, retorna 400 (BadRequest)
            }

            // Marca o produto como modificado no contexto
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                // Tenta salvar as mudanças no banco de dados de forma assíncrona
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Se houver uma exceção de concorrência, verifica se o produto ainda existe
                if (!ProductExists(id))
                {
                    return NotFound(); // Se o produto não existir, retorna 404 (NotFound)
                }
                else
                {
                    throw; // Se for outra exceção, lança o erro
                }
            }

            // Se a atualização for bem-sucedida, retorna 204 (NoContent) sem conteúdo adicional
            return NoContent();
        }

        // DELETE: api/products/5
        // Método DELETE para excluir um produto existente com base no ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Procura o produto no banco de dados pelo ID
            var product = await _context.Products.FindAsync(id);

            // Se o produto não for encontrado, retorna 404 (NotFound)
            if (product == null)
            {
                return NotFound();
            }

            // Remove o produto do contexto do banco de dados
            _context.Products.Remove(product);

            // Salva as mudanças de forma assíncrona no banco de dados
            await _context.SaveChangesAsync();

            // Retorna 204 (NoContent) após a exclusão bem-sucedida
            return NoContent();
        }

        // Método auxiliar para verificar se um produto existe no banco de dados com base no ID
        private bool ProductExists(int id)
        {
            // Verifica se existe algum produto no banco com o ID fornecido
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
