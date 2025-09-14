using XotaApi2.Managers;

namespace XotaApi2.Configuration;
public static class ManagerConfiguration
{
    public static WebApplicationBuilder ConfigureManagers(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IXotaDataManager, XotaDataManager>();
        return builder;
    }
}
