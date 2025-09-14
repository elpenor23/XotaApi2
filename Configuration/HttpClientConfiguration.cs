using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using XotaApi2.HttpClients;
using XotaApi2.Models;

namespace XotaApi2.Configuration;

public static class HttpClientConfiguration
{
    public static WebApplicationBuilder ConfigureHttpClients(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ProgramOptions>(builder.Configuration.GetRequiredSection(ProgramOptions.Location));

        builder.Services.AddHttpClient<IPotaClient, PotaClient>((serviceProvider, client) =>
            {
                var settings = serviceProvider
                    .GetRequiredService<IOptions<ProgramOptions>>().Value;

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "XotaAPI2");

                client.BaseAddress = new Uri(settings.Pota.BaseAddress);
            });

        builder.Services.AddHttpClient<ISotaClient, SotaClient>((serviceProvider, client) =>
            {
                var settings = serviceProvider
                    .GetRequiredService<IOptions<ProgramOptions>>().Value;

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "XotaAPI2");

                client.BaseAddress = new Uri(settings.Sota.BaseAddress);
            });

        builder.Services.AddHttpClient<IRadarClient, RadarClient>((serviceProvider, client) =>
            {
                var settings = serviceProvider
                    .GetRequiredService<IOptions<ProgramOptions>>().Value;

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "XotaAPI2");

                client.BaseAddress = new Uri(settings.Radar.BaseAddress);
            });

        return builder;
    }
}
