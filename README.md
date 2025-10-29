# 🧩 Microservices & React Client

Este proyecto incluye tres microservicios desarrollados en .NET y una aplicación cliente SPA construida con React + Vite, redux sagas, micro fronted. El sistema permite gestionar productos, clientes y órdenes, con una interfaz web para operar sobre ellos.

---

## 📦 Estructura del Proyecto

| Componente             | Descripción             | Puerto |
|------------------------|-------------------------|--------|
| `ProductMicroservice`  | Gestión de productos    | `7118` |
| `CustomerMicroservice` | Gestión de clientes     | `7275` |
| `OrderMicroservice`    | Gestión de órdenes      | `7235` |
| `client-app`           | Aplicación React (Vite) | `5173` |

---

## 🛠️ Prerrequisitos

Antes de comenzar, asegurate de tener instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/)
- [Node.js v16+](https://nodejs.org/) y `npm`
- `SQL Server LocalDB` (o modificar las `ConnectionStrings` según tu base de datos)

---

## 🗄️ Configuración de Base de Datos

Cada microservicio utiliza **Entity Framework Core** con LocalDB.

### 🔗 Connection String

En el archivo `appsettings.json` de cada microservicio:


- "ConnectionStrings": {
-  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MicroservicesDb;Trusted_Connection=True;MultipleActiveResultSets=true"
- }  

# Si querés usar otra base de datos, ajustá la propiedad DefaultConnection

# Aplicar migracione

- cd CustomerMicroservice
- dotnet ef database update

- cd ../ProductMicroservice
- dotnet ef database update

- cd ../OrderMicroservice
- dotnet ef database update

# 2. Levantar los microservicios
## Opción A: Visual Studio
- Abrí la solución "Microservices"
- Configurá múltiples proyectos de inicio:
- Proyecto → Solución "Microservices" → Configurar proyectos de inicio → "Varios proyectos de inicio" → Acción = "Iniciar"

# En una consola
- cd CustomerMicroservice
- dotnet run

# En otra consola
- cd ProductMicroservice
- dotnet run

# En otra consola
- cd OrderMicroservice
- dotnet run

# Cada uno expondrá su Swagger UI en su respectivo puerto:
- Productos: https://localhost:7118/swagger
- Clientes: https://localhost:7275/swagger
- Órdenes: https://localhost:7235/swagger


# 3. Configurar y levantar la SPA (React)
En la raíz del cliente (client-app) está el archivo .env con las URLs:
- VITE_CUSTOMER_URL=https://localhost:7275
- VITE_PRODUCT_URL=https://localhost:7118
- VITE_ORDER_URL=https://localhost:7235

# Instalar dependencias
- cd client-app
- npm install

# Iniciar servidor de desarrollo
- npm run dev


# 4. Flujo de pruebas
- Productos: desde Swagger o React, crear/listar productos.
- Clientes: crear un cliente.
- Carrito / Orden: seleccionar cliente, agregar productos, generar orden.
- Historial: listar órdenes existentes.


