namespace ef_crud_api.Models // Namespace onde a classe Product está localizada
{
    public class Product
    {
        public int Id { get; set; }             // Armazena o Id do produto
        public string Name { get; set; }        // Armazena o Nome do produto
        public decimal Price { get; set; }      // Armazena o Preço do produto
        public string Description { get; set; } // Armazena a Descrição do produto
    }
}
