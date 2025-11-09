using System.Text.Json;
using Microsoft.Extensions.Options;
using XotaApi2.Models;

namespace XotaApi2.HttpClients;

public class RadarClient(HttpClient httpClient, IOptions<ProgramOptions> settings) : XotaClientBase(httpClient), IRadarClient
{
    private readonly HttpClient _httpClient = httpClient;
    public async Task<T?> GetXotaListAsync<T>() where T: class
    {
        var x = await GetAsync<T>(settings.Value.Radar.ApiEndpoint);
        return x;
    }

    public Task HealthCheck()
    {
        throw new NotImplementedException();
    }

    public async Task<T?> PostXotaListAsync<T>() where T: class
    {
        var x = await PostAsync<T>(settings.Value.Radar.ApiEndpoint, settings.Value.Radar.Page, settings.Value.Radar.Rows);
        return x;
    }

    private async Task<T?> PostAsync<T>(string endPoint, int page = 1, int rows = 10) where T : class
    {
        var x = new RadarPostRequest
        {
            Page = page,
            Rows = rows
        };

        var response = await _httpClient.PostAsJsonAsync(endPoint, x);

        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = string.Format($"Error Getting data from {endPoint}. Status Code: {response.StatusCode}");
            throw new Exception(errorMessage);
        }

        var result = await response.Content.ReadAsStringAsync();

        //Console.WriteLine(result);

        if (IsValidJson<T>(result))
            return JsonSerializer.Deserialize<T>(result);

        return result as T;
    }
}
