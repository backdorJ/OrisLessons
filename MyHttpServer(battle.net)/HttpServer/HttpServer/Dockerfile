FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HttpServer/HttpServer.csproj", "HttpServer/"]
RUN dotnet restore "HttpServer/HttpServer.csproj"
COPY . .
WORKDIR "/src/HttpServer"
RUN dotnet build "HttpServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HttpServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HttpServer.dll"]
