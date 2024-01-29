# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore
RUN dotnet publish -c release -o /app --no-restore

# Serve stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5050

ENTRYPOINT ["dotnet", "bin/Debug/net8.0/Exercise1.dll"]