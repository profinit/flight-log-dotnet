FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FlightLogNet/FlightLogNet.csproj FlightLogNet/
COPY FlightLogDotNet.sln .
RUN dotnet restore FlightLogNet/FlightLogNet.csproj
COPY FlightLogNet/ FlightLogNet/
RUN dotnet publish FlightLogNet/FlightLogNet.csproj -c Release -o /app/publish /p:UseAppHost=false

# === Runtime stage ===
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./
RUN mkdir -p /data && chown app:app /data
USER app
ENV ASPNETCORE_URLS=http://+:44313
ENV SqliteConnectionString="Data Source=/data/flightlog.db"
ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 44313
VOLUME ["/data"]
ENTRYPOINT ["dotnet", "FlightLogNet.dll"]
