using System.Collections.Generic;
using System.Threading.Tasks;
using KrisMyAss.Commands;
using KrisMyAss.Processors;
using KrisMyAss.Models;

namespace KrisMyAss
{
    public class Commander
    {
        // A list of explicit commands we support
        private static List<KeyValuePair<string, ICommand>> _commands = new List<KeyValuePair<string, ICommand>>
        {
            //new KeyValuePair<string, ICommand>("ping", new Ping()),
            new KeyValuePair<string, ICommand>("$", new Stocks()),
            new KeyValuePair<string, ICommand>("lmgtfy", new LMGTFY())
        };

        // A list of explicit language processors we support
        private static List<IProcessor> _processors = new List<IProcessor>
        {
            
        };

        public static async Task Process(MessageEnvelope env)
        {
            // Run through the quick command comparisons first
            for (int i = 0; i < _commands.Count; ++i)
            {
                var cmd = _commands[i];
                if (env.PossibleCommand.IndexOf(cmd.Key) == 0)
                {
                    await cmd.Value.Execute(env);
                    break;
                }
            }

            // Then through the language processors
            for (int i = 0; i < _processors.Count; ++i)
            {
                var proc = _processors[i];
                // Do something with the processor
            }
        }
    }
}
