FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CreditPipeline/CreditPipeline.csproj", "CreditPipeline/"]
RUN dotnet restore "CreditPipeline/CreditPipeline.csproj"
COPY . .
WORKDIR "/src/CreditPipeline"
RUN dotnet build "CreditPipeline.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CreditPipeline.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CreditPipeline.dll"]
