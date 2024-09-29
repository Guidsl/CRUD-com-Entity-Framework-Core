// src/api.js
import axios from 'axios';

const API_URL = 'http://localhost:5162/api/products';

export const getProducts = async () => {
    try {
        const response = await axios.get(API_URL);
        return response; // Retorna a resposta
    } catch (error) {
        console.error('Error fetching products:', error);
        throw error; // Lança o erro para tratamento na chamada
    }
};
export const addProduct = (product) => {
    return axios.post(API_URL, product);
};
