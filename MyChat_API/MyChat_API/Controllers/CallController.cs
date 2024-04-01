using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyChat_API.Hubs;

namespace MyChat_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private readonly IHubContext<SignalRHub> _chatHubContext;

        public CallController(IHubContext<SignalRHub> chatHubContext)
        {
            _chatHubContext = chatHubContext;
        }
        [HttpPost("call")]
        public IActionResult CallUser(int callerId, int receiverId)
        {
            _chatHubContext.Clients.All.SendAsync("CallUser", callerId, receiverId);
            return Ok();
        }

    }
}
