FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CreditPipeline.API/CreditPipeline.API.csproj", "CreditPipeline.API/"]
RUN dotnet restore "CreditPipeline.API/CreditPipeline.API.csproj"
COPY . .
WORKDIR "/src/CreditPipeline.API"
RUN dotnet build "CreditPipeline.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CreditPipeline.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CreditPipeline.API.dll"]
