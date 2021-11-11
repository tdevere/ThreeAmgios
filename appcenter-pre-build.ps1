Write-Host "TDEVERE Pre-Build script start"
Write-Host  "./ThreeAmgios/ThreeAmgios.UWP/appcenter-pre-build.sh"

ls

dotnet restore './ThreeAmgios/ThreeAmgios.UWP/ThreeAmgios.UWP.csproj' 

Write-Host  "TDEVERE Pre-Build script end"