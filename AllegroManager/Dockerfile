#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
RUN apt-get update && apt-get install -y libkrb5-3 && rm -rf /var/lib/apt/lists/*
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AllegroManager/AllegroManager.csproj", "AllegroManager/"]
COPY ["AllegroConnector.Application/AllegroConnector.Application.csproj", "AllegroConnector.Application/"]
COPY ["AllegroConnector.BuildingBlocks.Application/AllegroConnector.BuildingBlocks.Application.csproj", "AllegroConnector.BuildingBlocks.Application/"]
COPY ["AllegroConnector.BuildingBlocks.Domain/AllegroConnector.BuildingBlocks.Domain.csproj", "AllegroConnector.BuildingBlocks.Domain/"]
COPY ["AllegroConnector.BuildingBlocks.Infrastructure/AllegroConnector.BuildingBlocks.Infrastructure.csproj", "AllegroConnector.BuildingBlocks.Infrastructure/"]
COPY ["AllegroConnector.Domain/AllegroConnector.Domain.csproj", "AllegroConnector.Domain/"]
COPY ["AllegroConnector.IntegrationEvents/AllegroConnector.IntegrationEvents.csproj", "AllegroConnector.IntegrationEvents/"]
COPY ["BaselinkerConnector.IntegrationEvents/BaselinkerConnector.IntegrationEvents.csproj", "BaselinkerConnector.IntegrationEvents/"]
COPY ["AllegroConnector/AllegroConnector.Infrastructure.csproj", "AllegroConnector/"]
COPY ["BaselinkerConnector.Application/BaselinkerConnector.Application.csproj", "BaselinkerConnector.Application/"]
COPY ["BaselinkerConnector.Domain/BaselinkerConnector.Domain.csproj", "BaselinkerConnector.Domain/"]
COPY ["BaselinkerConnector.Infrastructure/BaselinkerConnector.Infrastructure.csproj", "BaselinkerConnector.Infrastructure/"]
RUN dotnet restore "./AllegroManager/AllegroManager.csproj"
COPY . .
WORKDIR "/src/AllegroManager"
RUN dotnet build "./AllegroManager.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AllegroManager.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AllegroManager.dll"]