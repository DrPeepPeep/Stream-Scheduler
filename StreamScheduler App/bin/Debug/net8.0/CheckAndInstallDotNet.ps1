# Define the .NET 8.0 installer URL
$dotnetInstallerUrl = "https://download.visualstudio.microsoft.com/download/pr/9b07f3c0-7d84-4edb-8a02-f5fbc5dfdc15/ce21e5f0d3b0bfa8e2cb86e378b05e64/dotnet-sdk-8.0.0-win-x64.exe"

# Define the installer path
$installerPath = "$env:TEMP\dotnet-sdk-8.0.0-win-x64.exe"

# Function to check if .NET 8.0 SDK is installed
function IsDotNet8Installed {
    $dotnetInfo = & "dotnet" --list-sdks 2>&1
    return $dotnetInfo -match "8\.0"
}

# Check if .NET 8.0 is installed
if (-not (IsDotNet8Installed)) {
    Write-Host ".NET 8.0 SDK is not installed. Downloading and installing..."
    
    # Download the .NET 8.0 installer
    Invoke-WebRequest -Uri $dotnetInstallerUrl -OutFile $installerPath

    # Install .NET 8.0 SDK
    Start-Process -FilePath $installerPath -ArgumentList "/quiet" -Wait

    Write-Host ".NET 8.0 SDK installation completed."
} else {
    Write-Host ".NET 8.0 SDK is already installed."
}

# Check if the installer file exists before attempting to delete it
if (Test-Path $installerPath) {
    # Clean up installer file
    Remove-Item $installerPath
} else {
    Write-Host "Installer file not found; skipping cleanup."
}
