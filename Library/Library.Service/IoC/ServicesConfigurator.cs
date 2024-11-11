using AutoMapper;
using Library.BusinessLogic.Employees.Manager;
using Library.BusinessLogic.Employees.Provider;
using Library.BusinessLogic.Users.Manager;
using Library.BusinessLogic.Users.Provider;
using Library.DataAccess;
using Library.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Service.IoC;

public class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
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
    }
}