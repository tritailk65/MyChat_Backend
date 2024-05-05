using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.ViewModels
{
	public class RegisterRequest
	{
		public String FirstName { get; set; }
		public String LastName { get; set; }
		public DateTime Birthday { get; set; }
		public string Email { get; set; }
		public string? PhoneNumber { get; set; }
        public string Username { get; set; }
		public string? Title { get; set; }
		public string? Body { get; set; }
        public bool Status { get; set; }
        public string Password { get; set; }
		public string? ConfirmPassword { get; set; }
		
	}
}
