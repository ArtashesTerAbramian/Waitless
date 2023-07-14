using Waitless.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waitless.BLL.Filters
{
    public class BeverageFilter : BaseFilter<Beverage>
    {
        public string? Name { get; set; }
        
        public override IQueryable<Beverage> CreateQuery(IQueryable<Beverage> query)
        {
            if(Query != null)
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
}
