
import axios from 'axios';

const base = import.meta.env.VITE_CUSTOMER_URL || 'https://localhost:7275';

export const getAllCustomers = () =>
  axios.get(`${base}/api/Customers`).then(res => res.data);

export const getCustomerById = id =>
  axios.get(`${base}/api/Customers/${id}`).then(res => res.data);

export const createCustomer = dto =>
  axios.post(`${base}/api/Customers`, dto).then(res => res.data);
