using AutoMapper;
using Library.BusinessLogic.Employees.Entities;
using Library.BusinessLogic.Employees.Exceptions;
using Library.DataAccess;
using Library.DataAccess.Entities;

namespace Library.BusinessLogic.Employees.Provider;

public class EmployeesProvider : IEmployeesProvider
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeesProvider(IRepository<Employee> employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public IEnumerable<EmployeeModel> GetEmployees(FilterEmployeeModel? filter = null)
    {
        string? loginPart = filter?.LoginPart;
        string? emailPart = filter?.EmailPart;
        string lastNamePart = filter?.LastNamePart;
        string firstNamePart = filter?.FirstNamePart;
        string patronymicNamePart = filter?.PatronymicNamePart;
        string phoneNumberPart = filter?.PhoneNumberPart;
        DateTime? creationTime = filter?.CreationTime;
        DateTime? modificationTime = filter?.ModificationTime;

        var users = _employeeRepository.GetAll(e =>
            (loginPart == null || e.Login.Contains(loginPart)) &&
            (emailPart == null || e.Email.Contains(emailPart)) &&
            (creationTime == null || e.CreationTime == creationTime) &&
            (modificationTime == null || e.ModificationTime == modificationTime) &&
            (lastNamePart == null || e.LastName.Contains(lastNamePart)) &&
            (firstNamePart == null || e.FirstName.Contains(firstNamePart)) &&
            (patronymicNamePart == null || e.PatronymicName!.Contains(patronymicNamePart)) &&
            (phoneNumberPart == null || e.PhoneNumber.Contains(phoneNumberPart))
        );
        return _mapper.Map<IEnumerable<EmployeeModel>>(users);
    }

    public EmployeeModel GerEmployeeInfo(int id)
    {
        var entity = _employeeRepository.GetById(id);
        if (entity == null)
        {
            throw new EmployeeNotFoundException("Employee not found");
        }

        return _mapper.Map<EmployeeModel>(entity);
    }
}