using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Data.Entities
{
    public class UserRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
