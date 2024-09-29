Add-Migration -Name Initial -OutputDir Migrations -Context EntityContext -Project ManagementOfWatchedFilms.Infrastructure.Data -Verbose
Add-Migration -Name ChangeEntityMovies -OutputDir Migrations -Context EntityContext -Project ManagementOfWatchedFilms.Infrastructure.Data -Verbose

Script-Migration -Context EntityContext
Script-Migration Initial ChangeEntityMovies -Context EntityContext

Update-Database -Context EntityContext
Remove-Migration -Context EntityContext

#Terminal Commands
dotnet ef migrations add Initial --context EntityContext

dotnet ef migrations script Initial ChangeEntityMovies --context EntityContext -o "Scripts/1 - ChangeEntityMovies.sql"

dotnet ef migrations remove --context EntityContext