# CrudLeads Web API

ASP.NET Web API 2 CRUD for Leads with clean architecture (no MediatR).

## Restore & Run

1. **Restore NuGet packages**  
   In Visual Studio: right-click solution → **Restore NuGet Packages**, or in Package Manager Console:
   ```powershell
   Update-Package -reinstall -ProjectName CrudLeads
   ```

2. **Build**  
   Build the solution (Ctrl+Shift+B).

3. **Run**  
   F5 or Ctrl+F5. The API runs and the database is created/updated on first request (EF migration + seed).

## Endpoints

- **GET** `/api/leads` – list all leads  
- **GET** `/api/leads/{id}` – get lead by id  
- **POST** `/api/leads` – create lead (body: `LeadCreateDto`)  
- **PUT** `/api/leads/{id}` – update lead (body: `LeadUpdateDto`)  
- **DELETE** `/api/leads/{id}` – delete lead  

## Swagger

- **Swagger UI:** `https://localhost:44369/swagger` (adjust port if different)

## Connection string

In `Web.config`, `DefaultConnection` uses LocalDB. To use SQL Server Express, change to:

```xml
<add name="DefaultConnection" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=CrudLeads;Integrated Security=True" providerName="System.Data.SqlClient" />
```

## Project layout

- **Domain** – `Lead` entity, `IGenericRepository<T>`, `IUnitOfWork`, `ILeadRepository`
- **Application** – DTOs, `ILeadService`, AutoMapper `LeadMappingProfile`
- **Infrastructure** – `ApplicationDbContext`, repositories, `UnitOfWork`, `LeadService`
- **API** – `LeadController`, Swagger, Autofac DI

## Validation

- Required: `FirstName`, `LastName`, `ContactNumber`
- Contact number: Indian format `91XXXXXXXXXX` (10 digits after 91, first digit 6–9)
