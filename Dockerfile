FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GameStore.API.csproj", "GameStoreAPI/"]
RUN dotnet restore "GameStoreAPI/GameStore.API.csproj"

WORKDIR "/src/GameStoreAPI"
COPY . .
RUN dotnet build "GameStore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameStore.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","GameStore.API.dll"]

