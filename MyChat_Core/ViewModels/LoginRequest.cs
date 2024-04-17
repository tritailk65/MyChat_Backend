using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.ViewModels
{
	public class LoginRequest
	{
		public string Name { get; set; }

		public string Email { get; set; }
		public string Password { get; set; }

		public bool RememberMe { get; set; }
	}
}
