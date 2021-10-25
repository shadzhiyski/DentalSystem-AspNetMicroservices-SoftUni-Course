FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DentalSystem.Watchdog/DentalSystem.Watchdog.csproj", "DentalSystem.Watchdog/"]
COPY ["DentalSystem/DentalSystem.csproj", "DentalSystem/"]
# COPY DentalSystem.Watchdog/DentalSystem.Watchdog.csproj .
RUN dotnet restore "DentalSystem.Watchdog/DentalSystem.Watchdog.csproj"
COPY . .
RUN dotnet publish "DentalSystem.Watchdog/DentalSystem.Watchdog.csproj" -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
ENTRYPOINT ["dotnet", "DentalSystem.Watchdog.dll"]