namespace Waitless.DAL.Models;

public class PermissionRole : BaseEntity
{
    public long PermissionId { get; set; }
    public long RoleId { get; set; }

    public Permission Permission { get; set; }
    public Role Role { get; set; }
}