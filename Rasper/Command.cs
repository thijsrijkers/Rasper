using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Lavalink;
using DSharpPlus.Lavalink.EventArgs;

namespace Rasper
{
    public class Command : BaseCommandModule
    {
        private LavalinkExtension LavalinkService { get; }
        private LavalinkNodeConnection Lavalink { get; set; }
        private LavalinkGuildConnection LavalinkVoice { get; set; }


        [Command("hi")]
        public async Task Hi(CommandContext ctx)
        {
            await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");
        }

        [Command("github")]
        public async Task Github(CommandContext ctx)
        {
            await ctx.RespondAsync("https://github.com/thijsrijkers/Rasper");
        }

        [Command("advise")]
        public async Task musicAdvise(CommandContext ctx)
        {
            await ctx.RespondAsync("https://www.youtube.com/watch?v=F3IwBMuDtu8");
            await ctx.RespondAsync("https://www.youtube.com/watch?v=FCesTBJFBwE");
            await ctx.RespondAsync("https://www.youtube.com/watch?v=XEC2avceTxY");
        }
        private Process CreateStream(string url)
        {
            Process currentsong = new Process();
            try
            {
                currentsong.StartInfo = new ProcessStartInfo
                {
                    FileName = "youtube-dl.exe",
                    Arguments = $"-o - {url} | ffmpeg -i pipe:0 -ac 2 -f s16le -ar 48000 pipe:1",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
            }
            catch
            {
            }
            currentsong.Start();
            return currentsong;
        }

        [Command("play")]
        public async Task playAsync(CommandContext ctx, string url)
        {
        }
    }
}