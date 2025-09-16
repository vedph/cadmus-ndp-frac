@echo off
echo PRESS ANY KEY TO INSTALL Cadmus Libraries TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.NdpFrac.Parts\bin\Debug\Cadmus.NdpFrac.Parts.0.0.12.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.NdpFrac.Services\bin\Debug\Cadmus.NdpFrac.Services.0.0.12.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.NdpFrac.Parts\bin\Debug\Cadmus.Seed.NdpFrac.Parts.0.0.12.nupkg -source C:\Projects\_NuGet
pause
