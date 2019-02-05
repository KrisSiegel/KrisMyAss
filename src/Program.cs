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
            await _client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("discord_bot_krismyass_token", EnvironmentVariableTarget.Machine));
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
