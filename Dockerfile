# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY XotaApi2.csproj .
COPY XotaApi2.sln .
COPY Directory.Packages.props .
RUN dotnet restore XotaApi2.sln

# Copy the entire project and build
COPY . .
WORKDIR /src
RUN dotnet build XotaApi2.csproj -c Release -o /app/build

# Stage 2: Publish the application
FROM build AS publish
RUN dotnet publish XotaApi2.csproj -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080

# Copy published output from the publish stage
COPY --from=publish /app/publish .

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "XotaApi2.dll"]