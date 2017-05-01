cd GladLive.ModuleService.ASP
dotnet restore
dotnet build src/GladLive.ModuleService.ASP -c Release
cd ..

dotnet restore
cd src/Booma.GameServerList.Module
dotnet build -c Release
cd ..
cd ..

xcopy GladLive.ModuleService.ASP\src\GladLive.ModuleService.ASP\bin\Release\net451\win7-x64 build /s /y
xcopy src\Booma.GameServerList.Module\bin\Release\net451 build\Modules\GameServerList\ /s /y
xcopy config build /s /y

PAUSE