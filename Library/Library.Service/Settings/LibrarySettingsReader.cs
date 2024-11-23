namespace Library.Service.Settings;

public static class LibrarySettingsReader
{
    public static LibrarySettings Read(IConfiguration configuration)
    {
        return new LibrarySettings
        {
            LibraryDbContextConnectionString = configuration.GetValue<string>("LibraryDbContext"),
            ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
            ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri")
        };
    }
}