using Authentication.Domain.Core.Models;
using Authentication.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Persistence.Mapping
{
    public class DefaultMap<T> : EntityTypeConfiguration<T> where T : Entity<T>
    {
        public override void Map(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id)
                .IsClustered();

            builder.Property(e => e.Active)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.Removed)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValueSql("((0))");

            builder.Ignore(e => e.CascadeMode);

        }
    }
}
