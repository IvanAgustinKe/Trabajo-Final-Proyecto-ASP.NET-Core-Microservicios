import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchOrders } from '../store/modules/orders';

export default function OrderHistory() {
  const dispatch = useDispatch();
  const { list, loading, error } = useSelector(s => s.orders);

  useEffect(() => {
    dispatch(fetchOrders());
  }, [dispatch]);

  if (loading) return <p>Cargando órdenes…</p>;
  if (error)   return <p style={{ color: 'red' }}>Error: {error}</p>;

  return (
    <div>
      <h2>Historial de Órdenes</h2>
      {list.length === 0 ? (
        <p>No hay órdenes.</p>
      ) : (
        list.map(order => (
          <div key={order.id} style={{ marginBottom: '1rem' }}>
            <strong>Orden #{order.id}</strong> —{' '}
            {new Date(order.createdAt).toLocaleString()} — Total:{' '}
            ${order.total.toFixed(2)}
            <ul>
              {order.items.map(item => (
                <li key={item.productId}>
                  {item.name} — ${item.unitPrice.toFixed(2)} ×{' '}
                  {item.quantity} = ${item.subtotal.toFixed(2)}
                </li>
              ))}
            </ul>
          </div>
        ))
      )}
    </div>
  );
}
