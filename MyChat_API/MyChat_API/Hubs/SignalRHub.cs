using Microsoft.AspNetCore.SignalR;

namespace MyChat_API.Hubs
{
    public class SignalRHub : Hub
    {
        public void SendMessage(string user, string message)
        {
            Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
