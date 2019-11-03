cd .\register-protocol
dotnet.exe run
Write-Output "Switching to Client App"
cd..
cd .\client-app
Write-Output "Building and Publishing..."
dotnet build Client-App.csproj /p:DeployOnBuild=true /p:PublishProfile=FolderProfile