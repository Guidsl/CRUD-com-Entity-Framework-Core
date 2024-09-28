// src/components/ProductDetail.jsx
import React from 'react';

const ProductDetail = ({ product }) => {
  return (
    <div>
      <h1>Product Details</h1>
      <p>Name: {product.name}</p>
    </div>
  );
};

export default ProductDetail;
