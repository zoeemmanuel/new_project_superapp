# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution file
COPY *.sln .
COPY Nuget.Config .

# Copy the main project
COPY Super_new_project/*.csproj Super_new_project/
COPY TestSuper_new_project/*.csproj TestSuper_new_project/

# Restore NuGet packages
RUN dotnet restore --configfile Nuget.Config

# Copy the rest of the files
COPY . .

# Publish the application
WORKDIR "/src/Super_new_project"
RUN dotnet publish -c Release -o /app/publish

# Serve stage
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]