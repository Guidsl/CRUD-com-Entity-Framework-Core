import React from 'react';
import './App.css';
import ProductList from './components/ProductList';
import ProductForm from './components/ProductForm';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>My Product App</h1>

        {/* Formulário para adicionar um novo produto */}
        <ProductForm />

        {/* Lista de produtos */}
        <ProductList />
      </header>
    </div>
  );
}

export default App;
