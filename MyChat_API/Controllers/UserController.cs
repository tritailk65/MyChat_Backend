using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyChat_API.Utils;
using MyChat_Core.Interfaces;
using MyChat_Core.Services;
using MyChat_Core.ViewModels;
using MyChat_Data.Entities;
using Org.BouncyCastle.Asn1.Ocsp;
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
        private readonly UserManager<User> _usermanager;

        public UserController(IUserService userService, ILogger<UserController> logger, IWebHostEnvironment webHostEnvironment,UserManager<User>usermanager)
        {
            this.userService = userService;
            this.logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _usermanager = usermanager;
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
            logger.LogInformation("Login Successful:{Email}",request.Email);
			return Ok(resultToken);
		}
        

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request )
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
        [HttpPost]
        [Route("edit-register")]
        public async Task<IActionResult> Edit([FromForm] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _usermanager.FindByEmailAsync(request.Email);
            if (result == null)
            {
                return NotFound("User Not Found");
            }
            result.FirstName = request.FirstName;
            result.LastName = request.LastName;
            result.Birthday = request.Birthday;
            result.PhoneNumber = request.PhoneNumber;
            result.Status = request.Status;
            if(request.ProfileImage!=null && request.ProfileImage.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.ProfileImage.FileName);
                var filePath = Path.Combine("C:\\Users\\Dell\\Documents\\GitHub\\MyChat_Backend\\MyChat_Data\\Image", fileName); // Thay đổi "Uploads" thành đường dẫn thư mục lưu trữ của bạn
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ProfileImage.CopyToAsync(stream);
                }
                result.UpImage = filePath;
            }
            var result1 = await _usermanager.UpdateAsync(result);
            if (!result1.Succeeded)
            {
                return BadRequest("Failed to update user registration information");
            }

            return Ok("Registration information updated successfully");
        }
      
    }
}
