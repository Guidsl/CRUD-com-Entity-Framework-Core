using System.ComponentModel.DataAnnotations;

namespace ef_crud_api.Models
{
    public class Product
    {
        public int Id { get; set; } // Armazena o Id do produto

        [Required] // Adiciona uma validação para garantir que o nome não é nulo
        public string Name { get; set; } = string.Empty; // Armazena o Nome do produto

        [Range(0.01, double.MaxValue)] // Adiciona uma validação para o preço
        public decimal Price { get; set; } // Armazena o Preço do produto

        public string Description { get; set; } = string.Empty; // Armazena a Descrição do produto
    }
}