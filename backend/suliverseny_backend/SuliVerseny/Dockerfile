#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SuliVerseny/SuliVerseny.csproj", "SuliVerseny/"]
RUN dotnet restore "SuliVerseny/SuliVerseny.csproj"
COPY . .
WORKDIR "/src/SuliVerseny"
RUN dotnet build "SuliVerseny.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SuliVerseny.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SuliVerseny.dll"]