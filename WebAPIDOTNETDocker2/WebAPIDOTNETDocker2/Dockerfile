#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#INICIO Dockerfile LocalHost
# FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# WORKDIR /src
# COPY ["WebAPIDOTNETDocker2/WebAPIDOTNETDocker2.csproj", "WebAPIDOTNETDocker2/"]
# RUN dotnet restore "WebAPIDOTNETDocker2/WebAPIDOTNETDocker2.csproj"
# COPY . .
# WORKDIR "/src/WebAPIDOTNETDocker2"
# RUN dotnet build "WebAPIDOTNETDocker2.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "WebAPIDOTNETDocker2.csproj" -c Release -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "WebAPIDOTNETDocker2.dll"]
#FIN Dockerfile LocalHost

#INICIO Dockerfile GoogleCloud-GitHub
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
#COPY ["WebAPIDOTNETDocker2/WebAPIDOTNETDocker2/WebAPIDOTNETDocker2.csproj", "WebAPIDOTNETDocker2/WebAPIDOTNETDocker2/"]
RUN dotnet restore "WebAPIDOTNETDocker2/WebAPIDOTNETDocker2/WebAPIDOTNETDocker2.csproj"
COPY . .
WORKDIR "/src/WebAPIDOTNETDocker2/WebAPIDOTNETDocker2"
RUN dotnet build "WebAPIDOTNETDocker2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPIDOTNETDocker2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPIDOTNETDocker2.dll"]
#FIN Dockerfile GoogleCloud-GitHub