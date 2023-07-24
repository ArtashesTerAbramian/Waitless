using Waitless.DAL.Models;

namespace Waitless.BLL.Filters;

public class VendorFilter : BaseFilter<Vendor>
{
    public string? Name { get; set; }
    public override IQueryable<Vendor> CreateQuery(IQueryable<Vendor> query)
    {
        if(Query is not null)
        {
            return Query;
        }
        if (!string.IsNullOrWhiteSpace(Name))
        {
            query = query.Where(x => x.Name.ToLower().Contains(Name.ToLower()));
        }

        return query;
    }
}
