using AutoMapper;
using Library.BusinessLogic.Users.Entities;
using Library.Service.Controllers.Entities.Users;
namespace Library.Service.Mapper;

public class UsersServiceProfile : Profile
{
    public UsersServiceProfile()
    {
        CreateMap<UserFilter, FilterUserModel>();
        CreateMap<RegisterUserRequest, CreateUserModel>();
    }
}