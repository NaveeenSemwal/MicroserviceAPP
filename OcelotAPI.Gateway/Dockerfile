#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["OcelotAPI.Gateway/OcelotAPI.Gateway.csproj", "OcelotAPI.Gateway/"]
RUN dotnet restore "OcelotAPI.Gateway/OcelotAPI.Gateway.csproj"
COPY . .
WORKDIR "/src/OcelotAPI.Gateway"
RUN dotnet build "OcelotAPI.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OcelotAPI.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OcelotAPI.Gateway.dll"]
