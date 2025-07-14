FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /app

COPY *.sln .
COPY NotasAPI/*.csproj ./NotasAPI/

RUN dotnet restore

COPY . .
WORKDIR /app/NotasAPI
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview
WORKDIR /app
COPY --from=build /app/NotasAPI/out ./

EXPOSE 80
ENTRYPOINT ["dotnet", "NotasAPI.dll"]
