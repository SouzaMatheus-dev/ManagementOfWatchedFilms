using ManagementOfWatchedFilms.Infrastructure.Core.Factories.Enums;

namespace ManagementOfWatchedFilms.Infrastructure.Core.Factories
{
    public static class DatabaseConnectionStringFactory
    {
        public static readonly int CommandTimeout = (int)TimeSpan.FromMinutes(10).TotalSeconds;
        public const string UserId = "Debug";

        public static string Get(DatabaseConnection connection)
        {
            //TODO: configure to read the appsettings.json
            return connection switch
            {
                DatabaseConnection.ManagementFilms => "Server=localhost;Database=ManagementOfWatchedFilms;Integrated Security=SSPI;TrustServerCertificate=true;",
                _ => default
            };
        }
    }
}