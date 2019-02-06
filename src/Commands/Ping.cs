using KrisMyAss.Models;
using System.Threading.Tasks;

namespace KrisMyAss.Commands
{
    // This is the 'Hello, World!' of commands for KrisMyAss. This is usually disabled by default, heh
    public class Ping : ICommand
    {
        public async Task Execute(MessageEnvelope env)
        {
            await env.Raw.Channel.SendMessageAsync("Pong!");
        }
    }
}
