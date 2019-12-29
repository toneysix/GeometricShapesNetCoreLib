[CmdletBinding(PositionalBinding=$false)]
param(
    [bool] $WithTests = $true
)

Write-Host "Build Parameters:" -ForegroundColor Cyan
Write-Host "  RunTests: $WithTests"
Write-Host "  dotnet --version:" (dotnet --version)

$libOutputFolder = "$PSScriptRoot\bin\"

Write-Host "Restoring all projects..." -ForegroundColor "Magenta"
dotnet restore
Write-Host "Done restoring." -ForegroundColor "Green"
Write-Host $PSScriptRoot
Write-Host "Building library..." -ForegroundColor "Magenta"
Get-ChildItem "$PSScriptRoot\src\" -Filter *.csproj -Recurse | % {
	Push-Location
	dotnet build $_.FullName -c Release -o $libOutputFolder --no-restore /p:CI=true
	Pop-Location
}
Write-Host "Done building." -ForegroundColor "Green"

if ($WithTests) 
{
	Get-ChildItem "$PSScriptRoot\tests\" -Filter *.csproj -Recurse | % {
        Write-Host "Running tests: $_.Name" -ForegroundColor "Magenta"
        Push-Location

        dotnet test $_.FullName -c Release
        if ($LastExitCode -ne 0)
		{
            Write-Host "Error with tests, aborting build." -Foreground "Red"
            Pop-Location
            Exit 1
        }

        Write-Host "Tests passed!" -ForegroundColor "Green"
	    Pop-Location
    }
}

Write-Host "Build Complete." -ForegroundColor "Green"