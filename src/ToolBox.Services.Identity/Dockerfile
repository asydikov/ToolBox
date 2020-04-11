FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5010
ENV ASPNETCORE_URLS http://*:5010

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ToolBox.Services.Identity/ToolBox.Services.Identity.csproj", "ToolBox.Services.Identity/"]
COPY ["Toolbox.Common/Toolbox.Common.csproj", "Toolbox.Common/"]
RUN dotnet restore "ToolBox.Services.Identity/ToolBox.Services.Identity.csproj"
COPY . .
WORKDIR "/src/ToolBox.Services.Identity"
RUN dotnet build "ToolBox.Services.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToolBox.Services.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToolBox.Services.Identity.dll", "--urls", "http://docker:5010"]