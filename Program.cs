using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Scalar.AspNetCore;
using Serilog;
using XotaApi2.Configuration;

var builder = WebApplication.CreateBuilder(args)
    .ConfigureOptions()
    .ConfigureHttpClients()
    .ConfigureManagers()
    .ConfigureServices()
    .ConfigureHealthChecks();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

app.MapHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Xota Aggrigator")
            .WithTheme(ScalarTheme.Solarized)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.AsyncHttp);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
