FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HttpServerBattleNet/HttpServerBattleNet.csproj", "HttpServerBattleNet/"]
RUN dotnet restore "HttpServerBattleNet/HttpServerBattleNet.csproj"
COPY . .
WORKDIR "/src/HttpServerBattleNet"
RUN dotnet build "HttpServerBattleNet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HttpServerBattleNet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HttpServerBattleNet.dll"]
