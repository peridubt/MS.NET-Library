namespace Library.BusinessLogic.Authorization.Entities;

public class TokensResponse
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}