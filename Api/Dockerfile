FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG Version=1.0.0
WORKDIR /src

COPY DOC.ApiService/DOC.ApiService.csproj DOC.ApiService/
COPY DOC.ServiceDefaults/DOC.ServiceDefaults.csproj DOC.ServiceDefaults/
COPY libraries/CradlepointManagement/CradlepointManagement.csproj libraries/CradlepointManagement/

RUN dotnet restore DOC.ApiService/DOC.ApiService.csproj

COPY . .
RUN dotnet publish DOC.ApiService/DOC.ApiService.csproj -c Release -o /app /p:Version=$Version

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
EXPOSE 8080
EXPOSE 7007
COPY --from=build /app .
COPY DOC.ApiService/appsettings.json .
COPY DOC.ApiService/appsettings.Development.json .

ENV DOTNET_ENVIRONMENT=Development
RUN useradd -ms /bin/bash appuser
USER appuser

ENTRYPOINT ["dotnet", "DOC.ApiService.dll"]
