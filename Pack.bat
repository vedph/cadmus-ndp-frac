@echo off
echo BUILD Cadmus NdpFrac Packages
del .\Cadmus.NdpFrac.Parts\bin\Debug\*.snupkg
del .\Cadmus.NdpFrac.Parts\bin\Debug\*.nupkg

del .\Cadmus.NdpFrac.Services\bin\Debug\*.snupkg
del .\Cadmus.NdpFrac.Services\bin\Debug\*.nupkg

del .\Cadmus.Seed.NdpFrac.Parts\bin\Debug\*.snupkg
del .\Cadmus.Seed.NdpFrac.Parts\bin\Debug\*.nupkg

cd .\Cadmus.NdpFrac.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.NdpFrac.Services
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Seed.NdpFrac.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
