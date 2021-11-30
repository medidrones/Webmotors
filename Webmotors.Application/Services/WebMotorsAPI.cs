using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Webmotors.Application.Services
{
    public class WebMotorsAPI
    {
        static HttpClient _client = new HttpClient();
        const string makesEndpoint = "api/OnlineChallenge/Make";
        const string modelsEndpoint = "api/OnlineChallenge/Model?MakeID=";
        const string versionsEndpoint = "api/OnlineChallenge/Version?ModelID=";

        public WebMotorsAPI()
        {
            _client.BaseAddress = new Uri("https://desafioonline.webmotors.com.br/");
        }

        public async Task<IEnumerable<WebMotorsOptions>> GetMakes()
        {
            var response = _client.GetAsync(makesEndpoint).Result;

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <IEnumerable<WebMotorsOptions>>(responseStream);
        }

        public async Task<IEnumerable<WebMotorsOptions>> GetModels(int makeId)
        {
            var response = _client.GetAsync(modelsEndpoint + makeId).Result;

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <IEnumerable<WebMotorsOptions>>(responseStream);
        }

        public async Task<IEnumerable<WebMotorsOptions>> GetVersions(int modelId)
        {
            var response = _client.GetAsync(versionsEndpoint + modelId).Result;

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <IEnumerable<WebMotorsOptions>>(responseStream);
        }
    }

    public class WebMotorsOptions
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
