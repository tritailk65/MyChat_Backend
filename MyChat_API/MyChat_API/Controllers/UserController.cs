using Microsoft.AspNetCore.Mvc;
using MyChat_API.Utils;
using MyChat_Core.Interfaces;
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
        public APIResult GetAllUser()
        {

            logger.LogInformation(Request.Method + " " + Request.Scheme + "://" + Request.Host + Request.Path);

            List<User> dtResult = userService.GetAllUser();

            APIResult rs = new APIResult();
            return rs.Success(dtResult);
        }
    }
}
