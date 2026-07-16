# Monitor Project API

A small ASP.NET Core Web API that manages people and records application-level changes such as additions, updates, warnings, and validation errors.

## Highlights

- ASP.NET Core Web API on .NET 9
- Dependency injection and layered service design
- Asynchronous CRUD operations
- Change tracking for important application events
- OpenAPI support in the development environment
- Separate test project

## Project structure

```text
WebFEB/
├── Controllers/    HTTP API endpoints
├── Models/         Data transfer objects
├── Services/       Business logic and service contracts
├── Storage/        In-memory data storage
├── Enums/          Change type definitions
└── Program.cs      Application configuration

WebFEBTests/         Automated tests
```

## Requirements

- .NET 9 SDK

## Run locally

```bash
dotnet restore
dotnet run --project WebFEB/WebFEB.csproj
```

The application redirects HTTP requests to HTTPS. In development, the OpenAPI document is exposed by ASP.NET Core.

## Build and test

```bash
dotnet build
dotnet test
```

## Main API capabilities

- List people
- Add a person
- Update a person
- Delete a person
- Record warnings, errors, and successful changes

## Technology stack

- C#
- .NET 9
- ASP.NET Core
- Microsoft.AspNetCore.OpenApi
- xUnit test project

## Status

This repository is a demonstration project focused on clean API structure, dependency injection, asynchronous services, and change tracking.
