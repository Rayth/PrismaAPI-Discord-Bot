using System.Threading.Tasks;
using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;
using PrismaBot.Config;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace PrismaBot
{
    internal class CommandHandler
    {
        private CommandService commands;
        private DiscordSocketClient bot;
        private IServiceProvider map;

        public CommandHandler(IServiceProvider provider)
        {
            map = provider;
            bot = map.GetService<DiscordSocketClient>();
            commands = map.GetService<CommandService>();

            //Now handle Messages Received
            bot.MessageReceived += HandleCommand;
        }

        public async Task ConfigureAsync()
        {
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), map);
        }

        public async Task HandleCommand(SocketMessage msg)
        {
            //Don't handle the command if it is a system message
            SocketUserMessage message = msg as SocketUserMessage;
            if (message == null)
                return;
            SocketCommandContext context = new SocketCommandContext(bot, message);
            //Mark where the prefix ends and the command begins
            int argPos = 0;
            //Determine if the message has a valid prefix, adjust argPos
            if (message.HasStringPrefix(str: BotConfig.Load().Prefix, argPos: ref argPos))
            {
                if (message.Author.IsBot)
                    return;
                //Execute the command, store the result
                IResult result = await commands.ExecuteAsync(context, argPos, map);

                //If the command failed, notify the user
                if (!result.IsSuccess && result.ErrorReason != "Unknown command.")

                    await message.Channel.SendMessageAsync($"**Error:** {result.ErrorReason}");
            }
            else
            {
                return;
            }
        }
    }
}