using Library.Service.DI;
using Library.Service.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = LibrarySettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

ApplicationConfigurator.ConfigureServices(builder, settings);

var app = builder.Build();

ApplicationConfigurator.ConfigureApplication(app);

app.Run();