// src/components/ProductList.js
import React, { useEffect, useState } from 'react';
import { getProducts, deleteProduct } from '../api'; // Importe a função de deletar
import { Link } from 'react-router-dom'; // Importe Link

const ProductList = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const response = await getProducts();
        setProducts(response.data);
      } catch (error) {
        console.error('Error fetching products:', error);
      }
    };

    fetchProducts();
  }, []);

  const handleDelete = async (id) => {
    try {
      await deleteProduct(id); // Chame a função de deletar
      setProducts(products.filter(product => product.id !== id)); // Atualize a lista
      alert('Product deleted successfully!');
    } catch (error) {
      console.error('Error deleting product:', error);
    }
  };

  return (
    <div>
      <h2>Product List</h2>
      <ul>
        {products.map(product => (
          <li key={product.id}>
            <strong>{product.name}</strong> - ${product.price}<br />
            <em>Description:</em> {product.description}
            <br />
            <button onClick={() => handleDelete(product.id)}>Delete</button> {/* Botão de deletar */}
            <Link to={`/products/update/${product.id}`}>
              <button>Update</button> {/* Botão de atualizar */}
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ProductList;
