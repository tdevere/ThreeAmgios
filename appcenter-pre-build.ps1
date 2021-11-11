Write-Host "TDEVERE Pre-Build script start"
Write-Host  "./ThreeAmgios/ThreeAmgios.UWP/appcenter-pre-build.sh"

dotnet --version
dotnet restore './ThreeAmgios/ThreeAmgios.UWP/ThreeAmgios.UWP.csproj' -v:diag

Write-Host  "TDEVERE Pre-Build script end"