// src/api.js
import axios from 'axios';

const API_URL = 'http://localhost:5162/api/products';

// Função para obter todos os produtos
export const getProducts = async () => {
    try {
        const response = await axios.get(API_URL);
        return response; // Retorna a resposta
    } catch (error) {
        console.error('Error fetching products:', error);
        throw error; // Lança o erro para tratamento na chamada
    }
};

// Função para adicionar um novo produto
export const addProduct = (product) => {
    return axios.post(API_URL, product);
};

// Função para deletar um produto por ID
export const deleteProduct = (id) => {
    return axios.delete(`${API_URL}/${id}`);
};

// Função para buscar um produto por ID
export const getProductById = (id) => {
    return axios.get(`${API_URL}/${id}`);
};

// Função para atualizar um produto por ID
export const updateProduct = (id, product) => {
    return axios.put(`${API_URL}/${id}`, product);
};
