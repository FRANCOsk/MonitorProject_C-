# Monitor Project API

ASP.NET Core backend for managing monitored people and recording changes detected by the monitoring service.

## Technology

- .NET 9
- ASP.NET Core Web API
- MSTest
- OpenAPI

## Repository structure

- `WebFEB/` — API application, controllers, services, storage and domain models
- `WebFEBTests/` — automated unit tests

## Prerequisites

Install the .NET 9 SDK.

## Restore, build and test

```bash
dotnet restore
dotnet build --configuration Release --no-restore
dotnet test --configuration Release --no-build
```

## Run locally

```bash
dotnet run --project WebFEB/WebFEB.csproj
```

The development server prints its HTTP and HTTPS URLs to the console. OpenAPI endpoints are available when enabled by the application environment.

## Dependency and security checks

```bash
dotnet list WebFEB/WebFEB.csproj package --vulnerable --include-transitive
dotnet list WebFEBTests/WebFEBTests.csproj package --vulnerable --include-transitive
```

GitHub Actions executes restore, release build, tests and vulnerability checks for pull requests and changes to `main`.

## Development notes

- Do not commit `.vs`, `bin`, `obj`, user-specific IDE files, local secrets or generated IIS Express configuration.
- Keep credentials and environment-specific settings outside source control. Use environment variables or .NET user secrets for local development.
- Add tests for service and controller behavior when changing business logic.
