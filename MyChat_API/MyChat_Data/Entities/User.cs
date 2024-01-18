using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public String FirstName {  get; set; }
        public String LastName { get; set; }
        public DateTime Birthday { get; set; }

    }
}
