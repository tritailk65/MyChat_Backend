using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public static IWebHostEnvironment _webHostEnvironment;
        private readonly IUserService userService;
        private readonly ILogger<UserController> logger;

        public UserController(IUserService userService, ILogger<UserController> logger, IWebHostEnvironment webHostEnvironment)
        {
            this.userService = userService;
            this.logger = logger;
            _webHostEnvironment = webHostEnvironment;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(Guid id)
        {
            var user = await userService.GetbyId(id);
            if (user == null)
            {
                return NotFound(); // Trả về mã lỗi 404 nếu không tìm thấy user
            }
            return Ok(user);
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
				return BadRequest(ModelState);

			
            var resultToken = await userService.Authentication(request);
   
			if (string.IsNullOrEmpty(resultToken.ResultObj))
			{
                return BadRequest();
			}
            logger.LogInformation("Login Successful:{username}",request.Name);
			return Ok(resultToken);
		}

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request )
        {
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
      
    }
}
