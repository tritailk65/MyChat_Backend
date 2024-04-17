using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyChat_API.DTOs;

namespace MyChat_API.Hubs
{
    public class CallHub : Hub
    {
        public async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }

        public async Task LeaveRoom(string roomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
        }

        public async Task SendOffer(string roomId, RTCSessionDescriptionDTO offer)
        {
            await Clients.OthersInGroup(roomId).SendAsync("ReceiveOffer", offer);
        }

        public async Task SendAnswer(string roomId, RTCSessionDescriptionDTO answer)
        {
            await Clients.OthersInGroup(roomId).SendAsync("ReceiveAnswer", answer);
        }

        public async Task SendIceCandidate(string roomId, RTCIceCandidateDTO candidate)
        {
            await Clients.OthersInGroup(roomId).SendAsync("ReceiveIceCandidate", candidate);
        }
    }
}
