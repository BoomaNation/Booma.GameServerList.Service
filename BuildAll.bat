cd GladLive.ModuleService.ASP
dotnet restore
dotnet build src/GladLive.ModuleService.ASP
cd ..

msbuild Booma.GameServerList.Service /p:Configuration=Release