#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RabbitMqDocker.Consumer/RabbitMqDocker.Consumer.csproj", "RabbitMqDocker.Consumer/"]
COPY ["RabbitMqDocker.Messaging/RabbitMqDocker.Messaging.csproj", "RabbitMqDocker.Messaging/"]
RUN dotnet restore "RabbitMqDocker.Consumer/RabbitMqDocker.Consumer.csproj"
COPY . .
WORKDIR "/src/RabbitMqDocker.Consumer"
RUN dotnet build "RabbitMqDocker.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RabbitMqDocker.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RabbitMqDocker.Consumer.dll"]