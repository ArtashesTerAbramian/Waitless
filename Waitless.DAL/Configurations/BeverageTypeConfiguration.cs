using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations;

public class BeverageTypeConfiguration : BaseConfiguration<BeverageType>
{
    public override void Configure(EntityTypeBuilder<BeverageType> builder)
    {
        base.Configure(builder);

        builder.ToTable("beverage_type");
    }
}