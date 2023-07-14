using Waitless.DAL.Models;

namespace Waitless.BLL.Filters;

public class UserFilter : BaseFilter<User>
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public override IQueryable<User> CreateQuery(IQueryable<User> query)
    {
        if (Query != null)
        {
            return Query;
        }

        if (!string.IsNullOrWhiteSpace(UserName))
        {
            query = query.Where(x => x.UserName.ToLower().Contains(UserName.ToLower()));
        }
        
        if (!string.IsNullOrWhiteSpace(Email))
        {
            query = query.Where(x => x.Email.ToLower().Contains(Email.ToLower()));
        }

        return query;
    }
}