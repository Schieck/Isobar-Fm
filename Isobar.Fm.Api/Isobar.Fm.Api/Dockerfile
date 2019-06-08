FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Isobar.Fm.Api/Isobar.Fm.Api.csproj", "Isobar.Fm.Api/"]
RUN dotnet restore "Isobar.Fm.Api/Isobar.Fm.Api.csproj"
COPY . .
WORKDIR "/src/Isobar.Fm.Api"
RUN dotnet build "Isobar.Fm.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Isobar.Fm.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Isobar.Fm.Api.dll"]