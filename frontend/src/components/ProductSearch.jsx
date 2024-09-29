import React, { useState } from 'react';
import { getProductById, deleteProduct } from '../api'; // Certifique-se de ter a função de API para buscar e deletar produto
import { Link } from 'react-router-dom'; // Importe Link para redirecionar para a página de atualização

const ProductSearch = () => {
  const [id, setId] = useState('');
  const [product, setProduct] = useState(null);

  const handleSearch = async (e) => {
    e.preventDefault();
    try {
      const response = await getProductById(id); // Busque o produto pelo ID
      setProduct(response.data);
    } catch (error) {
      console.error('Error fetching product:', error);
      alert('Product not found');
    }
  };

  const handleDelete = async (id) => {
    try {
      await deleteProduct(id); // Chame a função de deletar
      alert('Product deleted successfully!');
      setProduct(null); // Limpa o estado do produto
      setId(''); // Limpa o ID no input
    } catch (error) {
      console.error('Error deleting product:', error);
      alert('Error deleting product');
    }
  };

  return (
    <div>
      <h2>Search Product by ID</h2>
      <form onSubmit={handleSearch}>
        <input
          type="number"
          value={id}
          onChange={(e) => setId(e.target.value)}
          placeholder="Enter Product ID"
          required
        />
        <button type="submit">Search</button>
      </form>
      {product && (
        <div>
          <h3>Product Details</h3>
          <strong>Name:</strong> {product.name}<br />
          <strong>Price:</strong> ${product.price}<br />
          <strong>Description:</strong> {product.description}<br />
          <button onClick={() => handleDelete(product.id)}>Delete</button> {/* Botão de deletar */}
          <Link to={`/products/update/${product.id}`}>
            <button>Update</button> {/* Botão de atualizar */}
          </Link>
        </div>
      )}
    </div>
  );
};

export default ProductSearch;
