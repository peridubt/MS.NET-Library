using Library.Service.Settings;
using Microsoft.EntityFrameworkCore;
using Library.DataAccess;

namespace Library.Service.IoC;

public class DbContextConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        string connectionString = configuration.GetValue<string>("LibraryDbContext");

        builder.Services.AddDbContextFactory<LibraryDbContext>(
            options => { options.UseNpgsql(connectionString); },
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