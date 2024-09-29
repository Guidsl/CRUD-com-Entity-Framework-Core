// src/components/ProductForm.js
import React, { useState } from 'react';
import { addProduct } from '../api'; // Certifique-se de ter a função de API para adicionar produtos

const ProductForm = () => {
  const [name, setName] = useState('');
  const [price, setPrice] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    const newProduct = { name, price: parseFloat(price) };

    try {
      await addProduct(newProduct);
      alert('Product added successfully!');
      // Limpa os campos após a adição
      setName('');
      setPrice('');
    } catch (error) {
      console.error('Error adding product:', error);
    }
  };

  return (
    <div>
      <h2>Add New Product</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Name:</label>
          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Price:</label>
          <input
            type="number"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
            required
          />
        </div>
        <button type="submit">Add Product</button>
      </form>
    </div>
  );
};

export default ProductForm;
