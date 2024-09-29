import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import ProductList from './components/ProductList';
import ProductForm from './components/ProductForm';
import ProductSearch from './components/ProductSearch';
import ProductUpdate from './components/ProductUpdate';

function App() {
  const [showProductList, setShowProductList] = useState(false);
  const [showProductForm, setShowProductForm] = useState(false);
  const [showProductSearch, setShowProductSearch] = useState(false);

  return (
    <Router>
      <div className="App">
        <header className="App-header">
          <h1>Product Management</h1>

          {/* Botões para exibir as funcionalidades */}
          <button onClick={() => setShowProductList(!showProductList)}>
            {showProductList ? 'Hide Product List' : 'Show Product List'}
          </button>
          <button onClick={() => setShowProductForm(!showProductForm)}>
            {showProductForm ? 'Hide Add Product Form' : 'Show Add Product Form'}
          </button>
          <button onClick={() => setShowProductSearch(!showProductSearch)}>
            {showProductSearch ? 'Hide Search Product' : 'Show Search Product'}
          </button>

          {/* Exibir os componentes com base no estado */}
          {showProductList && <ProductList />}
          {showProductForm && <ProductForm />}
          {showProductSearch && <ProductSearch />}

          <Routes>
            <Route path="/products/update/:id" element={<ProductUpdate />} />
          </Routes>
        </header>
      </div>
    </Router>
  );
}

export default App;
