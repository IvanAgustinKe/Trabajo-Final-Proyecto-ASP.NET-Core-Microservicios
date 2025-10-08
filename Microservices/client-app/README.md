# Microservices & React Client

Este repositorio contiene tres microservicios y una aplicación cliente SPA desarrollada con React:

- **ProductMicroservice**: gestión de productos (puerto: `7118`)
- **CustomerMicroservice**: gestión de clientes (puerto: `7275`)
- **OrderMicroservice**: gestión de órdenes (puerto: `7235`)
- **client-app**: aplicación React (Vite, puerto: `5173`)

## Prerrequisitos

- `.NET 8 SDK`
- `Node.js (v16+)` y `npm`
- `SQL Server LocalDB` (o modificar `ConnectionStrings` según tu base de datos)

## 1. Configurar la base de datos

Cada microservicio usa **EF Core** con LocalDB. El `appsettings.json` de cada uno debe incluir:


`"ConnectionStrings":` `{
  `"DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MicroservicesDb;Trusted_Connection=True;MultipleActiveResultSets=true"`
}`


## Si quieres otra BD, ajusta DefaultConnection.
## Para aplicar migraciones (desde PowerShell):

- `cd CustomerMicroservice`
- `dotnet ef database update`

- `cd ..\ProductMicroservice`
- `dotnet ef database update`

- `cd ..\OrderMicroservice`
- `dotnet ef database update`

2. Levantar los microservicios
Puedes ejecutar cada proyecto desde Visual Studio, seleccionando como proyectos de inicio múltiples:
- Proyecto -> Solución "Microservices" -> Configurar proyectos de inicio -> "Varios proyectos de inicio" -> Acción = "Iniciar"
O bien desde la terminal (una por cada microservicio):

# En una ventana de consola:
cd CustomerMicroservice
dotnet run

# abrir otra consola:
cd ProductMicroservice
dotnet run

# abrir otra consola:
cd OrderMicroservice
dotnet run

Cada uno expondrá su Swagger UI:
-  (Products)
-  (Customers)
-  (Orders)


3. Configurar y levantar la SPA (React)
En la raíz del cliente (client-app) esta el archivo .env con las URLs:

VITE_CUSTOMER_URL=https://localhost:7275
VITE_PRODUCT_URL=https://localhost:7118
VITE_ORDER_URL=https://localhost:7235

# Instala dependencias:

`cd client-app`
`npm install`

# Inicia el servidor de desarrollo:

`npm run dev`


Abre tu navegador en 
CORS: Los microservicios ya incluyen política CORS para permitir origen http://localhost:5173.

4. Flujo de pruebas
- Productos: desde Swagger o React, crea/lista productos.
- Clientes: crea un cliente.
- Carrito / Orden: selecciona cliente, agrega productos, genera orden.
- Historial: lista órdenes existentes.
