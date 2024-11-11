using AutoMapper;
using Library.BusinessLogic.Employees.Entities;
using Library.BusinessLogic.Employees.Manager;
using Library.BusinessLogic.Employees.Provider;
using Library.Service.Controllers.Entities.Employees;
using Library.Service.Validator.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Library.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeesManager _employeesManager;
    private readonly IEmployeesProvider _employeesProvider;
    private readonly IMapper _mapper;
    private readonly Serilog.ILogger _logger;

    public EmployeesController(IEmployeesManager employeesManager,
        IEmployeesProvider employeesProvider,
        IMapper mapper, Serilog.ILogger logger)
    {
        _employeesManager = employeesManager;
        _employeesProvider = employeesProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult RegisterEmployee([FromBody] RegisterEmployeeRequest request)
    {
        var validationResult = new EmployeeValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var createEmployeeModel = _mapper.Map<CreateEmployeeModel>(request);
            var employeeModel = _employeesManager.CreateEmployee(createEmployeeModel);
            return Ok(new EmployeeListResponse
            {
                Employees = [employeeModel]
            });
        }

        _logger.Error(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }

    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        var employees = _employeesProvider.GetEmployees();
        return Ok(new EmployeeListResponse
        {
            Employees = employees.ToList()
        });
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredEmployees([FromQuery] EmployeeFilter filter)
    {
        var employeeFilterModel = _mapper.Map<FilterEmployeeModel>(filter);
        var employees = _employeesProvider.GetEmployees(employeeFilterModel);
        return Ok(new EmployeeListResponse
        {
            Employees = employees.ToList()
        });
    }
}