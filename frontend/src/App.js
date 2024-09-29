// src/App.js
import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import ProductList from './components/ProductList';
import ProductForm from './components/ProductForm';
import TestButton from './components/TestButton'; // Importa o TestButton

function App() {
  return (
    <Router>
      <div className="App">
        <header className="App-header">
          <h1>My Product App</h1>
          
          {/* Link para adicionar um novo produto */}
          <Link to="/products/new">Add New Product</Link>

          {/* Adicionando o TestButton aqui */}
          <TestButton />

          {/* Definindo rotas com Routes e Route */}
          <Routes>
            {/* Rota para o formulário de adicionar produto */}
            <Route path="/products/new" element={<ProductForm />} />
            
            {/* Rota para listar produtos */}
            <Route path="/" element={<ProductList />} />
          </Routes>
        </header>
      </div>
    </Router>
  );
}

export default App;
