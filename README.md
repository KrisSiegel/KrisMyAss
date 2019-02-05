# KrisMyAss
Kris My Ass is a fantastic Discord bot written in .Net Core.

## Getting started
This is a fairly straight forward service to run but first thing is first!

1. Setup your application and bot in discord's developer portal (https://discordapp.com/developers/)
2. Once setup, take the bot's token and put it in a system level environment variable called `discord_bot_krismyass_token`
3. Invite your bot to your Discord server(s) by crafting the following URL, making sure to set the `client_id` query string appropriately with your discord app's client_id: https://discordapp.com/oauth2/authorize?client_id=##########&scope=bot&permissions=378944
4. Enjoy!

## Currently supported
Eventually this bot will support a wide variety of features but, initially, it's a bit limited. So they're all listed here!

### Stock ticker
Simply run `$SYMBOL` to get the current price of a stock. You can chain multiple like `$aapl msft ebay` via spaces or any other, non-alphanumeric character.