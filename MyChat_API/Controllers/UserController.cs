using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyChat_API.Utils;
using MyChat_Core.Interfaces;
using MyChat_Core.Services;
using MyChat_Core.ViewModels;
using MyChat_Data.Entities;
using System.Data;
using System.Diagnostics;

namespace MyChat_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILogger<UserController> logger;


        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpGet]
        [Authorize]
        public APIResult GetAllUser()
        {
			logger.LogInformation(Request.Method + " " + Request.Scheme + "://" + Request.Host + Request.Path);
            List<User> dtUsers = userService.GetAllUser();
            APIResult rs = new APIResult();
            return rs.Success(dtUsers);
		}

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<APIResult> Authenticate([FromBody] LoginRequest request)
        {
            logger.LogInformation(Request.Method + " " + Request.Scheme + "://" + Request.Host + Request.Path+ Request.Query);
			
            var resultToken = await userService.Authentication(request);
            APIResult rs = new();

			return rs.Success(resultToken);
		}

        [HttpPost]
        [AllowAnonymous]
        public async Task<APIResult> Register([FromBody] RegisterRequest request )
        {
            logger.LogInformation(Request.Method + " " + Request.Scheme + "://" + Request.Host + Request.Path + Request.Query);
             await userService.Register(request);
            logger.LogInformation("Register Successful:{username}", request.Email);
            APIResult rs = new APIResult();
            return rs.MessageSuccess("Đăng ký thành công !");
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> GetByID([BindRequired] Guid id)
        {
            logger.LogInformation(Request.Method + " " + Request.Scheme + "://" + Request.Host + Request.Path + Request.Query);
            var result = await userService.GetUserByID(id);
            if (result == null)
            {
                return BadRequest("User not found!");
            }
            UserViewModel rs = new UserViewModel
            {
                Id = result.Id,
                UserName = result.UserName,
                Email = result.Email,
                FirstName = result.FirstName,
                LastName = result.LastName,
            };
         
            return Ok(rs);
        }
    }
}
