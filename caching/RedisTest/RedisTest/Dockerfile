#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RedisTest/RedisTest.csproj", "RedisTest/"]
RUN dotnet restore "RedisTest/RedisTest.csproj"
COPY . .
WORKDIR "/src/RedisTest"
RUN dotnet build "RedisTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisTest.dll"]