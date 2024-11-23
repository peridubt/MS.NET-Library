using AutoMapper;
using Duende.IdentityServer.Models;
using IdentityModel.Client;
using Library.BusinessLogic.Authorization.Entities;
using Library.BusinessLogic.Exceptions;
using Library.BusinessLogic.Users.Entities;
using Library.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace Library.BusinessLogic.Authorization;

public class AuthProvider(
    SignInManager<User> signInManager,
    UserManager<User> userManager,
    IHttpClientFactory httpClientFactory,
    string identityServerUri,
    string clientId,
    string clientSecret,
    IMapper mapper) : IAuthProvider
{
    public async Task<TokensResponse> AuthorizeUser(string email, string password)
    {
        var user = await userManager.FindByEmailAsync(email); // IRepository<User>
        if (user is null)
        {
            throw new BusinessLogicException(ResultCode.UserNotFound);
        }

        var verificationPasswordResult = await signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!verificationPasswordResult.Succeeded)
        {
            throw new BusinessLogicException(ResultCode.EmailOrPasswordIsIncorrect);
        }

        var client = httpClientFactory.CreateClient();
        var discoveryDoc = await client.GetDiscoveryDocumentAsync(identityServerUri);
        if (discoveryDoc.IsError)
        {
            throw new BusinessLogicException(ResultCode.IdentityServerError);
        }

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = discoveryDoc.TokenEndpoint,
            GrantType = GrantType.ResourceOwnerPassword,
            ClientId = clientId,
            ClientSecret = clientSecret,
            UserName = user.UserName!,
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

    public async Task<UserModel> RegisterUser(string email, string password)
    {
        var existingUser = await userManager.FindByEmailAsync(email);
        if (existingUser != null)
        {
            throw new BusinessLogicException(ResultCode.UserAlreadyExists);
        }

        var user = new User
        {
            Email = email,
            Login = email
        };

        var result = await userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            throw new BusinessLogicException(ResultCode.UserCreationFailure);
        }

        var createdUser = await userManager.FindByEmailAsync(email);
        return mapper.Map<UserModel>(createdUser);
    }
}