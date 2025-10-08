
import axios from 'axios';

const base = import.meta.env.VITE_PRODUCT_URL || 'https://localhost:7118';

export const getAllProducts = () =>
  axios.get(`${base}/api/Products`).then(res => res.data);

export const getProductById = id =>
  axios.get(`${base}/api/Products/${id}`).then(res => res.data);

export const updateProductStock = (id, newStock) =>
  axios.put(`${base}/api/Products/${id}`, { stock: newStock })
       .then(res => res.data);
