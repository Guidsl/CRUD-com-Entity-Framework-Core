import React from 'react';

const ProductDetail = ({ product }) => {
  return (
    <div>
      <h1>Product Details</h1>
      <p>Name: {product.name}</p>
      <p>Description: {product.description}</p>
      <p>Price: R$ {product.price}</p>
      {/* Adicione um botão de voltar se necessário */}
      <button onClick={() => window.history.back()}>Go Back</button>
    </div>
  );
};

export default ProductDetail;
