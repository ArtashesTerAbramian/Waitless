using Waitless.DAL.Models;

namespace Waitless.BLL.Filters;

public class CartFilter : BaseFilter<Cart>
{
    public long? UserId { get; set; }

    public override IQueryable<Cart> CreateQuery(IQueryable<Cart> query)
    {
        if(Query != null)
        {
            return Query;
        }

        if(UserId.HasValue && UserId.Value > 0)
        {
            query = query.Where(x => x.UserId == UserId);
        }

        return query;
    }
}
