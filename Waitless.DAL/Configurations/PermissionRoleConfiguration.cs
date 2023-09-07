using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations;

public class PermissionRoleConfiguration : BaseConfiguration<PermissionRole>
{
    public override void Configure(EntityTypeBuilder<PermissionRole> builder)
    {
        base.Configure(builder);

        builder.ToTable("permission_role");

        builder.HasIndex(x => new { x.RoleId, x.PermissionId })
            .IsUnique();
    }
}