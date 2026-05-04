FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .
RUN dotnet publish FlightLogNet/FlightLogNet.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

RUN mkdir /data

COPY --from=build /app/publish ./

EXPOSE 8080
EXPOSE 44313

ENV ConnectionStrings__DefaultConnection="Data Source=/data/flightlog.db"

ENTRYPOINT ["dotnet", "FlightLogNet.dll"]