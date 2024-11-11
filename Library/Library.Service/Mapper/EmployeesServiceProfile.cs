using AutoMapper;
using Library.BusinessLogic.Employees.Entities;
using Library.Service.Controllers.Entities.Employees;

namespace Library.Service.Mapper;

public class EmployeesServiceProfile: Profile
{
    public EmployeesServiceProfile()
    {
        CreateMap<EmployeeFilter, FilterEmployeeModel>();
        CreateMap<RegisterEmployeeRequest, CreateEmployeeModel>();
    }
}