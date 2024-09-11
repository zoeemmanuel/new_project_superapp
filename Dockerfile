# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["super_new_project_blazor_wasm/Super_new_project.csproj", "super_new_project_blazor_wasm/"]
RUN dotnet restore "super_new_project_blazor_wasm/Super_new_project.csproj"
COPY . .
WORKDIR "/src/super_new_project_blazor_wasm"
RUN dotnet build "Super_new_project.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Super_new_project.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Super_new_project.dll"]