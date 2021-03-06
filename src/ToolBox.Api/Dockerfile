
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS http://*:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ToolBox.Api/ToolBox.Api.csproj", "ToolBox.Api/"]
COPY ["Toolbox.Common/Toolbox.Common.csproj", "Toolbox.Common/"]
RUN dotnet restore "ToolBox.Api/ToolBox.Api.csproj"
COPY . .
WORKDIR "/src/ToolBox.Api"
RUN dotnet build "ToolBox.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToolBox.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToolBox.Api.dll", "--urls", "http://*:5000"]