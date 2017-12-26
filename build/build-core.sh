#!/bin/bash

# dotnet restore "../src/NSwag.ConsoleCore" --no-cache
# dotnet publish "../src/NSwag.ConsoleCore" -c release -f "netcoreapp1.0" -o "bin/release/netcoreapp1.0/Publish"
# dotnet publish "../src/NSwag.ConsoleCore" -c release -f "netcoreapp1.1" -o "bin/release/netcoreapp1.1/Publish"
# dotnet publish "../src/NSwag.ConsoleCore" -c release -f "netcoreapp2.0" -o "bin/release/netcoreapp2.0/Publish"

mkdir -p ../src/NSwag.Npm/bin/binaries

cp -rf ../src/NSwag.ConsoleCore/bin/release/netcoreapp1.0 ../src/NSwag.Npm/bin/binaries/NetCore10
cp -rf ../src/NSwag.ConsoleCore/bin/release/netcoreapp1.1 ../src/NSwag.Npm/bin/binaries/NetCore11
cp -rf ../src/NSwag.ConsoleCore/bin/release/netcoreapp2.0 ../src/NSwag.Npm/bin/binaries/NetCore20

