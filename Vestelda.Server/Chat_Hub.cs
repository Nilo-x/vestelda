using Microsoft.AspNetCore.SignalR;

namespace Vestelda.Server
{
    public class Chat_Hub : Hub
    {
        // Join a specific chat room
        public async Task JoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        // Send a message to all users in a specific room
        public async Task SendMessageToRoom(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        // Optionally, to send a message only to the group (room):
        public async Task SendMessageToGroup(string roomName, string user, string message)
        {
            await Clients.Group(roomName).SendAsync("ReceiveMessage", user, message);
        }
    }
}