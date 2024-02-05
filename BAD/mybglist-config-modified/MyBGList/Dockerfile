# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# SDK image for building the project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyBGList.csproj", "./"]
RUN dotnet restore "MyBGList.csproj"
COPY . .
RUN dotnet build "MyBGList.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "MyBGList.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBGList.dll"]