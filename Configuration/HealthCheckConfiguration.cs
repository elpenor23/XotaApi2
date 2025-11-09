using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using XotaApi2.HealthChecks;

namespace XotaApi2.Configuration;

public static class HealthCheckConfiguration
{
    public static WebApplicationBuilder ConfigureHealthChecks(this WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            .AddCheck<PotaHealthCheck>("Pota-Api", HealthStatus.Unhealthy)
            .AddCheck<SotaHealthCheck>("Sota-Api", HealthStatus.Unhealthy);

        return builder;
    }

    public static WebApplication AddHeathChecks(this WebApplication app)
    {
        app.MapGet("/health", () => "Healthy");

        app.MapHealthChecks("/health-status",
            new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            
        return app;
    }
}