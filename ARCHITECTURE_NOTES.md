# CrudLeads – Architecture & Domain Notes

## Tech Stack

- **Framework**: .NET Framework 4.6.1
- **API**: ASP.NET Web API 2
- **ORM**: Entity Framework 6 (Code First, Migrations)
- **DI**: Autofac (Web API integration)
- **Mapping**: AutoMapper
- **Docs**: Swagger / Swashbuckle
- **DB**: SQL Server (`DESKTOP-C05KS37\MSSQLSERVER01`, DB: `Leads`, Windows Auth)

## Project Structure (Logical Layers in One Project)

- `Domain`
  - `Entities`
    - `Broker`
    - `Lead` (used as FollowUp/activity)
    - `ActivityType`
  - `Interfaces`
    - `IGenericRepository<T>`
    - `IBrokerRepository`
    - `ILeadRepository`
    - `IActivityTypeRepository`
    - `IUnitOfWork`
- `Application`
  - `DTOs` for `Broker`, `Lead`, `ActivityType`
  - `Interfaces` for services:
    - `IBrokerService`
    - `ILeadService`
    - `IActivityTypeService`
  - `Mapping` (AutoMapper profiles)
- `Infrastructure`
  - `Data`
    - `ApplicationDbContext`
  - `Repositories`
    - `GenericRepository<T>`
    - `BrokerRepository`
    - `LeadRepository`
    - `ActivityTypeRepository`
  - `Services`
    - `BrokerService`
    - `LeadService`
    - `ActivityTypeService`
  - `UnitOfWork`
- `Controllers` (Web API)
  - `BrokerController`
  - `LeadController`
  - `ActivityTypeController`
  - `DefaultController` (redirects root `/` to `/swagger`)
- `App_Start`
  - `WebApiConfig`
  - `SwaggerConfig`
  - `AutofacConfig`
  - `FilterConfig`

## Key Domain Concepts

### Broker

Represents a main party (customer/broker).

All Ids are `long`.

Main fields:

- `Id`
- `FirstName`, `LastName`
- `ContactNumber`
  - Indian format regex: `^91[6-9]\d{9}$`
- `SalesAgent`
- `CoOwner`
- `Project`
- `LeadSource` (text; values like `Other`, `Facebook`, `99acres`)
- `ChannelPartner`
- `SourcingManager`
- `Remark`
- `CreatedAt`, `UpdatedAt`

### ActivityType (Master)

Master table for activity/follow-up types.

- `Id` (`long`)
- `Name` (`string`, max 50)

Seeded values:

- `Call`
- `Mail`
- `Meeting`
- `Site Visit`
- `Other`

### Lead (Used as FollowUp / Activity)

This is not the original simple Lead entity anymore.  
Now it represents FollowUps / activities for a Broker.

Fields:

- `Id` (`long`)
- `BrokerId` (`long`, FK → `Broker`)
- `CreatedDate` (`DateTime`) – when follow-up was created
- `Title` (`string`, max 200)
- `Remark` (`string`)
- `Mobile` (`string`, max 20) – free-format mobile (international if needed)
- `ActivityTypeId` (`long`, FK → `ActivityType`)
- `AssignedBy` (`int?`) – current user/sales agent id (nullable)
- `ScheduleDate` (`DateTime`) – due date & time of the follow-up
- `ReminderMinutes` (`int?`, 0–1440)
- `RemindMe` (`bool`)
- `Completed` (`bool`)
- `CompletedOn` (`DateTime?`)
- `CompletedBy` (`int?`)
- `Stage` (`string`, max 100)
- `Status` (`string`, max 100) – used for values like `New`, `Untouched`, `Returned`
- `Action` (`string`, max 200) – next action or note
- Navigation:
  - `Broker` (FK `BrokerId`)
  - `ActivityType` (FK `ActivityTypeId`)

## FollowUp / Activity Semantics

A FollowUp for a Broker is represented by a `Lead` record.

UI fields mapping (example):

- `Last Activity` → derived from latest `Lead` (FollowUp) for that `Broker`
- `Assigned to` → `AssignedBy`
- `Due Date & Time` → `ScheduleDate`
- `Remark` → `Remark`
- `Type` → `ActivityType.Name` (e.g. `OTHER`)
- `Created By` → can later be mapped from a user table
- `Completed on` → `CompletedOn`
- `TaskCompleted` flag → `Completed` + `CompletedOn` + `CompletedBy`
- `Status` → `Status` field on `Lead`:
  - expected values: `New`, `Untouched`, `Returned`

## API Overview

- `GET /api/brokers`
- `GET /api/brokers/{id}`
- `POST /api/brokers`
- `PUT /api/brokers/{id}`
- `DELETE /api/brokers/{id}`

- `GET /api/leads`
- `GET /api/leads/{id}`
- `GET /api/leads/broker/{brokerId}`
- `POST /api/leads`
- `PUT /api/leads/{id}`
- `DELETE /api/leads/{id}`

- `GET /api/activitytypes`
- `GET /api/activitytypes/{id}`

## Migrations / DB

- Initial migration created basic schema.
- Refactor migration (`RefactorToBrokerAndLead`) transformed old `Leads` table into new `Brokers` + `Leads` (follow-ups) + `ActivityTypes`.
- Automatic migrations: disabled (`AutomaticMigrationsEnabled = false`).
- Database initializer: `MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>` configured in `Global.asax`.

## Swagger / DI

- Swagger enabled via `SwaggerConfig.Register(config)` and XML comments file `CrudLeads.XML`.
- Autofac configured in `AutofacConfig.Configure()`:
  - Registers Web API controllers.
  - Registers `ApplicationDbContext`, `UnitOfWork`, AutoMapper profiles, and all services.

