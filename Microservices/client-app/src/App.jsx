// src/App.jsx
import { NavLink, Routes, Route } from "react-router-dom";
import ProductList from "./components/ProductList";
import CustomerForm from "./components/CustomerForm";
import Cart from "./components/Cart";
import OrderHistory from "./components/OrderHistory";
import Footer from "./components/Footer";           
import "./App.css";                                 

export default function App() {
  return (
    <div className="app-wrapper">
      <nav className="app-nav">
        <NavLink to="/products" className={({ isActive }) => isActive ? 'active' : ''}>
          Productos
        </NavLink>
        <NavLink to="/customer" className={({ isActive }) => isActive ? 'active' : ''}>
          Nuevo Cliente
        </NavLink>
        <NavLink to="/cart" className={({ isActive }) => isActive ? 'active' : ''}>
          Carrito
        </NavLink>
        <NavLink to="/orders" className={({ isActive }) => isActive ? 'active' : ''}>
          Órdenes
        </NavLink>
      </nav>

      <main className="app-main">
        <Routes>
          <Route path="/products" element={<ProductList />} />
          <Route path="/customer" element={<CustomerForm />} />
          <Route path="/cart" element={<Cart />} />
          <Route path="/orders" element={<OrderHistory />} />
          <Route path="*" element={<ProductList />} />
        </Routes>
      </main>

      <Footer />  
    </div>
  );
}
