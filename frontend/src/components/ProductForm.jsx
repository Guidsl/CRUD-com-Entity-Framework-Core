// src/components/ProductForm.jsx
import React, { useState } from 'react';
import { addProduct, updateProduct } from '../api';

const ProductForm = ({ product, onSubmit }) => {
  const [name, setName] = useState(product ? product.name : '');

  const handleSubmit = async (e) => {
    e.preventDefault();
    const newProduct = { name };

    if (product) {
      await updateProduct(product.id, newProduct);
    } else {
      await addProduct(newProduct);
    }

    onSubmit();
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        value={name}
        onChange={(e) => setName(e.target.value)}
        placeholder="Product Name"
      />
      <button type="submit">{product ? 'Update' : 'Add'} Product</button>
    </form>
  );
};

export default ProductForm;
