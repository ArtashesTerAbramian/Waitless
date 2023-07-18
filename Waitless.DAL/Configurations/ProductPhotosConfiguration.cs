using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class BeveragePhotosConfiguration : BaseConfiguration<ProductPhoto>
{
    public override void Configure(EntityTypeBuilder<ProductPhoto> builder)
    {
        base.Configure(builder);

        builder.ToTable("beverage_photo");

        builder.Property(x => x.FileUrl)
            .HasMaxLength(256);
    }
}
