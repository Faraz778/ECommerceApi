# 🛒 ECommerce API

A RESTful E-Commerce API built with **ASP.NET Core Web API** using **C#**, **Entity Framework Core**, and **SQL Server**.

The project includes product and category management, user registration/login, password hashing, JWT authentication, and order management.

## 🚀 Features

- 🔐 User Registration & Login
- 🔑 JWT Authentication & Authorization
- 🔒 Password Hashing using ASP.NET Core Identity
- 📦 Product CRUD Operations
- 🗂️ Category CRUD Operations
- 🛒 Order Management
- 📋 Order Items
- 📄 DTOs for API requests
- 🏗️ Service Layer Architecture
- 🗄️ Entity Framework Core
- 🛢️ SQL Server Database
- 🧪 API Testing with Postman
- 🔧 Entity Framework Core Migrations
- ⚙️ User Secrets for sensitive configuration

## 🛠️ Technologies Used

- C#
- ASP.NET Core Web API
- .NET
- Entity Framework Core
- SQL Server
- LINQ
- JWT
- ASP.NET Core Identity PasswordHasher
- Postman
- Git & GitHub

## 📁 Project Structure

```text
ECommerceApi
│
├── Controllers
│   ├── CategoriesController.cs
│   ├── ProductsController.cs
│   ├── UsersController.cs
│   └── OrdersController.cs
│
├── Data
│   └── AppDbContext.cs
│
├── DTOs
│   ├── RegisterUserDto.cs
│   ├── LoginUserDto.cs
│   ├── CreateProductDto.cs
│   ├── UpdateProductDto.cs
│   ├── CreateOrderDto.cs
│   └── CreateOrderItemDto.cs
│
├── Models
│   ├── User.cs
│   ├── Category.cs
│   ├── Product.cs
│   ├── Order.cs
│   └── OrderItem.cs
│
├── Services
│   ├── IUserService.cs
│   ├── UserService.cs
│   ├── ICategoryService.cs
│   ├── CategoryService.cs
│   ├── IProductService.cs
│   ├── ProductService.cs
│   ├── IOrderService.cs
│   ├── OrderService.cs
│   ├── IOrderItemService.cs
│   └── OrderItemService.cs
│
└── Program.cs
