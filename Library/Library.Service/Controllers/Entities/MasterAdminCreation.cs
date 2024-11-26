using Library.BusinessLogic.Authorization;
using Library.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace Library.Service.Controllers.Entities;

public class MasterAdminCreation
{
    private const string AdminEmail = " example@email.ru ";
    private const string AdminPassword = "example";

    private static async Task RegisterMasterAdmin(IAuthProvider authProvider)
    {
        await authProvider.RegisterUser(AdminEmail, AdminPassword);
    }

    public static async Task InitializeRepository(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
        var userManager = (UserManager<User>)scope.ServiceProvider.GetRequiredService(typeof(UserManager<User>));
        var user = await userManager.FindByEmailAsync(AdminEmail);
        if (user == null)
        {
            var authService = (IAuthProvider)scope.ServiceProvider.GetRequiredService(typeof(IAuthProvider));
            await RegisterMasterAdmin(authService);
        }
    }
}