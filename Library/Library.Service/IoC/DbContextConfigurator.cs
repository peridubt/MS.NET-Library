using Library.Service.Settings;
using Microsoft.EntityFrameworkCore;
using Library.DataAccess;

namespace Library.Service.IoC;

public class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, LibrarySettings settings)
    {
        services.AddDbContextFactory<LibraryDbContext>(
            options => { options.UseNpgsql(settings.LibraryDbContextConnectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<LibraryDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}