FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Ocelot.Example.MsDePrecoDoProduto/Ocelot.Example.MsDePrecoDoProduto.csproj", "Ocelot.Example.MsDePrecoDoProduto/"]
RUN dotnet restore "Ocelot.Example.MsDePrecoDoProduto/Ocelot.Example.MsDePrecoDoProduto.csproj"
COPY . .
WORKDIR "/src/Ocelot.Example.MsDePrecoDoProduto"
RUN dotnet build "Ocelot.Example.MsDePrecoDoProduto.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ocelot.Example.MsDePrecoDoProduto.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ocelot.Example.MsDePrecoDoProduto.dll"]