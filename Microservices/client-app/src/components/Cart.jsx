import React, { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { fetchProducts } from '../store/modules/products';
import { fetchCustomers } from '../store/modules/customers';
import { createOrder, fetchOrders } from '../store/modules/orders';

export default function Cart() {
  const dispatch = useDispatch();
  const { list: products } = useSelector(s => s.products);
  const { list: customers } = useSelector(s => s.customers);
  const { loading: orderLoading, error: orderError } = useSelector(s => s.orders);

  const [customerId, setCustomerId] = useState('');
  const [productId, setProductId] = useState('');
  const [quantity, setQuantity] = useState(1);
  const [cart, setCart] = useState([]);

  useEffect(() => {
    dispatch(fetchProducts());
    dispatch(fetchCustomers());
  }, [dispatch]);

  const addItem = e => {
    e.preventDefault();
    if (!productId || quantity < 1) return;
    setCart(prev => {
      const exists = prev.find(i => i.productId === +productId);
      if (exists) {
        return prev.map(i =>
          i.productId === +productId
            ? { ...i, quantity: i.quantity + quantity }
            : i
        );
      }
      return [...prev, { productId: +productId, quantity }];
    });
  };

  const handleOrder = () => {
    if (!customerId || cart.length === 0) return;
    dispatch(createOrder({ customerId: +customerId, items: cart }));
    setCart([]);

    dispatch(fetchOrders());
  };

  return (
    <div>
      <h2>Armar y Enviar Orden</h2>
      {orderError && <p style={{ color: 'red' }}>{orderError}</p>}

      <div>
        <label>
          Cliente:{' '}
          <select
            value={customerId}
            onChange={e => setCustomerId(e.target.value)}
          >
            <option value="">-- Selecciona --</option>
            {customers.map(c => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}
          </select>
        </label>
      </div>

      <form onSubmit={addItem}>
        <label>
          Producto:{' '}
          <select
            value={productId}
            onChange={e => setProductId(e.target.value)}
          >
            <option value="">-- Selecciona --</option>
            {products.map(p => (
              <option key={p.id} value={p.id}>
                {p.name}
              </option>
            ))}
          </select>
        </label>{' '}
        <label>
          Cantidad:{' '}
          <input
            type="number"
            min="1"
            value={quantity}
            onChange={e => setQuantity(+e.target.value)}
          />
        </label>{' '}
        <button type="submit">Añadir al Carrito</button>
      </form>

      <h3>Carrito</h3>
      {cart.length === 0 ? (
        <p>El carrito está vacío</p>
      ) : (
        <ul>
          {cart.map(item => {
            const prod = products.find(p => p.id === item.productId);
            return (
              <li key={item.productId}>
                {prod?.name} × {item.quantity}
              </li>
            );
          })}
        </ul>
      )}

      <button
        onClick={handleOrder}
        disabled={!customerId || cart.length === 0 || orderLoading}
      >
        {orderLoading ? 'Enviando…' : 'Enviar Orden'}
      </button>
    </div>
  );
}
