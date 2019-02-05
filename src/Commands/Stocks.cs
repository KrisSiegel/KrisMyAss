using KrisMyAss.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using YahooFinanceApi;

namespace KrisMyAss.Commands
{
    public class Stocks : ICommand
    {
        private static string AddPlusOrMinus(double val)
        {
            string str = val.ToString("0.00");
            if (val > 0)
                return $"+{str}";
            else
                return $"{str}";
        }

        public async Task Execute(MessageEnvelope env)
        {
            string prepared = env.Raw.Content.TrimStart().ToLower();
            List<string> symbols = new List<string>();
            StringBuilder str = new StringBuilder();
            foreach(char c in prepared)
            {
                if (char.IsLetterOrDigit(c))
                {
                    str.Append(c);
                } else if (str.Length > 0)
                {
                    symbols.Add(str.ToString());
                    str.Clear();
                }
            }

            if (str.Length > 0)
            {
                symbols.Add(str.ToString());
            }

            var stocks = await Yahoo.Symbols(symbols.ToArray()).Fields(
                Field.Symbol,
                Field.LongName,
                Field.RegularMarketPrice,
                Field.RegularMarketChange,
                Field.RegularMarketChangePercent
            ).QueryAsync();

            foreach (Security stock in stocks.Values)
            {
                EmbedBuilder eb = new EmbedBuilder();
                eb.WithAuthor(author =>
                {
                    author.Name = stock.LongName;
                    author.Url = $"https://finance.yahoo.com/quote/{stock.Symbol}";
                });
                eb.Title = stock.Symbol;
                eb.Color = (stock.RegularMarketChange > 0) ? Color.DarkGreen : Color.DarkRed;
                eb.WithFooter(footer =>
                {
                    footer.Text = "Yahoo Finance Quote";
                });
                eb.WithCurrentTimestamp();
                StringBuilder desc = new StringBuilder();
                desc.Append($"{stock.RegularMarketPrice.ToString("0.00")} ({Stocks.AddPlusOrMinus(stock.RegularMarketChange)} / {Stocks.AddPlusOrMinus(stock.RegularMarketChangePercent)}%)");

                eb.Description = desc.ToString();
                await env.Raw.Channel.SendMessageAsync(embed: eb.Build());
            }
        }
    }
}
