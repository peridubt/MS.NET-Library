using AutoMapper;
using Library.BusinessLogic.Authorization;
using Library.BusinessLogic.Employees.Manager;
using Library.BusinessLogic.Employees.Provider;
using Library.BusinessLogic.Users.Manager;
using Library.BusinessLogic.Users.Provider;
using Library.DataAccess;
using Library.DataAccess.Entities;
using Library.Service.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Service.IoC;

public class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services, LibrarySettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IRepository<User>>(x =>
            new Repository<User>(x.GetRequiredService<IDbContextFactory<LibraryDbContext>>()));
        services.AddScoped<IUsersProvider>(x =>
            new UsersProvider(x.GetRequiredService<IRepository<User>>(),
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IUsersManager>(x =>
            new UsersManager(x.GetRequiredService<IRepository<User>>(),
                x.GetRequiredService<IMapper>()));

        services.AddScoped<IRepository<Employee>>(x =>
            new Repository<Employee>(x.GetRequiredService<IDbContextFactory<LibraryDbContext>>()));
        services.AddScoped<IEmployeesProvider>(x =>
            new EmployeesProvider(x.GetRequiredService<IRepository<Employee>>(),
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IEmployeesManager>(x =>
            new EmployeesManager(x.GetRequiredService<IRepository<Employee>>(),
                x.GetRequiredService<IMapper>()));

        services.AddScoped<IAuthProvider>(x =>
            new AuthProvider(x.GetRequiredService<SignInManager<User>>(),
                x.GetRequiredService<UserManager<User>>(),
                x.GetRequiredService<IHttpClientFactory>(),
                settings.IdentityServerUri!,
                settings.ClientId!,
                settings.ClientSecret!
            ));
    }
}