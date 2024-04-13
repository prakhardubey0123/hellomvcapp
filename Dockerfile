# Use the official .NET 6 SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the source code into the container
COPY ./HelloWorldMvc/*.csproj ./
RUN dotnet restore

# Copy the rest of the source code
COPY ./HelloWorldMvc ./
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image as a runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
CMD ["dotnet", "HelloWorldMvc.dll"]
