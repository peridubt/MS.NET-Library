using AutoMapper;
using Library.BusinessLogic.Employees.Entities;
using Library.DataAccess.Entities;

namespace Library.BusinessLogic.Mapper;

public class EmployeesBLProfile : Profile
{
    public EmployeesBLProfile()
    {
        CreateMap<Employee, EmployeeModel>()
            .ForMember(src => src.Id, dest => dest.MapFrom(src => src.Id))
            .ForMember(src => src.ExternalId, dest => dest.MapFrom(src => src.ExternalId));

        CreateMap<CreateEmployeeModel, Employee>()
            .ForMember(src => src.Id, dest => dest.Ignore())
            .ForMember(src => src.ExternalId, dest => dest.Ignore())
            .ForMember(src => src.CreationTime, dest => dest.Ignore())
            .ForMember(src => src.ModificationTime, dest => dest.Ignore());

        CreateMap<UpdateEmployeeModel, Employee>()
            .ForMember(src => src.Id, dest => dest.MapFrom(src => src.Id))
            .ForMember(src => src.ExternalId, dest => dest.MapFrom(src => src.ExternalId))
            .ForMember(src => src.ModificationTime, dest => dest.Ignore());
    }
}