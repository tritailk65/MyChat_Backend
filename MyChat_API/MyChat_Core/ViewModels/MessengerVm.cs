using MyChat_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.ViewModels
{
	public class MessengerVm
	{
		public int ChatId { get; set; }
		public string Content { get; set; }
		public DateTime Constamps { get; set; }
		public bool status { get; set; }
	}
}
