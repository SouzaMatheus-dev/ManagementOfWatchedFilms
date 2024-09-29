using ManagementOfWatchedFilms.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public abstract class EntityTypeBaseConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<TBase> builder)
    {
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}