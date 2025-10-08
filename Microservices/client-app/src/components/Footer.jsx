import React from 'react';
import './styles/Footer.css'; 

export default function Footer() {
  return (
    <footer className="app-footer">
      <div className="footer-content">
        <span>© {new Date().getFullYear()} Mi Tienda Microservices</span>
        <nav className="footer-nav">
          <a href="/privacy">Privacidad</a>
          <a href="/terms">Términos</a>
        </nav>
      </div>
    </footer>
  );
}
