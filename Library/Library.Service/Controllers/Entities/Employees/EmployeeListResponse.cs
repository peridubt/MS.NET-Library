using Library.BusinessLogic.Employees.Entities;

namespace Library.Service.Controllers.Entities.Employees;

public class EmployeeListResponse
{
    public List<EmployeeModel> Employees { get; set; }
}