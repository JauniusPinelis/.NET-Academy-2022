#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/SquareManagement.WebApi/SquareManagement.WebApi.csproj", "src/SquareManagement.WebApi/"]
COPY ["src/SquareManagement.Services/SquareManagement.Services.csproj", "src/SquareManagement.Services/"]
COPY ["src/SquareManagement.Core/SquareManagement.Core.csproj", "src/SquareManagement.Core/"]
COPY ["src/SquareManagement.Repositories/SquareManagement.Repositories.csproj", "src/SquareManagement.Repositories/"]
RUN dotnet restore "src/SquareManagement.WebApi/SquareManagement.WebApi.csproj"
COPY . .
WORKDIR "/src/src/SquareManagement.WebApi"
RUN dotnet build "SquareManagement.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SquareManagement.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SquareManagement.WebApi.dll"]