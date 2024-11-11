using AutoMapper;
using Library.BusinessLogic.Users.Entities;
using Library.DataAccess.Entities;

namespace Library.BusinessLogic.Mapper;

public class UsersBLProfile : Profile
{
    public UsersBLProfile()
    {
        CreateMap<User, UserModel>()
            .ForMember(src => src.Id, dest => dest.MapFrom(src => src.Id))
            .ForMember(src => src.ExternalId, dest => dest.MapFrom(src => src.ExternalId));

        CreateMap<CreateUserModel, User>()
            .ForMember(src => src.Id, dest => dest.Ignore())
            .ForMember(src => src.ExternalId, dest => dest.Ignore())
            .ForMember(src => src.CreationTime, dest => dest.Ignore())
            .ForMember(src => src.ModificationTime, dest => dest.Ignore());

        CreateMap<UpdateUserModel, User>()
            .ForMember(src => src.Id, dest => dest.MapFrom(src => src.Id))
            .ForMember(src => src.ExternalId, dest => dest.MapFrom(src => src.ExternalId))
            .ForMember(src => src.ModificationTime, dest => dest.Ignore());
    }
}