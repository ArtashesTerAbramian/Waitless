using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class BeverageSizeConfiguration : BaseConfiguration<BeverageSize>
{
    public override void Configure(EntityTypeBuilder<BeverageSize> builder)
    {
        base.Configure(builder);

        builder.ToTable("coffee_size");
    }
}
