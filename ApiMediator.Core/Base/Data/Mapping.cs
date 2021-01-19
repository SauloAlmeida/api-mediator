using ApiMediator.Core.Base.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMediator.Core.Base.Data
{
    public abstract class Mapping<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // builder.ToTable(TEntity);
            builder.HasKey(k => k.Id);
            builder.HasIndex(k => k.Id).IsUnique();
        }

        public abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);
    }
}
