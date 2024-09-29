import React from 'react';
import axios from 'axios';

const TestButton = () => {
  const handleButtonClick = async () => {
    try {
      // Envia uma requisição GET para o backend com withCredentials: false
      const response = await axios.get('http://localhost:5162/api/products/test-cors', {
        withCredentials: false // Adiciona essa linha para desabilitar cookies/credenciais
      });
      alert(response.data); // Mostra a resposta em um alerta
    } catch (error) {
      console.error('Error:', error);
      alert('Error fetching message from backend.');
    }
  };

  return (
    <button onClick={handleButtonClick}>
      Test Backend Connection
    </button>
  );
};

export default TestButton;
