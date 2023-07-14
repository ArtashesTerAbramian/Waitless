using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class CoffeePhotosConfiguration : BaseConfiguration<BeveragePhoto>
{
    public override void Configure(EntityTypeBuilder<BeveragePhoto> builder)
    {
        base.Configure(builder);

        builder.ToTable("coffee_photo");

        builder.Property(x => x.FileUrl)
            .HasMaxLength(256);
    }
}
