FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/Basket.Api/Basket.Api.csproj", "/src/Basket.Api/"]
COPY ["/Logger/Logger.csproj", "/src/Logger/"]


RUN dotnet restore "Basket.Api/Basket.Api.csproj"
COPY . .
WORKDIR /src/Basket.Api


RUN dotnet build "Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.Api.dll"]  # Assuming a web app or library
