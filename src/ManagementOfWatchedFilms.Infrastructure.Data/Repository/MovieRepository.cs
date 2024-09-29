using ManagementOfWatchedFilms.Domain.Entity;
using ManagementOfWatchedFilms.Domain.Interface.Repository;
using ManagementOfWatchedFilms.Infrastructure.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ManagementOfWatchedFilms.Infrastructure.Data.Repository
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(EntityContext entityContext) : base(entityContext)
        {
        }

        private DbConnection GetConnection()
        {
            return new SqlConnection(_entityContext.Database.GetDbConnection().ConnectionString);
        }
    }
}