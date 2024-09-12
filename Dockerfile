FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy Nuget.config
COPY ["Nuget.config", "."]

# Copy csproj and restore as distinct layers
COPY ["Super_new_project/Super_new_project.csproj", "Super_new_project/"]

# Restore dependencies
RUN dotnet restore "Super_new_project/Super_new_project.csproj" --configfile "./Nuget.config"

# Copy everything else and build
COPY . .
WORKDIR "/src/Super_new_project"
RUN dotnet build "Super_new_project.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Super_new_project.csproj" -c Release -o /app/publish

# Final stage / image
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf