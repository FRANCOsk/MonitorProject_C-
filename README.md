# Monitor Project API

A modern ASP.NET Core Web API that manages people and records application-level events such as additions, updates, warnings, errors, and reads.

## Highlights

- ASP.NET Core Web API on .NET 10
- RESTful, typed controller responses
- automatic request-model validation
- dependency injection and layered service design
- cross-platform structured logging
- in-memory person and change storage
- OpenAPI support in development
- MSTest coverage and GitHub Actions CI
- automated NuGet and workflow dependency updates

## Project structure

```text
WebFEB/
├── Controllers/    HTTP API endpoints
├── Models/         validated data-transfer objects
├── Services/       business logic and service contracts
├── Storage/        in-memory data storage
├── Enums/          change-type definitions
└── Program.cs      application configuration

WebFEBTests/         automated tests
```

## Requirements

- .NET 10 SDK

## Run locally

```bash
dotnet restore WebFEB/WebFEB.sln
dotnet run --project WebFEB/WebFEB.csproj
```

The application redirects HTTP requests to HTTPS. In development, ASP.NET Core exposes an OpenAPI document.

## Build and test

```bash
dotnet build WebFEB/WebFEB.sln --configuration Release
dotnet test WebFEB/WebFEB.sln --configuration Release
```

## API overview

### People

```http
GET    /api/people
POST   /api/people
PUT    /api/people/{email}
DELETE /api/people/{email}
```

### Changes and health

```http
GET /api/changes
GET /api/changes/{id}
GET /api/changes/health
```

## Technology stack

- C#
- .NET 10
- ASP.NET Core
- Microsoft.AspNetCore.OpenApi
- Microsoft.Extensions.Logging
- MSTest
- GitHub Actions

## Security and maintenance

Dependabot checks NuGet and GitHub Actions dependencies every week. Pull requests are validated through restore, release build, and test stages before they are merged.

## Status

This is a demonstration project focused on clean API structure, dependency injection, request validation, structured logging, and automated quality checks. The storage layer is intentionally in-memory; a production deployment would require persistent storage, authentication, authorization, concurrency controls, and database migrations.
