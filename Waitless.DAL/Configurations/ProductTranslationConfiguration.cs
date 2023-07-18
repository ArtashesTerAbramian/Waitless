using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class ProductTranslationConfiguration : BaseConfiguration<ProductTranslation>
{
    public override void Configure(EntityTypeBuilder<ProductTranslation> builder)
    {
        base.Configure(builder);

        builder.ToTable("product_translation");

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Description)
           .HasMaxLength(256)
           .IsRequired();

        builder.HasKey(x => new { x.LanguageId, x.ProductId });
    }
}
