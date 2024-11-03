FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files
COPY ["src/SelfFinanceApp.Api/SelfFinanceApp.Api.csproj", "SelfFinanceApp.Api/"]
COPY ["src/SelfFinanceApp.Domain/SelfFinanceApp.Domain.csproj", "SelfFinanceApp.Domain/"]
COPY ["src/SelfFinanceApp.Application/SelfFinanceApp.Application.csproj", "SelfFinanceApp.Application/"]
COPY ["src/SelfFinanceApp.Infrastructure/SelfFinanceApp.Infrastructure.csproj", "SelfFinanceApp.Infrastructure/"]
COPY ["src/SelfFinanceApp.Persistance/SelfFinanceApp.Persistance.csproj", "SelfFinanceApp.Persistance/"]
COPY ["src/SelfFinanceApp.sln", "."]

# Restore dependencies
WORKDIR /src/SelfFinanceApp.Api
RUN dotnet restore "SelfFinanceApp.Api.csproj"

# Copy source code
WORKDIR /src
COPY ["src/SelfFinanceApp.Domain/", "SelfFinanceApp.Domain/"]
COPY ["src/SelfFinanceApp.Application/", "SelfFinanceApp.Application/"]
COPY ["src/SelfFinanceApp.Infrastructure/", "SelfFinanceApp.Infrastructure/"]
COPY ["src/SelfFinanceApp.Persistance/", "SelfFinanceApp.Persistance/"]
COPY ["src/SelfFinanceApp.Api/", "SelfFinanceApp.Api/"]

# Build and publish
RUN dotnet publish "SelfFinanceApp.Api/SelfFinanceApp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "SelfFinanceApp.Api.dll"]