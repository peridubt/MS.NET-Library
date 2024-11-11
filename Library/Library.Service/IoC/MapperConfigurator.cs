using Library.BusinessLogic.Mapper;
using Library.Service.Mapper;

namespace Library.Service.IoC;

public class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<UsersServiceProfile>();
            config.AddProfile<EmployeesBLProfile>();
            config.AddProfile<EmployeesServiceProfile>();
        });
    }
}