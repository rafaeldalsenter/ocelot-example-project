FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Ocelot.Example.MsAuth/Ocelot.Example.MsAuth.csproj", "Ocelot.Example.MsAuth/"]
RUN dotnet restore "Ocelot.Example.MsAuth/Ocelot.Example.MsAuth.csproj"
COPY . .
WORKDIR "/src/Ocelot.Example.MsAuth"
RUN dotnet build "Ocelot.Example.MsAuth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ocelot.Example.MsAuth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ocelot.Example.MsAuth.dll"]