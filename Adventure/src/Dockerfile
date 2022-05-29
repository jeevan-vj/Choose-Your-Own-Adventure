FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ./ ./
RUN ls -lha .

RUN echo 'Building Adventure container'

WORKDIR /app/Adventure/src/Adventure.Web

RUN dotnet restore

RUN dotnet build "Adventure.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adventure.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adventure.Web.dll"]
