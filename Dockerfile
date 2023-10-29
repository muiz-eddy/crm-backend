#Set the base image for the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

#Set the SDK for building the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["crmbackend.csproj", "./"]
RUN dotnet restore "./crmbackend.csproj"
COPY . . 
RUN dotnet build "crmbackend.csproj" -c Release -o /app/build

#publish app
FROM build AS publish
RUN dotnet publish "crmbackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish . 
ENTRYPOINT [ "dotnet", "crmbackend.dll" ]