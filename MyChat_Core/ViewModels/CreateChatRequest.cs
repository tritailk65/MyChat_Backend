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
        public int Participants { get; set; }
        public DateTime created_at { get; set; }

    }
}
