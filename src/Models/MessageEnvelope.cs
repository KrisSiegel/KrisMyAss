using System.Text.RegularExpressions;
using Discord.WebSocket;

namespace KrisMyAss.Models
{
    public class MessageEnvelope
    {
        public SocketMessage Raw { get; set; }

        private string possibleCommand = null;
        public string PossibleCommand {
            get
            {
                if (string.IsNullOrWhiteSpace(possibleCommand))
                {
                    possibleCommand = Regex.Replace((this.Raw?.Content?.ToLower() ?? string.Empty), @"\s", string.Empty);
                }
                return possibleCommand;
            }
        }

        public MessageEnvelope(SocketMessage msg)
        {
            this.Raw = msg;
        }
    }
}
