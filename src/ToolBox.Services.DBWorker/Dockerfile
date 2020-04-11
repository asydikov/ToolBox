FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5030
ENV ASPNETCORE_URLS http://*:5030

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ToolBox.Services.DBWorker/ToolBox.Services.DBWorker.csproj", "ToolBox.Services.DBWorker/"]
COPY ["Toolbox.Common/Toolbox.Common.csproj", "Toolbox.Common/"]
RUN dotnet restore "ToolBox.Services.DBWorker/ToolBox.Services.DBWorker.csproj"
COPY . .
WORKDIR "/src/ToolBox.Services.DBWorker"
RUN dotnet build "ToolBox.Services.DBWorker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToolBox.Services.DBWorker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToolBox.Services.DBWorker.dll", "--urls", "http://dbworker:5030"]