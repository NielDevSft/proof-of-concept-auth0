#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Authentication.API/Authentication.API.csproj", "Authentication.API/"]
COPY ["Authentication.Common/Authentication.Common.csproj", "Authentication.Common/"]
COPY ["Authentication.Domain/Authentication.Domain.csproj", "Authentication.Domain/"]
COPY ["Authentication.Domain.Core/Authentication.Domain.Core.csproj", "Authentication.Domain.Core/"]
COPY ["Authentication.Persistence/Authentication.Persistence.csproj", "Authentication.Persistence/"]
RUN dotnet restore "./Authentication.API/./Authentication.API.csproj"
COPY . .
WORKDIR "/src/Authentication.API"
RUN dotnet build "./Authentication.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Authentication.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authentication.API.dll"]