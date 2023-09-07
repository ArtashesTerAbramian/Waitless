using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations;

public class PermissionGroupConfiguration : BaseConfiguration<PermissionGroup>
{
    public override void Configure(EntityTypeBuilder<PermissionGroup> builder)
    {
        builder.ToTable("permission_group");

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}