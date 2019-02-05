using System.Collections.Generic;
using System.Threading.Tasks;
using KrisMyAss.Commands;
using KrisMyAss.Models;

namespace KrisMyAss
{
    public class Commander
    {
        // A list of explicit commands we support
        private static List<KeyValuePair<string, ICommand>> _commands = new List<KeyValuePair<string, ICommand>>
        {
            new KeyValuePair<string, ICommand>("ping", new Ping()),
            new KeyValuePair<string, ICommand>("$", new Stocks())
        };

        public static async Task Process(MessageEnvelope env)
        {
            // Run through the quick command comparisons first
            for (int i = 0; i < _commands.Count; ++i)
            {
                if (env.PossibleCommand.IndexOf(_commands[i].Key) == 0)
                {
                    await _commands[i].Value.Execute(env);
                    break;
                }
            }
        }
    }
}
