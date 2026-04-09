<h1 align="center">🌸 FlowerShop API</h1>

<p align="center">
  A RESTful back-end Web API for a retail floristry application, built with <strong>ASP.NET Core 9</strong>.
  <br />
  <a href="https://github.com/Lukash88/FlowerShop"><strong>Explore the repo »</strong></a>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-9.0-512BD4?style=flat-square&logo=dotnet" />
  <img src="https://img.shields.io/badge/EF%20Core-9.0-blue?style=flat-square" />
  <img src="https://img.shields.io/badge/Redis-StackExchange-red?style=flat-square&logo=redis" />
  <img src="https://img.shields.io/badge/Stripe-Payments-635BFF?style=flat-square&logo=stripe" />
  <img src="https://img.shields.io/badge/Swagger-OpenAPI-85EA2D?style=flat-square&logo=swagger" />
  <img src="https://img.shields.io/github/stars/Lukash88/FlowerShop?style=flat-square" />
</p>

---

## 📖 About

FlowerShop is a back-end RESTful API for an online retail floristry store. It supports browsing products, managing a shopping cart, placing orders, processing payments, and renting decoration items for special occasions.

This project was built as a **real-world backend simulation**, focusing on clean architecture, scalability, and maintainability using modern .NET technologies.

> 💡 The repository includes **380+ commits**, reflecting continuous development, refactoring, and feature expansion over time.

---

## 🧑‍💻 Developer Perspective

This project represents my hands-on experience designing and building a production-style backend system.

Key focus areas:

- Designing a **clean, layered architecture**
- Implementing **CQRS + Mediator patterns**
- Building secure **JWT-based authentication**
- Integrating external services (Stripe, Redis)
- Writing maintainable and scalable code
- Iterating consistently over time (380+ commits)

---

## 🏗️ Architecture & Project Structure

The solution follows a **clean, layered architecture** using the **CQRS** and **Mediator** patterns:
```bash
src/
├─ FlowerShop/ # ASP.NET Core Web API (entry point, controllers)
├─ FlowerShop.ApplicationServices/ # CQRS handlers, validators, mappings, business logic
├─ FlowerShop.DataAccess/ # Entity Framework Core, database models, migrations
└─ client/ # Angular front-end
```
---


### 🔎 Overview

- **API Layer (`FlowerShop`)**  
  Handles HTTP requests, routing, and controllers.

- **Application Layer (`ApplicationServices`)**  
  Contains business logic, CQRS handlers, validation, and mapping.

- **Data Layer (`DataAccess`)**  
  Manages database access, entities, and migrations via EF Core.

- **Client (`client`)**  
  Angular front-end application.

---

## ✨ Features

A feature-rich backend system covering real e-commerce use cases:

- 🌹 **Products, Flowers, Bouquets & Decorations** — Browse and manage floristry inventory
- 🛒 **Shopping Cart** — Redis-backed persistent basket
- 📦 **Orders & Delivery Methods** — Place orders with configurable delivery options
- 💳 **Payments** — Stripe payment processing integration
- 🎟️ **Coupons** — Discount coupon support
- 📅 **Reservations** — Rent decoration items for events and occasions
- 👤 **Authentication & Accounts** — JWT-based auth with ASP.NET Core Identity
- 🛡️ **Admin Panel** — Admin-scoped endpoints for store management
- 🔍 **Filtering & Pagination** — Powered by Sieve
- 📋 **Logging** — Structured logging via NLog

---

## ⚙️ Backend Design Highlights

- Clean Architecture with clear separation of concerns  
- CQRS pattern with MediatR  
- Global exception handling middleware  
- FluentValidation pipeline for request validation  
- Dependency Injection across layers  
- Secure JWT authentication and authorization  
- Redis caching for performance optimization  
- External payment integration (Stripe API)  

---

## 🛠️ Tech Stack

| Category | Technology |
|---|---|
| Framework | ASP.NET Core 9 |
| ORM | Entity Framework Core 9 |
| Database | SQL Server |
| Caching | Redis (StackExchange.Redis) |
| Messaging | MediatR 12 |
| Validation | FluentValidation |
| Mapping | AutoMapper 14 |
| Authentication | ASP.NET Core Identity + JWT Bearer |
| Payments | Stripe.net |
| Logging | NLog |
| API Docs | Swagger / Swashbuckle |
| Filtering | Sieve |

---

## 🔌 API Endpoints Overview

