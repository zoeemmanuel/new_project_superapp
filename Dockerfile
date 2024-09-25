# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the NuGet.Config file
COPY Nuget.Config ./

# Copy the project files
COPY Super_new_project ./

# Restore NuGet packages
RUN dotnet restore --configfile Nuget.Config

# Build and publish the project
RUN dotnet publish -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80

# List the contents of the /app directory
RUN ls -la /app

# Use the application's dll as the entrypoint instead of bash
ENTRYPOINT ["dotnet", "Super_new_project.dll"]