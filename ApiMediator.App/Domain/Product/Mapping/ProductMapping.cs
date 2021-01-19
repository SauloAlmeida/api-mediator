using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMediator.App.Domain.Product.Mapping
{
    public class ProductMapping : Core.Base.Data.Mapping<Model.Product>
    {
        public override void ConfigureProperties(EntityTypeBuilder<Model.Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired();
        }
    }
}
