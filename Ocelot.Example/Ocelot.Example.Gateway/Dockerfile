FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Ocelot.Example.Gateway/Ocelot.Example.Gateway.csproj", "Ocelot.Example.Gateway/"]
RUN dotnet restore "Ocelot.Example.Gateway/Ocelot.Example.Gateway.csproj"
COPY . .
WORKDIR "/src/Ocelot.Example.Gateway"
RUN dotnet build "Ocelot.Example.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ocelot.Example.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ocelot.Example.Gateway.dll"]