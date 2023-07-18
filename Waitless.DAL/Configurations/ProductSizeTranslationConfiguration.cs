using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class ProductSizeTranslationConfiguration : BaseConfiguration<ProductSizeTranslation>
{
    public override void Configure(EntityTypeBuilder<ProductSizeTranslation> builder)
    {
        base.Configure(builder);

        builder.ToTable("product_size_translation");

        builder.Property(x => x.Size)
            .HasMaxLength(50);

        builder.HasIndex(x => x.ProductSizeId);
    }
}
