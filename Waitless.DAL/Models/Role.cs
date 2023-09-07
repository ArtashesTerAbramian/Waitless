namespace Waitless.DAL.Models;

public class Role : BaseEntity
{
    public Role()
    {
        PermissionRoles = new HashSet<PermissionRole>();
    }

    public string Name { get; set; }
    public long[] ArticlePermissionStatusIds { get; set; }

    public ICollection<PermissionRole> PermissionRoles { get; set; }
}