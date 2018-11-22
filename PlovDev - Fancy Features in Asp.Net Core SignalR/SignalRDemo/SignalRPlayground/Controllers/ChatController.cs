using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRPlayground.Hubs;
using System.Threading.Tasks;

namespace SignalRPlayground.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> chatHub;

        public ChatController(IHubContext<ChatHub> chatHub)
        {
            this.chatHub = chatHub;
        }

        [HttpGet("/Message")]
        public Task SendMessage(string message)
        {
            return this.chatHub.Clients.All.SendAsync("receiveMessage", "Controller", message);
        }
    }
}
