import React, { useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { fetchProducts } from '../store/modules/products';

export default function ProductList() {
  const dispatch = useDispatch();
  const { list, loading, error } = useSelector(s => s.products);

  useEffect(() => {
    dispatch(fetchProducts());
  }, [dispatch]);

  return (
    <div className="card">
      <h2>Productos</h2>
      {loading && <p>Cargando productos…</p>}
      {error   && <p>Error al cargar: {error}</p>}

      {!loading && !error && (
        <ul className="plain">
          {list.map(p => (
            <li key={p.id}>
              {p.name} — ${p.price.toFixed(2)} — stock {p.stock}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}
