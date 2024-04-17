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

        public async Task CallUser(string userId)
        {
            // Gửi yêu cầu cuộc gọi đến người dùng với userId
            await Clients.User(userId).SendAsync("ReceiveCall");
        }

        public async Task AnswerCall(string userId)
        {
            // Trả lời cuộc gọi từ người dùng với userId
            await Clients.User(userId).SendAsync("ReceiveAnswer");
        }

        public async Task SendICECandidate(string userId, string candidate)
        {
            // Gửi ICE candidate đến người dùng với userId
            await Clients.User(userId).SendAsync("ReceiveICECandidate", candidate);
        }
    }
}
