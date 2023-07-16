using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class BeveragePhotosConfiguration : BaseConfiguration<BeveragePhoto>
{
    public override void Configure(EntityTypeBuilder<BeveragePhoto> builder)
    {
        base.Configure(builder);

        builder.ToTable("beverage_photo");

        builder.Property(x => x.FileUrl)
            .HasMaxLength(256);
    }
}
