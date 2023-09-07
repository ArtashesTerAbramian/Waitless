namespace Waitless.DAL.Models;

public class Permission : BaseEntity
{
    public Permission()
    {
        PermissionRoles = new HashSet<PermissionRole>();
    }

    public string Name { get; set; }    
    public string Value { get; set; }
    public long PermissionGroupId { get; set; }

    public PermissionGroup PermissionGroup { get; set; }
    public ICollection<PermissionRole> PermissionRoles { get; set; }
}