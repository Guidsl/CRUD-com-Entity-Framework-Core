using Xunit;
using ef_crud_api.Controllers;
using ef_crud_api.Data;
using ef_crud_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ef_crud_api.Tests
{
    public class ProductsControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            // Configura um DbContextOptions fake para o ApplicationDbContext
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Usa o DbContext com as opções fake
            _context = new ApplicationDbContext(options);

            // Cria a instância do controlador com o contexto real
            _controller = new ProductsController(_context);

            // Limpa o banco de dados entre os testes
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetProducts_ReturnsListOfProducts()
        {
            // Arrange - Simula dados de produtos (sem definir o Id, ele será gerado automaticamente)
            var mockProducts = new List<Product>
            {
                new Product { Name = "Product 1", Price = 10.0M },
                new Product { Name = "Product 2", Price = 15.0M }
            };

            // Adiciona os produtos ao contexto real (InMemory)
            await _context.Products.AddRangeAsync(mockProducts);
            await _context.SaveChangesAsync();

            // Act - Chama o método GetProducts
            var result = await _controller.GetProducts();  // Usa await para aguardar a tarefa

            // Assert - Verifica se o retorno contém a lista de produtos mockada
            var products = Assert.IsType<ActionResult<IEnumerable<Product>>>(result);
            Assert.NotNull(products.Value);
            Assert.Equal(2, products.Value.Count());  // Verifica se há 2 produtos
        }

        [Fact]
        public async Task GetProductById_ReturnsProduct_WhenProductExists()
        {
            // Arrange - Adicionar um produto ao contexto (Id gerado automaticamente)
            var product = new Product { Name = "Product 1", Price = 10.0M };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            // Act - Chamar o método GetProduct com o Id do produto gerado
            var result = await _controller.GetProduct(product.Id);

            // Assert - Verificar se o produto retornado é o esperado
            var actionResult = Assert.IsType<ActionResult<Product>>(result);
            var returnedProduct = Assert.IsType<Product>(actionResult.Value);
            Assert.Equal(product.Name, returnedProduct.Name);
        }

        [Fact]
        public async Task AddProduct_CreatesProduct()
        {
            // Arrange - Criar um novo produto (Id gerado automaticamente)
            var newProduct = new Product { Name = "New Product", Price = 20.0M };

            // Act - Chamar o método PostProduct
            await _controller.PostProduct(newProduct);

            // Assert - Verificar se o produto foi adicionado
            var product = await _context.Products.FindAsync(newProduct.Id);
            Assert.NotNull(product);
            Assert.Equal(newProduct.Name, product.Name);
        }

        [Fact]
        public async Task UpdateProduct_UpdatesProduct()
        {
            // Arrange - Adicionar um produto ao contexto
            var product = new Product { Name = "Product 1", Price = 10.0M };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            // Act - Atualizar o produto
            product.Name = "Updated Product";
            await _controller.PutProduct(product.Id, product);

            // Assert - Verificar se o produto foi atualizado
            var updatedProduct = await _context.Products.FindAsync(product.Id);
            Assert.Equal("Updated Product", updatedProduct.Name);
        }

        [Fact]
        public async Task DeleteProduct_RemovesProduct()
        {
            // Arrange - Adicionar um produto ao contexto
            var product = new Product { Name = "Product 1", Price = 10.0M };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            // Act - Chamar o método DeleteProduct
            await _controller.DeleteProduct(product.Id);

            // Assert - Verificar se o produto foi removido
            var deletedProduct = await _context.Products.FindAsync(product.Id);
            Assert.Null(deletedProduct);
        }
    }
}
