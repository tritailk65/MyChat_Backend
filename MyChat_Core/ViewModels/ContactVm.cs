using MyChat_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.ViewModels
{
    public class ContactVm
    {
        public int contact_id { get; set; }
        public int MessengerId { get; set; }
        public string contact_phone { get; set; }
    }
}
