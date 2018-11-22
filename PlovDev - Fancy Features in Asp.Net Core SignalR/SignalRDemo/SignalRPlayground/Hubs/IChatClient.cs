using System.Threading.Tasks;

namespace SignalRPlayground.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
    }
}
