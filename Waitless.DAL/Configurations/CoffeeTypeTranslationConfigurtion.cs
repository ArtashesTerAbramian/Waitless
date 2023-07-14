using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class CoffeeTypeTranslationConfigurtion : BaseConfiguration<BeverageTypeTranslation>
{
    public override void Configure(EntityTypeBuilder<BeverageTypeTranslation> builder)
    {
        base.Configure(builder);

        builder.ToTable("coffee_type_translation");

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasIndex(x => new { x.BeverageTypeId, x.LanguageId });
    }
}
