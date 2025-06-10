# .NET 9.0 Upgrade Plan

## Execution Steps

1. Validate that an .NET 9.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 9.0 upgrade.
3. Upgrade src/SelfFinanceApp.Domain/SelfFinanceApp.Domain.csproj
4. Upgrade src/SelfFinanceApp.Persistance/SelfFinanceApp.Persistance.csproj
5. Upgrade tests/SelfFinanceApp.Tests.Shared/SelfFinanceApp.Tests.Shared.csproj
6. Upgrade src/SelfFinanceApp.Application/SelfFinanceApp.Application.csproj
7. Upgrade src/SelfFinanceApp.Infrastructure/SelfFinanceApp.Infrastructure.csproj
8. Upgrade tests/SelfFinanceApp.Application.Tests/SelfFinanceApp.Application.Tests.csproj
9. Upgrade tests/SelfFinanceApp.Infrastructure.Tests/SelfFinanceApp.Infrastructure.Tests.csproj
10. Upgrade tests/SelfFinanceApp.Domain.Tests/SelfFinanceApp.Domain.Tests.csproj
11. Upgrade src/SelfFinanceApp.Api/SelfFinanceApp.Api.csproj
12. Run unit tests to validate upgrade in the projects listed below:
  - tests/SelfFinanceApp.Tests.Shared/SelfFinanceApp.Tests.Shared.csproj
  - tests/SelfFinanceApp.Application.Tests/SelfFinanceApp.Application.Tests.csproj
  - tests/SelfFinanceApp.Infrastructure.Tests/SelfFinanceApp.Infrastructure.Tests.csproj
  - tests/SelfFinanceApp.Domain.Tests/SelfFinanceApp.Domain.Tests.csproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

| Project name                                   | Description                 |
|:-----------------------------------------------|:---------------------------:|

### Aggregate NuGet packages modifications across all projects

| Package Name                        | Current Version | New Version | Description                         |
|:------------------------------------|:---------------:|:-----------:|:------------------------------------|
| Microsoft.AspNetCore.Http.Abstractions | 2.2.0 | 2.3.0 | Deprecated, replace as recommended |
| Microsoft.AspNetCore.JsonPatch | 8.0.10 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.AspNetCore.Mvc.NewtonsoftJson | 8.0.10 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.AspNetCore.OpenApi | 8.0.10 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.EntityFrameworkCore | 8.0.10 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.EntityFrameworkCore.Tools | 8.0.10 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.Extensions.DependencyInjection | 8.0.1 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.Extensions.DependencyInjection.Abstractions | 8.0.2 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.Extensions.Diagnostics.HealthChecks | 8.0.10 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions | 8.0.10 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.Extensions.Hosting.Abstractions | 8.0.1 | 9.0.5 | Recommended for .NET 9.0 |

### Project upgrade details

#### src/SelfFinanceApp.Domain/SelfFinanceApp.Domain.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/SelfFinanceApp.Persistance/SelfFinanceApp.Persistance.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`
NuGet packages changes:
  - Microsoft.EntityFrameworkCore should be updated from `8.0.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.Extensions.DependencyInjection should be updated from `8.0.1` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.Extensions.DependencyInjection.Abstractions should be updated from `8.0.2` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.Extensions.Diagnostics.HealthChecks should be updated from `8.0.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions should be updated from `8.0.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.Extensions.Hosting.Abstractions should be updated from `8.0.1` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.AspNetCore.Http.Abstractions should be updated from `2.2.0` to `2.3.0` (*deprecated, replace as recommended*)

#### tests/SelfFinanceApp.Tests.Shared/SelfFinanceApp.Tests.Shared.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/SelfFinanceApp.Application/SelfFinanceApp.Application.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`
NuGet packages changes:
  - Microsoft.AspNetCore.JsonPatch should be updated from `8.0.10` to `9.0.5` (*recommended for .NET 9.0*)

#### src/SelfFinanceApp.Infrastructure/SelfFinanceApp.Infrastructure.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`
NuGet packages changes:
  - Microsoft.Extensions.DependencyInjection.Abstractions should be updated from `8.0.2` to `9.0.5` (*recommended for .NET 9.0*)

#### tests/SelfFinanceApp.Application.Tests/SelfFinanceApp.Application.Tests.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### tests/SelfFinanceApp.Infrastructure.Tests/SelfFinanceApp.Infrastructure.Tests.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### tests/SelfFinanceApp.Domain.Tests/SelfFinanceApp.Domain.Tests.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/SelfFinanceApp.Api/SelfFinanceApp.Api.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`
NuGet packages changes:
  - Microsoft.AspNetCore.JsonPatch should be updated from `8.0.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.AspNetCore.Mvc.NewtonsoftJson should be updated from `8.0.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.AspNetCore.OpenApi should be updated from `8.0.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.EntityFrameworkCore should be updated from `8.0.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.EntityFrameworkCore.Tools should be updated from `8.0.10` to `9.0.5` (*recommended for .NET 9.0*)
