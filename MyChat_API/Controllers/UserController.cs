using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyChat_API.Utils;
using MyChat_Core.Interfaces;
using MyChat_Core.Services;
using MyChat_Core.ViewModels;
using MyChat_Data.Entities;
using System.Data;

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
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            logger.LogInformation(Request.Method + " " + Request.Scheme + "://" + Request.Host + Request.Path+ Request.Query);
            if (!ModelState.IsValid)
				return BadRequest(ModelState);

			
            var resultToken = await userService.Authentication(request);
   
			if (resultToken.Data == null)
			{
                return BadRequest();
			}

			return Ok(resultToken);
		}

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request )
        {
            logger.LogInformation(Request.Method + " " + Request.Scheme + "://" + Request.Host + Request.Path + Request.Query);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await userService.Register(request);
            if(result==null)
            {
                return BadRequest("Register is not successfull");
            }
			logger.LogInformation("Register Successful:{username}", request.Email);
			return Ok(result);
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
