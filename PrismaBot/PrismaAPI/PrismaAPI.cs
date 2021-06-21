using PrismaBot.Config;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrismaBot.PrismaAPI
{
    public class PrisAPI
    {
        private string Key = BotConfig.Load().APIKey;
        private string User = BotConfig.Load().APIUser;
        private string Server = BotConfig.Load().APIServer;

        public async Task ConsoleCmdAsync(string command)
        {
            using HttpClient httpClient = new HttpClient();

            using HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("POST"), "https://prisma.cubedhost.com/api/server/" + Server + "/console");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("X-Api-Key", Key);
            request.Headers.TryAddWithoutValidation("X-Api-User", User);
            request.Content = new FormUrlEncodedContent(new[] {
                                    new KeyValuePair<string, string>("command", command),
                                });
            HttpResponseMessage response = await httpClient.SendAsync(request);
            return;
        }

        public async Task StartServerAsync()
        {
            using HttpClient httpClient = new HttpClient();

            using HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("POST"), "https://prisma.cubedhost.com/api/server/" + Server + "/start");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("X-Api-Key", Key);
            request.Headers.TryAddWithoutValidation("X-Api-User", User);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            return;
        }

        public async Task StopServerAsync()
        {
            using HttpClient httpClient = new HttpClient();

            using HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("POST"), "https://prisma.cubedhost.com/api/server/" + Server + "/stop");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("X-Api-Key", Key);
            request.Headers.TryAddWithoutValidation("X-Api-User", User);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            return;
        }

        public async Task RestartServerAsync()
        {
            using HttpClient httpClient = new HttpClient();

            using HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("POST"), "https://prisma.cubedhost.com/api/server/" + Server + "/restart");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("X-Api-Key", Key);
            request.Headers.TryAddWithoutValidation("X-Api-User", User);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            return;
        }

    }
}
