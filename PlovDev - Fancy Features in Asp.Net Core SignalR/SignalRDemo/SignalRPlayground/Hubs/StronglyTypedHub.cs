using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRPlayground.Hubs
{
    public class StronglyTypedHub : Hub<IChatClient>
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.ReceiveMessage(user, message);
        }
    }
}
