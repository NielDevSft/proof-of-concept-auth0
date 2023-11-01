﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Persistence.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
