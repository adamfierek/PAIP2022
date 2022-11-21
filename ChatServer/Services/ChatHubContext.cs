using ChatServer.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer.Services
{
    public class ChatHubContext
    {
        private readonly IHubContext<ChatHub> hubContext;

        public ChatHubContext(IHubContext<ChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }
    }
}
