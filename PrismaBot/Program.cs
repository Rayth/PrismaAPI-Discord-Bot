using System;
using System.IO;
using System.Threading.Tasks;
using PrismaBot.Config;

namespace PrismaBot
{
    public class Program
    {
        public static void Main(string[] args) =>
            new Program().Start().GetAwaiter().GetResult();

        public async Task Start()
        {
            LoadConfig();
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
