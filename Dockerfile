# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the NuGet.Config file
COPY Nuget.Config ./

# Copy the project files
COPY Super_new_project ./

# Debug: Output the contents of Nuget.Config (remove sensitive info)
RUN cat Nuget.Config | sed 's/\(ClearTextPassword\)="[^"]*"/\1="REDACTED"/g'

# Restore NuGet packages
RUN dotnet restore --configfile Nuget.Config

# Build and publish the project
RUN dotnet publish -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80

# Use the application's dll as the entrypoint
ENTRYPOINT ["dotnet", "Super_new_project.dll"]