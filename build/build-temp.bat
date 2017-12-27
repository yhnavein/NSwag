rmdir "..\src\NSwag.Npm\bin\binaries" /Q /S nonemptydir
mkdir "..\src\NSwag.Npm\bin\binaries"

REM Build and copy full .NET command line
"nuget.exe" restore "../src/NSwagCore.sln"
dotnet restore "../src/NSwagCore.sln"

xcopy "../src/NSwag.Console/bin/Release/net461" "../src/NSwag.Npm/bin/binaries/Win" /E /I /y /exclude:ignore-files.txt
xcopy "..\src\NSwag.Console.x86\bin\Release\net461\NSwag.x86.exe" "..\src\NSwag.Npm\bin\binaries\Win" /exclude:ignore-files.txt
xcopy "..\src\NSwag.Console.x86\bin\Release\net461\NSwag.x86.exe.config" "..\src\NSwag.Npm\bin\binaries\Win" /exclude:ignore-files.txt

REM Build and copy .NET Core command line
dotnet restore "../src/NSwag.ConsoleCore" --no-cache
dotnet publish "../src/NSwag.ConsoleCore" -c release -f "netcoreapp1.0" -o "bin/release/netcoreapp1.0/Publish"
dotnet publish "../src/NSwag.ConsoleCore" -c release -f "netcoreapp1.1" -o "bin/release/netcoreapp1.1/Publish"
dotnet publish "../src/NSwag.ConsoleCore" -c release -f "netcoreapp2.0" -o "bin/release/netcoreapp2.0/Publish"

xcopy "../src/NSwag.ConsoleCore/bin/release/netcoreapp1.0/publish" "../src/NSwag.Npm/bin/binaries/NetCore10" /E /I /y /exclude:ignore-files.txt
xcopy "../src/NSwag.ConsoleCore/bin/release/netcoreapp1.1/publish" "../src/NSwag.Npm/bin/binaries/NetCore11" /E /I /y /exclude:ignore-files.txt
xcopy "../src/NSwag.ConsoleCore/bin/release/netcoreapp2.0/publish" "../src/NSwag.Npm/bin/binaries/NetCore20" /E /I /y /exclude:ignore-files.txt
