using Discord.Commands;
using Discord;
using System;
using System.Threading.Tasks;
using PrismaBot.PrismaAPI;

namespace PrismaBot.Modules.Admin
{
    public class Prisma : ModuleBase
    {
        [Command("console")]
        [Remarks("Sends a command to your Prisma Console")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task ConsoleCmd([Remainder] string command)
        {
            PrisAPI Prisma = new PrisAPI();
            await Prisma.ConsoleCmdAsync(command);
            await ReplyAsync("Command Executed.");
        }

        [Command("start")]
        [Remarks("Starts the Server")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Start()
        {
            PrisAPI Prisma = new PrisAPI();
            await Prisma.StartServerAsync();
            await ReplyAsync("Server Started.");
        }

        [Command("stop")]
        [Remarks("Stops the Server")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Stop()
        {
            PrisAPI Prisma = new PrisAPI();
            await Prisma .StopServerAsync();
            await ReplyAsync("Server Stopped.");
        }

        [Command("restart")]
        [Remarks("Restarts the Server")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Restart()
        {
            PrisAPI Prisma = new PrisAPI();
            await Prisma .RestartServerAsync();
            await ReplyAsync("Server restarted.");
        }
    }
}
