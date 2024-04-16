using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MyChat_Core.Common;
using MyChat_Core.Interfaces;
using MyChat_Core.ViewModels;
using MyChat_Data.EF;
using MyChat_Data.Entities;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace MyChat_Core.Services
{
    public class UserService : IUserService
    {
        private readonly MyChatDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;
        private readonly EmailSettings emailSettings;
     
        public UserService(MyChatDbContext db, UserManager<User> userManager, SignInManager<User> signInManager, 
            IConfiguration config, IOptions<EmailSettings> options)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            this.emailSettings = options.Value;
        }

		public async Task<ApiResult<string>> Authentication(LoginRequest request)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
				return new ApiErrorResult<string>("Khong tim thay ");
			var result = await _signInManager.
			PasswordSignInAsync(user, request.Password, request.RememberMe, true);
			if (!result.Succeeded)
			{
				return null;
			}
			var roles = await _userManager.GetRolesAsync(user);
			//Luu Token Can Thiet
			var claims = new[]
			{
				 new Claim(ClaimTypes.Email,user.Email),
				 new Claim(ClaimTypes.GivenName,user.FirstName),
				 new Claim(ClaimTypes.Role,string.Join(";",roles)),
				 new Claim(ClaimTypes.Name,user.UserName)
			 };
			//Ma Hoa Bang Thu Vien SymmerTric
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(_config["Tokens:Issuer"],
				_config["Tokens:Issuer"],
				claims,
				expires: DateTime.Now.AddHours(7),
				signingCredentials: creds
				);
			return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
		}
        public async Task<UserViewModel>GetbyId(Guid id)
        {
            var query = from c in _db.Users
                        where c.Id==id
                        select new { c};
            return await query.Select(x => new UserViewModel()
            {
               Id=x.c.Id,
               Email=x.c.Email,
               FirstName=x.c.FirstName,
               LastName=x.c.LastName,
               UserName=x.c.UserName

            }).FirstOrDefaultAsync();
        }
		public List<User> GetAllUser()
        {
            return _db.Users.ToList();
        }

		public async Task<string> Register(RegisterRequest request)
		{
            var user = new User()
            {
                Birthday=request.Birthday,
                FirstName=request.FirstName,
                LastName=request.LastName,
                UserName=request.Username,
                Status=request.Status,
                Email=request.Email,
                PhoneNumber=request.PhoneNumber
            };
            request.Title = "MyChatApp";
            request.Body = "Hello";
            var result = await _userManager.CreateAsync(user, request.Password);

/*            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(request.Email));
            email.Subject = request.Title;
            var builder = new BodyBuilder();
            builder.HtmlBody = request.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailSettings.Email, emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);*/

            if (result.Succeeded)
            {
                return "Chào mừng"+" "+request.FirstName+" "+request.LastName+" Đến với MyChat";
            }
            return null;
		}
	}
}
