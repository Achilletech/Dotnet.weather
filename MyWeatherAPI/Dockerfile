# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the .csproj and restore any dependencies
COPY MyWeatherAPI/*.csproj MyWeatherAPI/
RUN dotnet restore MyWeatherAPI/MyWeatherAPI.csproj

# Copy the source code and publish the application
COPY MyWeatherAPI/ MyWeatherAPI/
WORKDIR /src/MyWeatherAPI
RUN dotnet publish -c Release -o /app/publish --no-restore

# Build the final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyWeatherAPI.dll"]
