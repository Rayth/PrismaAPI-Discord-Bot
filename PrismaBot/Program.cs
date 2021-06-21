using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using System.IO;
using PrismaBot.Config;

namespace PrismaBot
{
    public class Program
    {
        public static void Main(string[] args) =>
            new Program().Start().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task Start()
        {
            LoadConfig();

            //Let's connect the bot to Discord
            _client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Verbose
            });
            //_client.Log += Logger; //Send logs to console.
            await _client.LoginAsync(TokenType.Bot, BotConfig.Load().DiscordToken);
            await _client.StartAsync();

            //Keep program running until it is closed or told to close.
            await Task.Delay(-1);
        }

        public static void LoadConfig()
        {
            string loc = $"{AppContext.BaseDirectory}Config.json";
            //If File doesn't exist, create it. Ask user for inputs.
            if (!File.Exists(loc))
            {
                var Config = new BotConfig(); //New config object
                Console.WriteLine("This is the first time you have run this bot. Please enter some information to get set up.");
                Console.Write("Discord Bot Token: "); Config.DiscordToken = Console.ReadLine();
                Console.Write("Discord Command Prefix: "); Config.Prefix = Console.ReadLine();
                Console.Write("Prisma API Key: "); Config.APIKey = Console.ReadLine();
                Console.Write("Prisma API User: "); Config.APIUser = Console.ReadLine();
                Console.Write("CubedHost Server ID: "); Config.APIServer = Console.ReadLine();
                Config.Save();
                Console.WriteLine("New Config file created, and loaded.");
            } else
            {
                Console.WriteLine("Existing Config file located. Loaded.");
            }
        }
    }
}
