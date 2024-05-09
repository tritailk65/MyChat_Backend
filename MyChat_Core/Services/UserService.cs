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
using MyChat_API.Exceptions;

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

		public async Task<UserViewModel> Authentication(LoginRequest request)
		{
            try
            {
                if (!_db.Database.CanConnect())
                {
                    throw new BadRequestException("Can not connect to database !",400,400);
                }

			    var user = await _userManager.FindByEmailAsync(request.Email);
			    if (user == null)
                    throw new BadRequestException("User not found", 404, 404);
                var result = await _signInManager.
			    PasswordSignInAsync(user, request.Password, request.RememberMe, true);
			    if (!result.Succeeded)
			    {
                    throw new BadRequestException("Authenticate fail !",401, 401);
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
                UserViewModel userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)             
                };
                return userViewModel;
            } catch 
            {
                throw;
            }
		}

		public List<User> GetAllUser()
        {
            return _db.Users.ToList();
        }

        public async Task<User> GetUserByID(Guid id)
        {
            var data  =  await _db.Users.FindAsync(id);
            return data;
        }

        public async Task Register(RegisterRequest request)
		{
            try
            {
                var user = new User()
                {
                    FirstName=request.FirstName,
                    LastName=request.LastName,
                    Email=request.Email,
                    UserName = request.Username
                };

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

                if (!result.Succeeded) { 
   
                    throw new BadRequestException(result.ToString(), 400, 400);
                }
            } catch (Exception ex)
            {
                throw new BadRequestException(ex.ToString(),400,400);
            }

		}
	}
}
