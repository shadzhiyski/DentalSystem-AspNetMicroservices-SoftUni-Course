FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DentalSystem.Scheduling/DentalSystem.Scheduling.csproj", "DentalSystem.Scheduling/"]
COPY ["DentalSystem/DentalSystem.csproj", "DentalSystem/"]
RUN dotnet restore "DentalSystem.Scheduling/DentalSystem.Scheduling.csproj"
COPY . .
RUN dotnet publish "DentalSystem.Scheduling/DentalSystem.Scheduling.csproj" -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
ENTRYPOINT ["dotnet", "DentalSystem.Scheduling.dll"]