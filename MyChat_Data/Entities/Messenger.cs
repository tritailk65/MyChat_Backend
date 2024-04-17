using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Data.Entities
{
    public class Messenger 
    {
        public int MessengerId { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public string Content { get; set; }
        public DateTime Constamps { get; set; }
        public List<Contact> Contacts { get; set; }
        public bool status { get; set; }

    }
}
