namespace Waitless.DAL.Models;

public class PermissionGroup : BaseEntity
{
    public PermissionGroup()
    {
        Permissions = new HashSet<Permission>();
    }

    public string Name { get; set; }

    public ICollection<Permission> Permissions { get; set; }
}