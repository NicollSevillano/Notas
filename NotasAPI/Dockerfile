FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln ./

COPY NotasAPI/*.csproj ./NotasAPI/

RUN dotnet restore

COPY . . 
WORKDIR /app/NotasAPI

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/NotasAPI/out ./

EXPOSE 80

ENTRYPOINT ["dotnet", "NotasAPI.dll"]
