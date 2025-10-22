# dotPokeNET

## Descripción General

dotPokeNET es una solución basada en .NET 8 que implementa una API backend siguiendo los principios de Clean Architecture. Su objetivo principal es componer y entregar dinámicamente URLs válidas de la [PokeAPI](https://pokeapi.co/) según el recurso y parámetro solicitado. Por ejemplo, si el backend recibe el recurso `pokemon` y el parámetro `pikachu`, retorna la URL completa: `https://pokeapi.co/api/v2/pokemon/pikachu`.

Esta solución está diseñada para ser consumida por un frontend desarrollado en React + TypeScript, facilitando la integración y el consumo de la PokeAPI de manera centralizada y controlada.

---

## Arquitectura

El backend está estructurado bajo los principios de **Clean Architecture**, separando responsabilidades en diferentes capas:

- **Domain**: Contiene las entidades y modelos de dominio.
- **Application**: Incluye la lógica de negocio, casos de uso, servicios y contratos (interfaces de repositorios, DTOs, handlers con MediatR, etc.).
- **Persistence**: Implementa el acceso a datos y la infraestructura de almacenamiento.
- **WebAPI**: Expone los endpoints HTTP, configura middlewares, Swagger, CORS, etc.
- **ConsoleApp**: Proyecto auxiliar para migraciones y carga inicial de datos.

---

## Proyectos en la Solución

- **Domain**: Define las entidades principales como `EntityPokeAPI` y `EntityResource`.
- **Application**: Implementa la lógica para componer URLs, manejar recursos y endpoints, y coordina la interacción entre capas mediante patrones como Repository y Unit of Work.
- **Persistence**: Gestiona la persistencia de las partes que conforman las URLs de la PokeAPI.
- **WebAPI**: Expone endpoints RESTful para recibir solicitudes de recursos y parámetros, y retorna la URL correspondiente de la PokeAPI. Incluye documentación Swagger y soporte para JWT.
- **ConsoleApp**: Permite ejecutar migraciones y operaciones administrativas sobre la base de datos.

---

## Ejemplo de Uso

**Solicitud:**
```json
{
  "resource": "pokemon",
  "parameter": "pikachu"
}
```

**Respuesta:**
```json
{
  "url": "https://pokeapi.co/api/v2/pokemon/pikachu"
}
```

---

## Frontend

El frontend está desarrollado en React + TypeScript (ver carpeta `webapp`). Consume la WebAPI para obtener URLs de la PokeAPI y mostrar información relevante al usuario.

---

## Desarrollo y Despliegue

1. **Clonar el repositorio**
2. **Configurar la base de datos** (si aplica)
3. **Ejecutar migraciones** usando el proyecto ConsoleApp
4. **Levantar el backend**
   ```bash
   dotnet run --project WebAPI/WebAPI.csproj
   ```
5. **Levantar el frontend**
   ```bash
   cd webapp
   npm install
   npm run dev
   ```

---

## Tecnologías principales
- .NET 8
- Clean Architecture
- MediatR
- Entity Framework Core
- React + TypeScript + Vite
- Swagger (OpenAPI)

---

## English Documentation

# dotPokeNET

## General Description

dotPokeNET is a solution based on .NET 8 that implements a backend API following Clean Architecture principles. Its main goal is to dynamically compose and deliver valid [PokeAPI](https://pokeapi.co/) URLs according to the requested resource and parameter. For example, if the backend receives the resource `pokemon` and the parameter `pikachu`, it returns the full URL: `https://pokeapi.co/api/v2/pokemon/pikachu`.

This solution is designed to be consumed by a frontend developed in React + TypeScript, facilitating centralized and controlled integration and consumption of the PokeAPI.

---

## Architecture

The backend is structured following **Clean Architecture** principles, separating responsibilities into different layers:

- **Domain**: Contains domain entities and models.
- **Application**: Includes business logic, use cases, services, and contracts (repository interfaces, DTOs, handlers with MediatR, etc.).
- **Persistence**: Implements data access and storage infrastructure.
- **WebAPI**: Exposes HTTP endpoints, configures middlewares, Swagger, CORS, etc.
- **ConsoleApp**: Auxiliary project for migrations and initial data loading.

---

## Solution Projects

- **Domain**: Defines main entities such as `EntityPokeAPI` and `EntityResource`.
- **Application**: Implements logic to compose URLs, manage resources and endpoints, and coordinates interaction between layers using patterns like Repository and Unit of Work.
- **Persistence**: Manages persistence of the parts that make up the PokeAPI URLs.
- **WebAPI**: Exposes RESTful endpoints to receive resource and parameter requests, and returns the corresponding PokeAPI URL. Includes Swagger documentation and JWT support.
- **ConsoleApp**: Allows running migrations and administrative operations on the database.

---

## Usage Example

**Request:**
```json
{
  "resource": "pokemon",
  "parameter": "pikachu"
}
```

**Response:**
```json
{
  "url": "https://pokeapi.co/api/v2/pokemon/pikachu"
}
```

---

## Frontend

The frontend is developed in React + TypeScript (see the `webapp` folder). It consumes the WebAPI to obtain PokeAPI URLs and display relevant information to the user.

---

## Development and Deployment

1. **Clone the repository**
2. **Configure the database** (if applicable)
3. **Run migrations** using the ConsoleApp project
4. **Start the backend**
   ```bash
   dotnet run --project WebAPI/WebAPI.csproj
   ```
5. **Start the frontend**
   ```bash
   cd webapp
   npm install
   npm run dev
   ```

---

## Main Technologies
- .NET 8
- Clean Architecture
- MediatR
- Entity Framework Core
- React + TypeScript + Vite
- Swagger (OpenAPI)

---

## License

Cornelius D. Von ® 2025

---

For more information, check each project's documentation or contact the support team.