// src/components/ProductUpdate.jsx
import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom'; // Importando useNavigate
import { getProductById, updateProduct } from '../api';

const ProductUpdate = () => {
  const { id } = useParams(); // Obtém o ID do produto da URL
  const navigate = useNavigate(); // Substituindo useHistory por useNavigate
  const [name, setName] = useState('');
  const [price, setPrice] = useState('');
  const [description, setDescription] = useState('');

  useEffect(() => {
    const fetchProduct = async () => {
      try {
        const response = await getProductById(id);
        setName(response.data.name);
        setPrice(response.data.price);
        setDescription(response.data.description);
      } catch (error) {
        console.error('Error fetching product:', error);
      }
    };

    fetchProduct();
  }, [id]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    const updatedProduct = { id: parseInt(id), name, price: parseFloat(price), description };

    try {
      await updateProduct(id, updatedProduct);
      alert('Product updated successfully!');
      navigate('/'); // Usando navigate para redirecionar após a atualização
    } catch (error) {
      console.error('Error updating product:', error);
    }
  };

  return (
    <div>
      <h2>Update Product</h2>
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
        <div>
          <label>Description:</label>
          <input
            type="text"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            required
          />
        </div>
        <button type="submit">Update Product</button>
      </form>
    </div>
  );
};

export default ProductUpdate;
