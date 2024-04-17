using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Data.Entities
{
    public class Contact
    {
        public int contact_id { get; set; }
        public Messenger Messenger { get; set; }
        public int MessengerId { get; set; }
        public string contact_phone { get; set; }
    }
}
