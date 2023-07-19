using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waitless.DAL.Enums
{
    public enum OrderStateEnum
    {
        Placed = 1,
        InProgress = 2,
        Ready= 3,
        Completed = 4,
        Cancelled = 5
    }
}
