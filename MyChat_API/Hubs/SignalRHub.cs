using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MyChat_API.Hubs
{
    public class SignalRHub : Hub
    {
        public async Task SendMessage(int senderId, int receiverId, string message)
        {
            // Gửi tin nhắn tới receiverId thông qua giao thức SignalR
            await Clients.User(receiverId.ToString()).SendAsync("ReceiveMessage", senderId, message);
        }
        public async Task CallUser(int callerId, int receiverId)
        {
            // Gửi tín hiệu gọi điện tới receiverId
            await Clients.User(receiverId.ToString()).SendAsync("ReceiveCall", callerId);
        }
       
    }
}
