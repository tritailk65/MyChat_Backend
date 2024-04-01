using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyChat_Core.Common;
using MyChat_Core.Interfaces;
using MyChat_Core.ViewModels;
using MyChat_Data.EF;
using MyChat_Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.Services
{
    public class UserService : IUserService
    {
        private readonly MyChatDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;
        public UserService(MyChatDbContext db, UserManager<User> userManager, SignInManager<User> signInManager, 
            IConfiguration config)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

		public async Task<ApiResult<string>> Authentication(LoginRequest request)
		{
			var user = await _userManager.FindByNameAsync(request.Name);
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
				 new Claim(ClaimTypes.Name,request.Name)
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

		public List<User> GetAllUser()
        {
            return _db.Users.ToList();
        }

		public async Task<bool> Register(RegisterRequest request)
		{
            var user = new User()
            {
                Birthday=request.Birthday,
                FirstName=request.FirstName,
                LastName=request.LastName,
                UserName=request.UserName,
                Email=request.Email,
                PhoneNumber=request.PhoneNumber
            };
			var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
		}
	}
}
