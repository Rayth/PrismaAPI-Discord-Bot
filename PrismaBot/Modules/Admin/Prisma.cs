using Discord.Commands;
using Discord;
using System.Threading.Tasks;
using PrismaBot.PrismaAPI;

namespace PrismaBot.Modules.Admin
{
    public class Prisma : ModuleBase
    {
        [Command("console")]
        [Remarks("Sends a command to your Prisma Console")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Console([Remainder] string command)
        {
            PrisAPI Prisma = new PrisAPI();
            Prisma.Console(command);
            await ReplyAsync("Command Executed.");
        }

        [Command("start")]
        [Remarks("Starts the Server")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Start()
        {
            PrisAPI Prisma = new PrisAPI();
            Prisma.StartServer();
            await ReplyAsync("Server Started.");
        }

        [Command("stop")]
        [Remarks("Stops the Server")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Stop()
        {
            PrisAPI Prisma = new PrisAPI();
            Prisma.StopServer();
            await ReplyAsync("Server Stopped.");
        }

        [Command("restart")]
        [Remarks("Restarts the Server")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Restart()
        {
            PrisAPI Prisma = new PrisAPI();
            Prisma.RestartServer();
            await ReplyAsync("Server restarted.");
        }
    }
}
