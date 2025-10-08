
import axios from 'axios';

const base = import.meta.env.VITE_ORDER_URL || 'https://localhost:7235';

export const getAllOrders = () =>
  axios.get(`${base}/api/Orders`).then(res => res.data);

export const getOrderById = id =>
  axios.get(`${base}/api/Orders/${id}`).then(res => res.data);

export const createOrder = dto =>
  axios.post(`${base}/api/Orders`, dto).then(res => res.data);
