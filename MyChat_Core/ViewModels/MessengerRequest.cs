using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.ViewModels
{
    public class MessengerRequest
    {
        public string Content { get; set; }
        public DateTime Constamps { get; set; }
        public bool status { get; set; }
        public string Title { get; set; }
        public int MessengerId{ get; set; }
        public int ChatId { get; set; }
    }
}
