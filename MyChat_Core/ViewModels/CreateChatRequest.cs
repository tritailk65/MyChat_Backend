using MyChat_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.ViewModels
{
      public class CreateChatRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Username_Display { get; set; }
        public bool Status { get; set; }
        public DateTime last_seen { get; set; }
        public DateTime created_at { get; set; }

    }
}
