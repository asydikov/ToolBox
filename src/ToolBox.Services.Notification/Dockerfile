FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5050
ENV ASPNETCORE_URLS http://*:5050

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ToolBox.Services.Notification/ToolBox.Services.Notification.csproj", "ToolBox.Services.Notification/"]
COPY ["Toolbox.Common/Toolbox.Common.csproj", "Toolbox.Common/"]
RUN dotnet restore "ToolBox.Services.Notification/ToolBox.Services.Notification.csproj"
COPY . .
WORKDIR "/src/ToolBox.Services.Notification"
RUN dotnet build "ToolBox.Services.Notification.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToolBox.Services.Notification.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToolBox.Services.Notification.dll", "--urls", "http://notification:5050"]