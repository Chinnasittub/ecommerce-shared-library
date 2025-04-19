using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SharedLibrary.Helpers
{
    public static class HttpClientHelper
    {
        private static readonly HttpClient _client = new();

        public static async Task<T?> GetAsync<T>(string url)
        {
            // var response = await _client.GetAsync(url);
            // if (!response.IsSuccessStatusCode) return default;

            // var stream = await response.Content.ReadAsStreamAsync();
            // return await JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions
            // {
            //     PropertyNameCaseInsensitive = true
            // });

            using var client = new HttpClient();
            int retryCount = 3;
            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);
                }
                catch (HttpRequestException)
                {
                    if (i == retryCount - 1) throw;
                    await Task.Delay(1000); // รอ 1 วินาทีก่อน retry
                }
            }
            throw new Exception("Failed to connect after retries.");
        }

        public static async Task<bool> PostAsync<T>(string url, T content)
        {
            var response = await _client.PostAsJsonAsync(url, content);
            return response.IsSuccessStatusCode;
        }
    }
}
