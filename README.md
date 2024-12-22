# Klicky
Simple command line auto-clicker

# Getting Started
Download the published exe (if available) or download the source code and compile with .NET 8.0

## Syntax
`klicky [--seconds/-S (num)] [--debug/-D]`

`--seconds` is the maximum number of seconds between clicks. It will use a random number between 0 and the seconds argument value provided. Defaults at 60 seconds.

# Build Script Example
```powershell
[CmdletBinding()]
param(
    [Alias('P')]
    [switch]$Publish,
    [Alias('D')]
    [string]$ProjectDir = $PWD,
    [Alias('C')]
    [ValidateSet('Release','Debug')]
    [string]$Config = "Debug"
)
$AppName = "Klicky"
# Directory to move single file exe to
$AppDir = ""
$PublishDir = "$ProjectDir\publish\"

if($Publish) {
    Invoke-Expression("dotnet publish $ProjectDir -o $PublishDir -p:PublishSingleFile=true --self-contained true")
    xcopy "$PublishDir\$AppName.exe" $AppDir  /f /d /y /z /q
} else {
    Invoke-Expression("dotnet build $ProjectDir -c $Config")
}
```