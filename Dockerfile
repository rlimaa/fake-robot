FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/FakeRobot.Api/FakeRobot.Api.csproj", "FakeRobot.Api/"]
COPY ["src/FakeRobot.Application/FakeRobot.Application.csproj", "FakeRobot.Application/"]
COPY ["src/FakeRobot.Domain/FakeRobot.Domain.csproj", "FakeRobot.Domain/"]
COPY ["src/FakeRobot.Infrastructure/FakeRobot.Infrastructure.csproj", "FakeRobot.Infrastructure/"]
RUN dotnet restore "FakeRobot.Api/FakeRobot.Api.csproj"
COPY . ../
WORKDIR /src/FakeRobot.Api
RUN dotnet build "FakeRobot.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE ${ASPNETCORE_HTTP_PORTS}
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FakeRobot.Api.dll"]