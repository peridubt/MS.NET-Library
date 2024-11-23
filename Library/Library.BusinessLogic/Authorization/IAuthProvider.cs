using Library.BusinessLogic.Authorization.Entities;
using Library.BusinessLogic.Users.Entities;

namespace Library.BusinessLogic.Authorization;

public interface IAuthProvider
{
    // #TODO: Реализовать
    Task RegisterUser(string email, string password);
    Task<TokensResponse> AuthorizeUser(string email, string password);
}