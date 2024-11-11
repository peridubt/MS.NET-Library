using AutoMapper;
using Library.BusinessLogic.Employees.Entities;
using Library.BusinessLogic.Employees.Exceptions;
using Library.DataAccess;
using Library.DataAccess.Entities;

namespace Library.BusinessLogic.Employees.Manager;

public class EmployeesManager : IEmployeesManager
{
    private readonly IRepository<Employee> _employeesRepository;
    private readonly IMapper _mapper;

    public EmployeesManager(IRepository<Employee> employeesRepository, IMapper mapper)
    {
        _employeesRepository = employeesRepository;
        _mapper = mapper;
    }

    public EmployeeModel CreateEmployee(CreateEmployeeModel createModel)
    {
        var entity = _mapper.Map<Employee>(createModel);
        entity = _employeesRepository.Save(entity);
        return _mapper.Map<EmployeeModel>(entity);
    }

    public void DeleteEmployee(int id)
    {
        try
        {
            var entity = _employeesRepository.GetById(id);
            _employeesRepository.Delete(entity);
        }
        catch (Exception e)
        {
            throw new EmployeeNotFoundException(e.Message);
        }
    }

    public EmployeeModel UpdateEmployee(UpdateEmployeeModel updateModel)
    {
        var entity = _mapper.Map<Employee>(updateModel);
        entity = _employeesRepository.Save(entity);
        return _mapper.Map<EmployeeModel>(entity);
    }
}