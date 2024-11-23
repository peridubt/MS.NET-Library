using Duende.IdentityServer.Models;
using IdentityModel.Client;
using Library.BusinessLogic.Authorization.Entities;
using Library.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace Library.BusinessLogic.Authorization;

public class AuthProvider(
    SignInManager<User> signInManager,
    UserManager<User> userManager,
    IHttpClientFactory httpClientFactory,
    string identityServerUri,
    string clientId,
    string clientSecret) : IAuthProvider
{
    public async Task<TokensResponse> AuthorizeUser(string email, string password)
    {
        var user = await userManager.FindByEmailAsync(email); // IRepository<User>
        if (user is null)
        {
            throw new Exception(); // UserNotFoundException, BusinessLogicException(Code.UserNotFound)
        }

        var verificationPasswordResult = await signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!verificationPasswordResult.Succeeded)
        {
            throw new Exception(); // UserNotFoundException, BusinessLogicException(Code.UserNotFound)
        }

        var client = httpClientFactory.CreateClient();
        var discoveryDoc = await client.GetDiscoveryDocumentAsync(identityServerUri);
        if (discoveryDoc.IsError)
        {
            throw new Exception();
        }

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = discoveryDoc.TokenEndpoint,
            GrantType = GrantType.ResourceOwnerPassword,
            ClientId = clientId,
            ClientSecret = clientSecret,
            UserName = user.UserName,
            Password = password,
            Scope = "api offline_access"
        });

        if (tokenResponse.IsError)
        {
            throw new Exception();
        }

        return new TokensResponse
        {
            AccessToken = tokenResponse.AccessToken,
            RefreshToken = tokenResponse.RefreshToken,
        };
    }

    // #TODO: Реализовать
    public async Task RegisterUser(string email, string password) // Реализовать!
    {
        var user = new User
        {
            Email = email,
            UserName = email,
        };
        
        var createUserResult = await userManager.CreateAsync(user, password);
    }
}