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
public class EmployeesController(
    IEmployeesManager employeesManager,
    IEmployeesProvider employeesProvider,
    IMapper mapper,
    Serilog.ILogger logger)
    : ControllerBase
{
    [HttpPost]
    public IActionResult RegisterEmployee([FromBody] RegisterEmployeeRequest request)
    {
        var validationResult = new EmployeeValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var createEmployeeModel = mapper.Map<CreateEmployeeModel>(request);
            var employeeModel = employeesManager.CreateEmployee(createEmployeeModel);
            return Ok(new EmployeeListResponse
            {
                Employees = [employeeModel]
            });
        }

        logger.Error(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }

    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        var employees = employeesProvider.GetEmployees();
        return Ok(new EmployeeListResponse
        {
            Employees = employees.ToList()
        });
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredEmployees([FromQuery] EmployeeFilter filter)
    {
        var employeeFilterModel = mapper.Map<FilterEmployeeModel>(filter);
        var employees = employeesProvider.GetEmployees(employeeFilterModel);
        return Ok(new EmployeeListResponse
        {
            Employees = employees.ToList()
        });
    }
}