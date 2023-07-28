using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waitless.DAL.Models
{
    public class UserPasswordReset : BaseEntity
    {
        public long UserId { get; set; }
        public string Token { get; set; }
        public bool Expired { get; set; } = false;

        public User User { get; set; }
    }
}
