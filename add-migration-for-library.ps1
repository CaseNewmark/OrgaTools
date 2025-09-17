param(
    [Parameter(Position = 0, Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$LibraryName,
    [Parameter(Position = 1, Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$MigrationName
)

dotnet ef --startup-project .\Api\ migrations add "$MigrationName" --project .\Services\$LibraryName\ --context ${LibraryName}DbContext -o Data\Migrations