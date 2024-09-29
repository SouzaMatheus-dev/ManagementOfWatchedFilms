using ManagementOfWatchedFilms.Infrastructure.Core.Factories;
using ManagementOfWatchedFilms.Infrastructure.Core.Factories.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ManagementOfWatchedFilms.Infrastructure.Core.Extensions
{
    public static class ManagementSqlServerDbContextExtensions
    {
        public static DbContextOptionsBuilder UseSqlServer(this DbContextOptionsBuilder optionsBuilder, Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction = null)
        {
            sqlServerOptionsAction ??= x => x.CommandTimeout(DatabaseConnectionStringFactory.CommandTimeout);
            return optionsBuilder.UseSqlServer(DatabaseConnectionStringFactory.Get(DatabaseConnection.ManagementFilms), sqlServerOptionsAction);
        }

        public static DbContextOptionsBuilder UseSqlServerWithNetTopologySuite(this DbContextOptionsBuilder optionsBuilder, Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction = null)
        {
            return optionsBuilder.UseSqlServer(
                DatabaseConnectionStringFactory.Get(DatabaseConnection.ManagementFilms),
                x => x.UseNetTopologySuite()
                    .CommandTimeout(DatabaseConnectionStringFactory.CommandTimeout));
        }
    }
}