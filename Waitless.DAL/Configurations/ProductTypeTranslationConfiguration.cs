using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations;

public class ProductTypeTranslationConfiguration : BaseConfiguration<ProductTypeTranslation>
{
    public override void Configure(EntityTypeBuilder<ProductTypeTranslation> builder)
    {
        base.Configure(builder);

        builder.ToTable("beverage_type_translation");

        builder.Property(x => x.Name)
            .HasMaxLength(50);
    }
}