using ManagementOfWatchedFilms.Domain.Entity;
using ManagementOfWatchedFilms.Infrastructure.Core.Extensions;
using ManagementOfWatchedFilms.Infrastructure.Core.Factories;
using ManagementOfWatchedFilms.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ManagementOfWatchedFilms.Infrastructure.Data.Context
{
    public class EntityContext : DbContext
    {
        private readonly string _userId;

#if DEBUG

        public EntityContext()
            => _userId = DatabaseConnectionStringFactory.UserId;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServerWithNetTopologySuite();

#endif

        public EntityContext(DbContextOptions<EntityContext> optionsBuilder) : base(optionsBuilder)
        {
        }

        public EntityContext(DbContextOptions<EntityContext> optionsBuilder, string userId) :
            base(optionsBuilder)
        {
            _userId = userId;
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Removing OneToManyCascadeDeleteConvention
            var foreignKeys = modelBuilder.Model
                .GetEntityTypes()
            .SelectMany(fk => fk.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Movie>(new MovieConfiguration().Configure);

            modelBuilder.HasDefaultSchema("domain");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetEntityBaseData();
            return base.SaveChangesAsync(true, cancellationToken);
        }

        public override int SaveChanges()
        {
            SetEntityBaseData();
            return base.SaveChanges();
        }

        private void SetEntityBaseData()
        {
            //if (string.IsNullOrEmpty(_userId))
            //    throw new InvalidOperationException("The userId is required to create and update operations");

            var entities = ChangeTracker
                .Entries()
                .Where(x => x.Entity is EntityBase &&
                            (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((EntityBase)entity.Entity).CreatedAt = DateTime.UtcNow;
                    //((EntityBase)entity.Entity).CreatedBy = _userId;
                    ((EntityBase)entity.Entity).CreatedBy = "System";
                }
                else
                {
                    ((EntityBase)entity.Entity).ModifiedAt = DateTime.UtcNow;
                    //((EntityBase)entity.Entity).ModifiedBy = _userId;
                    ((EntityBase)entity.Entity).ModifiedBy = "System";
                }
            }
        }
    }
}