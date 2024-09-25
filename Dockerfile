# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY Super_new_project ./
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80

# List the contents of the /app directory
RUN ls -la /app

# Use a shell as the entrypoint for debugging
ENTRYPOINT ["/bin/bash"]