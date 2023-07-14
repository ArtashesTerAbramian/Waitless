using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class AddressConfiguration : BaseConfiguration<Address>
{
    public override void Configure(EntityTypeBuilder<Address> builder)
    {
        base.Configure(builder);

        builder.ToTable("address");

        builder.Property(x => x.PostalCode).
            HasMaxLength(50);

        builder.HasIndex(x => x.CityId);
    }
}
