@ECHO OFF 
TITLE Running services
ECHO Please wait... 
ECHO ============================
ECHO API Gateway Service
ECHO ============================
start cmd /K cd ../server/ToolBox.Api/ 
dotnet run
ECHO ============================


PAUSE