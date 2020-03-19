FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app
EXPOSE 9090
ENV ASPNETCORE_URLS http://*:5090

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /src
COPY ["ToolBox.Client/ToolBox.Client.csproj", "ToolBox.Client/"]
RUN dotnet restore "ToolBox.Client/ToolBox.Client.csproj"
COPY . .
WORKDIR "/src/ToolBox.Client"
RUN dotnet build "ToolBox.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToolBox.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToolBox.Client.dll", "--urls", "http://*:9090"]
