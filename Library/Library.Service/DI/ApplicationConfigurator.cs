using Library.Service.IoC;
using Library.Service.Settings;

namespace Library.Service.DI;

public class ApplicationConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder, LibrarySettings settings)
    {
        DbContextConfigurator.ConfigureServices(builder, settings);
        SerilogConfigurator.ConfigureServices(builder);
        SwaggerConfigurator.ConfigureServices(builder.Services);
        MapperConfigurator.ConfigureServices(builder.Services);
        ServicesConfigurator.ConfigureServices(builder.Services);

        builder.Services.AddControllers();
    }

    public static void ConfigureApplication(WebApplication app)
    {
        SerilogConfigurator.ConfigureApplication(app);
        SwaggerConfigurator.ConfigureApplication(app);
        DbContextConfigurator.ConfigureApplication(app);

        app.MapControllers();
    }
}