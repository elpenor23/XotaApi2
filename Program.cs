using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using XotaApi2.Configuration;

var builder = WebApplication.CreateBuilder(args)
    .ConfigureOptions()
    .ConfigureHttpClients()
    .ConfigureManagers()
    .ConfigureServices();

var app = builder.Build();

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
