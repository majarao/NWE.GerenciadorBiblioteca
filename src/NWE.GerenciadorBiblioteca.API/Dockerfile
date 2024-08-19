# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/NWE.GerenciadorBiblioteca.API/NWE.GerenciadorBiblioteca.API.csproj", "src/NWE.GerenciadorBiblioteca.API/"]
COPY ["src/NWE.GerenciadorBiblioteca.Application/NWE.GerenciadorBiblioteca.Application.csproj", "src/NWE.GerenciadorBiblioteca.Application/"]
COPY ["src/NWE.GerenciadorBiblioteca.Domain/NWE.GerenciadorBiblioteca.Domain.csproj", "src/NWE.GerenciadorBiblioteca.Domain/"]
COPY ["src/NWE.GerenciadorBiblioteca.Infra/NWE.GerenciadorBiblioteca.Infra.csproj", "src/NWE.GerenciadorBiblioteca.Infra/"]
COPY ["src/NWE.GerenciadorBiblioteca.CrossCutting/NWE.GerenciadorBiblioteca.CrossCutting.csproj", "src/NWE.GerenciadorBiblioteca.CrossCutting/"]
RUN dotnet restore "./src/NWE.GerenciadorBiblioteca.API/NWE.GerenciadorBiblioteca.API.csproj"
COPY . .
WORKDIR "/src/src/NWE.GerenciadorBiblioteca.API"
RUN dotnet build "./NWE.GerenciadorBiblioteca.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NWE.GerenciadorBiblioteca.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NWE.GerenciadorBiblioteca.API.dll"]