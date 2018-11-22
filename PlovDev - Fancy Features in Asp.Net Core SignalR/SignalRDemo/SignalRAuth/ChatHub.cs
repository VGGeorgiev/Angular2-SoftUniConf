using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRPlayground.Hubs
{
    public class ChatHub : Hub
    {
        [Authorize]
        public async Task SendMessage(string user, string message)
        {
            await this.Clients.All.SendAsync("receiveMessage", user, message);
        }
    }
}
