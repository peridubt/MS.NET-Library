using Library.BusinessLogic.Authorization.Entities;
using Library.BusinessLogic.Users.Entities;

namespace Library.BusinessLogic.Authorization;

public interface IAuthProvider
{
    Task<UserModel> RegisterUser(string email, string password);
    Task<TokensResponse> AuthorizeUser(string email, string password);
}