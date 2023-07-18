using Waitless.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waitless.BLL.Filters
{
    public class ProductFilter : BaseFilter<Product>
    {
        public string? Name { get; set; }
        
        public override IQueryable<Product> CreateQuery(IQueryable<Product> query)
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
