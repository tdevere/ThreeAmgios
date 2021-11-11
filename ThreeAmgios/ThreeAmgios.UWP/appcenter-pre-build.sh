#/bin/bash

echo "TDEVERE Pre-Build script start"
echo "./ThreeAmgios.sln/ThreeAmgios.UWP/appcenter-pre-build.sh"

ls -l

nuget restore './ThreeAmgios.sln/ThreeAmgios.UWP/ThreeAmgios.UWP.csproj' 

echo "TDEVERE Pre-Build script end"