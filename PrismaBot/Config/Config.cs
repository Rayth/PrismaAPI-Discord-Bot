using Newtonsoft.Json;
using System;
using System.IO;

namespace PrismaBot.Config
{
    public class BotConfig
    {
        [JsonIgnore]
        public static readonly string appdir = AppContext.BaseDirectory;

        public string Prefix { get; set; }
        public string DiscordToken { get; set; }
        public string APIKey { get; set; }
        public string APIUser { get; set; }
        public string APIServer { get; set; }
        public BotConfig()
        {
            Prefix = "";
            DiscordToken = "";
            APIKey = "";
            APIUser = "";
            APIServer = "";
        }

        public void Save(string dir = "Config.json")
        {
            string file = Path.Combine(appdir, dir);
            File.WriteAllText(file, ToJson());
        }
        public static BotConfig Load(string dir = "Config.json")
        {
            string file = Path.Combine(appdir, dir);
            return JsonConvert.DeserializeObject<BotConfig>(File.ReadAllText(file));
        }
        public string ToJson()
            => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
