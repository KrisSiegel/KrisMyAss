using KrisMyAss.Models;
using System.Threading.Tasks;

namespace KrisMyAss.Commands
{
    public class Ping : ICommand
    {
        public async Task Execute(MessageEnvelope env)
        {
            await env.Raw.Channel.SendMessageAsync("Pong!");
        }
    }
}