| Controller | Base Route | Description |
|---|---|---|
| `AccountController` | `/api/account` | Registration, login, profile |
| `AdminController` | `/api/admin` | Admin management |
| `ProductsController` | `/api/products` | Product catalog |
| `FlowersController` | `/api/flowers` | Flowers listing |
| `BouquetsController` | `/api/bouquets` | Bouquet management |
| `DecorationsController` | `/api/decorations` | Decoration items |
| `CartController` | `/api/cart` | Shopping basket |
| `OrdersController` | `/api/orders` | Order management |
| `PaymentsController` | `/api/payments` | Stripe payment processing |
| `DeliveryMethodsController` | `/api/deliverymethods` | Delivery options |
| `ReservationsController` | `/api/reservations` | Decoration rentals |
| `CouponsController` | `/api/coupons` | Discount coupons |

---

## 📌 Example Request

POST /api/orders

```json
{
  "basketId": "123",
  "deliveryMethodId": 2,
  "shippingAddress": {
    "city": "Helsinki"
  }
}
```

## 📌 Example Response

```json
{
  "orderId": 45,
  "status": "Pending",
  "total": 59.99
}
```

---

## 🚀 Getting Started
**Prerequisites**
- .NET 9 SDK
- SQL Server
- Docker (for Redis)
- Visual Studio 2022+ or VS Code

**Installation**

**1. Clone the repository**
```bash
git clone https://github.com/Lukash88/FlowerShop.git
cd FlowerShop
```

**2. Start Redis with Docker**
```bash
cd src
docker-compose up -d
```

**3. Configure the application**

Update src/FlowerShop/appsettings.json:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=FlowerShopDb;Trusted_Connection=True;"
  },
  "StripeSettings": {
    "SecretKey": "your_stripe_secret_key"
  }
}
```

**4. Apply database migrations**
```bash
dotnet ef database update --project src/FlowerShop.DataAccess --startup-project src/FlowerShop
```

**5. Run the API**
```bash
dotnet run --project src/FlowerShop
```

**6. Explore the API**

Navigate to /swagger to view API documentation.

---

## 🐳 Docker Services

| Service | Port | Description |
| ----------- | ------ | --------------- |
| Redis | 6379 | In-memory data store |
| Redis Commander	 | 8081 | 	Redis web UI |

---

## 🧪 Testing
- Unit testing with xUnit (recommended)
- Integration testing for API endpoints (recommended)

---

## 📈 Development Activity
- 380+ commits
- Continuous refactoring and feature expansion
- Incremental implementation of architecture patterns

---

## 🔍 Keywords (for recruiters)

ASP.NET Core Web API, C#, RESTful API development, Entity Framework Core, SQL Server, Clean Architecture, CQRS, MediatR, Dependency Injection, JWT Authentication, API Security, Redis caching, Stripe API integration, Docker, scalable backend systems, asynchronous programming, logging (NLog), Swagger/OpenAPI

---

## 🚀 Future Improvements & Roadmap

Planned enhancements to evolve the project toward a more production-ready and scalable system:

### 🧩 Architecture
- Migrate toward a **microservices architecture** (separating Orders, Payments, Catalog, and Identity services)
- Introduce **API Gateway** for centralized routing and cross-cutting concerns
- Implement **event-driven communication** (e.g., message broker like RabbitMQ or Azure Service Bus)

### ⚡ Performance & Scalability
- Expand Redis usage for **distributed caching**
- Add **rate limiting** and request throttling
- Optimize database queries and indexing strategies

### 🔐 Security
- Implement **refresh tokens** and improved token lifecycle management
- Add **role-based access control (RBAC)** with fine-grained permissions
- Improve API security with **rate limiting and protection against common attacks**

### 🧪 Testing & Quality
- Increase **unit and integration test coverage**
- Add **end-to-end testing**
- Introduce **CI/CD pipelines** (GitHub Actions / Azure DevOps)

### ☁️ DevOps & Deployment
- Containerize services with **Docker**
- Deploy to **cloud platform** (Azure / AWS)
- Add **monitoring & observability** (e.g., OpenTelemetry, Application Insights)

### 🌐 Frontend
- Develop **Angular client application**
- Improve user experience and integrate fully with backend APIs

---

## ⭐ Why this project matters

This project demonstrates my ability to:

- Build a complete backend system from scratch
- Apply modern architectural patterns in practice
- Work consistently on a long-term codebase
- Integrate multiple technologies into a cohesive solution

It reflects my goal to grow as a backend developer and contribute to scalable, real-world systems.

## 👤 Author

Lukash88
GitHub: https://github.com/Lukash88

<p align="center">Made with ❤️ and 🌸</p>
