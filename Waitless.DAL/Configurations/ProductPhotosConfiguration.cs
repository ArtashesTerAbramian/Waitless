using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class ProductPhotosConfiguration : BaseConfiguration<ProductPhoto>
{
    public override void Configure(EntityTypeBuilder<ProductPhoto> builder)
    {
        base.Configure(builder);

        builder.ToTable("product_photo");

        builder.Property(x => x.FileUrl)
            .HasMaxLength(256);
    }
}
