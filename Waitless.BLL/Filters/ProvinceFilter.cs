using Waitless.DAL.Models;

namespace Waitless.BLL.Filters;

public class ProvinceFilter : BaseFilter<Province>
{
    public string? Name { get; set; }
    public override IQueryable<Province> CreateQuery(IQueryable<Province> query)
    {
        if(Query is { })
        {
            return Query;
        }

        if (!string.IsNullOrWhiteSpace(Name))
        {
            query = query.Where(x => x.Translations.Any(x => x.Name.ToLower().Contains(Name.ToLower())));
        }

        return query;
    }
}
