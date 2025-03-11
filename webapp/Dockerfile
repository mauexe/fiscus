FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
RUN mkdir -p /app/data
RUN chmod -R 777 /app/data
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["webapp/webapp.csproj", "webapp/"]
COPY ["domain/domain.csproj", "domain/"]
COPY ["model/model.csproj", "model/"]
RUN dotnet restore "webapp/webapp.csproj"
COPY . .
WORKDIR "/src/webapp"
RUN dotnet build "webapp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "webapp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webapp.dll"]
