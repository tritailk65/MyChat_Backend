using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.ViewModels
{
	public class LoginRequestValidator : AbstractValidator<LoginRequest>
	{
		public LoginRequestValidator()
		{
			RuleFor(x => x.Email
			).NotEmpty().WithMessage("UserName is Required");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Password is Required")
				.MinimumLength(6).WithMessage("Password is at least 6 character");
		}
	}
}
