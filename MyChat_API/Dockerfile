#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MyChat_API/MyChat_API.csproj", "MyChat_API/"]
COPY ["MyChat_Core/MyChat_Core.csproj", "MyChat_Core/"]
COPY ["MyChat_Data/MyChat_Data.csproj", "MyChat_Data/"]
RUN dotnet restore "./MyChat_API/MyChat_API.csproj"
COPY . .
WORKDIR "/src/MyChat_API"
RUN dotnet build "./MyChat_API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MyChat_API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyChat_API.dll"]
