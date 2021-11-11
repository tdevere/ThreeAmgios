Write-Host "TDEVERE Pre-Build script start"
Write-Host  "./ThreeAmgios.sln/ThreeAmgios.UWP/appcenter-pre-build.sh"

ls

nuget restore './ThreeAmgios.sln/ThreeAmgios.UWP/ThreeAmgios.UWP.csproj' 

Write-Host  "TDEVERE Pre-Build script end"