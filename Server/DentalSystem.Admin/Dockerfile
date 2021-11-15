FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DentalSystem.Admin/DentalSystem.Admin.csproj", "DentalSystem.Admin/"]
COPY ["DentalSystem/DentalSystem.csproj", "DentalSystem/"]
RUN dotnet restore "DentalSystem.Admin/DentalSystem.Admin.csproj"
COPY . .
RUN dotnet publish "DentalSystem.Admin/DentalSystem.Admin.csproj" -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
ENTRYPOINT ["dotnet", "DentalSystem.Admin.dll"]