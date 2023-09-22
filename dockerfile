# Use the .NET 7.0 SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set the working directory to /app
WORKDIR /app

# Copy the necessary project files and restore dependencies for your Web API project
COPY K123ShopApp.WebApi/*.csproj ./
RUN dotnet restore

# Copy the entire application source code
COPY . ./

# Publish the application (specify the project file)
RUN dotnet publish K123ShopApp.WebApi/K123ShopApp.WebApi.csproj -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Set the working directory to /app
WORKDIR /app

# Copy the published output from the build stage into the runtime image
COPY --from=build-env /app/out ./

# Set the entry point to start your ASP.NET Core Web API application
ENTRYPOINT ["dotnet", "K123ShopApp.WebApi.dll"]
