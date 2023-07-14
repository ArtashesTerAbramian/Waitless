using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class CoffeePhotosConfiguration : BaseConfiguration<CoffeePhoto>
{
    public override void Configure(EntityTypeBuilder<CoffeePhoto> builder)
    {
        base.Configure(builder);

        builder.ToTable("coffee_photo");

        builder.Property(x => x.FileUrl)
            .HasMaxLength(256);
    }
}
