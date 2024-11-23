namespace Library.Service.Settings;

public class LibrarySettings
{
    public string? LibraryDbContextConnectionString { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? IdentityServerUri { get; set; }
}