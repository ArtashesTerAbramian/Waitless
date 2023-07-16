using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations;

public class BeverageTypeTranslationConfiguration : BaseConfiguration<BeverageTypeTranslation>
{
    public override void Configure(EntityTypeBuilder<BeverageTypeTranslation> builder)
    {
        base.Configure(builder);

        builder.ToTable("beverage_type_translation");

        builder.Property(x => x.Name)
            .HasMaxLength(50);
    }
}