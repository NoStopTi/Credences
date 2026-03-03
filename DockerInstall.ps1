# Configuration
$FolderPath  = "C:\dev\apps"
$FileName    = "dockerDesktop.exe"
$Destination = Join-Path -Path $FolderPath -ChildPath $FileName
$Url         = "https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe?utm_source=docker&utm_medium=webreferral&utm_campaign=docs-driven-download-win-amd64&_gl=1*6mmwqu*_gcl_au*MTkzMDQzOTg2Ni4xNzcyMTE1Nzk1*_ga*MTM1MzM4MDI1MS4xNzcyMTE1Nzk0*_ga_XJWPQMJYHQ*czE3NzIxMTU3OTQkbzEkZzEkdDE3NzIxMTU3OTUkajU5JGwwJGgw"

try {
    # Ensure folder exists
    if (-not (Test-Path -Path $FolderPath -PathType Container)) {
        Write-Verbose "Creating folder $FolderPath..."
        New-Item -ItemType Directory -Path $FolderPath -Force | Out-Null
    }

    # Download Docker Desktop installer
    Write-Verbose "Downloading Docker Desktop installer..."
    Invoke-WebRequest -Uri $Url -OutFile $Destination -UseBasicParsing

    # Validate download
    if (-not (Test-Path -Path $Destination)) {
        throw "Download failed: file not found at $Destination"
    }

    Write-Host "Download completed successfully: $Destination"

    # Run installation
    Write-Host "Starting Docker Desktop installation..."
    Start-Process -FilePath $Destination -ArgumentList "install" -Wait -NoNewWindow
    Write-Host "Installation finished."

    # Detect current logged-in user
    $CurrentUser = (Get-WmiObject -Class Win32_ComputerSystem).UserName
    if (-not $CurrentUser) {
        throw "Unable to detect the logged-in user."
    }

    Write-Host "Logged-in user detected: $CurrentUser"

    # Add user to docker-users group
    Write-Host "Adding $CurrentUser to docker-users group..."
    net localgroup docker-users $CurrentUser /add | Out-Null

    Write-Host "User $CurrentUser successfully added to docker-users group."
     
    # Update WSL
     Write-Host "Updating Windows Subsystem for Linux (WSL)..."
     wsl --update
     Write-Host "WSL update completed."
}
catch {
    Write-Error "An error occurred: $_"
}
