using Library.Service.IoC;

namespace Library.Service.DI;

public static class ApplicationConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        SwaggerConfigurator.ConfigureServices(builder.Services);
        SerilogConfigurator.ConfigureService(builder);
    }

    public static void ConfigureApplication(WebApplication app)
    {
        SwaggerConfigurator.ConfigureApplication(app);
        SerilogConfigurator.ConfigureApplication(app);
    }
}