using Waitless.DAL.Models;

namespace Waitless.BLL.Filters;

public class CityFilter : BaseFilter<City>
{
    public string? Name { get; set; }
    public override IQueryable<City> CreateQuery(IQueryable<City> query)
    {
        if (Query != null)
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