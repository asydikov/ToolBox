FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5020
ENV ASPNETCORE_URLS http://*:5020

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /src
COPY ["ToolBox.Services.SQLMonitor/ToolBox.Services.SQLMonitor.csproj", "ToolBox.Services.SQLMonitor/"]
COPY ["Toolbox.Common/Toolbox.Common.csproj", "Toolbox.Common/"]
RUN dotnet restore "ToolBox.Services.SQLMonitor/ToolBox.Services.SQLMonitor.csproj"
COPY . .
WORKDIR "/src/ToolBox.Services.SQLMonitor"
RUN dotnet build "ToolBox.Services.SQLMonitor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToolBox.Services.SQLMonitor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToolBox.Services.SQLMonitor.dll", "--urls", "http://sqlmonitor:5020"]