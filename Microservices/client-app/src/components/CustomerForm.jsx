import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {
  fetchCustomers,
  createCustomer
} from '../store/modules/customers';

export default function CustomerForm() {
  const dispatch = useDispatch();
  const { loading, error } = useSelector(s => s.customers);
  const [form, setForm] = useState({ name: '', email: '', address: '' });

  const handleChange = e => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = e => {
    e.preventDefault();
    dispatch(createCustomer(form));
    setForm({ name: '', email: '', address: '' });
    dispatch(fetchCustomers());
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Crear Nuevo Cliente</h2>
      {error && <p style={{ color: 'red' }}>Error: {error}</p>}
      <div>
        <label>
          Nombre:{' '}
          <input
            name="name"
            value={form.name}
            onChange={handleChange}
            required
          />
        </label>
      </div>
      <div>
        <label>
          Email:{' '}
          <input
            name="email"
            type="email"
            value={form.email}
            onChange={handleChange}
            required
          />
        </label>
      </div>
      <div>
        <label>
          Dirección:{' '}
          <input
            name="address"
            value={form.address}
            onChange={handleChange}
            required
          />
        </label>
      </div>
      <button type="submit" disabled={loading}>
        {loading ? 'Guardando…' : 'Guardar Cliente'}
      </button>
    </form>
  );
}
