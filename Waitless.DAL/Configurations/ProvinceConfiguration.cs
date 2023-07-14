using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class ProvinceConfiguration : BaseConfiguration<Province>
{
    public override void Configure(EntityTypeBuilder<Province> builder)
    {
        base.Configure(builder);
    }
}
