using Discord;
using KrisMyAss.Commands;
using KrisMyAss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrisMyAss.Commands
{
    public class LMGTFY : ICommand
    {
        public async Task Execute(MessageEnvelope env)
        {
            string query = env.Raw.Content.Replace("lmgtfy", string.Empty, true, null).Trim();
            string url = Uri.EscapeUriString($"https://www.google.com/search?q={query}");
            EmbedBuilder eb = new EmbedBuilder();

            eb.Url = url;
            eb.Title = "Let Me Google That For You";
            eb.Color = Color.DarkTeal;

            await env.Raw.Channel.SendMessageAsync(embed: eb.Build());
        }
    }
}
