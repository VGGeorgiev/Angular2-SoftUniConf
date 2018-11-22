namespace SignalRPlayground.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System.Collections.Generic;
    using System.Threading.Channels;
    using System.Threading.Tasks;

    public class StreamingHub : Hub
    {
        private List<string> words = new List<string> { "Beans", "Corn", "Cucumber", "Onion", "Potato", "Cabbage", "Garlic", "Tomato", "Pumpkin", "Vlado" };

        public ChannelReader<string> ShowMeTheWords(int delay)
        {
            var channel = Channel.CreateUnbounded<string>();

            // We don't await WriteItemsAsync, otherwise we'd end up waiting 
            // for all the items to be written before returning the channel back to
            // the client.
            _ = WriteItemsAsync(channel.Writer, delay);

            return channel.Reader;
        }

        private async Task WriteItemsAsync(ChannelWriter<string> writer, int delay)
        {
            for (var i = 0; i < words.Count; i++)
            {
                await writer.WriteAsync(words[i]);
                await Task.Delay(delay);
            }
            
            writer.Complete();
        }
    }
}
