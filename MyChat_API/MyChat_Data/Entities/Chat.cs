using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Data.Entities
{
    public class Chat
    {
        public int Chatid { get; set;}
        public string Title { get; set;}
        public string Content { get; set; }
        public int Participants { get; set;}
        public List<Messenger> Messengers { get; set; }
        public DateTime created_at { get; set;}
    }
}
