using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class ProvinceTranslationConfiguration : BaseConfiguration<ProvinceTranslation>
{
    public override void Configure(EntityTypeBuilder<ProvinceTranslation> builder)
    {
        base.Configure(builder);

        builder.ToTable("province_translation");

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsUnicode(true)
            .IsRequired();
    }
}
