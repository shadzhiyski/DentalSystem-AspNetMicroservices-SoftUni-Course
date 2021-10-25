FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DentalSystem.Identity/DentalSystem.Identity.csproj", "DentalSystem.Identity/"]
COPY ["DentalSystem/DentalSystem.csproj", "DentalSystem/"]
# COPY DentalSystem.Identity/DentalSystem.Identity.csproj .
RUN dotnet restore "DentalSystem.Identity/DentalSystem.Identity.csproj"
COPY . .
RUN dotnet publish "DentalSystem.Identity/DentalSystem.Identity.csproj" -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
ENTRYPOINT ["dotnet", "DentalSystem.Identity.dll"]