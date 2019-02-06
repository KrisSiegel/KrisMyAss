using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using KrisMyAss.Models;

namespace KrisMyAss
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Startup the Discord bot
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        private readonly DiscordSocketClient _client;

        public Program()
        {
            _client = new DiscordSocketClient();

            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
            _client.MessageReceived += MessageReceivedAsync;
        }

        public async Task MainAsync()
        {
            // Let's use a token specified in the process, user or system environment allowing each to override the other.
            string processSetToken = Environment.GetEnvironmentVariable("discord_bot_krismyass_token", EnvironmentVariableTarget.Process);
            string userSetToken = Environment.GetEnvironmentVariable("discord_bot_krismyass_token", EnvironmentVariableTarget.User);
            string systemSetToken = Environment.GetEnvironmentVariable("discord_bot_krismyass_token", EnvironmentVariableTarget.Machine);

            string token = null;
            if (!string.IsNullOrWhiteSpace(processSetToken))
                token = processSetToken;

            if (token is null && !string.IsNullOrWhiteSpace(userSetToken))
                token = userSetToken;

            if (token is null && !string.IsNullOrWhiteSpace(systemSetToken))
                token = systemSetToken;

            if (token is null)
                throw new Exception("No discord token specified; dying a quick death.");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        private Task ReadyAsync()
        {
            Console.WriteLine($"{_client.CurrentUser} connected");
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(SocketMessage message)
        {
            if (message.Author.Id == _client.CurrentUser.Id)
                return;
            
            await Commander.Process(new MessageEnvelope(message));
        }
    }
}
