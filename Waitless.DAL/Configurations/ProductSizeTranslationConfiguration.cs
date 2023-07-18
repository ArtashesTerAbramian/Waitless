using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class BeverageSizeTranslationConfiguration : BaseConfiguration<ProductSizeTranslation>
{
    public override void Configure(EntityTypeBuilder<ProductSizeTranslation> builder)
    {
        base.Configure(builder);

        builder.ToTable("beverage_size_translation");

        builder.Property(x => x.Size)
            .HasMaxLength(50);

        builder.HasIndex(x => x.ProductSizeId);
    }
}
