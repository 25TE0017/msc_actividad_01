using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace actividad01.Hubs
{
    public class MapHub : Hub
    {
        public async Task SendMarker(string message, object user)
        {
            await Clients.All.SendAsync("ReceiveMarker", message, user);
        }
    }
}