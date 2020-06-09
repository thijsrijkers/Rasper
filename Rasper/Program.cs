using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Lavalink;
using DSharpPlus.Net;


namespace Rasper
{
    class Program
    {
        static DiscordClient discord;
        static CommandsNextExtension commands;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "____ENTER___TOKEN____HERE",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    await e.Message.RespondAsync("pong!");
            };

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = new List<string> {"!"}
            });

            commands.RegisterCommands<Command>();
            commands.RegisterCommands<LavaLink>();
            var Lavalink = discord.UseLavalink();
             
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
