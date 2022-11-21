using ChatModel;
using ChatServer.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatHubContext chatHubContext;

        public ChatHub(ChatHubContext chatHubContext)
        {
            this.chatHubContext = chatHubContext;
        }

        public async Task SendMessage(Message message)
        {
            await Clients.Others.SendAsync("ReceiveMessage", message);
        }

        public async Task Hello(string username)
        {
            await Clients.Others.SendAsync("HelloMessage", username);
        }

    }
}
