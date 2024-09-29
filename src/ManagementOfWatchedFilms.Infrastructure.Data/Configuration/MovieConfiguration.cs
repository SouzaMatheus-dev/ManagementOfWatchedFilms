using ManagementOfWatchedFilms.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementOfWatchedFilms.Infrastructure.Data.Configuration
{
    public class MovieConfiguration : EntityTypeBaseConfiguration<Movie>
    {
        public override void Configure(EntityTypeBuilder<Movie> builder)
        {
            base.Configure(builder);

            builder.ToTable("Movies");
        }
    }
}