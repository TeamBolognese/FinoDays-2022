FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /api

COPY . ./
ENV ASPNETCORE_URLS="http://+:5050"
EXPOSE 5050

ENTRYPOINT  ["dotnet", "/api/CreditPipeline.API.dll", "http://*:5050"]