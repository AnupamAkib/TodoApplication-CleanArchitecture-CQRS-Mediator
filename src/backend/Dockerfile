# Use the .NET SDK as a build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy all files from the current directory into the container
COPY . . 

# Restore dependencies
RUN dotnet restore "TodoApplication.csproj"

# Build the project
RUN dotnet build "TodoApplication.csproj" -c Release -o /app/build

# Publish the project
RUN dotnet publish "TodoApplication.csproj" -c Release -o /app/publish

# Use the ASP.NET Core runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/publish .

# Expose port 80 for HTTP traffic
EXPOSE 80

# Set the entry point
ENTRYPOINT ["dotnet", "TodoApplication.dll"]
