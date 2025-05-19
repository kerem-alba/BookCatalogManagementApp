# Book Catalog Management App

This is a simple book catalog management system built with ASP.NET Core MVC. It allows users to perform basic CRUD operations such as listing, adding, updating, and deleting books.

## Features

- List all books
- Add a new book
- Update existing book details
- Delete a book
- Server-side validation (using both Data Annotations and a custom validator)
- SQLite database integration
- Logging with Serilog
- Seed initial data on application startup

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- Serilog (file-based logging)
- Dependency Injection

## Project Structure

- `Program.cs` – Application startup and service configuration
- `ApplicationDbContext.cs` – Entity Framework Core database context
- `Models/` – Domain models (e.g., Book)
- `Dtos/` – Data Transfer Objects for creating and updating books
- `Services/` – Business logic layer (e.g., IBookService, BookService)
- `Repositories/` – Data access layer (e.g., IBookRepository, BookRepository)
- `Validators/` – Custom input validation logic
- `Data/SeedData.cs` – Seeds initial data into the database
- `Views/` – Razor views for UI
- `Controllers/` – MVC controllers (e.g., BooksController)

