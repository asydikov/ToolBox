@ECHO OFF 
TITLE Running services
ECHO Please wait... 
ECHO ============================
ECHO API Gateway Service
ECHO ============================
cd ../server/ToolBox.Api/
dotnet run
ECHO ============================
ECHO Identity Service
ECHO ============================
cd ../Toolbox.Services.Identity
dotnet run

PAUSE