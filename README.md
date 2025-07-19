# CoreAPIWithMySQL

A .NET 8 Web API demonstrating enterprise-ready architecture with:
- Entity Framework Core (EF Core) and Dapper for MySQL database access
- Repository and Service layers
- Clean separation of concerns
- Swagger/OpenAPI support

## Features
- Employee CRUD operations using both EF Core and Dapper
- Repository pattern for data access abstraction
- Service layer for business logic
- Easily extensible and testable

## Project Structure

```
CoreAPIWithMySQL/
?
??? Controllers/
?   ??? EmployeeController.cs         # API endpoints for Employee (uses both EF Core and Dapper services)
?   ??? WeatherForecastController.cs  # Example controller
?
??? Data/
?   ??? AppDbContext.cs              # EF Core DbContext
?   ??? EmployeeRepository.cs        # Repository pattern for Employee
?
??? Models/
?   ??? Employee.cs                  # Employee entity
?
??? Services/
?   ??? EmployeeService.cs           # Service layer for Employee (EF Core)
?   ??? IDapperEmployeeService.cs    # Dapper service interface
?   ??? DapperEmployeeService.cs     # Dapper-based CRUD implementation
?
??? Migrations/                      # EF Core migrations
?
??? appsettings.json                 # Configuration (connection string, etc.)
??? Program.cs                       # App startup and DI configuration
??? CoreAPIWithMySQL.csproj           # Project file
```

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)

### Clone the Repository
```sh
git clone <your-repo-url>
cd CoreAPIWithMySQL
```

### Configure the Database
Edit `appsettings.json` with your MySQL connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=EmpDB;user=mwaseem;password=xxxxx"
  }
}
```

### Apply EF Core Migrations
This will create the database and tables:
```sh
dotnet ef database update
```

### Run the Project
```sh
dotnet run
```

The API will be available at `https://localhost:5001` (or the port shown in the console).

### API Usage
- Swagger UI: Navigate to `/swagger` for interactive API docs.
- Employee endpoints:
  - `GET /employee` (Dapper)
  - `GET /employee/{id}` (EF Core)
  - `POST /employee` (EF Core)
  - `PUT /employee/{id}` (EF Core)
  - `DELETE /employee/{id}` (EF Core)

## Extending
- Add new entities to `Models/` and update `AppDbContext`.
- Add new repositories/services for additional business logic.
- Use Dapper or EF Core as needed for each use case.

## License
MIT
