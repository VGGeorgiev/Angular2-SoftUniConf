using Microsoft.AspNetCore.SignalR;
using SignalRPlayground.Models;
using System.Threading.Tasks;

namespace SignalRPlayground.Hubs
{
    public class MessagePackHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await this.Clients.All.SendAsync("receiveMessage", user, message);
        }
    }
}
