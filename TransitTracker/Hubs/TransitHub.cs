using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

namespace TransitTracker.Hubs {

    public class TransitHub: Hub {
        public string GetConnectionId() {
            return Context.ConnectionId;
        }

        public async Task SendMessage(string data) {
            await Clients.All.SendAsync("ReceiveMessage", data);
        }

        public override async Task OnConnectedAsync() {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception) {
            //if(Context.User.IsInRole("Administrator")) {
            //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "adminGroup");
            //}

            await base.OnDisconnectedAsync(exception);
        }
    }
}
