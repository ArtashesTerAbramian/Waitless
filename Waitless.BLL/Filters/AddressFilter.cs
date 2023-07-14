using Waitless.DAL.Models;

namespace Waitless.BLL.Filters;

public class AddressFilter : BaseFilter<Address>
{
    public string? Street { get; set; }
    
    public override IQueryable<Address> CreateQuery(IQueryable<Address> query)
    {
        if (Query != null)
        {
            return Query;
        }

        if (!string.IsNullOrWhiteSpace(Street))
        {
            query = query.Where(x => x.Translations.Any(x => 
                x.Street.ToLower().Contains(Street.ToLower())));
        }

        return query;
    }
}