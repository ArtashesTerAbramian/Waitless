using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class BeverageSizeTranslationConfiguration : BaseConfiguration<BeverageSizeTranslation>
{
    public override void Configure(EntityTypeBuilder<BeverageSizeTranslation> builder)
    {
        base.Configure(builder);

        builder.ToTable("beverage_size_translation");

        builder.Property(x => x.Size)
            .HasMaxLength(50);

        builder.HasIndex(x => x.BeverageSizeId);
    }
}
